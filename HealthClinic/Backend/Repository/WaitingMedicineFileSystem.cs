// File:    WaitingMedicineFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class WaitingMedicineFileSystem

using Model.Hospital;
using Newtonsoft.Json;
using System;

namespace Backend.Repository
{
    public class WaitingMedicineFileSystem : GenericFileSystem<Medicine>, WaitingMedicineRepository
    {
        public WaitingMedicineFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/waiting_medicine.txt";
            path = @"./../../data/waiting_medicine.txt";

        }
        public override Medicine Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Medicine>(objectStringFormat);
        }
    }
}