using Google.Cloud.Firestore;

namespace Firebase
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService()
        {
            _firestoreDb = FirestoreDb.Create("prn-project-75959");
        }

        public async Task AddMessageAsync(string collectionName, object message)
        {
            CollectionReference collection = _firestoreDb.Collection(collectionName);
            await collection.AddAsync(message);
        }
    }
}
