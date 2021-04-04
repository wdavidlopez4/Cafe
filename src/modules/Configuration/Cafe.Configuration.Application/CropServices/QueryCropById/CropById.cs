using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.QueryCropById
{
    public class CropById : IRequest<CropByIdDTO>
    {
        public string Id { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
