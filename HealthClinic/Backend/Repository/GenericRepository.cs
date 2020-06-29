// File:    GenericRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface GenericRepository

using Backend.Model.Util;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface GenericRepository<T> where T : Entity
    {
        List<T> GetAll();

        void Save(T newEntity);

        void Update(T updateEntity);

        void Delete(String id);

        T GetById(String id);

        T Instantiate(string objectStringFormat);
    }
}