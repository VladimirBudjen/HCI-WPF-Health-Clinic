// File:    MedicineDosage.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class MedicineDosage

using Backend.Model.Util;
using Model.Hospital;
using Newtonsoft.Json;
using System;

namespace Model.MedicalExam
{
    public class MedicineDosage : Entity
    {
        private double amount;
        private String note;
        private Medicine medicine;

        public Medicine Medicine
        {
            get
            {
                return medicine;
            }
        }

        public double Amount { get => amount; }
        public string Note { get => note; }

        public MedicineDosage(double ammount, string note, Medicine medicine) : base(Guid.NewGuid().ToString())
        {
            this.amount = ammount;
            this.note = note;
            this.medicine = medicine;
        }

        [JsonConstructor]
        public MedicineDosage(String serialNumber, double ammount, string note, Medicine medicine) : base(serialNumber)
        {
            this.amount = ammount;
            this.note = note;
            this.medicine = medicine;
        }

        public override bool Equals(object obj)
        {
            MedicineDosage other = obj as MedicineDosage;
            if(other == null)
            {
                return false;
            }
            return this.Medicine.Equals(other.Medicine) && this.Amount == other.Amount && this.Medicine.Equals(other.Medicine);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "medicine: " + medicine.ToString() + "\namount: " + amount + "\nnote: " + note;
        }
    }
}