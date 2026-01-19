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
    public partial class AdminForm : Form
    {
        private readonly User _loggedInUser;
        private readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:8080")
        };

        public AdminForm(User user)
        {
            InitializeComponent();
            _loggedInUser = user;
            this.Load += AdminForm_Load;

            // Wire up logout button if not done in designer
            logoutBtn.Click += (s, e) => this.Close();
        }

        private async void AdminForm_Load(object sender, EventArgs e)
        {
            await LoadPatients();
            await LoadDoctors();
            await LoadAppointments();
            await LoadUsers(); // New: Load Users for the 4th tab
        }

        // ==========================================================
        // DATA LOADING METHODS
        // ==========================================================
        public async Task LoadPatients()
        {
            try
            {
                var patients = await httpClient.GetFromJsonAsync<List<Patient>>("/api/patients");
                patientsGrid.DataSource = patients;
            }
            catch (Exception ex) { Console.WriteLine("Error loading patients: " + ex.Message); }
        }

        public async Task LoadDoctors()
        {
            try
            {
                var doctors = await httpClient.GetFromJsonAsync<List<Doctor>>("/api/doctors");
                doctorsGrid.DataSource = doctors;
            }
            catch (Exception ex) { Console.WriteLine("Error loading doctors: " + ex.Message); }
        }

        public async Task LoadAppointments()
        {
            try
            {
                var appointments = await httpClient.GetFromJsonAsync<List<Appointment>>("/api/appointments");
                appointmentsGrid.DataSource = appointments;
            }
            catch (Exception ex) { Console.WriteLine("Error loading appointments: " + ex.Message); }
        }

        public async Task LoadUsers()
        {
            try
            {
                // NOTE: You need a GET /api/users endpoint in your Java backend for this to work.
                // If you don't have it yet, this will fail silently due to try-catch.
                var users = await httpClient.GetFromJsonAsync<List<User>>("/api/users");
                usersGrid.DataSource = users;
            }
            catch (Exception ex) { Console.WriteLine("Error loading users (Endpoint might be missing): " + ex.Message); }
        }

        // ==========================================================
        // TAB 1: PATIENT LOGIC
        // ==========================================================
        private void addPatientBtn_Click(object sender, EventArgs e)
        {
            var form = new AddPatientForm(this, httpClient);
            form.ShowDialog();
        }

        private async void editPatientBtn_Click(object sender, EventArgs e)
        {
            if (patientsGrid.SelectedRows.Count == 0) { MessageBox.Show("Please select a patient to edit."); return; }
            var selectedPatient = (Patient)patientsGrid.SelectedRows[0].DataBoundItem;

            var form = new AddPatientForm(this, httpClient, selectedPatient);
            form.ShowDialog();
            await LoadPatients();
        }

        private async void deletePatientBtn_Click(object sender, EventArgs e)
        {
            if (patientsGrid.SelectedRows.Count == 0) { MessageBox.Show("Please select a patient to delete."); return; }
            var selectedPatient = (Patient)patientsGrid.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Delete {selectedPatient.Name}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var response = await httpClient.DeleteAsync($"/api/patients/{selectedPatient.Id}");
                if (response.IsSuccessStatusCode) { await ShowStatusMessage("Patient deleted.", Color.DarkGreen); await LoadPatients(); }
                else await ShowStatusMessage("Failed to delete patient.", Color.DarkRed);
            }
        }

        // ==========================================================
        // TAB 2: APPOINTMENT LOGIC
        // ==========================================================
        private async void addAppointmentBtn_Click(object sender, EventArgs e)
        {
            var form = new AddAppointmentForm(httpClient);
            form.ShowDialog();
            await LoadAppointments();
        }

        private async void rescheduleBtn_Click(object sender, EventArgs e)
        {
            if (appointmentsGrid.SelectedRows.Count == 0) { MessageBox.Show("Select an appointment first."); return; }
            var selectedApp = (Appointment)appointmentsGrid.SelectedRows[0].DataBoundItem;

            var form = new AddAppointmentForm(httpClient, selectedApp);
            form.ShowDialog();
            await LoadAppointments();
        }

        private async void cancelAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (appointmentsGrid.SelectedRows.Count == 0) { MessageBox.Show("Select an appointment first."); return; }
            var selectedApp = (Appointment)appointmentsGrid.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show("Cancel this appointment?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var response = await httpClient.DeleteAsync($"/api/appointments/{selectedApp.Id}");
                if (response.IsSuccessStatusCode) { await ShowStatusMessage("Appointment cancelled.", Color.DarkGreen); await LoadAppointments(); }
                else await ShowStatusMessage("Failed to cancel.", Color.DarkRed);
            }
        }

        // ==========================================================
        // TAB 3: DOCTOR LOGIC (NEW)
        // ==========================================================
        private async void addDoctorBtn_Click(object sender, EventArgs e)
        {
            var form = new AddDoctorForm(httpClient); // Opens the blank form we made
            form.ShowDialog();
            await LoadDoctors(); // Refresh list after adding
        }

        private async void editDoctorBtn_Click(object sender, EventArgs e)
        {
            if (doctorsGrid.SelectedRows.Count == 0) { MessageBox.Show("Select a doctor to edit."); return; }

            var selectedDoctor = (Doctor)doctorsGrid.SelectedRows[0].DataBoundItem;

            var form = new AddDoctorForm(httpClient, selectedDoctor); // Pass doctor to edit
            form.ShowDialog();
            await LoadDoctors();
        }

        private async void deleteDoctorBtn_Click(object sender, EventArgs e)
        {
            if (doctorsGrid.SelectedRows.Count == 0) { MessageBox.Show("Select a doctor to delete."); return; }
            var selectedDoctor = (Doctor)doctorsGrid.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Delete Dr. {selectedDoctor.Name}?\nWarning: This may delete their future appointments!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var response = await httpClient.DeleteAsync($"/api/doctors/{selectedDoctor.Id}");
                if (response.IsSuccessStatusCode) { await ShowStatusMessage("Doctor deleted.", Color.DarkGreen); await LoadDoctors(); }
                else await ShowStatusMessage("Failed to delete doctor.", Color.DarkRed);
            }
        }

        private async void addUserBtn_Click(object sender, EventArgs e)
        {
            // Create the Add User popup
            var form = new AddUserForm(httpClient);

            // Show it to the admin
            form.ShowDialog();

            // Refresh the list so the new user appears immediately
            await LoadUsers();
        }
        private async void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) { MessageBox.Show("Select a user to delete."); return; }
            var selectedUser = (User)usersGrid.SelectedRows[0].DataBoundItem;

            // Prevent deleting yourself!
            if (selectedUser.Username == _loggedInUser.Username)
            {
                MessageBox.Show("You cannot delete your own admin account while logged in!");
                return;
            }

            if (MessageBox.Show($"Delete user {selectedUser.Username}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var response = await httpClient.DeleteAsync($"/api/users/{selectedUser.Id}");
                if (response.IsSuccessStatusCode) { await ShowStatusMessage("User deleted.", Color.DarkGreen); await LoadUsers(); }
                else await ShowStatusMessage("Failed to delete user.", Color.DarkRed);
            }
        }

        // ==========================================================
        // HELPERS
        // ==========================================================
        private async Task ShowStatusMessage(string message, Color color)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = color;
            await Task.Delay(3000);
            statusLabel.Text = "";
        }
    }
}