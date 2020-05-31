
using System.ComponentModel;

namespace HealthClinic.Model
{
    public class PhysicianModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;
        private string _surname;
        private string _jmbg;
        private string _adress;
        private string _birthDate;
        private string _specialty;
        private string _workingHours;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Name { get => _name; set { if (value != _name) _name = value;
                OnPropertyChanged("Name");
            } }
        public string Surname { get => _surname; set { if (value != _surname) _surname = value; OnPropertyChanged("Surname"); } }
        public string Jmbg { get => _jmbg; set { if (value != _jmbg) _jmbg = value; OnPropertyChanged("Jmbg"); }  }
        public string Adress { get => _adress; set { if (value != _adress) _adress = value; OnPropertyChanged("Adress"); }  }
        public string BirthDate { get => _birthDate; set { if (value != _birthDate) _birthDate = value; OnPropertyChanged("BirthDate"); } }
        public string Specialty { get => _specialty; set { if (value != _specialty) _specialty = value; OnPropertyChanged("Speciality"); } }
        public string WorkingHours { get => _workingHours; set { if (value != _workingHours) _workingHours = value; OnPropertyChanged("WorkingHours"); } }

        public PhysicianModel(string name, string surname, string jmbg, string adress, string birthDate, string specialty, string workingHours)
        {
            Name = name;
            Surname = surname;
            Jmbg = jmbg;
            Adress = adress;
            BirthDate = birthDate;
            Specialty = specialty;
            WorkingHours = workingHours;
        }
    }
}
