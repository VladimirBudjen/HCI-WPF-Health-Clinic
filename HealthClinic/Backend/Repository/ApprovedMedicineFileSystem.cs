// File:    ApprovedMedicineFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class ApprovedMedicineFileSystem

using Model.Hospital;
using Newtonsoft.Json;
using System;

namespace Backend.Repository
{
    public class ApprovedMedicineFileSystem : GenericFileSystem<Medicine>, ApprovedMedicineRepository
    {
        public ApprovedMedicineFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/approved_medicine.txt";
            path = @"./../../data/approved_medicine.txt";

        }
        public override Medicine Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Medicine>(objectStringFormat);
        }
    }
}