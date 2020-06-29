// File:    FollowUpAppointmentSchedulingController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class FollowUpAppointmentSchedulingController

using Backend.Dto;
using Backend.Service.SchedulingService;
using Backend.Service.SchedulingService.SchedulingStrategies;
using Model.Accounts;
using Model.MedicalExam;
using System;

namespace Backend.Controller.PhysitianControllers
{
    public class FollowUpAppointmentSchedulingController
    {
        private AppointmentSchedulingService appointmentSchedulingService;

        public FollowUpAppointmentSchedulingController()
        {
            this.appointmentSchedulingService = new AppointmentSchedulingService(new PhysitianFollowUpSchedulingStrategy());
        }

        public AppointmentDTO GetRecommendedAppointment(AppointmentDTO appointmentDTO)
        {
            return appointmentSchedulingService.FindNearestAppointment(appointmentDTO);
        }
    }
}