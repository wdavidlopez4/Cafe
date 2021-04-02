using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.QueryCropById
{
    public class CropById : IRequest<CropByIdDTO>
    {
        public string Id { get; set; }
    }
}
