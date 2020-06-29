// File:    Physitian.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Physitian

using Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Accounts
{
    public class Physitian : Account
    {
        
        private List<Specialization> specialization;
        public Physitian(string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address)
            : base(Guid.NewGuid().ToString(), name, surname, id, dateOfBirth, contact, email, address)
        {
            this.specialization = new List<Specialization>();
        }
   
        [JsonConstructor]
        public Physitian(String serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, TimeInterval workSchedule, List<Specialization> specialization = null)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address)
        {
            this.workSchedule = workSchedule;
            if (specialization == null)
            {
                this.specialization = new List<Specialization>();
            }
            else
            {
                this.specialization = specialization;
            }
        }

        public List<Specialization> Specialization
        {
            get
            {
                if (specialization == null)
                    specialization = new List<Specialization>();
                return specialization;
            }
        }

        public void AddSpecialization(Specialization newSpecialization)
        {
            if (newSpecialization == null)
                return;
            if (this.specialization == null)
                this.specialization = new List<Specialization>();
            if (!this.specialization.Contains(newSpecialization))
                this.specialization.Add(newSpecialization);
        }

        public void RemoveSpecialization(Specialization oldSpecialization)
        {
            if (oldSpecialization == null)
                return;
            if (this.specialization != null)
                if (this.specialization.Contains(oldSpecialization))
                    this.specialization.Remove(oldSpecialization);
        }

        public void RemoveAllSpecialization()
        {
            if (specialization != null)
                specialization.Clear();
        }

        public override string ToString()
        {
            return base.ToString();
        }


        private TimeInterval workSchedule;
        private System.Collections.Generic.List<TimeInterval> vacationTime;

        public System.Collections.Generic.List<TimeInterval> VacationTime
        {
            get
            {
                if (vacationTime == null)
                    vacationTime = new System.Collections.Generic.List<TimeInterval>();
                return vacationTime;
            }
            set
            {
                RemoveAllVacationTime();
                if (value != null)
                {
                    foreach (TimeInterval oTimeInterval in value)
                        AddVacationTime(oTimeInterval);
                }
            }
        }

        public void AddVacationTime(TimeInterval newTimeInterval)
        {
            if (newTimeInterval == null)
                return;
            if (this.vacationTime == null)
                this.vacationTime = new System.Collections.Generic.List<TimeInterval>();
            if (!this.vacationTime.Contains(newTimeInterval))
                this.vacationTime.Add(newTimeInterval);
        }

        public void RemoveVacationTime(TimeInterval oldTimeInterval)
        {
            if (oldTimeInterval == null)
                return;
            if (this.vacationTime != null)
                if (this.vacationTime.Contains(oldTimeInterval))
                    this.vacationTime.Remove(oldTimeInterval);
        }

        public void RemoveAllVacationTime()
        {
            if (vacationTime != null)
                vacationTime.Clear();
        }
        public TimeInterval WorkSchedule { get => workSchedule; set => workSchedule = value; }

        public String AllSpecializations
        {
            get
            {
                String specializations = "";
                foreach (Specialization s in Specialization)
                {
                    specializations += s.ToString() + ", ";
                }
                return specializations;
            }
        }

        public bool IsOnVacation(TimeInterval timeInterval)
        {
            foreach (TimeInterval vacation in VacationTime)
            {
                if (vacation.IsOverLapping(timeInterval))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsTheirShift(TimeInterval timeInterval)
        {
            return workSchedule.IsTimeOfDayContained(timeInterval);
        }
    }
}