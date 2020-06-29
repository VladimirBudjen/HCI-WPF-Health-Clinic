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
    public class AddressFileSystem : GenericFileSystem<Address>, AddressRepository
    {
        public AddressFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/addresses.txt";
            path = @"./../../data/addresses.txt";
        }
        public override Address Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Address>(objectStringFormat);
        }
    }
}
