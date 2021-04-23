using Cafe.Intelligent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Intelligent.Domain.Ports
{
    public interface IDirectoryProgram
    {
        public string GetProjectDirectory();

        public string CreateDirectory(string projectRootUrl, string nameDirectoryRoot);

        public string CreateDirectory(string projectRootUrl, string directoryUrl, string nameDirectoryRoot);

        public IEnumerable<ImageDataModel> LoadImagesFromDirectory(string folder, bool useFolderNameAsLabel = true);
    }

}
