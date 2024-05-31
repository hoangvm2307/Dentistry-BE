namespace DentistryRepositories
{
  public interface IRepository<T>
  {
    Task Create(T entity);
    Task<T> Get(int id);
    Task<List<T>> GetList();
    Task Update(T entity);
    Task Delete(int id);
  }
}