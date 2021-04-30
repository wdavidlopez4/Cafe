using Cafe.Climate.Application.Exceptions;
using Cafe.Climate.Domain.Entities;
using Cafe.Climate.Domain.Factories;
using Cafe.Climate.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe.Climate.Application.ArduinoServices.QueryArduinoByRangeTime
{
    public class ArduinoByRangeTimeHandler : IRequestHandler<ArduinoByRangeTime, List<ArduinoByRangeTimeDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public ArduinoByRangeTimeHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.autoMapping = autoMapping;
            this.repository = repository;
        }

        public async Task<List<ArduinoByRangeTimeDTO>> Handle(ArduinoByRangeTime request, CancellationToken cancellationToken)
        {
            //verificamos peticion
            if (request == null)
                throw new ArgumentNullException("la peticion para hacer la consulta es nula.");

            //recuperamos el crop y validamos
            else if (this.repository.Exists<Crop>(x => x.Id == request.CropId) == false)
                throw new EntityNullException("la peticion para hacer la consulta es nula.");

            var crop = await this.repository.GetWithNestedObject<Crop>(
                x => x.Id == request.CropId, x => x.Monitoring.Arduino, cancellationToken);

            if (crop.Monitoring.Arduino == null)
                throw new ArgumentNullException("el arduino no se a creado");

            else if (crop.CoffeeGrowerId != request.Claims.Find(x => x.Type == "CoffeeGrowerId").Value)
                throw new ArgumentNullException("el usuario no pertenece al cultivo. verificar el token");


            //obtenermos la lista de arduinos datas y mapeamos la lista
            var datas = await this.repository.GetObjects<ArduinoData>(
                x => x.ArduinoId == crop.Monitoring.Arduino.Id && x.Time >= request.RangeTimelower && x.Time <= request.RangeTimeUpper, 
                cancellationToken);

            if(datas == null)
                throw new EntityNullException("no se pudo encontrar ningun dato de arduino.");

            return this.autoMapping.Map<List<ArduinoData>, List<ArduinoByRangeTimeDTO>>(datas);
        }
    }
}
