using Model.Accounts;
using Model.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class SecretaryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Secretary _secretary;
      

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Name
        {
            get => _secretary.Name; set
            {
                if (value != _secretary.Name)
                    _secretary = new Secretary(_secretary.SerialNumber, value, _secretary.Surname, _secretary.Id,
                        _secretary.DateOfBirth, _secretary.Contact, _secretary.Email, _secretary.Address);
                OnPropertyChanged("Name");
            }
        }
        public string Surname
        {
            get => _secretary.Surname; set
            {
                if (value != _secretary.Surname)
                    _secretary = new Secretary(_secretary.SerialNumber, _secretary.Name, value, _secretary.Id,
                   _secretary.DateOfBirth, _secretary.Contact, _secretary.Email, _secretary.Address);
                OnPropertyChanged("Surname");
            }
        }
        public string Jmbg
        {
            get => _secretary.Id; set
            {
                if (value != _secretary.Id)
                    _secretary = new Secretary(_secretary.SerialNumber, _secretary.Name, _secretary.Surname, value,
                      _secretary.DateOfBirth, _secretary.Contact, _secretary.Email, _secretary.Address);
                OnPropertyChanged("Jmbg");
            }
        }

        public string Address
        {
            get => _secretary.Address.Street.ToString();
            set
            {
                if (value != _secretary.Address.Street.ToString())
                {

                    _secretary = new Secretary(_secretary.SerialNumber, _secretary.Name, _secretary.Surname, _secretary.Id,
                      _secretary.DateOfBirth, _secretary.Contact, _secretary.Email, new Address(value));
                }
                OnPropertyChanged("Address");

            }
        }

        public string BirthDate
        {
            get => _secretary.DateOfBirth.ToString("yyyy-MM-dd"); set
            {
                if (value != _secretary.DateOfBirth.ToString())
                    _secretary = new Secretary(_secretary.SerialNumber, _secretary.Name, _secretary.Surname, _secretary.Id,
                     Convert.ToDateTime(value), _secretary.Contact, _secretary.Email, _secretary.Address);
                OnPropertyChanged("BirthDate");
            }
        }

        public string Contact
        {
            get => _secretary.Contact; set
            {
                if (value != _secretary.Contact)
                {
                    _secretary = new Secretary(_secretary.SerialNumber, _secretary.Name, _secretary.Surname, _secretary.Id,
                      _secretary.DateOfBirth, value, _secretary.Email, _secretary.Address);
                }
                OnPropertyChanged("Contact");
            }
        }

        public string Email
        {
            get => _secretary.Email; set
            {
                if (value != _secretary.Email)
                {
                    _secretary = new Secretary(_secretary.SerialNumber, _secretary.Name, _secretary.Surname, _secretary.Id,
                      _secretary.DateOfBirth, _secretary.Contact, value, _secretary.Address);
                }
                OnPropertyChanged("Contact");
            }
        }

        public Secretary Secretary { get => _secretary; set => _secretary = value; }

        public SecretaryViewModel(Secretary secretary)
        {
            _secretary = secretary;
        }
    }
}
