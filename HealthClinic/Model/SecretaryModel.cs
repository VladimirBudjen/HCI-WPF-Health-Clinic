using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class SecretaryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _surname;
        private string _jmbg;
        private string _adress;
        private string _birthDate;
  


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Name
        {
            get => _name; set
            {
                if (value != _name) _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Surname { get => _surname; set { if (value != _surname) _surname = value; OnPropertyChanged("Surname"); } }
        public string Jmbg { get => _jmbg; set { if (value != _jmbg) _jmbg = value; OnPropertyChanged("Jmbg"); } }
        public string Adress { get => _adress; set { if (value != _adress) _adress = value; OnPropertyChanged("Adress"); } }
        public string BirthDate { get => _birthDate; set { if (value != _birthDate) _birthDate = value; OnPropertyChanged("BirthDate"); } }

        public SecretaryModel(string name, string surname, string jmbg, string adress, string birthDate)
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            Adress = adress;
            BirthDate = birthDate;
        }
    }
}
