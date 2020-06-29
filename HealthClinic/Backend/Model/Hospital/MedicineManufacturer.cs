// File:    MedicineManufacturer.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class MedicineManufacturer

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Hospital
{
    public class MedicineManufacturer : Entity
    {
        private String name;

        public string Name { get => name; }

        public MedicineManufacturer(string name) : base(Guid.NewGuid().ToString())
        {
            this.name = name;
        }

        [JsonConstructor]
        public MedicineManufacturer(String serialNumber, string name) : base(serialNumber)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            MedicineManufacturer other = obj as MedicineManufacturer;
            if(other == null)
            {
                return false;
            }
            return this.Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}