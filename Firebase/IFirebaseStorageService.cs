namespace Firebase
{
    public interface IFirebaseStorageService
    {
        Task<string> UploadFileAsync(Stream fileStream, string objectName);
    }
}