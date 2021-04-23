using Cafe.Intelligent.Domain.Entities;
using Cafe.Intelligent.Domain.Factories;
using Cafe.Intelligent.Domain.Ports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cafe.Intelligent.Infrastructure.Repository
{
    public class DirectoryProgram : IDirectoryProgram
    {
        private readonly IFactory factory;

        public DirectoryProgram(IFactory factory)
        {
            this.factory = factory;
        }


        public string GetProjectDirectory()
        {
            var projectDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../../../../../"));
            return projectDirectory;
        }

        public string CreateDirectory(string projectRootUrl, string nameDirectoryRoot)
        {
            var assetsRelativepath = Path.Combine(projectRootUrl, nameDirectoryRoot);
            return Directory.CreateDirectory(assetsRelativepath).FullName;
        }

        public string CreateDirectory(string projectRootUrl, string directoryUrl, string nameDirectoryRoot)
        {
            var assetsRelativepath = Path.Combine(projectRootUrl, directoryUrl, nameDirectoryRoot);
            return Directory.CreateDirectory(assetsRelativepath).FullName;
        }

        public IEnumerable<ImageData> LoadImagesFromDirectory(string folder, bool useFolderNameAsLabel = true)
        {
            //obtiene todos los archivos de los directorios
            var files = Directory.GetFiles(folder, "*", searchOption: SearchOption.AllDirectories);

            //verificar que el archivo sea .jpg.png y ponerle la etiqueta para catalogar el archivo
            foreach (var file in files)
            {
                if ((Path.GetExtension(file) != ".jpg") && (Path.GetExtension(file) != ".png"))
                    continue;

                var label = Path.GetFileName(file);

                if (useFolderNameAsLabel)
                    label = Directory.GetParent(file).Name;
                else
                {
                    for (int index = 0; index < label.Length; index++)
                    {
                        if (!char.IsLetter(label[index]))
                        {
                            label = label.Substring(0, index);
                            break;
                        }
                    }
                }

                yield return new ImageData()
                {
                    ImagePath = file,
                    Label = label
                };
            }
        }
    }
}

