using Model.Hospital;
using Backend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Service.MedicineService
{
    class SuperintendentMedicineService
    {
        private RejectionRepository rejectionRepository;
        private WaitingMedicineRepository waitingRepostitory;
        private ApprovedMedicineRepository approvedRepository;

        public SuperintendentMedicineService()
        {
            rejectionRepository = new RejectionFileSystem();
            waitingRepostitory = new WaitingMedicineFileSystem();
            approvedRepository = new ApprovedMedicineFileSystem();
        }

        public List<Medicine> getAllApproved()
        {
            return approvedRepository.GetAll();
        }

        public List<Rejection> getAllRejected()
        {
            return rejectionRepository.GetAll();
        }

        public List<Medicine> getAllWaiting()
        {
            return waitingRepostitory.GetAll();
        }

        public void DeleteWaitingMedicine(Medicine medicine)
        {
            waitingRepostitory.Delete(medicine.SerialNumber);
        }

        public void NewWaitinMedicine(Medicine medicine)
        {
            waitingRepostitory.Save(medicine);
        }

        public void EditWaitingMedicine(Medicine medicineDTO)
        {
            waitingRepostitory.Update(medicineDTO);
        }

        public void DeleteRejection(Rejection rejection)
        {
            rejectionRepository.Delete(rejection.SerialNumber);
        }

        public void NewRejection(Rejection rejection)
        {
            rejectionRepository.Save(rejection);
        }

        public void EditRejection(Rejection rejection)
        {
            waitingRepostitory.Save(rejection.Medicine);
            rejectionRepository.Delete(rejection.SerialNumber);
        }

        public void DeleteApprovedMedicine(Medicine medicine)
        {
            approvedRepository.Delete(medicine.SerialNumber);
        }

        public void NewApprovedMedicine(Medicine medicine)
        {
            approvedRepository.Save(medicine);
        }



        //TODO: Dodati metode za getovanje pojedinacnih i brisanje ako treba
    }
}
