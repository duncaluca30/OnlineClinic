using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClinicClient.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }   // nested object from backend
        public Patient Patient { get; set; } // nested object from backend
        public DateTime AppointmentDate { get; set; }
        public decimal Price { get; set; }

    }
}
