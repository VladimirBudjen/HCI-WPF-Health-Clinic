using Backend.Dto;
using Backend.Repository;
using Model.Accounts;
using Model.Hospital;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class AppointmentGeneralitiesManager
    {
        private AppointmentDTO appointmentPreferrences;
        private PhysitianRepository physitianRepository;
        private RoomRepository roomRepository;

        public AppointmentGeneralitiesManager()
        {
            this.physitianRepository = new PhysitianFileSystem();
            this.roomRepository = new RoomFileSystem();
        }

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentPreferrences)
        {
            this.appointmentPreferrences = appointmentPreferrences;
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();

            List<TimeInterval> allTimeIntervals = GetAllTimeIntervals();
            List<Physitian> allPhysitians = GetAllPhysitians();
            List<Room> allRooms = GetAllRooms();

            PhysitianAvailabilityService physitianAvailabilityService = new PhysitianAvailabilityService();
            RoomAvailabilityService roomAvailabilityService = new RoomAvailabilityService();

            foreach (TimeInterval timeInterval in allTimeIntervals)
            {
                foreach (Physitian physitian in allPhysitians)
                {
                    if (physitianAvailabilityService.IsPhysitianAvailable(physitian, timeInterval))
                    {
                        foreach (Room room in allRooms)
                        {
                            if (roomAvailabilityService.IsRoomAvailable(room, timeInterval))
                            {
                                AppointmentDTO appointmentDTO = createAppointment(physitian, room, timeInterval);
                                appointments.Add(appointmentDTO);
                            }
                        }
                    }
                }
            }

            return appointments;
        }

        private AppointmentDTO createAppointment(Physitian physitian, Room room, TimeInterval timeInterval)
        {
            AppointmentDTO appointment = new AppointmentDTO();
            appointment.ProcedureType = appointmentPreferrences.ProcedureType;
            appointment.Patient = appointmentPreferrences.Patient;
            appointment.Time = timeInterval;
            appointment.Physitian = physitian;
            appointment.Room = room;
            return appointment;
        }
        private List<Physitian> GetAllPhysitians()
        {
            List<Physitian> physitians = new List<Physitian>();
            if (appointmentPreferrences.IsPreferedPhysitianSelected())
            {
                physitians.Add(appointmentPreferrences.Physitian);
            }
            else
            {
                physitians = physitianRepository.GetPhysitiansByProcedureType(appointmentPreferrences.ProcedureType);
            }
            return physitians;
        }
        private List<Room> GetAllRooms()
        {
            return roomRepository.GetRoomsByProcedureType(appointmentPreferrences.ProcedureType);
        }
        private List<TimeInterval> GetAllTimeIntervals()
        {
            TimeIntervalGenerator generator = new TimeIntervalGenerator(appointmentPreferrences.ProcedureType, appointmentPreferrences.RestrictedHours);
            List<TimeInterval> timeIntervals = new List<TimeInterval>();
            if (appointmentPreferrences.IsPreferredDateSelected())
            {
                timeIntervals = generator.generateTimeIntervalsForDay(appointmentPreferrences.Date);
            }
            else
            {
                timeIntervals = generator.generateAllTimeIntervals(); ;
            }
            return timeIntervals;
        }
    }
}
