using Backend.Repository;
using Model.Accounts;
using Model.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace health_clinic_class_diagram.Backend.Service.HospitalAccountsService
{
    public class PatientAccountsService
    {
        private PatientRepository patientRepository;
        private AppointmentRepository appointmentRepository;
        private ReportRepository reportRepository;

        public PatientAccountsService()
        {
            this.patientRepository = new PatientFileSystem();
            this.appointmentRepository = new AppointmentFileSystem();
            this.reportRepository = new ReportFileSystem();
        }

        public List<Patient> getAllPatients()
        {
            return patientRepository.GetAll();
        }
        public List<Patient> getPatientsForPhysitian(Physitian physitian)
        {
            List<Patient> allPatients = patientRepository.GetAll();
            List<Patient> patients = new List<Patient>();
            foreach (Patient patient in allPatients)
            {
                if (IsPatientScheduledForPhysitian(patient, physitian))
                {
                    patients.Add(patient);
                }
            }
            return patients;
        }

        private bool IsPatientScheduledForPhysitian(Patient patient, Physitian physitian)
        {
            List<Appointment> patientAppointments = appointmentRepository.GetAppointmentsByPatient(patient);
            foreach (Appointment appointment in patientAppointments)
            {
                if (appointment.Physitian.Equals(physitian))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
