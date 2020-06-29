using Model.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Backend.Model.Hospital
{
    public class RoomBedType : RoomType
    {
        public RoomBedType(string name) : base(name)
        {
        }

        [JsonConstructor]
        public RoomBedType(String serialNumber, string name) : base(serialNumber, name)
        {
        }

    }
}
