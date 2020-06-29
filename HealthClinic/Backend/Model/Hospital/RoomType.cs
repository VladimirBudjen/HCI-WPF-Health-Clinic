// File:    RoomType.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class RoomType

using Backend.Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Hospital
{
    public class RoomType : Entity
    {
     
        private string name;

        public string Name { get => name; }


        public RoomType(string name) : base(Guid.NewGuid().ToString())
        {
            this.name = name;
        }

        [JsonConstructor]
        public RoomType(String serialNumber, string name) : base(serialNumber)
        {
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            RoomType other = obj as RoomType;
            if (other == null)
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
            return "name: " + this.Name;
        }
    }
}