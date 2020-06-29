// File:    PhysitianFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class PhysitianFileSystem

using Model.Accounts;
using Model.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class PhysitianFileSystem : GenericFileSystem<Physitian>, PhysitianRepository
    {
        public PhysitianFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/physitians.txt";
            path = @"./../../data/physitians.txt";

        }

        public List<Physitian> GetPhysitiansByProcedureType(ProcedureType procedureType)
        {
            List<Physitian> physitians = new List<Physitian>();
            foreach (Physitian physitian in GetAll())
            {
                if (physitian.Specialization.Contains(procedureType.Specialization))
                {
                    physitians.Add(physitian);
                }
            }
            return physitians;
        }

        public override Physitian Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Physitian>(objectStringFormat);
        }
    }
}