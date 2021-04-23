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
        /// <param name="nameBlob"></param>
        /// <returns></returns>
        public Task<List<string>> GetNamesBlobs(string nameBlob);

        /// <summary>
        /// obtenemos los nombres de los blobs
        /// </summary>
        /// <param name = "nameBlob" ></ param >
        /// < returns ></ returns >
        public Task<List<T>> GetEntitiesBlobs<T>(string nameBlob, string label) where T : ImageData;

        /// <summary>
        /// descargar los archivos en un directorio
        /// </summary>
        /// <param name="DirectoryUrl"></param>
        /// <param name="nameBlob"></param>
        /// <returns></returns>
        public Task DowloadBlobs(string DirectoryUrl, string nameBlob);
    }

}
