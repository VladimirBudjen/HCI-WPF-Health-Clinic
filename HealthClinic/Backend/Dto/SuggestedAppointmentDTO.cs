using Model.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Dto
{
    public class SuggestedAppointmentDTO
    {
        private DateTime date_start;
        private DateTime date_end;
        private Physitian physitian;
        private Patient patient;
        private bool prior;

        public Physitian Physitian { get => physitian; set => physitian = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public DateTime Date_start { get => date_start; set => date_start = value; }
        public DateTime Date_end { get => date_end; set => date_end = value; }
        public bool Prior { get => prior; set => prior = value; }
    }
}
