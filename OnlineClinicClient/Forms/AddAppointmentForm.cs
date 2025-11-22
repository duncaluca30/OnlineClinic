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
    public partial class AddAppointmentForm : Form
    {
        private readonly HttpClient httpClient;

        public AddAppointmentForm(HttpClient client)
        {
            InitializeComponent();
            httpClient = client;
            LoadPatients();
            LoadDoctors();
        }
        private Appointment existingAppointment;

        public AddAppointmentForm(HttpClient client, Appointment appointment) : this(client)
        {
            existingAppointment = appointment;
            PreFillFields();
        }

        private async void LoadPatients()
        {
            try
            {
                var response = await httpClient.GetAsync("/api/patients");
                if (response.IsSuccessStatusCode)
                {
                    var patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
                    patientComboBox.DataSource = patients;
                    patientComboBox.DisplayMember = "Name";
                    patientComboBox.ValueMember = "Id";
                }
                else
                {
                    statusLabel.Text = "Failed to load patients.";
                    statusLabel.ForeColor = Color.DarkRed;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error loading patients.";
                statusLabel.ForeColor = Color.DarkRed;
            }
        }
        private async void LoadDoctors()
        {
            try
            {
                var response = await httpClient.GetAsync("/api/doctors");
                if (response.IsSuccessStatusCode)
                {
                    var doctors = await response.Content.ReadFromJsonAsync<List<Doctor>>();
                    doctorComboBox.DataSource = doctors;
                    doctorComboBox.DisplayMember = "Name";
                    doctorComboBox.ValueMember = "Id";
                }
                else
                {
                    statusLabel.Text = "Failed to load doctors.";
                    statusLabel.ForeColor = Color.DarkRed;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Error loading doctors.";
                statusLabel.ForeColor = Color.DarkRed;
            }
        }
        private async void saveBtn_Click(object sender, EventArgs e)
        {
            if (patientComboBox.SelectedItem == null || doctorComboBox.SelectedItem == null)
            {
                statusLabel.Text = "Please select both patient and doctor.";
                statusLabel.ForeColor = Color.DarkRed;
                return;
            }

            if (!decimal.TryParse(priceTextBox.Text, out var price))
            {
                statusLabel.Text = "Invalid price format.";
                statusLabel.ForeColor = Color.DarkRed;
                return;
            }

            var appointmentDto = new AppointmentDto
            {
                DoctorId = (int)doctorComboBox.SelectedValue,
                PatientId = (int)patientComboBox.SelectedValue,
                AppointmentDate = datePicker.Value.Date + timePicker.Value.TimeOfDay,
                Price = price
            };

            HttpResponseMessage response;
            if (existingAppointment == null)
            {
                // New appointment
                response = await httpClient.PostAsJsonAsync("/api/appointments", appointmentDto);
            }
            else
            {
                // Update existing appointment
                response = await httpClient.PutAsJsonAsync($"/api/appointments/{existingAppointment.Id}", appointmentDto);
            }

            if (response.IsSuccessStatusCode)
            {
                statusLabel.Text = existingAppointment == null
                    ? "Appointment added successfully!"
                    : "Appointment rescheduled successfully!";
                statusLabel.ForeColor = Color.DarkGreen;
                await Task.Delay(2000);
                this.Close();
            }
            else
            {
                statusLabel.Text = "Failed to save appointment.";
                statusLabel.ForeColor = Color.DarkRed;
            }
        }
        private void PreFillFields()
        {
            patientComboBox.SelectedValue = existingAppointment.Patient.Id;
            doctorComboBox.SelectedValue = existingAppointment.Doctor.Id;
            datePicker.Value = existingAppointment.AppointmentDate.Date;
            timePicker.Value = existingAppointment.AppointmentDate;
            priceTextBox.Text = existingAppointment.Price.ToString("F2");
            saveBtn.Text = "Reschedule Appointment";
        }
    }
}
