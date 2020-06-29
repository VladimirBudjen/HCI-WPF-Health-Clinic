using HealthClinic.Backend.Service.HospitalAccountsService;
using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Backend.Controller.SuperintendentControllers
{
    public class SuperIntendentSecretariesController
    {
        public SecretaryAccountService secretaryService;

        public SuperIntendentSecretariesController()
        {
            secretaryService = new SecretaryAccountService();
        }

        public List<Secretary> GetAllSecretaries()
        {
            return secretaryService.GetAllSecretaries();
        }
        public void NewSecretary(Secretary secretary)
        {
            secretaryService.NewSecretary(secretary);
        }

        public void EditSecretary(Secretary secretary)
        {
            secretaryService.EditSecretary(secretary);
        }

        public void DeleteSecretary(Secretary secretary)
        {
            secretaryService.DeleteSecretary(secretary);
        }

        public bool jmbgExists(string jmbg)
        {
            return secretaryService.jmbgExists(jmbg);
        }
    }
}
