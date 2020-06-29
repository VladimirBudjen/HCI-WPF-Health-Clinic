using Backend.Repository;
using Model.Accounts;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Service.MedicineService
{
    class PhysitianMedicineService
    {
        private ApprovedMedicineRepository approvedMedicineRepository;
        private WaitingMedicineRepository waitingMedicineRepository;
        private RejectionRepository rejectionRepository;

        public PhysitianMedicineService()
        {
            this.approvedMedicineRepository = new ApprovedMedicineFileSystem();
            this.waitingMedicineRepository = new WaitingMedicineFileSystem();
            this.rejectionRepository = new RejectionFileSystem();
        }

        public List<Medicine> getAllFromWaitingList()
        {
            return waitingMedicineRepository.GetAll();
        }
        public List<Medicine> getAllApproved()
        {
            return approvedMedicineRepository.GetAll();
        }
        public List<Medicine> getAllMedicine()
        {
            List<Medicine> allMedicine = new List<Medicine>();
            allMedicine.AddRange(getAllApproved());
            allMedicine.AddRange(getAllFromWaitingList());
            return allMedicine;
        }

        public List<MedicineManufacturer> GetMedicineManufacturers()
        {
            List<MedicineManufacturer> medicineManufacturers = new List<MedicineManufacturer>();
            foreach (Medicine medicine in getAllMedicine())
            {
                if (!medicineManufacturers.Contains(medicine.MedicineManufacturer))
                {
                    medicineManufacturers.Add(medicine.MedicineManufacturer);
                }
            }
            return medicineManufacturers;
        }
        public void Approve(Medicine medicine)
        {
            waitingMedicineRepository.Delete(medicine.SerialNumber);
            approvedMedicineRepository.Save(medicine);
        }
        public void Reject(Rejection rejection)
        {
            waitingMedicineRepository.Delete(rejection.Medicine.SerialNumber);
            rejectionRepository.Save(rejection);
        }
    }
}
