// File:    RenovationControler.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RenovationControler

using Backend.Dto;
using Backend.Service.HospitalResourcesService;
using HealthClinic.Backend.Model.Hospital;
using Model.Hospital;
using System;
using System.Collections.Generic;

namespace Backend.Controller.SuperintendentControllers
{
   public class RenovationController
   {
      public Renovation GetById(String id)
      {
         throw new NotImplementedException();
      }
      
      public List<Renovation> GetAll()
      {
            return renovationService.GetAll();
      }
      
      public void EditRenovation(Renovation renovation)
      {
            renovationService.EditRenovation(renovation);
      }
      
      public void DeleteRenovation(Renovation renovation)
      {
            renovationService.DeleteRenovation(renovation);
      }
      
      public void NewRenovation(Renovation renovation)
      {
            renovationService.NewRenovation(renovation);
      }
      
      public RenovationService renovationService;

        public RenovationController()
        {
            this.renovationService =new RenovationService();
        }

        public void DeleteRenovationsWithRoom(Room room)
        {
            renovationService.DeleteRenovationsWithRoom(room);
        }
    }
}