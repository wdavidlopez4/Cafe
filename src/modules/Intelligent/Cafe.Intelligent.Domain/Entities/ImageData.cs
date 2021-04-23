using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Intelligent.Domain.Entities
{
    public class ImageData : EntityBase
    {
        /// <summary>
        /// ruta donde se almacenan las imagenes
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// es la categoria a la que pertenecen las imagenes, valor a predecir
        /// </summary>
        public string Label { get; set; }
    }
}
