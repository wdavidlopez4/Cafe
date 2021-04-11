using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.SetUpServices.QuerySetUpByIdCrop
{
    public class SetUpByIdCrop : IRequest<SetUpByIdCropDTO>
    {
        public string CropId { get; set; }

        public List<Claim> Claims { get; set; }
    }
}
