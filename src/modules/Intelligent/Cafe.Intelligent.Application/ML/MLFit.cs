using Cafe.Intelligent.Domain.Entities;
using Cafe.Intelligent.Domain.Ports;
using Microsoft.ML;
using Microsoft.ML.Vision;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.ML.DataOperationsCatalog;

namespace Cafe.Intelligent.Application.ML
{
    internal class MLFit
    {

        private readonly IDirectoryProgram directoryProgram;

        private readonly IRepositoryBlob repositoryBlob;

        private readonly MLContext mLContext;

        public MLFit(IDirectoryProgram directoryProgram, IRepositoryBlob repositoryBlob)
        {
            this.directoryProgram = directoryProgram;
            this.repositoryBlob = repositoryBlob;

            //asociacion de composicion con el ML
            mLContext = new MLContext();
        }

        /// <summary>
        /// preparar los datos antes de entrenar la IA
        /// </summary>
        /// <returns></returns>
        internal async Task<IDataView> PrepareData()
        {
            //definir rutas
            var projectDirectory = this.directoryProgram.GetProjectDirectory();
            var assentPath = this.directoryProgram.CreateDirectory(projectDirectory, "assent");
            var workSpaceRelativePath = this.directoryProgram.CreateDirectory(projectDirectory, "workspace");

            var brocadoPath = this.directoryProgram.CreateDirectory(projectDirectory, assentPath, BlobsNames.Brocado);
            var sanoPath = this.directoryProgram.CreateDirectory(projectDirectory, assentPath, BlobsNames.Sano);

            //descargar blobs en rutas
            await this.repositoryBlob.DowloadBlobs(brocadoPath, BlobsNames.Brocado);
            await this.repositoryBlob.DowloadBlobs(sanoPath, BlobsNames.Sano);


            // obtener la lsita de imagenes en el directorio para entrenarlos
            IEnumerable<ImageData> images = this.directoryProgram.LoadImagesFromDirectory(assentPath, true);

            //pasarle las imagenes al mlcontext
            IDataView imageData = mLContext.Data.LoadFromEnumerable(images);

            //Los datos se cargan en el orden en que se leyeron de los directorios. Para equilibrar los datos, revuélvalos usando el ShuffleRowsmétodo.
            IDataView shuffledData = mLContext.Data.ShuffleRows(imageData);

            //convertir o prepara las imagens en un congunto de bytes para que la ML lo pueda trabajar
            var preprocessingPipeline = mLContext.Transforms.Conversion.MapValueToKey(
                inputColumnName: "Label",
                outputColumnName: "LabelAsKey"
                ).Append(mLContext.Transforms.LoadRawImageBytes(
                    outputColumnName: "Image",
                    imageFolder: assentPath,
                    inputColumnName: "ImagePath"));

            //pasarle los  datos al preprocessingPipeline
            IDataView preProcessedData = preprocessingPipeline
                .Fit(shuffledData)
                .Transform(shuffledData);

            return preProcessedData;
        }

        /// <summary>
        /// dividir los datos en validacion, prueba y entrenamiento
        /// dividir los datos preprocesados en dos para usar el 30% en validadciones y el 70% en el entrenamiento
        /// luego el del 30% que es para validar se divide en 90% para validad y un 10% para pruebas
        /// </summary>
        /// <param name="preProcessedData"></param>
        internal (IDataView trains, IDataView validations, IDataView tests) DivideData(IDataView preProcessedData)
        {
            TrainTestData trainSplit = mLContext.Data.TrainTestSplit(data: preProcessedData, testFraction: 0.3);
            TrainTestData validationTestSplit = mLContext.Data.TrainTestSplit(trainSplit.TestSet);

            //asignando a las particiones sus respectivos valores para el entrenamiento la validadcion y prueba
            IDataView trainSet = trainSplit.TrainSet;
            IDataView validationSet = validationTestSplit.TrainSet;
            IDataView testSet = validationTestSplit.TrainSet;

            return (trainSet, validationSet, testSet);

        }

        /// <summary>
        /// entrenar la IA
        /// </summary>
        /// <param name="trainSet"></param>
        /// <param name="validationSet"></param>
        /// <param name="testSet"></param>
        internal void Fit(IDataView trainSet, IDataView validationSet, IDataView testSet)
        {
            //definir la canalizacion de la formacion
            //almacena el conjunto de parametor obligatorios y opcionales para la clasificacion de imagenes
            var classiFierOptions = new ImageClassificationTrainer.Options()
            {
                FeatureColumnName = "Image",
                LabelColumnName = "LabelAsKey",
                ValidationSet = validationSet,
                Arch = ImageClassificationTrainer.Architecture.ResnetV2101,
                MetricsCallback = (metrics) => Console.WriteLine(metrics),
                TestOnTrainSet = false,
                ReuseTrainSetBottleneckCachedValues = true,
                ReuseValidationSetBottleneckCachedValues = true
            };

            //canalizacion del entrenamiento, preparamos el entrenamiento
            var trainNingPipeline = mLContext.MulticlassClassification.Trainers.ImageClassification(classiFierOptions)
                .Append(mLContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            //entrenar el modelo
            ITransformer trainedModel = trainNingPipeline.Fit(trainSet);
        }
    }
}
