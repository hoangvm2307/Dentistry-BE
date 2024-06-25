using System.Linq.Expressions;
using DentistryBusinessObjects;

namespace DentistryRepositories
{
    public class DentistRepository : BaseRepository<Dentist>
    {
        public DentistRepository(DBContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Dentist>> GetAllAsync(params Expression<Func<Dentist, object>>[] includeProperties)
        {
            return await base.GetAllAsync(d => d.Clinic);
        }

        public override async Task<Dentist> GetByIdAsync(object id, params Expression<Func<Dentist, object>>[] includeProperties)
        {
            return await base.GetByIdAsync(id, d => d.Clinic);
        }
    }
}
