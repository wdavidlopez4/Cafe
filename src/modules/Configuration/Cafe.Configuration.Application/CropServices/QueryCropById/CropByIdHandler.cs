using Cafe.Configuration.Domain.Entities;
using Cafe.Configuration.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Configuration.Application.CropServices.QueryCropById
{
    public class CropByIdHandler : IRequestHandler<CropById, CropByIdDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public CropByIdHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.repository = repository;
        }

        public async Task<CropByIdDTO> Handle(CropById request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException("la peticion para recuperar el cultivo es nula");

            return autoMapping.Map<Crop, CropByIdDTO>(await this.repository.Get<Crop>(x => x.Id == request.Id, cancellationToken));
        }
    }
}
