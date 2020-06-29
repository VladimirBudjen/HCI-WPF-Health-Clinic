using Model.Accounts;
using Model.Hospital;
using health_clinic_class_diagram.Backend.Service.MedicineService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dto;

namespace Backend.Controller.PhysitianControllers
{
    class PhysitianMedicineController
    {
        private PhysitianMedicineService physitianMedicineService;
        public PhysitianMedicineController()
        {
            this.physitianMedicineService = new PhysitianMedicineService();
        }

        public List<MedicineManufacturer> GetMedicineManufacturers()
        {
            return physitianMedicineService.GetMedicineManufacturers();
        }
        public List<Medicine> getAllFromWaitingList()
        {
            return physitianMedicineService.getAllFromWaitingList();
        }
        public List<Medicine> getAllApproved()
        {
            return physitianMedicineService.getAllApproved();
        }
        public void Approve(Medicine medicine)
        {
            physitianMedicineService.Approve(medicine);
        }
        public void Reject(Rejection rejection)
        {
            physitianMedicineService.Reject(rejection);
        }
    }
}
