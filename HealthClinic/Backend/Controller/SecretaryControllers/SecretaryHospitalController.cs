// File:    SecretaryHospitalController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryHospitalController

using Model.Accounts;
using Backend.Service.HospitalAccountsService;
using System;
using System.Collections.Generic;
using Model.Util;
using Backend.Service.HospitalResourcesService;
using Model.Hospital;
using Model.Schedule;
using Backend.Controller.PhysitianControllers;
using HealthClinic.Backend.Service.HospitalAccountsService;
using health_clinic_class_diagram.Backend.Service.HospitalAccountsService;

namespace Backend.Controller.SecretaryControllers
{
    public class SecretaryHospitalController
    {
        public HospitalService hospitalService;
        public RoomService roomService;
        public PhysicianAccountService physicianService;
        public PatientAccountsService patientAccountsService;

        public SecretaryHospitalController()
        {
            hospitalService = new HospitalService();
            roomService = new RoomService();
            physicianService = new PhysicianAccountService();
            patientAccountsService = new PatientAccountsService();
        }

        public List<Patient> GetAllPatients()
        {
            return patientAccountsService.getAllPatients();
        }

        public List<Physitian> GetAllPhysitians()
        {
            return physicianService.GetAllPhysitians();
        }

        public List<Room> GetAllRooms()
        {
            return roomService.GetAll();
        }

        internal List<Country> GetAllCountries()
        {
            return hospitalService.getAllCountries();
        }

        internal List<ProcedureType> GetAllProcedureTypes()
        {
            return hospitalService.GetAllProcedureTypes();
        }
    }
}