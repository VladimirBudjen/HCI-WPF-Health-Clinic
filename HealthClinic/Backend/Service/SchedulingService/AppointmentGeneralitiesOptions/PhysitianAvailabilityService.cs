using Backend.Repository;
using Model.Accounts;
using Model.Schedule;
using Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Service.SchedulingService.AppointmentGeneralitiesOptions
{
    class PhysitianAvailabilityService
    {
        private AppointmentRepository appointmentRepository;

        public PhysitianAvailabilityService()
        {
            this.appointmentRepository = new AppointmentFileSystem();
        }

        public bool IsPhysitianAvailableAtAnyTime(Physitian physitian, List<TimeInterval> timeIntervals)
        {
            foreach (TimeInterval timeInterval in timeIntervals)
            {
                if (IsPhysitianAvailable(physitian, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsAnyPhysitianAvailable(List<Physitian> physitians, TimeInterval timeInterval)
        {
            foreach (Physitian physitian in physitians)
            {
                if (IsPhysitianAvailable(physitian, timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsPhysitianAvailable(Physitian physitian, TimeInterval timeInterval)
        {
            bool isTheirShift = physitian.IsTheirShift(timeInterval);
            bool isNotOnVacation = !physitian.IsOnVacation(timeInterval);
            bool isNotScheduled = !IsPhysitianScheduled(physitian, timeInterval);
            return isTheirShift && isNotOnVacation && isNotScheduled;
        }
        public bool canGoOnVacation(Physitian physitian, TimeInterval timeInterval)
        {
            bool isNotOnVacation = !physitian.IsOnVacation(timeInterval);
            bool isNotScheduled = !IsPhysitianScheduled(physitian, timeInterval);
            return isNotOnVacation && isNotScheduled;
        }

        private bool IsPhysitianScheduled(Physitian physitian, TimeInterval timeInterval)
        {
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByPhysitian(physitian);
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
