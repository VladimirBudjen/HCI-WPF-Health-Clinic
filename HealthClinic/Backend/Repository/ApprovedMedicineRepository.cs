// File:    ApprovedMedicineRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ApprovedMedicineRepository

using Model.Hospital;
using System;

namespace Backend.Repository
{
   public interface ApprovedMedicineRepository : GenericRepository<Medicine>
   {
   }
}