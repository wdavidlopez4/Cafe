using Cafe.Climate.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Arduino : EntityBase
    {
        public List<ArduinoData> ArduinoDatas { get; private set; }

        public Monitoring Monitoring { get; private set; }

        public string MonitoringId { get; private set; }

        public bool Occupied { get; private set; }

        /// <summary>
        /// para sincronizar el arduino
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monitoringId"></param>
        /// <param name="occupied"></param>
        internal Arduino(Guid id, string monitoringId, bool occupied):base(id)
        {
            this.MonitoringId = monitoringId;
            this.Occupied = occupied;
            //falta validarlo
        }

        /// <summary>
        /// para crearle la data del arduino
        /// </summary>
        /// <param name="id"></param>
        /// <param name="arduinoData"></param>
        internal Arduino(Guid id, List<ArduinoData> ArduinoDatas) :base(id)
        {
            this.ArduinoDatas = ArduinoDatas;
        }

        private Arduino()
        {
            //for EF
        }
    }
}
