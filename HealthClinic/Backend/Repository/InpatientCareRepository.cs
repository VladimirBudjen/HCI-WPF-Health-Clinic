// File:    InpatientCareRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface InpatientCareRepository

using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
   public interface InpatientCareRepository : GenericRepository<InpatientCare>
   {
        List<InpatientCare> GetInpatientCaresForPatient(Patient patient);

    }
}