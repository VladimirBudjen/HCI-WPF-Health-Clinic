// File:    ReportFileSystem.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class ReportFileSystem

using Model.Accounts;
using Model.MedicalExam;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class ReportFileSystem : GenericFileSystem<Report>, ReportRepository
    {
        public ReportFileSystem()
        {
            path = @"./../../../../project-generated-code-backend/data/reports.txt";
        }

        public List<Report> GetReportsByPatient(Patient patient)
        {
            List<Report> reports = new List<Report>();
            foreach(Report report in GetAll())
            {
                if(patient.Equals(report.Patient))
                {
                    reports.Add(report);
                }
            }
            return reports;
        }

        public override Report Instantiate(string objectStringFormat)
        {
            return JsonConvert.DeserializeObject<Report>(objectStringFormat);
        }
    }
}