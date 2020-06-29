// File:    InpatientCare.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class InpatientCare

using Backend.Model.Util;
using Model.Accounts;
using Newtonsoft.Json;
using System;

namespace Model.MedicalExam
{
    public class InpatientCare : Entity
    {
        private DateTime dateOfAdmition;
        private DateTime dateOfDischarge;

        private Physitian physitian;
        private Patient patient;

        public DateTime DateOfAdmition { get => dateOfAdmition; }
        public DateTime DateOfDischarge { get => dateOfDischarge; }
        public Physitian Physitian { get => physitian; }
        public Patient Patient { get => patient; }

        public InpatientCare(DateTime dateOfAdmition, DateTime dateOfDischarge, Physitian physitian, Patient patient) : base(Guid.NewGuid().ToString())
        {
            this.dateOfAdmition = dateOfAdmition;
            this.dateOfDischarge = dateOfDischarge;
            this.physitian = physitian;
            this.patient = patient;
        }

        [JsonConstructor]
        public InpatientCare(String serialNumber, DateTime dateOfAdmition, DateTime dateOfDischarge, Physitian physitian, Patient patient) : base(serialNumber)
        {
            this.dateOfAdmition = dateOfAdmition;
            this.dateOfDischarge = dateOfDischarge;
            this.physitian = physitian;
            this.patient = patient;
        }

        public override bool Equals(object obj)
        {
            InpatientCare other = obj as InpatientCare;
            if (other == null)
            {
                return false;
            }
            return this.DateOfAdmition.Equals(other.DateOfAdmition) && this.DateOfDischarge.Equals(other.DateOfDischarge)
                && this.Patient.Equals(other.Patient) && this.Physitian.Equals(other.Physitian);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "patient: " + patient.FullName + "\nphysitian: " + physitian.FullName + "\ndate of admition:"
                + dateOfAdmition.ToString("dd.MM.yyyy.") + "\ndate of discharge:" + dateOfDischarge.ToString("dd.MM.yyyy.");
        }
    }
}