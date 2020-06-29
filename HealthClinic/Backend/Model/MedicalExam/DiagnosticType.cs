// File:    DiagnosticType.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class DiagnosticType

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.MedicalExam
{
    public class DiagnosticType : Entity
    {
        private String name;

        public string Name { get => name; }

        public DiagnosticType(string name) : base(Guid.NewGuid().ToString())
        {
            this.name = name;
        }

        [JsonConstructor]
        public DiagnosticType(String serialNumber, string name) : base(serialNumber)
        {
            this.name = name;
        }
        public override bool Equals(object obj)
        {
            DiagnosticType other = obj as DiagnosticType;
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
            return Name;
        }
    }
}