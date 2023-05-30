using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Model.Dtos
{
    public class ParameterDto
    {
        public int PacketId { get; set; }

        public string? ParameterId { get; set; }

        public DateTime ParameterTime { get; set; }

        public double ParameterValue { get; set; }
    }


}
