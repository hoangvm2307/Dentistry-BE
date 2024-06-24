using DentistryRepositories;
using Search;

namespace prn_dentistry.API.Data
{
    public class SearchIndexInitializer
    {
 
        public static async Task Initialize(DBContext context, LuceneIndexer indexer)
        {
            var clinics = context.Clinics.ToList();
            var dentists = context.Dentists.ToList();   
            var services = context.Services.ToList();
            
            foreach (var clinic in clinics)
            {
                indexer.IndexClinic(clinic);
            }
            foreach(var dentist in dentists)
            {
                indexer.IndexDentist(dentist);
            }
            foreach(var service in services)
            {
                indexer.IndexService(service);
            }
            indexer.Commit();
        }
    }
}
