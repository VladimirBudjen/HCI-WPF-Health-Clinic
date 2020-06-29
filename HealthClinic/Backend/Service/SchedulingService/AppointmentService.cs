// File:    AppointmentService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentService

using Backend.Dto;
using Backend.Repository;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Service.SchedulingService
{
    public class AppointmentService
    {
        public AppointmentRepository appointmentRepository;

        public AppointmentService()
        {
            appointmentRepository = new AppointmentFileSystem();
        }

        public void EditAppointment(Appointment appointment)
        {
            appointmentRepository.Update(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointmentRepository.Delete(appointment.SerialNumber);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return appointmentRepository.GetAppointmentsByDate(date);
        }

        public void NewAppointment(AppointmentDTO appointmentDTO)
        {
            appointmentRepository.Save(new Appointment(appointmentDTO));
        }

    }
}