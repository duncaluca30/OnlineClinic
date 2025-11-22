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
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:8080")
        };

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

        public async Task LoadPatients()
        {
            var patients = await httpClient.GetFromJsonAsync<List<Patient>>("/api/patients");
            patientsGrid.DataSource = patients;
        }
        public async Task LoadDoctors()
        {
            var doctors = await httpClient.GetFromJsonAsync<List<Doctor>>("/api/doctors");
            doctorsGrid.DataSource = doctors;
        }

        public async Task LoadAppointments()
        {
            var appointments = await httpClient.GetFromJsonAsync<List<Appointment>>("/api/appointments");

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

        private void addPatientBtn_Click(object sender, EventArgs e)
        { 
            var form = new AddPatientForm(this, httpClient);
            form.ShowDialog();
        }

        private async void editPatientBtn_Click(object sender, EventArgs e)
        {
            if (patientsGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to edit.");
                return;
            }

            var selectedPatient = (Patient)patientsGrid.SelectedRows[0].DataBoundItem;
            var form = new AddPatientForm(this, httpClient, selectedPatient);
            form.ShowDialog();
            await LoadPatients(); // refresh after edit
        }

        private async void deletePatientBtn_Click(object sender, EventArgs e)
        {
            if (patientsGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient to delete.");
                return;
            }

            var selectedPatient = (Patient)patientsGrid.SelectedRows[0].DataBoundItem;

            var confirm = MessageBox.Show(
                $"Are you sure you want to delete {selectedPatient.Name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                var response = await httpClient.DeleteAsync($"/api/patients/{selectedPatient.Id}");
                if (response.IsSuccessStatusCode)
                {
                    await ShowStatusMessage("Patient deleted successfully.", Color.DarkGreen);
                    await LoadPatients(); // refresh grid
                }
                else
                {
                    await ShowStatusMessage("Failed to delete patient.", Color.DarkRed);
                }
            }
        }
        private async Task ShowStatusMessage(string message, Color color)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = color;
            await Task.Delay(3000); // show for 3 seconds
            statusLabel.Text = "";
        }
    }
}

