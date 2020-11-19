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
        private DateTime dateStart;
        private DateTime dateEnd;
        private Physitian physitian;
        private Patient patient;
        private bool prior;

        public Physitian Physitian { get => physitian; set => physitian = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public DateTime DateStart { get => dateStart; set => dateStart = value; }
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }
        public bool Prior { get => prior; set => prior = value; }
    }
}
