using Model.Hospital;
using health_clinic_class_diagram.Backend.Service.MedicineService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Controller.SuperintendentControllers
{
    class SuperintendentMedicineController
    {
        private SuperintendentMedicineService superintendentMedicineService;
        public SuperintendentMedicineController()
        {
            superintendentMedicineService = new SuperintendentMedicineService();
        }
        public List<Medicine> getAllApproved()
        {
            return superintendentMedicineService.getAllApproved();
        }

        public List<Rejection> getAllRejected()
        {
            return superintendentMedicineService.getAllRejected();
        }

        public List<Medicine> getAllWaiting()
        {
            return superintendentMedicineService.getAllWaiting();
        }

        public void DeleteWaitingMedicine(Medicine medicine)
        {
            superintendentMedicineService.DeleteWaitingMedicine(medicine);
        }

        public void NewWaitinMedicine(Medicine medicine)
        {
            superintendentMedicineService.NewWaitinMedicine(medicine);
        }

        public void EditWaitingMedicine(Medicine medicineDTO)
        {
            superintendentMedicineService.EditWaitingMedicine(medicineDTO);
        }

        public void DeleteRejection(Rejection rejection)
        {
            superintendentMedicineService.DeleteRejection(rejection);
        }

        public void NewRejection(Rejection rejection)
        {
            superintendentMedicineService.NewRejection(rejection);
        }

        public void EditRejection(Rejection rejection)
        {
            superintendentMedicineService.EditRejection(rejection);
        }

        public void DeleteApprovedMedicine(Medicine medicine)
        {
            superintendentMedicineService.DeleteApprovedMedicine(medicine);
        }
        public void NewApprovedMedicine(Medicine medicine)
        {
            superintendentMedicineService.NewApprovedMedicine(medicine);
        }
    }
}
