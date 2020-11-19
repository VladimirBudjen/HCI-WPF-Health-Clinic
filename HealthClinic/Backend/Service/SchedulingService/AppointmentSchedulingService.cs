// File:    AppointmentSchedulingService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentSchedulingService

using Backend.Dto;
using Model.Accounts;
using Model.Hospital;
using Model.Util;
using Backend.Service.SchedulingService.SchedulingStrategies;
using System;
using System.Collections.Generic;
using Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;
using Backend.Service.SchedulingService.PriorityStrategies;

namespace Backend.Service.SchedulingService
{
    public class AppointmentSchedulingService
    {
        private SchedulingStrategy schedulingStrategyContext;
        private AppointmentGeneralitiesManager appointmentGeneralitiesManager;

        public AppointmentSchedulingService(SchedulingStrategy schedulingStrategyContext)
        {
            this.schedulingStrategyContext = schedulingStrategyContext;
            this.appointmentGeneralitiesManager = new AppointmentGeneralitiesManager();
        }

        public List<AppointmentDTO> GetAvailableAppointments(AppointmentDTO appointmentPreferences)
        {
            AppointmentDTO preparedAppointmentPreferences = schedulingStrategyContext.PrepareAppointment(appointmentPreferences);
            return appointmentGeneralitiesManager.GetAllAvailableAppointments(preparedAppointmentPreferences);
        }
        public AppointmentDTO FindNearestAppointment(AppointmentDTO appointmentPreferences)
        {
            AppointmentDTO preparedAppointmentPreferences = schedulingStrategyContext.PrepareAppointment(appointmentPreferences);
            throw new NotImplementedException();
        }
        public AppointmentDTO GetSuggestedAppointment(SuggestedAppointmentDTO suggestedAppointmentDTO)
        {
            DateTime currentDate = suggestedAppointmentDTO.DateStart;
            
            while (!currentDate.Equals(suggestedAppointmentDTO.DateEnd))
            {
                AppointmentDTO appointment = new AppointmentDTO();
                appointment.Date = currentDate;
                appointment.Physitian = suggestedAppointmentDTO.Physitian;
                appointment.Patient = suggestedAppointmentDTO.Patient;
                List<AppointmentDTO> suggestedAppointmentDTOs = GetAvailableAppointments(appointment);
                if (suggestedAppointmentDTOs.Count != 0)
                {
                    return suggestedAppointmentDTOs[0];
                }
                currentDate = currentDate.AddDays(1);
            }
            if (suggestedAppointmentDTO.Prior)
            {
                DatePriorityStrategy datePriorityStrategy = new DatePriorityStrategy();
                List<AppointmentDTO> suggestedAppointmentDTOsDate = datePriorityStrategy.FindSuggestedAppointments(suggestedAppointmentDTO);
                foreach(AppointmentDTO appointmentDTO in suggestedAppointmentDTOsDate)
                {
                    List<AppointmentDTO> suggestedAppointmentDTOs = GetAvailableAppointments(appointmentDTO);
                    if (suggestedAppointmentDTOs.Count != 0)
                    {
                        return suggestedAppointmentDTOs[0];
                    }
                }
            }
            else
            {
                PhysitianPriorityStrategy physitianPriorityStrategy = new PhysitianPriorityStrategy();
                List<AppointmentDTO> suggestedAppointmentDTOsPhysitian = physitianPriorityStrategy.FindSuggestedAppointments(suggestedAppointmentDTO);
                foreach (AppointmentDTO appointmentDTO in suggestedAppointmentDTOsPhysitian)
                {
                    List<AppointmentDTO> suggestedAppointmentDTOs = GetAvailableAppointments(appointmentDTO);
                    if (suggestedAppointmentDTOs.Count != 0)
                    {
                        return suggestedAppointmentDTOs[0];
                    }
                }
            }
            return null;
        }

    }
}