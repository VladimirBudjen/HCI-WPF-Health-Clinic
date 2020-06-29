// File:    City.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class City

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Util
{
    public class City : Entity
    {
        private static int serialNumberGenerator = 0;
        private String name;
        private String postalCode;

        private System.Collections.Generic.List<Address> address;

        public System.Collections.Generic.List<Address> Address
        {
            get
            {
                if (address == null)
                    address = new System.Collections.Generic.List<Address>();
                return address;
            }
            set
            {
                RemoveAllAddress();
                if (value != null)
                {
                    foreach (Address oAddress in value)
                        AddAddress(oAddress);
                }
            }
        }

        public string Name { get => name; }
        public string PostalCode { get => postalCode; }

        public City(string name, string postalCode) : base(Guid.NewGuid().ToString())
        {
            this.name = name;
            this.postalCode = postalCode;
        }

        [JsonConstructor]
        public City(String serialNumber, string name, string postalCode) : base(serialNumber)
        {
            this.name = name;
            this.postalCode = postalCode;
        }

        public void AddAddress(Address newAddress)
        {
            if (newAddress == null)
                return;
            if (this.address == null)
                this.address = new System.Collections.Generic.List<Address>();
            if (!this.address.Contains(newAddress))
                this.address.Add(newAddress);
        }

        public void RemoveAddress(Address oldAddress)
        {
            if (oldAddress == null)
                return;
            if (this.address != null)
                if (this.address.Contains(oldAddress))
                    this.address.Remove(oldAddress);
        }

        public void RemoveAllAddress()
        {
            if (address != null)
                address.Clear();
        }

        public override string ToString()
        {
            return name + " " + postalCode;
        }

        public override bool Equals(object obj)
        {
            City other = obj as City;
            if (other == null)
            {
                return false;
            }
            return this.Name.Equals(other.Name) && this.postalCode.Equals(other.postalCode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}