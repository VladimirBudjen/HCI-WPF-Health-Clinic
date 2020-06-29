using Backend.Repository;
using Model.Accounts;
using Model.MedicalExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Service.PatientCareService
{
    class ReportService
    {
        private ReportRepository reportRepository;

        public ReportService()
        {
            this.reportRepository = new ReportFileSystem();
        }

        public List<Report> GetReportsByPatient(Patient patient)
        {
            return reportRepository.GetReportsByPatient(patient);
        }

        public Report GetLastReportByPatient(Patient patient)
        {
            List<Report> reports = reportRepository.GetReportsByPatient(patient);
            if(reports.Count > 0)
            {
                reports.Sort((a, b) => b.CompareTo(a));
                return reports[0];
            }
            return null;
        }

        public void NewReport(Report report)
        {
            reportRepository.Save(report);
        }
    }
}
