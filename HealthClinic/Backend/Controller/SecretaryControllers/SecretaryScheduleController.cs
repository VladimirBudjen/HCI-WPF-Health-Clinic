// File:    SecretaryScheduleContoller.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryScheduleController

using Backend.Dto;
using Backend.Service.SchedulingService;
using Backend.Service.SchedulingService.SchedulingStrategies;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Controller.SecretaryControllers
{
    public class SecretaryScheduleController
    {

        public AppointmentService appointmentService;
        public AppointmentSchedulingService appointmentSchedulingService;

        public SecretaryScheduleController()
        {
            appointmentSchedulingService = new AppointmentSchedulingService(new SecretarySchedulingStrategy());
            appointmentService = new AppointmentService();
        }

        public void EditAppointment(Appointment appointment)
        {
            appointmentService.EditAppointment(appointment);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointmentService.DeleteAppointment(appointment);
        }

        public List<Appointment> GetAppointmentsByDate(DateTime date)
        {
            return appointmentService.GetAppointmentsByDate(date);
        }

        public void NewAppointment(AppointmentDTO appointmentDTO)
        {
            appointmentService.NewAppointment(appointmentDTO);
        }

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentDTO)
        {
            return appointmentSchedulingService.GetAvailableAppointments(appointmentDTO);
        }

        public AppointmentDTO GetRecommendedAppointment(AppointmentDTO appointmentDTO)
        {
            throw new NotImplementedException();
        }
    }
}