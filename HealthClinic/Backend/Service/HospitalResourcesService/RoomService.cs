// File:    RoomService.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RoomService

using Backend.Repository;
using HealthClinic.Backend.Model.Hospital;
using Backend.Repository;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using HCI_SIMS_PROJEKAT.Backend.Repository;
using HealthClinic.Backend.Repository;

namespace Backend.Service.HospitalResourcesService
{
    public class RoomService
    {

        public Room GetById(String id)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAll()
        {
            return  roomRepository.GetAll();
        }

        public void EditRoom(Room room)
        {
            roomRepository.Update(room);
        }

        public void NewRoom(Room room)
        {
            roomRepository.Save(room);
        }

        public void DeleteRoom(Room room)
        {
            roomRepository.Delete(room.SerialNumber);
        }

        public void AddEquipment(Equipment equipment, Room room)
        {
            room.AddEquipment(equipment);
            roomRepository.Update(room);
        }

        public void RemoveEquipmentById(String id, Room room)
        {
           
            foreach(Equipment e in room.Equipment.ToList())
            {
                if (e.SerialNumber.Equals(id))
                {
                    room.RemoveEquipment(e);
                }
            }
            roomRepository.Update(room);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return roomTypeRepository.GetAll();
        }

        public List<RoomType> GetAutoAllRoomTypes()
        {
            List<RoomType> types = new List<RoomType>();
            types.AddRange(roomTypeRepository.GetAll());
            types.AddRange(roomBedTypeRepository.GetAll());
            return types;
        }

        public List<RoomBedType> GetBedRoomTypes()
        {
            return roomBedTypeRepository.GetAll();
        }

        public void AddRoomType(RoomType roomType)
        {
            roomTypeRepository.Save(roomType);
        }

        internal void AddRoomBedType(RoomBedType roomType)
        {
            roomBedTypeRepository.Save(roomType);
        }


        public bool RoomNumberExists(int RoomNumber)
        {
            bool exists = false;
            foreach (Room r in roomRepository.GetAll())
            {
                if (r.Id == RoomNumber)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public List<Equipment> GetAllEquipment(Room room)
        {
            return roomRepository.GetById(room.SerialNumber).Equipment;
        }


        private Backend.Repository.RoomRepository roomRepository;
        private RoomTypeRepository roomTypeRepository;
        private RoomBedTypeRepository roomBedTypeRepository;


        public RoomService()
        {
            roomTypeRepository = new RoomTypeFileSystem();
            roomRepository = new RoomFileSystem();
            roomBedTypeRepository = new RoomBedTypeFileSystem();
        }
    }
}