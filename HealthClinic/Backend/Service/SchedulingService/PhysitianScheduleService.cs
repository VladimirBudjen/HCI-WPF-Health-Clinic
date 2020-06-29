// File:    PhysitianScheduleService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianScheduleService

using Backend.Dto;
using Backend.Repository;
using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Service.SchedulingService
{
    public class PhysitianScheduleService
    {
        private Physitian loggedPhysitian;
        private AppointmentRepository appointmentRepository;

        public PhysitianScheduleService(Physitian loggedPhysitian)
        {
            this.loggedPhysitian = loggedPhysitian;
            this.appointmentRepository = new AppointmentFileSystem();
        }

        public void NewAppointment(AppointmentDTO appointmentDTO)
        {
            Appointment appointment = new Appointment(appointmentDTO);
            appointmentRepository.Save(appointment);
        }
        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in appointmentRepository.GetAppointmentsByPhysitian(loggedPhysitian))
            {
                if (date.Equals(appointment.Date))
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }
        public Appointment GetTodaysAppointmentForPatient(Patient patient)
        {
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByPhysitian(loggedPhysitian);
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Date.Equals(DateTime.Today) && appointment.Patient.Equals(patient))
                {
                    return appointment;
                }
            }
            return null;
        }
        public Appointment GetPreviousAppointmentForPatient(Patient patient)
        {
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByPatient(patient);
            foreach (Appointment appointment in SortAppointmentsDescending(appointments))
            {
                if (IsInPast(appointment))
                {
                    return appointment;
                }
            }
            return null;
        }
        public Appointment GetNextAppointmentForPatient(Patient patient)
        {
            List<Appointment> appointments = appointmentRepository.GetAppointmentsByPatient(patient);
            foreach (Appointment appointment in SortAppointmentsAscending(appointments))
            {
                if (IsInFuture(appointment))
                {
                    return appointment;
                }
            }
            return null;
        }

        private bool IsInPast(Appointment appointment)
        {
            return appointment.Date.CompareTo(DateTime.Today) < 0;
        }
        private bool IsInFuture(Appointment appointment)
        {
            return appointment.Date.CompareTo(DateTime.Today) > 0;
        }
        private List<Appointment> SortAppointmentsDescending(List<Appointment> appointments)
        {
            appointments.Sort((a, b) => b.CompareTo(a));
            return appointments;
        }
        private List<Appointment> SortAppointmentsAscending(List<Appointment> appointments)
        {
            appointments.Sort((a, b) => a.CompareTo(b));
            return appointments;
        }

    }
}