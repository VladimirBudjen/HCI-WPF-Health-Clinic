// File:    PatientRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PatientRepository

using Model.Accounts;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
   public interface PatientRepository : GenericRepository<Patient>
   {
      List<Patient> GetPatientsByPhysitian(Physitian physitian);
   
   }
}