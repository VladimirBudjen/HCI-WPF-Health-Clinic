// File:    Medicine.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Medicine

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Hospital
{
    public class Medicine : Entity
    {
        private String copyrightName;
        private String genericName;
        private MedicineManufacturer medicineManufacturer;
        private MedicineType medicineType;

        public string CopyrightName { get => copyrightName; }
        public string GenericName { get => genericName; }
        public MedicineManufacturer MedicineManufacturer { get => medicineManufacturer; }
        public MedicineType MedicineType { get => medicineType; }

        public Medicine(string copyrightName, string genericName, MedicineManufacturer medicineManufacturer, MedicineType medicineType) : base(Guid.NewGuid().ToString())
        {
            this.copyrightName = copyrightName;
            this.genericName = genericName;
            this.medicineManufacturer = medicineManufacturer;
            this.medicineType = medicineType;
        }

        [JsonConstructor]
        public Medicine(String serialNumber, string copyrightName, string genericName, MedicineManufacturer medicineManufacturer, MedicineType medicineType) : base(serialNumber)
        {
            this.copyrightName = copyrightName;
            this.genericName = genericName;
            this.medicineManufacturer = medicineManufacturer;
            this.medicineType = medicineType;
        }

        public override bool Equals(object obj)
        {
            Medicine other = obj as Medicine;

            if(other == null)
            {
                return false;
            }

            return this.CopyrightName.Equals(other.CopyrightName);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return CopyrightName;
        }
    }
}