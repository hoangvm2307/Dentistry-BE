using Google.Cloud.Firestore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistryBusinessObjects
{
    [FirestoreData]
    public class ChatMessage : BaseEntity
    {
        [FirestoreProperty]
        [Key]
        public int MessageID { get; set; }

        [FirestoreProperty]

        [ForeignKey("Customer")]
        public int SenderID { get; set; }

        public Customer Sender { get; set; }
        [FirestoreProperty]

        [ForeignKey("Dentist")]
        public int ReceiverID { get; set; }
        public Dentist Receiver { get; set; }
        [FirestoreProperty]

        public string MessageContent { get; set; }
        [FirestoreProperty]

        public DateTime Timestamp { get; set; }
    }
}