
using Model.Accounts;
using Model.Util;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HealthClinic.Model
{
    public class PhysicianViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Physitian _physitian;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Name
        {
            get => Physitian.Name; set
            {
                if (value != Physitian.Name)
                    _physitian = new Physitian(_physitian.SerialNumber, value, _physitian.Surname, _physitian.Id,
                        _physitian.DateOfBirth, _physitian.Contact, _physitian.Email, _physitian.Address, _physitian.WorkSchedule, _physitian.Specialization);
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get => Physitian.Surname; set
            {
                if (value != Physitian.Surname)
                    _physitian = new Physitian(_physitian.SerialNumber, _physitian.Name, value, _physitian.Id,
                   _physitian.DateOfBirth, _physitian.Contact, _physitian.Email, _physitian.Address, _physitian.WorkSchedule, _physitian.Specialization);
                OnPropertyChanged("Surname");
            }
        }
        public string Jmbg
        {
            get => Physitian.Id; set
            {
                if (value != Physitian.Id)
                    _physitian = new Physitian(_physitian.SerialNumber, _physitian.Name, _physitian.Surname, value,
                      _physitian.DateOfBirth, _physitian.Contact, _physitian.Email, _physitian.Address, _physitian.WorkSchedule, _physitian.Specialization);
                OnPropertyChanged("Jmbg");
            }
        }
      
        public string Address
        {
            get => Physitian.Address.Street.ToString();
            set
            {
                if (value != Physitian.Address.Street.ToString())
                {
                    _physitian = new Physitian(_physitian.SerialNumber, _physitian.Name, _physitian.Surname, _physitian.Id,
                      _physitian.DateOfBirth, _physitian.Contact, _physitian.Email, new Address(value), _physitian.WorkSchedule, _physitian.Specialization);
                }
                OnPropertyChanged("Address");
               
            }
        }

  
        public string BirthDate
        {
            get => Physitian.DateOfBirth.ToString("yyyy-MM-dd"); set
            {
                if (value != Physitian.DateOfBirth.ToString())
                    _physitian = new Physitian(_physitian.SerialNumber, _physitian.Name, _physitian.Surname, _physitian.Id,
                     Convert.ToDateTime(value), _physitian.Contact, _physitian.Email, _physitian.Address, _physitian.WorkSchedule, _physitian.Specialization);
                OnPropertyChanged("BirthDate");
            }
        }

        public string Contact
        {
            get => Physitian.Contact; set
            {
                if (value != Physitian.Contact)
                {
                    _physitian = new Physitian(_physitian.SerialNumber, _physitian.Name, _physitian.Surname, _physitian.Id,
                      _physitian.DateOfBirth, value, _physitian.Email, _physitian.Address, _physitian.WorkSchedule, _physitian.Specialization);
                }
                OnPropertyChanged("Contact");
            }
        }

        public string Email
        {
            get => Physitian.Email; set
            {
                if (value != Physitian.Email)
                {
                    _physitian = new Physitian(_physitian.SerialNumber, _physitian.Name, _physitian.Surname, _physitian.Id,
                      _physitian.DateOfBirth, _physitian.Contact, value, _physitian.Address, _physitian.WorkSchedule, _physitian.Specialization);
                }
                OnPropertyChanged("Contact");
            }
        }


        public string Speciality
        {
            get { try { return Physitian.Specialization[0].ToString(); } catch { return ""; } }
            set
            {
                if (value != Physitian.Specialization.ToString())
                    Physitian.Specialization[0] = new Specialization(Physitian.Specialization[0].SerialNumber, value);
                OnPropertyChanged("Speciality");
            }
        }



        public string WorkingHours
        {
            get
            {
                if (Physitian.WorkSchedule != null)
                {
                    return Physitian.WorkSchedule.ToStringHours();
                }
                return null;
            }
            set
            {
                if (value != Physitian.WorkSchedule.ToStringHours())
                    if (Physitian.WorkSchedule != null)
                    {
                        Physitian.WorkSchedule.Start = Convert.ToDateTime(value);
                    }
                OnPropertyChanged("WorkingHours");
            }
        }

        public Physitian Physitian { get => _physitian; set => _physitian = value; }

     

        public PhysicianViewModel(Physitian physitian)
        {
            Physitian = physitian;
        }
    }
}
