// File:    PhysitianPriorityStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianPriorityStrategy

using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;
using Backend.Dto;

namespace Backend.Service.SchedulingService.PriorityStrategies
{
public class PhysitianPriorityStrategy : PriorityStrategy
    {
        public List<AppointmentDTO> FindSuggestedAppointments(SuggestedAppointmentDTO suggestedAppointmentDTO)
        {
            DateTime currentDate = suggestedAppointmentDTO.DateStart.AddDays(-3);
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            while (!currentDate.Equals(suggestedAppointmentDTO.DateEnd.AddDays(3)))
            {
                AppointmentDTO appointment = new AppointmentDTO();
                if (currentDate.CompareTo(DateTime.Today)<0)
                {
                    continue;
                }
                appointment.Date = currentDate;
                appointment.Physitian = suggestedAppointmentDTO.Physitian;
                appointment.Patient = suggestedAppointmentDTO.Patient;
                appointmentDTOs.Add(appointment);
                currentDate = currentDate.AddDays(1);
                if(currentDate == suggestedAppointmentDTO.DateStart)
                {
                    currentDate = suggestedAppointmentDTO.DateEnd;
                }
            }
            return appointmentDTOs;
        }

    }
}