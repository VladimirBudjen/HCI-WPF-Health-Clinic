// File:    ReportRepository.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Interface ReportRepository

using Model.Accounts;
using Model.MedicalExam;
using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface ReportRepository : GenericRepository<Report>
    {
        List<Report> GetReportsByPatient(Patient patient);
    }
}