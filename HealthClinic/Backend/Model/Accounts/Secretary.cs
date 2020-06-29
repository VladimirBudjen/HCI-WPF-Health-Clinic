// File:    Secretary.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Secretary

using Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Accounts
{
    public class Secretary : Account
    {
        
        public Secretary(string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address)
            : base(Guid.NewGuid().ToString(), name, surname, id, dateOfBirth, contact, email, address)
        {

        }

        [JsonConstructor]
        public Secretary(String serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address)
        {

        }
    }
}