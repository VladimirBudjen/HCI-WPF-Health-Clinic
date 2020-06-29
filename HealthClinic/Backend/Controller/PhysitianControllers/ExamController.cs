// File:    ExamController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class ExamController

using Backend.Service.PatientCareService;
using Backend.Service.PatientCareService;
using Model.Accounts;
using Model.MedicalExam;
using Model.Schedule;
using System;

namespace Backend.Controller.PhysitianControllers
{
    public class ExamController
    {
        private Physitian loggedPhysitian;
        private Patient selectedPatient;
        private Report currentReport;

        private ReportService reportService;

        public ExamController(Appointment appointment)
        {
            this.loggedPhysitian = appointment.Physitian;
            this.SelectedPatient = appointment.Patient;
            ProcedureType procedure = appointment.ProcedureType;

            reportService = new ReportService();

            String patientConditions = this.GetPatientConditions();
            this.CurrentReport = new Report(DateTime.Today, "", selectedPatient, loggedPhysitian, patientConditions);
        }

        public void SaveReport()
        {
            reportService.NewReport(currentReport);
        }

        public void AddDocument(AdditionalDocument additionalDocument)
        {
            currentReport.AddAdditionalDocument(additionalDocument);
        }

        private String GetPatientConditions()
        {
            Report lastReport = reportService.GetLastReportByPatient(selectedPatient);

            if (lastReport != null)
            {
                return lastReport.PatientConditions;
            }

            return "";
        }

        public Report CurrentReport { get => currentReport; set => currentReport = value; }
        public Patient SelectedPatient { get => selectedPatient; set => selectedPatient = value; }

    }
}