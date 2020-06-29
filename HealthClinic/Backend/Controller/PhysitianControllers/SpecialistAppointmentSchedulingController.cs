// File:    SpecialistAppointmentSchedulingController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SpecialistAppointmentSchedulingController

using Backend.Dto;
using Backend.Service.SchedulingService;
using Backend.Service.SchedulingService.SchedulingStrategies;
using Model.Accounts;
using Model.MedicalExam;
using System;
using System.Collections.Generic;

namespace Backend.Controller.PhysitianControllers
{
    public class SpecialistAppointmentSchedulingController
    {
        private AppointmentSchedulingService appointmentSchedulingService;

        public SpecialistAppointmentSchedulingController()
        {
            this.appointmentSchedulingService = new AppointmentSchedulingService(new PhysitianSpecialistSchedulingStrategy());
        }

        public List<AppointmentDTO> GetAllAvailableAppointments(AppointmentDTO appointmentDTO)
        {
            return appointmentSchedulingService.GetAvailableAppointments(appointmentDTO);
        }

    }
}