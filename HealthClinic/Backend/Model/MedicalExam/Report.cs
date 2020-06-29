// File:    Report.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Report

using Backend.Model.Util;
using Model.Accounts;
using Model.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.MedicalExam
{
    public class Report : Entity
    {
        private DateTime date;
        private String findings;
        private Patient patient;
        private Physitian physitian;
        private String patientConditions;
        private ProcedureType procedureType;

        private List<AdditionalDocument> additionalDocument;

        public List<AdditionalDocument> AdditionalDocument
        {
            get
            {
                if (additionalDocument == null)
                    additionalDocument = new List<AdditionalDocument>();
                return additionalDocument;
            }
            set
            {
                RemoveAllAdditionalDocument();
                if (value != null)
                {
                    foreach (AdditionalDocument oAdditionalDocument in value)
                        AddAdditionalDocument(oAdditionalDocument);
                }
            }
        }

        public DateTime Date { get => date; }
        public string Findings { get => findings; set => findings = value; }
        public Patient Patient { get => patient; }
        public Physitian Physitian { get => physitian; }
        public string PatientConditions { get => patientConditions; set => patientConditions = value; }
        public ProcedureType ProcedureType { get => procedureType; }

        public void AddAdditionalDocument(AdditionalDocument newAdditionalDocument)
        {
            if (newAdditionalDocument == null)
                return;
            if (this.additionalDocument == null)
                this.additionalDocument = new List<AdditionalDocument>();
            if (!this.additionalDocument.Contains(newAdditionalDocument))
                this.additionalDocument.Add(newAdditionalDocument);
        }

        public void RemoveAdditionalDocument(AdditionalDocument oldAdditionalDocument)
        {
            if (oldAdditionalDocument == null)
                return;
            if (this.additionalDocument != null)
                if (this.additionalDocument.Contains(oldAdditionalDocument))
                    this.additionalDocument.Remove(oldAdditionalDocument);
        }

        public void RemoveAllAdditionalDocument()
        {
            if (additionalDocument != null)
                additionalDocument.Clear();
        }

        public Report(DateTime date, string findings, Patient patient, Physitian physitian, string patientConditions) : base(Guid.NewGuid().ToString())
        {
            this.date = date;
            this.findings = findings;
            this.patient = patient;
            this.physitian = physitian;
            this.patientConditions = patientConditions;
        }

        [JsonConstructor]
        public Report(String serialNumber, DateTime date, string findings, Patient patient, Physitian physitian, string patientConditions) : base(serialNumber)
        {
            this.date = date;
            this.findings = findings;
            this.patient = patient;
            this.physitian = physitian;
            this.patientConditions = patientConditions;
        }

        public override bool Equals(object obj)
        {
            Report other = obj as Report;
            if(other == null)
            {
                return false;
            }
            if(this.additionalDocument.Count != other.additionalDocument.Count)
            {
                return false;
            }
            foreach(AdditionalDocument doc in additionalDocument)
            {
                if(!other.additionalDocument.Contains(doc))
                {
                    return false;
                }
            }
            return this.Date.Equals(other.Date) && this.Findings.Equals(other.Findings);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string ret = "date: " + this.date.ToString("dd.MM.yyyy.") + "\nfindings: " + this.findings;
            foreach(AdditionalDocument doc in this.additionalDocument)
            {
                ret += "\ndocument: " + doc.ToString();
            }
            return ret;
        }
        public int CompareTo(Report other)
        {
            return this.Date.CompareTo(other.Date);
        }
    }
}