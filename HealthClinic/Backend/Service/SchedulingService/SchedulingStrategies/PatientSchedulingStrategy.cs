// File:    PatientSchedulingStrategy.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientSchedulingStrategy

using Backend.Dto;
using Model.Accounts;
using Model.Schedule;
using System;

namespace Backend.Service.SchedulingService.SchedulingStrategies
{
    public class PatientSchedulingStrategy : SchedulingStrategy
    {
        private const int DISALLOW_SCHEDULING_HOURS = 24;
        public AppointmentDTO PrepareAppointment(AppointmentDTO appointment)
        {
            appointment.RestrictedHours = DISALLOW_SCHEDULING_HOURS;
            appointment.ProcedureType = new ProcedureType("Pregled opšte prakse", 39, new Specialization("Opšta praksa"));
            appointment.Urgency = false;
            return appointment;
        }
    }
}