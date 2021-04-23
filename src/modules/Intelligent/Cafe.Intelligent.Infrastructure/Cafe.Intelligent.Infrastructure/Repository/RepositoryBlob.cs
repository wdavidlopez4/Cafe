using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Cafe.Intelligent.Domain.Entities;
using Cafe.Intelligent.Domain.Factories;
using Cafe.Intelligent.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Intelligent.Infrastructure.Repository
{
    public class RepositoryBlob : IRepositoryBlob
    {
        private readonly BlobServiceClient blobServiceClient;

        private readonly IFactory factory;

        public RepositoryBlob(BlobServiceClient blobServiceClient, IFactory factory)
        {
            this.blobServiceClient = blobServiceClient;
            this.factory = factory;
        }

        public async Task<List<string>> GetNamesBlobs(string nameBlobContainer)
        {
            var container = this.blobServiceClient.GetBlobContainerClient(nameBlobContainer);
            var items = new List<string>();

            await foreach (var blob in container.GetBlobsAsync())
            {
                items.Add(blob.Name);
            }

            return items;
        }

        public async Task<List<T>> GetEntitiesBlobs<T>(string nameBlobContainer, string label) where T : ImageDataModel
        {
            var container = this.blobServiceClient.GetBlobContainerClient(nameBlobContainer);
            var entities = new List<T>();

            var names = await GetNamesBlobs(nameBlobContainer);

            foreach (var name in names)
            {
                //obtenemos la url y generamos los permisos para acceder
                var url = container.GetBlobClient(name).GenerateSasUri(expiresOn: DateTimeOffset.UtcNow.AddDays(2), permissions: BlobSasPermissions.All);

                //creamos la lista de objetos
                entities.Add((T)factory.CreateImageData(url.AbsoluteUri, label));
            }

            return entities;
        }

        public async Task DowloadBlobs(string DirectoryUrl, string nameBlobContainer)
        {
            List<string> namesBlobs = await GetNamesBlobs(nameBlobContainer);
            var container = this.blobServiceClient.GetBlobContainerClient(nameBlobContainer);

            foreach (var name in namesBlobs)
            {
                var blob = container.GetBlobClient(name);
                using (var fileStream = System.IO.File.OpenWrite($"{DirectoryUrl}/{name}"))
                {
                    await blob.DownloadToAsync(fileStream);
                }
            }
        }

    }
}
