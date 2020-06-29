// File:    ProcedureType.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class ProcedureType

using Backend.Model.Util;
using Model.Accounts;
using Model.Hospital;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Schedule
{
    public class ProcedureType : Entity
    {

        private String name;
        private Specialization specialization;
        private int estimatedTimeInMinutes;
        private List<Equipment> requiredEquipment;

        public List<Equipment> RequiredEquipment
        {
            get
            {
                if (requiredEquipment == null)
                    requiredEquipment = new List<Equipment>();
                return requiredEquipment;
            }
            set
            {
                RemoveAllRequiredEquipment();
                if (value != null)
                {
                    foreach (Equipment oEquipment in value)
                        AddRequiredEquipment(oEquipment);
                }
            }
        }

        public Specialization Specialization { get => specialization; }
        public string Name { get => name; }
        public int EstimatedTimeInMinutes { get => estimatedTimeInMinutes; }

        public void AddRequiredEquipment(Equipment newEquipment)
        {
            if (newEquipment == null)
                return;
            if (this.requiredEquipment == null)
                this.requiredEquipment = new List<Equipment>();
            if (!this.requiredEquipment.Contains(newEquipment))
                this.requiredEquipment.Add(newEquipment);
        }

        public void RemoveRequiredEquipment(Equipment oldEquipment)
        {
            if (oldEquipment == null)
                return;
            if (this.requiredEquipment != null)
                if (this.requiredEquipment.Contains(oldEquipment))
                    this.requiredEquipment.Remove(oldEquipment);
        }

        public void RemoveAllRequiredEquipment()
        {
            if (requiredEquipment != null)
                requiredEquipment.Clear();
        }

        public override bool Equals(object obj)
        {
            ProcedureType other = obj as ProcedureType;
            if (other == null)
            {
                return false;
            }
            if(this.RequiredEquipment.Count != other.RequiredEquipment.Count)
            {
                return false;
            }
            foreach(Equipment e in requiredEquipment)
            {
                if(!other.RequiredEquipment.Contains(e))
                {
                    return false;
                }
            }
            return this.Specialization.Equals(other.Specialization) && this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ProcedureType(string name, int estimatedTimeInMinutes, Specialization specialization) : base(Guid.NewGuid().ToString())
        {
            this.name = name;
            this.specialization = specialization;
            this.estimatedTimeInMinutes = estimatedTimeInMinutes;
            this.requiredEquipment = new List<Equipment>();
        }

        [JsonConstructor]
        public ProcedureType(String serialNumber, int estimatedTimeInMinutes, string name, Specialization specialization) : base(serialNumber)
        {
            this.name = name;
            this.specialization = specialization;
            this.estimatedTimeInMinutes = estimatedTimeInMinutes;
            this.requiredEquipment = new List<Equipment>();
        }

        public override string ToString()
        {
            return name;
        }
    }
}