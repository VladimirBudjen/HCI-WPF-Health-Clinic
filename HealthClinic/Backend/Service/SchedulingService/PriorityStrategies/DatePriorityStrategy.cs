// File:    DatePriorityStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class DatePriorityStrategy

using Model.Schedule;
using Model.Util;
using System;
using System.Collections.Generic;
using Backend.Dto;
using Backend.Repository;
using Model.Accounts;

namespace Backend.Service.SchedulingService.PriorityStrategies
{
    public class DatePriorityStrategy : PriorityStrategy
    {

        public List<AppointmentDTO> FindSuggestedAppointments(SuggestedAppointmentDTO suggestedAppointmentDTO)
        {
            PhysitianFileSystem pfs = new PhysitianFileSystem();
            List<Physitian> physitians = pfs.GetAll();
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (Physitian physitian in physitians)
            {
                DateTime currentDate = suggestedAppointmentDTO.DateStart;

                while (!currentDate.Equals(suggestedAppointmentDTO.DateEnd))
                {
                    AppointmentDTO appointment = new AppointmentDTO();
                    appointment.Date = currentDate;
                    appointment.Physitian = physitian;
                    appointment.Patient = suggestedAppointmentDTO.Patient;
                    appointmentDTOs.Add(appointment);
                    currentDate = currentDate.AddDays(1);
                }
            }
            return appointmentDTOs;
        }

    }
}