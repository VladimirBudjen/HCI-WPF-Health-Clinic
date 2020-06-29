// File:    HospitalService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class HospitalService

using Backend.Repository;
using HCI_SIMS_PROJEKAT.Backend.Repository;
using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using Model.Util;
using System;
using System.Collections.Generic;

namespace Backend.Service.HospitalAccountsService
{
    //TODO: REFAKTORISATI samo geteri za country, procedure type, room type... (stvari koje idu u CB)
    // Dodati PhysitianAccountsService i SecretaryAccountsService 
    public class HospitalService
    {
        private PatientRepository patientRepository;
        private CountryRepository countryRepository;
        private ProcedureTypeRepository procedureTypeRepository;
        private DiagnosticTypeRepository diagnosticTypeRepository;

        public HospitalService()
        {
            this.patientRepository = new PatientFileSystem();
            this.countryRepository = new CountryFileSystem();
            this.procedureTypeRepository = new ProcedureTypeFileSystem();
            this.diagnosticTypeRepository = new DiagnosticTypeFileSystem();
        }

        internal List<ProcedureType> GetAllProcedureTypes()
        {
            return procedureTypeRepository.GetAll();
        }

        internal List<Country> getAllCountries()
        {
            return countryRepository.GetAll();
        }

        public List<ProcedureType> GetProcedureTypes()
        {
            return procedureTypeRepository.GetAll();
        }

        public List<DiagnosticType> GetDiagnosticTypes()
        {
            return diagnosticTypeRepository.GetAll();
        }
    }
}