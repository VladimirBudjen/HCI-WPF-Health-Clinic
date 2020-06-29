// File:    PatientScheduleController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientScheduleController

using Backend.Dto;
using Backend.Service.SchedulingService;
using Backend.Service.SchedulingService.SchedulingStrategies;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Controller.PatientControllers
{
    public class PatientScheduleController
    {
        public PatientScheduleController()
        {
            appointmentSchedulingService = new AppointmentSchedulingService(new PatientSchedulingStrategy());
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

        public void NewAppointment(Backend.Dto.AppointmentDTO appointmentDTO)
        {
            appointmentService.NewAppointment(appointmentDTO);
        }

        public Backend.Dto.AppointmentDTO GetSuggestedAppointment(String physitiansID, List<DateTime> dates, int prior)
        {
            throw new NotImplementedException();
        }
        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentDTO)
        {
            return appointmentSchedulingService.GetAvailableAppointments(appointmentDTO);
        }

        public AppointmentService appointmentService;
        public AppointmentSchedulingService appointmentSchedulingService;

    }
}