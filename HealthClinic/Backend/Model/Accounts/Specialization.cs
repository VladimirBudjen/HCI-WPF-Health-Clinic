// File:    Specialization.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Specialization

using Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Accounts
{
    public class Specialization : Entity
    {
        private String name;

        public Specialization(string name) : base(Guid.NewGuid().ToString())
        {
            this.name = name;
        }

        [JsonConstructor]
        public Specialization(String serialNumber, string name) : base(serialNumber)
        {
            this.name = name;
        }

        public string Name { get => name; }

        public override string ToString()
        {
            return this.name;
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }
        public override bool Equals(object obj)
        {
            Specialization other = obj as Specialization;
            if (other == null)
            {
                return false;
            }
            return this.Name.Equals(other.Name);
        }
    }
}