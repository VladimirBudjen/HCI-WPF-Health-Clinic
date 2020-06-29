using Model.Accounts;
using Model.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Repository
{
    public class BedReservationFileSystem : GenericFileSystem<BedReservation>, BedReservationRepository
    {
        public BedReservationFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/approved_medicine.txt";
            path = @"./../../data/bedreservations.txt";
        }

        public BedReservation GetBedReservationByPatient(Patient patient)
        {
            List<BedReservation> bedReservations = GetAll();
            foreach (BedReservation bedReservation in bedReservations)
            {
                if (patient.Equals(bedReservation.Patient))
                {
                    return bedReservation;
                }
            }
            return null;
        }

        public override BedReservation Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<BedReservation>(objectStringFormat);
        }
    }
}
