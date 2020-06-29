using Model.Util;
using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
{
    class CityFileSystem : GenericFileSystem<City>, CityRepository
    {
        public CityFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/cities.txt";
        }
        public override City Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<City>(objectStringFormat);
        }
    }
}
