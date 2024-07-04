using Google.Cloud.Storage.V1;

namespace Firebase
{
  public class FirebaseStorageService :IFirebaseStorageService
  {
    private readonly StorageClient _storageClient;
    private readonly string _bucketName;

    public FirebaseStorageService(string bucketName)
    {
      
      _storageClient = StorageClient.Create();
      _bucketName = bucketName;
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string objectName)
    {
      var contentType = "image/jpeg";
      await _storageClient.UploadObjectAsync(_bucketName, objectName, contentType, fileStream);

    //   var objectUrl = GetPublicUrl(_bucketName, objectName);
        var objectUrl = $"https://storage.googleapis.com/{_bucketName}/{objectName}";
      return objectUrl;

    }
    private string GetPublicUrl(string bucket, string objectName)
    {
      var serviceAccountPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

      if (string.IsNullOrEmpty(serviceAccountPath) || !File.Exists(serviceAccountPath))
      {
        throw new InvalidOperationException("Service account key file not found. Ensure GOOGLE_APPLICATION_CREDENTIALS is set correctly.");
      }

      var urlSigner = UrlSigner.FromServiceAccountPath(serviceAccountPath);
      
      var url = urlSigner.Sign(bucket, objectName, TimeSpan.FromDays(7));


      return url;
    }
  }
}
