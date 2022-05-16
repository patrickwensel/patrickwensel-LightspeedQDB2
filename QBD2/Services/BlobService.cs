using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using QBD2.Models;
using static QBD2.Models.Enum;

namespace QBD2.Services
{
    public class BlobService
    {
        private IOptions<ApplicationSettings> _appSettings;
        
        public BlobService(IOptions<ApplicationSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<string> UploadBlob(IBrowserFile browserFile)
        {
            //Key cmYy46Pk0yx0J/abTwT3fWGSx7u4gHm8DI4EQoIKkeYVG3tfsGQ5aL/l/2DJRF/Z/8rc4uHiZXg6+AStW3rdhA==
            //connection DefaultEndpointsProtocol=https;AccountName=lightspeedavaition;AccountKey=cmYy46Pk0yx0J/abTwT3fWGSx7u4gHm8DI4EQoIKkeYVG3tfsGQ5aL/l/2DJRF/Z/8rc4uHiZXg6+AStW3rdhA==;EndpointSuffix=core.windows.net

            try
            {
                if (this._appSettings.Value.FileUploadType.ToLower() == FileUploadType.Azure.ToString().ToLower())
                {
                    var connectionString = this._appSettings.Value.StorageConnectionString;
                    string containerName = this._appSettings.Value.FileUploadContainer;

                    var serviceClient = new BlobServiceClient(connectionString);
                    var containerClient = serviceClient.GetBlobContainerClient(containerName);
                    var blobClient = containerClient.GetBlobClient(browserFile.Name);
                    Stream stream = browserFile.OpenReadStream();
                    await blobClient.UploadAsync(stream, true);
                    stream.Close();
                    stream.Dispose();
                    return blobClient.Uri.AbsoluteUri;
                }
                else
                {
                    var folderPath = this._appSettings.Value.LocalFileUploadPath;
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    Stream stream = browserFile.OpenReadStream();
                    var path = $"{this._appSettings.Value.LocalFileUploadPath}{browserFile.Name}";
                    FileStream fs = File.Create(path);
                    await stream.CopyToAsync(fs);
                    stream.Close();
                    fs.Close();
                    return path;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CloudBlob> DownloadFile(string filePath, string blobContainerName)
        {
            if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrEmpty(blobContainerName))
            {
                // Retrieve storage account information from connection string
                CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString();

                // Create a blob client for interacting with the blob service.
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                // Create a container for organizing blobs within the storage account.
                CloudBlobContainer container = blobClient.GetContainerReference(blobContainerName);

                try
                {
                    Uri uri = new Uri(filePath);
                    string BlobName = Path.GetFileName(uri.LocalPath);
                    CloudBlob file = container.GetBlobReference(BlobName);
                    return file;
                }
                catch (Exception ExceptionObj)
                {
                    throw ExceptionObj;
                }
            }
            return null;
        }

        /// <summary>
        /// Get Storage Account Connection string
        /// </summary>
        /// <returns></returns>
        private CloudStorageAccount CreateStorageAccountFromConnectionString()
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(this._appSettings.Value.StorageConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
            return storageAccount;
        }
    }
}