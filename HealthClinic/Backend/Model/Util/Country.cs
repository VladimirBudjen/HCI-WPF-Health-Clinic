// File:    Country.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Country

using Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Util
{
    public class Country : Entity
    {
        private static int serialNumberGenerator = 0;
        private String name;

        private List<City> city;

        public List<City> City
        {
            get
            {
                if (city == null)
                    city = new List<City>();
                return city;
            }
            set
            {
                RemoveAllCity();
                if (value != null)
                {
                    foreach (City oCity in value)
                        AddCity(oCity);
                }
            }
        }

        public string Name { get => name; }

        public Country(string name) : base(Guid.NewGuid().ToString())
        {
            this.name = name;
        }

        [JsonConstructor]
        public Country(String serialNumber, string name) : base(serialNumber)
        {
            this.name = name;
        }

        public void AddCity(City newCity)
        {
            if (newCity == null)
                return;
            if (this.city == null)
                this.city = new List<City>();
            if (!this.city.Contains(newCity))
                this.city.Add(newCity);
        }

        public void RemoveCity(City oldCity)
        {
            if (oldCity == null)
                return;
            if (this.city != null)
                if (this.city.Contains(oldCity))
                    this.city.Remove(oldCity);
        }

        public void RemoveAllCity()
        {
            if (city != null)
                city.Clear();
        }

        public override string ToString()
        {
            return name;
        }

        public List<City> Cities
        {
            get
            {
                return City;
            }
        }

        public override bool Equals(object obj)
        {
            Country other = obj as Country;
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
    }
}