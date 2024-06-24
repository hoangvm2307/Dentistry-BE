using DentistryBusinessObjects;

namespace Search
{
    public class IndexBuilder
    {
        private readonly LuceneIndexer _indexer;

        public IndexBuilder(LuceneIndexer indexer)
        {
            _indexer = indexer;
        }

        public void BuildIndex(IEnumerable<Clinic> clinics, IEnumerable<Dentist> dentists, IEnumerable<Service> services)
        {
            foreach (var clinic in clinics)
            {
                _indexer.IndexClinic(clinic);
            }

            foreach (var dentist in dentists)
            {
                _indexer.IndexDentist(dentist);
            }

            foreach (var service in services)
            {
                _indexer.IndexService(service);
            }

            _indexer.Commit();
        }
    }

}
