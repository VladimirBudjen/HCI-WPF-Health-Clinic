// File:    FollowUp.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class FollowUp

using Model.Accounts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.MedicalExam
{
    public class FollowUp : AdditionalDocument
    {
        private Physitian physitian;
        public Physitian Physitian { get => physitian; }

        public FollowUp(DateTime date, string notes, Physitian physitian) : base(Guid.NewGuid().ToString(), date, notes)
        {
            this.physitian = physitian;
        }

        [JsonConstructor]
        public FollowUp(String serialNumber, DateTime date, string notes, Physitian physitian) : base(serialNumber, date, notes)
        {
            this.physitian = physitian;
        }

        public override bool Equals(object obj)
        {
            FollowUp other = obj as FollowUp;
            if(other == null)
            {
                return false;
            }
            return base.Equals(obj) && this.Physitian.Equals(other.Physitian);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + "\nphysitian: " + this.Physitian.FullName; 
        }
    }
}