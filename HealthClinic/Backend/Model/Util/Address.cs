// File:    Address.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Address

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Util
{
    public class Address : Entity
    {

        private String street;

        public string Street { get => street; }

        public Address(string street) : base(Guid.NewGuid().ToString())
        {
            this.street = street;
        }

        [JsonConstructor]
        public Address(String serialNumber, string street) : base(serialNumber)
        {
            this.street = street;
        }

        public override string ToString()
        {
            return street;
        }

        public override bool Equals(object obj)
        {
            Address other = obj as Address;
            if (other == null)
            {
                return false;
            }
            return this.Street.Equals(other.Street);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}