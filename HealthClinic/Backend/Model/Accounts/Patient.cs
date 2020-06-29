// File:    Patient.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Patient

using Backend.Dto;
using Model.Util;
using Newtonsoft.Json;
using System;

namespace Model.Accounts
{
    public class Patient : Account
    {

        private String parentName;
        private String gender;
        private bool guest;
        private string password;

        public Patient(string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string parentName, string gender, string password, bool isGuest = false)
            : base(Guid.NewGuid().ToString(), name, surname, id, dateOfBirth, contact, email, address)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
            this.password = password;
        }

        [JsonConstructor]
        public Patient(string serialNumber, string name, string surname, string id, DateTime dateOfBirth, string contact, string email, Address address, string parentName, string gender, string password, bool isGuest = false)
            : base(serialNumber, name, surname, id, dateOfBirth, contact, email, address)
        {
            this.parentName = parentName;
            this.gender = gender;
            this.Guest = isGuest;
            this.password = password;
        }

        public Patient(PatientDTO patientDTO) : base(Guid.NewGuid().ToString(), patientDTO.Name, patientDTO.Surname, patientDTO.Id, patientDTO.DateOfBirth, patientDTO.Contact, patientDTO.Email, patientDTO.Address)
        {
            this.parentName = patientDTO.ParentName;
            this.gender = patientDTO.Gender;
            this.Guest = patientDTO.IsGuest;
            this.password = patientDTO.Password;
            Console.WriteLine(Guest);
        }

        public string ParentName { get => parentName; }
        public string Gender { get => gender; }
        public bool Guest { get => guest; set => guest = value; }
        public string Password { get => password; }

        public override string ToString()
        {
            return base.ToString();
        }

    }

}