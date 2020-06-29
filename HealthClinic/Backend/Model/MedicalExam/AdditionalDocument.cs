// File:    AdditionalDocument.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class AdditionalDocument

using Backend.Model.Util;
using System;

namespace Model.MedicalExam
{
    public abstract class AdditionalDocument : Entity
    {
        protected DateTime date;
        protected String notes;

        public DateTime Date { get => date; }
        public string Notes { get => notes; }

        protected AdditionalDocument(String serialNumber, DateTime date, string notes) : base(serialNumber)
        {
            this.date = date;
            this.notes = notes;
        }

        public override bool Equals(object obj)
        {
            AdditionalDocument other = obj as AdditionalDocument;
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
            return "date: " + this.Date.ToString("dd.MM.yyyy.") + "\nnotes: " + this.Notes;
        }
    }
}