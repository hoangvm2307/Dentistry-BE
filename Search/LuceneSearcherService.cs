using DTOs.ClinicDtos;
using DTOs.DentistDtos;
using DTOs.SearchDtos;
using DTOs.ServiceDtos;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;

namespace Search
{
  public class LuceneSearcherService : ILuceneSearcherService
  {
    private readonly Lucene.Net.Store.Directory _indexDirectory;
    private readonly Analyzer _analyzer;

    public LuceneSearcherService(string indexPath)
    {
      _indexDirectory = FSDirectory.Open(new DirectoryInfo(indexPath));
      _analyzer = new StandardAnalyzer(LuceneVersion.LUCENE_48);
    }

    public async Task<SearchResultDto> SearchAsync(string queryText)
{
    try
    {
        using var reader = DirectoryReader.Open(_indexDirectory);
        var searcher = new IndexSearcher(reader);

        var parser = new MultiFieldQueryParser(LuceneVersion.LUCENE_48, new[] { "Name", "DentistName", "Address", "PhoneNumber" }, _analyzer);
        var query = parser.Parse(queryText);

        var hits = searcher.Search(query, 5).ScoreDocs;

        var clinics = new List<ClinicDto>();
        var dentists = new List<DentistDto>();
        var services = new List<ServiceDto>();

        var seenIds = new HashSet<string>();

        foreach (var hit in hits)
        {
            var doc = searcher.Doc(hit.Doc);
            var type = doc.Get("Type");

            if (type == "Clinic")
            {
                var clinicId = doc.Get("ClinicId");
                var address = doc.Get("Address");
                var phoneNumber = doc.Get("PhoneNumber");
                var email = doc.Get("Email");
                var name = doc.Get("Name");

                var clinicDto = new ClinicDto
                {
                    ClinicID = int.Parse(clinicId),
                    Name = name,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Dentists = new List<DentistDto>() // Initialize the list of dentists
                };

                // Query to find dentists working at this clinic
                var dentistQuery = new TermQuery(new Term("ClinicId", clinicId));
                var dentistHits = searcher.Search(dentistQuery, 10).ScoreDocs;

                foreach (var dentistHit in dentistHits)
                {
                    var dentistDoc = searcher.Doc(dentistHit.Doc);
                    var dentistIdString = dentistDoc.Get("DentistId");
                    var dentistPhoneNumber = dentistDoc.Get("DentistPhoneNumber");
                    var dentistName = dentistDoc.Get("Name");
                    var dentistClinicId = dentistDoc.Get("ClinicId");

                    if (!string.IsNullOrEmpty(dentistIdString))
                    {
                        clinicDto.Dentists.Add(new DentistDto
                        {
                            Id = dentistIdString,
                            Name = dentistName,
                            ClinicID = int.Parse(dentistClinicId),
                            PhoneNumber = dentistPhoneNumber
                        });
                    }
                    else
                    {
                        // Log error message or handle invalid dentistIdString
                        Console.WriteLine($"Error parsing DentistId '{dentistIdString}' to integer.");
                    }
                }

                clinics.Add(clinicDto);
            }
            else if (type == "Service")
            {
                var serviceClinicIdString = doc.Get("ClinicId");
                var serviceId = doc.Get("ServiceId");
                var name = doc.Get("Name");
                if (int.TryParse(serviceClinicIdString, out int serviceClinicId))
                {
                    services.Add(new ServiceDto { ServiceID = int.Parse(serviceId), Name = name, ClinicID = serviceClinicId });
                }
            }
            else if (type == "Dentist")
            {
                var dentistIdString = doc.Get("DentistId");
                var clinicIdString = doc.Get("ClinicId");
                if (!string.IsNullOrEmpty(dentistIdString))
                {
                    var dentistPhoneNumber = doc.Get("DentistPhoneNumber");
                    var dentistName = doc.Get("Name");
                    dentists.Add(new DentistDto
                    {
                        Id = dentistIdString,
                        Name = dentistName,
                        ClinicID = int.Parse(clinicIdString),
                        PhoneNumber = dentistPhoneNumber
                    });
                }
                else
                {
                    // Log error message or handle invalid dentistIdString
                    Console.WriteLine($"Error parsing DentistId '{dentistIdString}' to integer.");
                }
            }
            else
            {
                // Log error message or handle empty idString
                Console.WriteLine($"Id is null or empty for type {type}.");
            }
        }

        return new SearchResultDto
        {
            Clinics = clinics,
            Dentists = dentists,
            Services = services
        };
    }
    catch (Exception ex)
    {
        // Log the exception message
        Console.WriteLine($"Error searching Lucene index: {ex.Message}");
        throw;
    }
}





  }
}
