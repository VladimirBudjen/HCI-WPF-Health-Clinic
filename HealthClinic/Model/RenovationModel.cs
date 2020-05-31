using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class RenovationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _room;
        private string _startMoment;
        private string _endMoment;

        public string Room { get => _room;
            set
            {
                if (value !=  _room) _room = value; ;
                OnPropertyChanged("Room");
             }
        }
        public string StartMoment
        {
            get => _startMoment;
            set
            {
                if (value != _startMoment) _startMoment = value; ;
                OnPropertyChanged("StartMoment");
            }
        }
        public string EndMoment
        {
            get => _endMoment;
            set
            {
                if (value != _endMoment) _endMoment = value; ;
                OnPropertyChanged("EndMoment");
            }
        }

   
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public RenovationModel(string room, string startMoment, string endMoment)
        {
            Room = room;
            StartMoment = startMoment;
            EndMoment = endMoment;
        }
    }
}
