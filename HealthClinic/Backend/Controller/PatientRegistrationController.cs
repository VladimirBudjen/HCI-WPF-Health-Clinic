// File:    PatientRegistrationController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientRegistrationController

using Backend.Dto;
using Backend.Service.HospitalAccountsService;
using Model.Accounts;
using System;

namespace Backend.Controller
{
    public class PatientRegistrationController
    {
        public PatientRegistrationService patientRegistrationService;

        public PatientRegistrationController()
        {
            patientRegistrationService = new PatientRegistrationService();
        }

        public void RegisterPatient(PatientDTO patientDTO)
        {
            patientRegistrationService.RegisterPatient(patientDTO);
        }

        public void DeletePatientAccount(Patient patient)
        {
            patientRegistrationService.DeletePatientAccount(patient);
        }

    }
}