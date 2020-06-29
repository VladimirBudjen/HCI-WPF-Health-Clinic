using Model.MedicalExam;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Repository
{
    public class DiagnosticTypeFileSystem : GenericFileSystem<DiagnosticType>, DiagnosticTypeRepository
    {
        public DiagnosticTypeFileSystem()
        {
            path = @"./../../data/diagnostic_types.txt";
        }

        public override DiagnosticType Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<DiagnosticType>(objectStringFormat);
        }
    }
}
