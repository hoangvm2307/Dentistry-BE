using DTOs.ClinicDtos;
using DTOs.DentistDtos;
using DTOs.SearchDtos;
using DTOs.ServiceDtos;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
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

                var hits = searcher.Search(query, 1000).ScoreDocs;

                var clinics = new List<ClinicDto>();
                var dentists = new List<DentistDto>();
                var services = new List<ServiceDto>();

                var seenClinicIds = new HashSet<string>();
                var seenDentistIds = new HashSet<string>();

                foreach (var hit in hits)
                {
                    var doc = searcher.Doc(hit.Doc);
                    var type = doc.Get("Type");

                    switch (type)
                    {
                        case "Clinic":
                            ProcessClinic(doc, searcher, clinics, seenClinicIds, seenDentistIds);
                            break;
                        case "Service":
                            ProcessService(doc, services);
                            break;
                        case "Dentist":
                            ProcessDentist(doc, dentists, seenDentistIds);
                            break;
                        default:
                            Console.WriteLine($"Unknown type: {type}");
                            break;
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
                Console.WriteLine($"Error searching Lucene index: {ex.Message}");
                throw;
            }
        }

        private void ProcessClinic(Document doc, IndexSearcher searcher, List<ClinicDto> clinics, HashSet<string> seenClinicIds, HashSet<string> seenDentistIds)
        {
            var clinicIdString = doc.Get("ClinicId");

            if (int.TryParse(clinicIdString, out int clinicId) && !seenClinicIds.Contains(clinicIdString))
            {
                seenClinicIds.Add(clinicIdString);

                var clinicDto = new ClinicDto
                {
                    ClinicID = clinicId,
                    Name = doc.Get("Name"),
                    Address = doc.Get("Address"),
                    PhoneNumber = doc.Get("PhoneNumber"),
                    Email = doc.Get("Email"),
                    Dentists = GetDentistsForClinic(searcher, clinicIdString, seenDentistIds)
                };

                clinics.Add(clinicDto);
            }
        }

        private List<DentistDto> GetDentistsForClinic(IndexSearcher searcher, string clinicIdString, HashSet<string> seenDentistIds)
        {
            var dentistQuery = new TermQuery(new Term("ClinicId", clinicIdString));
            var dentistHits = searcher.Search(dentistQuery, 1000).ScoreDocs;

            var dentists = new List<DentistDto>();

            foreach (var dentistHit in dentistHits)
            {
                var dentistDoc = searcher.Doc(dentistHit.Doc);
                var dentistIdString = dentistDoc.Get("DentistId");

                if (!seenDentistIds.Contains(dentistIdString) && !string.IsNullOrEmpty(dentistIdString))
                {
                    seenDentistIds.Add(dentistIdString);

                    var dentistDto = new DentistDto
                    {
                        Id = dentistIdString,
                        Name = dentistDoc.Get("Name"),
                        ClinicID = int.Parse(dentistDoc.Get("ClinicId")),
                        PhoneNumber = dentistDoc.Get("DentistPhoneNumber")
                    };

                    dentists.Add(dentistDto);
                }
            }

            return dentists;
        }

        private void ProcessService(Document doc, List<ServiceDto> services)
        {
            var serviceClinicIdString = doc.Get("ClinicId");
            if (int.TryParse(serviceClinicIdString, out int serviceClinicId))
            {
                services.Add(new ServiceDto
                {
                    ServiceID = int.Parse(doc.Get("ServiceId")),
                    Name = doc.Get("Name"),
                    ClinicID = serviceClinicId
                });
            }
        }

        private void ProcessDentist(Document doc, List<DentistDto> dentists, HashSet<string> seenDentistIds)
        {
            var dentistIdString = doc.Get("DentistId");

            if (!seenDentistIds.Contains(dentistIdString) && !string.IsNullOrEmpty(dentistIdString))
            {
                seenDentistIds.Add(dentistIdString);

                dentists.Add(new DentistDto
                {
                    Id = dentistIdString,
                    Name = doc.Get("Name"),
                    ClinicID = int.Parse(doc.Get("ClinicId")),
                    PhoneNumber = doc.Get("DentistPhoneNumber")
                });
            }
        }
    }
}
