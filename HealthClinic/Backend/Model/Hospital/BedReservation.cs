// File:    BedReservation.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class BedReservation

using Backend.Dto;
using Backend.Model.Util;
using Model.Accounts;
using Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Hospital
{
    public class BedReservation : Entity
    {
        private TimeInterval timeInterval;
        private Patient patient;
        private Bed bed;

        public Bed Bed
        {
            get
            {
                return bed;
            }
        }

        public Patient Patient { get => patient; }
        public TimeInterval TimeInterval { get => timeInterval; }

        public BedReservation(TimeInterval timeInterval, Patient patient, Bed bed) : base(Guid.NewGuid().ToString())
        {
            this.timeInterval = timeInterval;
            this.patient = patient;
            this.bed = bed;
        }

        [JsonConstructor]
        public BedReservation(String serialNumber, TimeInterval timeInterval, Patient patient, Bed bed) : base(serialNumber)
        {
            this.timeInterval = timeInterval;
            this.patient = patient;
            this.bed = bed;
        }
        public BedReservation(BedReservationDTO bedReservationDTO) : base(Guid.NewGuid().ToString())
        {
            this.timeInterval = bedReservationDTO.TimeInterval;
            this.patient = bedReservationDTO.Patient;
            this.bed = bedReservationDTO.Bed;
        }
        public override bool Equals(object obj)
        {
            BedReservation other = obj as BedReservation;

            if(other == null)
            {
                return false;
            }

            return this.Patient.Equals(other.Patient) && this.TimeInterval.Equals(other.TimeInterval)
                && this.Bed.Equals(other.Bed);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "patient: " + this.Patient.FullName + "\nbed: " + this.Bed.ToString() + "\ntime interval: "
                + this.TimeInterval.ToString();
        }
    }
}