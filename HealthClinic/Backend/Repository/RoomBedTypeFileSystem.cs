using Backend.Repository;
using HealthClinic.Backend.Model.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Backend.Repository
{
    class RoomBedTypeFileSystem : GenericFileSystem<RoomBedType>, RoomBedTypeRepository
    {
        public RoomBedTypeFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/room_bed_types.txt";
            path = @"./../../data/room_bed_types.txt";
        }
        public override RoomBedType Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<RoomBedType>(objectStringFormat);
        }
    }
    
}
