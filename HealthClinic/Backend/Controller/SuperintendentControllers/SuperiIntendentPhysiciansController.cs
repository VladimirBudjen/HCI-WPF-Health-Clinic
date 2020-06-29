using HealthClinic.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Backend.Controller.SuperintendentControllers
{
    public class SuperiIntendentPhysiciansController
    {
        public PhysicianAccountService physiciansService;

        public SuperiIntendentPhysiciansController()
        {
            physiciansService = new PhysicianAccountService();
        }

        public List<Physitian> GetAllPhysitians()
        {
            return physiciansService.GetAllPhysitians();
        }
        public void NewPhysician(Physitian physitian)
        {
            physiciansService.NewPhysician(physitian);
        }

        public void EditPhysitian(Physitian physitian)
        {
            physiciansService.EditPhysician(physitian);
        }

        public void DeletePhysitian(Physitian physitian)
        {
            physiciansService.DeletePhysician(physitian);
        }

        internal List<TimeInterval> GetAllVacations(Physitian physitianDTO)
        {
            return physiciansService.GetAllVacations(physitianDTO);
        }

        internal void AddVacation(TimeInterval timeInterval, Physitian physitianDTO)
        {
            physiciansService.AddVacation(timeInterval, physitianDTO);
        }

        internal void RemoveVacation(TimeInterval timeInterval, Physitian physitianDTO)
        {
            physiciansService.RemoveVacation(timeInterval, physitianDTO);
        }

        public bool jmbgExists(string jmbg)
        {
            return physiciansService.jmbgExists(jmbg);
        }
    }
}
