using DentistryBusinessObjects;
using DTOs.ChatMessageDtos;
using Firebase;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.SignalR;

namespace DentistryServices
{
  public class ChatService : IChatService
  {
    private readonly IFirestoreService _firestoreService;
    private readonly IHubContext<ChatHub> _hubContext;
    private readonly FirestoreDb _firestoreDb;
    public ChatService(IFirestoreService firestoreService, IHubContext<ChatHub> hubContext, FirestoreDb fireStoreDb)
    {
      _firestoreService = firestoreService;
      _hubContext = hubContext;
      _firestoreDb = fireStoreDb;
    }

    public void ListenForMessages()
    {
      ListenForRealTimeUpdates(async message =>
      {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
      });
    }

    public async Task SendMessageAsync(ChatMessageDto messageDto)
    {
      var message = new ChatMessage
      {
        SenderID = messageDto.SenderID,
        ReceiverID = messageDto.ReceiverID,
        MessageContent = messageDto.Message,
        Timestamp = messageDto.Timestamp,
      };

      await _firestoreService.AddMessageAsync("ChatMessages", message);
      await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);

    }
    public void ListenForRealTimeUpdates(Action<ChatMessage> onMessageAdded)
    {
      CollectionReference collection = _firestoreDb.Collection("ChatMessages");
      collection.Listen(snapshot =>
      {
        foreach (var documentChange in snapshot.Changes)
        {
          if (documentChange.ChangeType == DocumentChange.Type.Added)
          {
            var message = documentChange.Document.ConvertTo<ChatMessage>();
            onMessageAdded(message);
          }
        }
      });
    }
  }
}
