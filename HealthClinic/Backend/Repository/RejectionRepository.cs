// File:    RejectionRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface RejectionRepository

using Model.Hospital;
using System;

namespace Backend.Repository
{
   public interface RejectionRepository : GenericRepository<Rejection>
   {
   }
}