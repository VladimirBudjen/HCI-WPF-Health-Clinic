// File:    WaitingMedicineRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface WaitingMedicineRepository

using Model.Hospital;
using System;

namespace Backend.Repository
{
   public interface WaitingMedicineRepository : GenericRepository<Medicine>
   {
   }
}