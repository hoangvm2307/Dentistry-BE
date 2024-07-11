namespace DTOs.ChatMessageDtos
{
  public class ChatMessageDto
  {
    public string SenderID { get; set; }
    public string ReceiverID { get; set; }
    public string MessageContent { get; set; }
    public DateTime Timestamp { get; set; }
  }
}
