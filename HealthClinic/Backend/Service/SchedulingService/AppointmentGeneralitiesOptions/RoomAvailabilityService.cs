using Backend.Repository;
using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using Model.Schedule;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class RoomAvailabilityService
    {
        private AppointmentRepository appointmentRepository;
        private RenovationRepository renovationRepository;
        private BedReservationRepository bedReservationRepository;

        public RoomAvailabilityService()
        {
            this.appointmentRepository = new AppointmentFileSystem();
            this.renovationRepository = new RenovationFileSystem();
            this.bedReservationRepository = new BedReservationFileSystem();
        }

        public bool IsRoomAvailableAtAnyTime(Room room, List<TimeInterval> timeIntervals)
        {
            foreach (TimeInterval timeInterval in timeIntervals)
            {
                if (IsRoomAvailable(room, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsAnyRoomAvailable(List<Room> rooms, TimeInterval timeInterval)
        {
            foreach (Room room in rooms)
            {
                if (IsRoomAvailable(room, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsRoomAvailable(Room room, TimeInterval timeInterval)
        {
            return !IsRoomScheduled(room, timeInterval) && !IsRoomInRenovation(room, timeInterval);
        }

        public bool IsRoomAvailableForInpatientCare(Room room)
        {
            Console.WriteLine("" + HasAvailableBed(room) + " " + !IsRoomInRenovation(room, new TimeInterval(DateTime.Now, DateTime.Now)));
            return HasAvailableBed(room) && !IsRoomInRenovation(room, new TimeInterval(DateTime.Now, DateTime.Now));
        }
        public List<Bed> GetAvailableBeds(Room room)
        {
            List<Bed> beds = new List<Bed>();
            foreach (Equipment equipment in room.Equipment)
            {
                beds.Add(equipment as Bed);
                // ne razlikuje krevet i opremu
                //if(equipment.IsBed() && !IsBedReserved(equipment))
                //{
                //    beds.Add(equipment as Bed);
                //}
            }
            return beds;
        }

        private bool HasAvailableBed(Room room)
        {
            return true;
            // ne razlikuje krevet i opremu
            //foreach(Equipment equipment in room.Equipment)
            //{
            //    if(equipment.IsBed() && !IsBedReserved(equipment))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }
        private bool IsBedReserved(Equipment bed)
        {
            List<BedReservation> bedReservations = bedReservationRepository.GetAll();
            foreach (BedReservation bedReservation in bedReservations)
            {
                if (bedReservation.Bed.Equals(bed))
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsRoomInRenovation(Room room, TimeInterval timeInterval)
        {
            List<Renovation> renovations = renovationRepository.GetRenovationsByRoom(room);
            foreach (Renovation renovation in renovations)
            {
                if (timeInterval.IsOverLapping(renovation.TimeInterval))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsRoomScheduled(Room room, TimeInterval timeInterval)
        {
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByRoom(room);
            foreach (Appointment appointment in appointments)
            {
                if (timeInterval.IsOverLapping(appointment.TimeInterval))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
