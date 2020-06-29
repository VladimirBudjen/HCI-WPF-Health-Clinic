// File:    RejectedMedicineDTO.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class RejectedMedicineDTO

using Model.Hospital;
using System;

namespace Backend.Dto
{
    public class RejectedMedicineDTO
    {
        private string reason;
        private Medicine medicine;

        public string Reason { get => reason; set => reason = value; }
        public Medicine Medicine { get => medicine; set => medicine = value; }
    }
}