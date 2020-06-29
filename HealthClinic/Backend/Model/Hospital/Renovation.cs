using Backend.Model.Util;
using Model.Hospital;
using Model.Util;
using Newtonsoft.Json;
using System;

namespace HealthClinic.Backend.Model.Hospital
{
    public class Renovation : Entity
    {
        private static int idMaker = 0;
        private int id;
        private TimeInterval renovationTime;
        private Room room;

        public TimeInterval TimeInterval { get => renovationTime; set => renovationTime = value; }
        public int Id { get => id; set => id = value; }
        public Room Room { get => room; set => room = value; }

        public Renovation(Room room ,TimeInterval timeInteval) : base(Guid.NewGuid().ToString())
        {
            id = ++idMaker;
            TimeInterval = timeInteval;
            this.room = room;
        }

        [JsonConstructor]
        public Renovation(String serialNumber,Room room ,TimeInterval timeInteval) : base()
        {
            this.SerialNumber = serialNumber;
            id = ++idMaker;
            this.room = room;
            TimeInterval = timeInteval;
        }

        public override bool Equals(object obj)
        {
            Renovation other = obj as Renovation;
            if (other == null)
            {
                return false;
            }
            return this.Room.Equals(other.Room) && this.TimeInterval.Equals(other.TimeInterval);
            
        }
    }
}

