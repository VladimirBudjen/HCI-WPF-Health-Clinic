// File:    RenovationService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RenovationService

using Backend.Dto;
using Backend.Repository;
using HealthClinic.Backend.Model.Hospital;
using Backend.Repository;
using Model.Hospital;
using System;
using System.Collections.Generic;

namespace Backend.Service.HospitalResourcesService
{
    public class RenovationService
    {
        public Renovation GetById(String id)
        {
            throw new NotImplementedException();
        }

        public List<Renovation> GetAll()
        {
            return renovationRepository.GetAll();
        }

        public void EditRenovation(Renovation renovation)
        {
            renovationRepository.Update(renovation);
        }

        public void DeleteRenovation(Renovation renovation)
        {
            renovationRepository.Delete(renovation.SerialNumber);
        }

        public void NewRenovation(Renovation renovation)
        {
            renovationRepository.Save(renovation);
        }

        public RenovationRepository renovationRepository;

        public RenovationService()
        {
            renovationRepository = new RenovationFileSystem();
        }

        public void DeleteRenovationsWithRoom(Room room)
        {
           foreach (Renovation r in renovationRepository.GetAll())
            {
                if (r.Room.SerialNumber.Equals(room.SerialNumber))
                {
                    renovationRepository.Delete(r.SerialNumber);
                }
            }
            
        }
    }
}