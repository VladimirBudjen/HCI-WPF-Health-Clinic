
using Backend.Dto;
using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace HealthClinic.Model
{
    public class RoomViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Room _room;

        public string Id
        {
            get { return  _room.Id.ToString(); }
            set {
                if(value != _room.Id.ToString())
                {
                    try
                    {
                        _room = new Room(_room.SerialNumber,Int32.Parse(value), _room.RoomType);
                        
                    }
                    catch
                    {
                        
                    }
                   
                    OnPropertyChanged("Id");
                }
                }
        }
        public string Type
        {
            get { return _room.RoomType.Name; }
            set
            {
                if (value != _room.RoomType.Name)
                {
                    _room = new Room(_room.SerialNumber,_room.Id,new RoomType(_room.RoomType.SerialNumber, value));
                    OnPropertyChanged("Type");
                }
            }
        }
 

        public Room Room { get => _room; set => _room = value; }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



  
        public RoomViewModel(Room room)
        {
            Room = room;
        }


    }
}
