// File:    InpatientCareFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class InpatientCareFileSystem

using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class InpatientCareFileSystem : GenericFileSystem<InpatientCare>, InpatientCareRepository
    {
        public InpatientCareFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/inpatient_care.txt";
        }
        public List<InpatientCare> GetInpatientCaresForPatient(Patient patient)
        {
            List<InpatientCare> inpatientCares = new List<InpatientCare>();
            foreach (InpatientCare inpatientCare in GetAll())
            {
                if (patient.Equals(inpatientCare.Patient))
                {
                    inpatientCares.Add(inpatientCare);
                }
            }
            return inpatientCares;
        }

        public override InpatientCare Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<InpatientCare>(objectStringFormat);
        }
    }
}