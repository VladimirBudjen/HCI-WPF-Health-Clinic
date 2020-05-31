using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.Model
{
    public class RoomModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String _id;
        private String _type;
        private String _occupation;

        public string Id
        {
            get { return _id; }
            set {
                if(value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
                }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public String Occupation
        {
            get { return _occupation; }
            set
            {
                if (value != _occupation)
                {
                    _occupation = value;
                    OnPropertyChanged("Occupation");
                }
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public RoomModel(string id, string type, String occupation)
        {
            Id = id;
            Type = type;
            Occupation = occupation;
        }
        public RoomModel(string id, string type)
        {
            Id = id;
            Type = type;
            Occupation = "";
        }


    }
}
