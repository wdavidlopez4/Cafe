using Cafe.Intelligent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Intelligent.Domain.Ports
{
    public interface IRepositoryBlob
    {
        /// <summary>
        /// obtenemos las url de los blobs
        /// </summary>
        /// <param name="nameBlobContainer"></param>
        /// <returns></returns>
        public Task<List<string>> GetNamesBlobs(string nameBlobContainer);

        /// <summary>
        /// obtenemos los nombres de los blobs
        /// </summary>
        /// <param name = "nameBlobContainer" ></ param >
        /// < returns ></ returns >
        public Task<List<T>> GetEntitiesBlobs<T>(string nameBlobContainer, string label) where T : ImageData;

        /// <summary>
        /// descargar los archivos en un directorio
        /// </summary>
        /// <param name="DirectoryUrl"></param>
        /// <param name="nameBlobContainer"></param>
        /// <returns></returns>
        public Task DowloadBlobs(string DirectoryUrl, string nameBlobContainer);
    }

}
