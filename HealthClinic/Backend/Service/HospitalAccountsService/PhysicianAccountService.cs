using Backend.Repository;
using Model.Accounts;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Backend.Service.HospitalAccountsService
{
    public class PhysicianAccountService
    {
        public PhysitianRepository physitianRepository;

        public PhysicianAccountService()
        {
            physitianRepository = new PhysitianFileSystem();
        }

        internal List<TimeInterval> GetAllVacations(Physitian physitianDTO)
        {
            return physitianRepository.GetById(physitianDTO.SerialNumber).VacationTime;
        }

        internal void AddVacation(TimeInterval timeInterval, Physitian physitianDTO)
        {
            physitianDTO.AddVacationTime(timeInterval);
            physitianRepository.Update(physitianDTO);
        }

        internal void RemoveVacation(TimeInterval timeInterval, Physitian physitianDTO)
        {
            physitianDTO.RemoveVacationTime(timeInterval);
            physitianRepository.Update(physitianDTO);
        }

        internal void DeletePhysician(Physitian physitian)
        {
            physitianRepository.Delete(physitian.SerialNumber);
        }

        public List<Physitian> GetAllPhysitians()
        {
            return physitianRepository.GetAll();
        }

        internal void NewPhysician(Physitian physitian)
        {
            physitianRepository.Save(physitian);
        }

        internal void EditPhysician(Physitian physitian)
        {
            physitianRepository.Update(physitian);
        }

        internal void DeletePhysicianById(string id)
        {
            physitianRepository.Delete(id);
        }

        public bool jmbgExists(string jmbg)
        {
            bool exists = false;
            foreach (Physitian p in physitianRepository.GetAll())
            {
                if (p.Id.Equals(jmbg))
                {
                    exists = true;
                }
            }
            return exists;
        }
    }
}
