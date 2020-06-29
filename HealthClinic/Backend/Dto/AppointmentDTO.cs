// File:    AppointmentDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class AppointmentDTO

using Model.Accounts;
using Model.Hospital;
using Model.Schedule;
using Model.Util;
using System;

namespace Backend.Dto
{
    public class AppointmentDTO
    {
        public bool IsPreferedPhysitianSelected()
        {
            return (Physitian != null);
        }

        public bool IsPreferredTimeSelected()
        {
            return (Time != null);
        }
        public bool IsPreferredDateSelected()
        {
            DateTime defaultDate = DateTime.MinValue;
            return !date.Equals(defaultDate);
        }

        public bool IsPreferedRoomSelected()
        {
            return (Room != null);
        }

        private ProcedureType procedureType;
        private TimeInterval time;
        private DateTime date;
        private Physitian physitian;
        private Patient patient;
        private Room room;
        private bool urgency;
        private int restrictedHours;

        public ProcedureType ProcedureType { get => procedureType; set => procedureType = value; }
        public TimeInterval Time { get => time; set => time = value; }
        public Physitian Physitian { get => physitian; set => physitian = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Room Room { get => room; set => room = value; }
        public bool Urgency { get => urgency; set => urgency = value; }
        public int RestrictedHours { get => restrictedHours; set => restrictedHours = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}