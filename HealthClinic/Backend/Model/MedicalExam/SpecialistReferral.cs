// File:    SpecialistReferral.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class SpecialistReferral

using Model.Accounts;
using Model.Schedule;
using Newtonsoft.Json;
using System;

namespace Model.MedicalExam
{
    public class SpecialistReferral : AdditionalDocument
    {
        private ProcedureType procedureType;
        private Physitian physitian;

        public ProcedureType ProcedureType { get => procedureType; }
        public Physitian Physitian { get => physitian; }

        public SpecialistReferral(DateTime date, string notes, ProcedureType procedureType, Physitian physitian) : base(Guid.NewGuid().ToString(), date, notes)
        {
            this.procedureType = procedureType;
            this.physitian = physitian;
        }

        [JsonConstructor]
        public SpecialistReferral(String serialNumber, DateTime date, string notes, ProcedureType procedureType, Physitian physitian) : base(serialNumber, date, notes)
        {
            this.procedureType = procedureType;
            this.physitian = physitian;
        }

        public override bool Equals(object obj)
        {
            SpecialistReferral other = obj as SpecialistReferral;
            if (other == null)
            {
                return false;
            }
            return this.SerialNumber.Equals(other.SerialNumber);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "\nphysitian: " + this.Physitian.FullName
                + "\nspecialization: " + this.procedureType;
        }
    }
}