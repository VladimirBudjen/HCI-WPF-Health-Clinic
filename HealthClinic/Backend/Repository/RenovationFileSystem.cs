using Backend.Dto;
using Backend.Repository;
using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repository
{
    public class RenovationFileSystem : GenericFileSystem<Renovation>, RenovationRepository
    {
        public RenovationFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/rooms.txt";
            path = @"./../../data/renovations.txt";

        }

        public List<Renovation> GetRenovationsByRoom(Room room)
        {
            List<Renovation> renovations = new List<Renovation>();
            foreach(Renovation renovation in GetAll())
            {
                if(room.Equals(renovation.Room))
                {
                    renovations.Add(renovation);
                }
            }
            return renovations;
        }

        public override Renovation Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Renovation>(objectStringFormat);
        }
    }
}
