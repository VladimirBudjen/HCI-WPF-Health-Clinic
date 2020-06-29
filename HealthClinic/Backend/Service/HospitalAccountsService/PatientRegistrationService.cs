// File:    PatientRegistrationService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PatientRegistrationService

using Backend.Dto;
using Backend.Repository;
using Model.Accounts;
using System;
using System.Collections.Generic;

namespace Backend.Service.HospitalAccountsService
{
    public class PatientRegistrationService
    {
        public PatientRepository patientRepository;

        public PatientRegistrationService()
        {
            patientRepository = new PatientFileSystem();
        }

        private bool IsJMBGValid(String jmbg)
        {
            List<Patient> patients = patientRepository.GetAll();
            foreach (Patient p in patients)
            {
                if (p.Id == jmbg)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsGuest(String jmbg)
        {
            List<Patient> patients = patientRepository.GetAll();
            foreach (Patient p in patients)
            {
                if (p.Id.Equals(jmbg))
                {
                    if (p.Guest)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RegisterPatient(PatientDTO patientDTO)
        {
            if (!IsJMBGValid(patientDTO.Id) && IsGuest(patientDTO.Id))
            {
                Patient p = GetExistingPatient(patientDTO.Id);
                if (p == null)
                {
                    return;
                }
                else
                {
                    Patient newPatient = new Patient(patientDTO);
                    newPatient.SerialNumber = p.SerialNumber;
                    patientRepository.Update(newPatient);
                }
            }
            else if (IsJMBGValid(patientDTO.Id))
            {
                patientRepository.Save(new Patient(patientDTO));
            }
            else
            {
                return;
            }
        }

        public Patient GetExistingPatient(String jmbg)
        {
            List<Patient> patients = patientRepository.GetAll();
            foreach (Patient p in patients)
            {
                if (p.Id.Equals(jmbg))
                {
                    return p;
                }
            }
            return null;
        }

        public void DeletePatientAccount(Patient patient)
        {
            patientRepository.Delete(patient.SerialNumber);
        }

    }
}