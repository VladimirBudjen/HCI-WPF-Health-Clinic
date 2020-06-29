using Model.Util;
using System;
using System.ComponentModel;


namespace HealthClinic.Model
{
    public class VacationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private TimeInterval _vacation;

        public string StartMoment
        {
            get => Vacation.Start.ToString("yyyy/MM/dd"); set
            {
                try
                {
                    if (value != Vacation.Start.ToString("yyyy-MM-dd")) Vacation.Start = Convert.ToDateTime(value);
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
            get => Vacation.End.ToString("yyyy/MM/dd"); set
            {
                try
                {
                    if (value != Vacation.End.ToString("yyyy-MM-dd")) Vacation.End = Convert.ToDateTime(value);
                    OnPropertyChanged("EndMoment");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public TimeInterval Vacation { get => _vacation; set => _vacation = value; }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    
        public VacationViewModel(TimeInterval timeInterval)
        {
            Vacation = timeInterval;
        }


    }
}

