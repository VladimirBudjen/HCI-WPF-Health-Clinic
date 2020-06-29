using Backend.Repository;
using Model.Accounts;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Repository
{
    public interface BedReservationRepository : GenericRepository<BedReservation>
    {
        BedReservation GetBedReservationByPatient(Patient patient);
    }
}
