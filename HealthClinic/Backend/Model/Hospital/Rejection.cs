// File:    Rejection.cs
// Author:  Vladimir
// Created: Monday, May 25, 2020 17:06:42
// Purpose: Definition of Class Rejection

using Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Hospital
{
    public class Rejection : Entity
    {
        private String reason;
        private Medicine medicine;

        public string Reason { get => reason; }
        public Medicine Medicine { get => medicine; }

        public Rejection(string reason, Medicine medicine) : base(Guid.NewGuid().ToString())
        {
            this.reason = reason;
            this.medicine = medicine;
        }

        [JsonConstructor]
        public Rejection(String serialNumber, string reason, Medicine medicine) : base(serialNumber)
        {
            this.reason = reason;
            this.medicine = medicine;
        }

        public override bool Equals(object obj)
        {
            Rejection other = obj as Rejection;
            if(other == null)
            {
                return false;
            }
            return this.Reason.Equals(other.Reason) && this.Medicine.Equals(other.Medicine);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "medicine: " + this.Medicine.ToString() + "\nreason: " + this.Reason;
        }
    }
}