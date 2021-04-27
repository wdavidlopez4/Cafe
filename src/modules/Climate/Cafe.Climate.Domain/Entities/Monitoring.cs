﻿using Cafe.Climate.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cafe.Climate.Domain.Entities
{
    public class Monitoring : EntityBase
    {
        public Arduino Arduino { get; private set; }

        public string ArduinoId { get; private set; }

        public List<Climate> Climate { get; private set; }

        internal Monitoring(string arduinoId, List<Climate> climate, Guid? id = null) : base(id)
        {
            this.ArduinoId = arduinoId;
            this.Climate = climate;

            if (Validator.Validate<Monitoring>(this, MonitoringValidation.Validation) == false)
                throw new ArgumentException("modelo es incorrecto");
        }

        private Monitoring()
        {
            //for ef
        }
    }
}
