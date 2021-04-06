using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Cafe.Configuration.Application.CropServices.QueryCropByPage
{
    public class CropByPage : IRequest<List<CropByPageDTO>>
    {
        public List<Claim> Claims { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
