using Azure.Storage.Blobs;

namespace QBD2.Services
{
    public class BlobService
    {

        public static async Task UploadBlob()
        {
            //Key cmYy46Pk0yx0J/abTwT3fWGSx7u4gHm8DI4EQoIKkeYVG3tfsGQ5aL/l/2DJRF/Z/8rc4uHiZXg6+AStW3rdhA==
            //connection DefaultEndpointsProtocol=https;AccountName=lightspeedavaition;AccountKey=cmYy46Pk0yx0J/abTwT3fWGSx7u4gHm8DI4EQoIKkeYVG3tfsGQ5aL/l/2DJRF/Z/8rc4uHiZXg6+AStW3rdhA==;EndpointSuffix=core.windows.net
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=lightspeedavaition;AccountKey=cmYy46Pk0yx0J/abTwT3fWGSx7u4gHm8DI4EQoIKkeYVG3tfsGQ5aL/l/2DJRF/Z/8rc4uHiZXg6+AStW3rdhA==;EndpointSuffix=core.windows.net";
            string containerName = "blobcontainer";
            var serviceClient = new BlobServiceClient(connectionString);
            var containerClient = serviceClient.GetBlobContainerClient(containerName);
            var path = @"c:\\temp";
            var fileName = "Testfile.txt";
            var localFile = Path.Combine(path, fileName);
            await File.WriteAllTextAsync(localFile, "This is a test message");
            var blobClient = containerClient.GetBlobClient(fileName);
            Console.WriteLine("Uploading to Blob storage");
            using FileStream uploadFileStream = File.OpenRead(localFile);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
        }

    }
}
