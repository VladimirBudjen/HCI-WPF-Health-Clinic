
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class EquipmentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Equipment _equipment;


        public string Name
        {
            get => _equipment.Name; set
            {
                if (value != _equipment.Name)
                    _equipment = new Equipment(_equipment.SerialNumber,value, _equipment.Id);
                OnPropertyChanged("Name");
            }
        }

        public string Id
        {
            get => _equipment.Id; set
            {
                if (value != _equipment.Id)
                    _equipment = new Equipment(_equipment.SerialNumber,_equipment.Name,value);
                OnPropertyChanged("Id");
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public EquipmentViewModel(Equipment equipment)
        {
            this._equipment = equipment;
        }

    }
}
