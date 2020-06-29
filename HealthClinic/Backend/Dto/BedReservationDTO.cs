// File:    BedReservationDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class BedReservationDTO

using Model.Accounts;
using Model.Hospital;
using Model.Util;
using System;

namespace Backend.Dto
{
    public class BedReservationDTO
    {
        private Bed bed;
        private Patient patient;
        private TimeInterval timeInterval;

        public Bed Bed { get => bed; set => bed = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public TimeInterval TimeInterval { get => timeInterval; set => timeInterval = value; }
    }
}