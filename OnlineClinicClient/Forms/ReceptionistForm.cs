using OnlineClinicClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineClinicClient.Forms
{
    public partial class ReceptionistForm : Form
    {
        private readonly User _loggedInUser;

        public ReceptionistForm(User user)
        {
            InitializeComponent();
            this.Load += ReceptionistForm_Load;
        }
        private async void ReceptionistForm_Load(object sender, EventArgs e)
        {
            await LoadPatients();
            await LoadDoctors();
            await LoadAppointments();
        }

        private async Task LoadPatients()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080");
                var patients = await client.GetFromJsonAsync<List<Patient>>("/patients");
                patientsGrid.DataSource = patients;
            }
        }
        private async Task LoadDoctors()
        {
            using (HttpClient client = new HttpClient())
            {
                var doctors = await client.GetFromJsonAsync<List<Doctor>>("/doctors");
                doctorsGrid.DataSource = doctors;
            }
        }

        private async Task LoadAppointments()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080");
                var appointments = await client.GetFromJsonAsync<List<Appointment>>("/appointments");

                var appointmentView = appointments.Select(a => new
                {
                    AppointmentId = a.Id,
                    PatientName = a.Patient.Name,
                    DoctorName = a.Doctor.Name,
                    Date = a.AppointmentDate,
                    Price = a.Price
                }).ToList();

                appointmentsGrid.DataSource = appointmentView;
            }
        }

    }
}

