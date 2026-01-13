using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineClinicClient.Models
{
    public class AppointmentDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTimeOffset AppointmentDate { get; set; }
        public decimal Price { get; set; }
    }
}
