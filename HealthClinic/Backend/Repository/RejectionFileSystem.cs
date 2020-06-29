// File:    RejectionFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RejectionFileSystem

using Model.Hospital;
using Newtonsoft.Json;
using System;

namespace Backend.Repository
{
    public class RejectionFileSystem : GenericFileSystem<Rejection>, RejectionRepository
    {
        public RejectionFileSystem()
        {
            //path = @"./../../../../project-generated-code-backend/data/rejections.txt";
            path = @"./../../data/rejections.txt";
        }
        public override Rejection Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Rejection>(objectStringFormat);
        }
    }
}