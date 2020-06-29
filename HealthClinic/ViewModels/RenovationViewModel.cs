
using Backend.Dto;
using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class RenovationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Renovation _renovation;


        public string Room {
            get => _renovation.Room.Id.ToString();
            set
            {
                if (value != _renovation.Room.Id.ToString()) _renovation = new Renovation(new Room(_renovation.Room.SerialNumber, int.Parse(value), _renovation.Room.RoomType), _renovation.TimeInterval);
                OnPropertyChanged("Room");
             }
        }
        public string StartMoment
        {
            get => _renovation.TimeInterval.Start.ToString("yyyy-MM-dd");
            set
            {
               
                try
                {
                    if (value != _renovation.TimeInterval.Start.ToString("yyyy-MM-dd")) _renovation.TimeInterval.Start = Convert.ToDateTime(value);
                    OnPropertyChanged("StartMoment");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
        public string EndMoment
        {
            get => _renovation.TimeInterval.End.ToString("yyyy-MM-dd");
            set
            {
                try
                {
                    if (value != _renovation.TimeInterval.End.ToString("yyyy-MM-dd")) _renovation.TimeInterval.End = Convert.ToDateTime(value); ;
                    OnPropertyChanged("EndMoment");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public Renovation Renovation { get => _renovation; set => _renovation = value; }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    
        public RenovationViewModel(Renovation renovation)
        {
            Renovation = renovation;
        }



    }
}
