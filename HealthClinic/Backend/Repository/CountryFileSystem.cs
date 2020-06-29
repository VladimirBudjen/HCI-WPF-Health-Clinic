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
    class CountryFileSystem : GenericFileSystem<Country>, CountryRepository
    {
        public CountryFileSystem()
        {
            path = @"./../../data/countries.txt";
        }
        public override Country Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Country>(objectStringFormat);
        }
    }
}
