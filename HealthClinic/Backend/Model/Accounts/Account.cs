// File:    Account.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Account

using Backend.Model.Util;
using Model.Util;
using System;

namespace Model.Accounts
{
    public abstract class Account : Entity
    {
        protected String name;
        protected String surname;
        protected String id;
        protected DateTime dateOfBirth;
        protected String contact;
        protected String email;
        protected Address address;

        public string Name { get => name; }
        public string Surname { get => surname; }
        public string FullName { get => name + " " + surname; }
        public string Id { get => id; }
        public DateTime DateOfBirth { get => dateOfBirth; }
        public string Contact { get => contact; }
        public string Email { get => email; }
        public Address Address { get => address; }

        public Account(String serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address) : base(serialNumber)
        {
            this.name = name;
            this.surname = surname;
            this.id = id;
            this.dateOfBirth = dateOfBirth;
            this.contact = contact;
            this.email = email;
            this.address = address;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Account other = obj as Account;

            if(other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}