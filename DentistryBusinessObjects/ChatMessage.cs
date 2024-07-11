using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistryBusinessObjects
{

  public class ChatMessage : BaseEntity
  {
    [Key]
    public int MessageID { get; set; }

    [ForeignKey("Sender")]
    public string SenderID { get; set; }
    public User Sender { get; set; }

    [ForeignKey("Receiver")]
    public string ReceiverID { get; set; }
    public User Receiver { get; set; }

    public string MessageContent { get; set; }

    public DateTime Timestamp { get; set; }
  }
}