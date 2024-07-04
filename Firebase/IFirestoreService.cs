 
namespace Firebase
{
    public interface IFirestoreService
    {
        Task AddMessageAsync(string collectionName, object message);
       
    }
}