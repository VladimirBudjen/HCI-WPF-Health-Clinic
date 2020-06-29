// File:    PhysitianRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface PhysitianRepository

using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
   public interface PhysitianRepository : GenericRepository<Physitian>
   {
        List<Physitian> GetPhysitiansByProcedureType(ProcedureType procedureType);

    }
}