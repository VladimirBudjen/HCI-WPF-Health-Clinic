using Model.Hospital;
using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Service.MedicineService
{
    class MedicineAddingService
    {
        private RejectionRepository rejectionRepository;
        private WaitingMedicineRepository waitingRepostitory;
        public void addMedicineToWaiting(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public void removeFromRejected(Rejection rejectedMedicine)
        {
            throw new NotImplementedException();
        }

        public void editRejectedMedicine(Medicine medicine)
        {
            // TODO: Obrisati iz rejected liste i ubaciti u waiting listu
            throw new NotImplementedException();
        }

        public Rejection getFromRejected(Rejection rejectedMedicine)
        {
            throw new NotImplementedException();
        }
    }
}
