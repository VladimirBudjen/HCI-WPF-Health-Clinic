using Model.Schedule;
using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HCI_SIMS_PROJEKAT.Backend.Repository
{
    public class ProcedureTypeFileSystem : GenericFileSystem<ProcedureType>, ProcedureTypeRepository
    {
        public ProcedureTypeFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/procedure_types.txt";
            path = @"./../../data/procedure_types.txt";
        }
        public override ProcedureType Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<ProcedureType>(objectStringFormat);
        }
    }
}
