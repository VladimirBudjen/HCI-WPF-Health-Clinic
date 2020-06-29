// File:    EquipmentService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class EquipmentService

using Backend.Repository;
using Model.Hospital;
using System;
using System.Collections.Generic;

namespace Backend.Service.HospitalResourcesService
{
    public class EquipmentService
    {
        public Equipment GetById()
        {
            throw new NotImplementedException();
        }

        public List<Equipment> GetAll()
        {
            return equipmentRepository.GetAll();
        }

        public void EditEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public void NewEquipment(Equipment equipment)
        {
            equipmentRepository.Save(equipment);
        }

        public void DeleteEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public EquipmentService()
        {
            equipmentRepository = new EquipmentFileSystem();
        }
        public Backend.Repository.EquipmentRepository equipmentRepository;


    }
}