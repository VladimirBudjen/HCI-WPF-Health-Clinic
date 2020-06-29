// File:    SecretaryFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class SecretaryFileSystem

using Model.Accounts;
using Newtonsoft.Json;
using System;

namespace Backend.Repository
{
    public class SecretaryFileSystem : GenericFileSystem<Secretary>, SecretaryRepository
    {
        public SecretaryFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/secretaries.txt";
            path = @"./../../data/secretaries.txt";

        }
        public override Secretary Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Secretary>(objectStringFormat);
        }
    }
}