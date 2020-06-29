// File:    InpatientCareController.cs
// Author:  Luka Doric
// Created: Sunday, June 7, 2020 4:19:02 PM
// Purpose: Definition of Class InpatientCareController

using Backend.Dto;
using Backend.Service.PatientCareService;
using Model.Accounts;
using Model.Hospital;
using Model.MedicalExam;
using System;
using System.Collections.Generic;

namespace Backend.Controller.PhysitianControllers
{
    public class InpatientCareController
    {
        private Physitian loggedPhysitian;
        private InpatientCareService inpatientCareService;

        public InpatientCareController(Physitian loggedPhysitian)
        {
            this.loggedPhysitian = loggedPhysitian;
            this.inpatientCareService = new InpatientCareService(loggedPhysitian);
        }

        public void StartInpatientCare(BedReservationDTO bedReservationDTO)
        {
            inpatientCareService.StartInpatientCare(bedReservationDTO);
        }

        public void DischargeParient(Patient patient)
        {
            inpatientCareService.DischargeParient(patient);
        }

        public BedReservation getActiveInpatientCare(Patient patient)
        {
            return inpatientCareService.GetActiveBedReservation(patient);
        }
        public List<InpatientCare> getPreviousInpatientCares(Patient patient)
        {
            return inpatientCareService.GetAllInpatientCares(patient);
        }

        public List<Room> GetAvailableRooms()
        {
            return inpatientCareService.GetAvailableRooms();
        }
        public List<Bed> GetAvailableBeds(Room room)
        {
            return inpatientCareService.GetAvailableBeds(room);
        }

    }
}