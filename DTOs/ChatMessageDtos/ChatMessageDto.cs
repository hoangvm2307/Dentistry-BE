using Google.Cloud.Firestore;

namespace DTOs.ChatMessageDtos
{
    [FirestoreData]
    public class ChatMessageDto
    {
        [FirestoreProperty]
        public int SenderID { get; set; }
        [FirestoreProperty]
        public int ReceiverID { get; set; }
        [FirestoreProperty]
        public string Message { get; set; }
        [FirestoreProperty]
        public DateTime Timestamp { get; set; }
    }
}
