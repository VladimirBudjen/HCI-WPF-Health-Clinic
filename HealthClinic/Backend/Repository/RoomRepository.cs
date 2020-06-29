// File:    RoomRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface RoomRepository

using Model.Hospital;
using Model.Schedule;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface RoomRepository : GenericRepository<Room>
    {
        List<Room> GetRoomsByProcedureType(ProcedureType procedureType);
        List<Room> GetRoomsByRoomType(RoomType roomType);
    }
}