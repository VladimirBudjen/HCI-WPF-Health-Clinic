// File:    PatientDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientDTO

using Model.Util;
using System;

namespace Backend.Dto
{
    public class PatientDTO
    {
        private String name;
        private String surname;
        private String id;
        private DateTime dateOfBirth;
        private String contact;
        private String parentName;
        private String gender;
        private bool isGuest;
        private String email;
        private Address address;
        private string password;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Id { get => id; set => id = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Contact { get => contact; set => contact = value; }
        public string ParentName { get => parentName; set => parentName = value; }
        public string Gender { get => gender; set => gender = value; }
        public bool IsGuest { get => isGuest; set => isGuest = value; }
        public string Email { get => email; set => email = value; }
        public Address Address { get => address; set => address = value; }
        public string Password { get => password; set => password = value; }
    }
}