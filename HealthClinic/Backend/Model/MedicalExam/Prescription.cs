// File:    Prescription.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Prescription

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.MedicalExam
{
    public class Prescription : AdditionalDocument
    {
        private List<MedicineDosage> medicineDosage;

        public Prescription(DateTime date, string notes) : base(Guid.NewGuid().ToString(), date, notes)
        {
            medicineDosage = new List<MedicineDosage>();
        }

        [JsonConstructor]
        public Prescription(String serialNumber, DateTime date, string notes) : base(serialNumber, date, notes)
        {
            medicineDosage = new List<MedicineDosage>();
        }

        public List<MedicineDosage> MedicineDosage
        {
            get
            {
                if (medicineDosage == null)
                    medicineDosage = new List<MedicineDosage>();
                return medicineDosage;
            }
            set
            {
                RemoveAllMedicineDosage();
                if (value != null)
                {
                    foreach (MedicineDosage oMedicineDosage in value)
                        AddMedicineDosage(oMedicineDosage);
                }
            }
        }

        public void AddMedicineDosage(MedicineDosage newMedicineDosage)
        {
            if (newMedicineDosage == null)
                return;
            if (this.medicineDosage == null)
                this.medicineDosage = new List<MedicineDosage>();
            if (!this.medicineDosage.Contains(newMedicineDosage))
                this.medicineDosage.Add(newMedicineDosage);
        }

        public void RemoveMedicineDosage(MedicineDosage oldMedicineDosage)
        {
            if (oldMedicineDosage == null)
                return;
            if (this.medicineDosage != null)
                if (this.medicineDosage.Contains(oldMedicineDosage))
                    this.medicineDosage.Remove(oldMedicineDosage);
        }

        public void RemoveAllMedicineDosage()
        {
            if (medicineDosage != null)
                medicineDosage.Clear();
        }

        public override bool Equals(object obj)
        {
            Prescription other = obj as Prescription;
            if(other == null)
            {
                return false;
            }
            if(this.medicineDosage.Count != other.medicineDosage.Count)
            {
                return false;
            }
            foreach(MedicineDosage m in this.medicineDosage)
            {
                if(!other.medicineDosage.Contains(m))
                {
                    return false;
                }
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string ret = base.ToString();
            foreach(MedicineDosage m in medicineDosage)
            {
                ret += "\nmedicine dosage: " +  m.ToString();
            }
            return ret;
        }
    }
}