using OnlineClinicClient.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace OnlineClinicClient.Forms
{
    public partial class AddPatientForm : Form
    {
        // We need references to BOTH types of potential parents
        private readonly ReceptionistForm _receptionistParent;
        private readonly AdminForm _adminParent;

        private readonly HttpClient httpClient;
        private Patient editingPatient;

        // --- CONSTRUCTOR 1: Called by Receptionist ---
        public AddPatientForm(ReceptionistForm parent, HttpClient client, Patient patientToEdit = null)
        {
            InitializeComponent();
            _receptionistParent = parent; // Set Receptionist
            _adminParent = null;          // Admin is null

            httpClient = client;
            SetupForm(patientToEdit);
        }

        // --- CONSTRUCTOR 2: Called by Admin (NEW) ---
        public AddPatientForm(AdminForm parent, HttpClient client, Patient patientToEdit = null)
        {
            InitializeComponent();
            _adminParent = parent;        // Set Admin
            _receptionistParent = null;   // Receptionist is null

            httpClient = client;
            SetupForm(patientToEdit);
        }

        // Shared setup logic to avoid code duplication
        private void SetupForm(Patient patientToEdit)
        {
            editingPatient = patientToEdit;
            if (editingPatient != null)
            {
                this.Text = "Edit Patient";
                nameTextBox.Text = editingPatient.Name;
                emailTextBox.Text = editingPatient.Email;
                phoneTextBox.Text = editingPatient.Phone;
                dobPicker.Value = editingPatient.DateOfBirth;
            }
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (editingPatient == null)
            {
                // --- CREATE ---
                var newPatient = new Patient
                {
                    Name = nameTextBox.Text,
                    Email = emailTextBox.Text,
                    Phone = phoneTextBox.Text,
                    DateOfBirth = dobPicker.Value.Date
                };

                var response = await httpClient.PostAsJsonAsync("/api/patients", newPatient);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Patient added successfully!");
                    await RefreshParent(); // Helper method to refresh whoever opened us
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add patient.");
                }
            }
            else
            {
                // --- EDIT ---
                editingPatient.Name = nameTextBox.Text;
                editingPatient.Email = emailTextBox.Text;
                editingPatient.Phone = phoneTextBox.Text;
                editingPatient.DateOfBirth = dobPicker.Value;

                var response = await httpClient.PutAsJsonAsync($"/api/patients/{editingPatient.Id}", editingPatient);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Patient updated successfully!");
                    await RefreshParent(); // Helper method
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update patient.");
                }
            }
        }

        // Helper to refresh the correct parent form
        private async System.Threading.Tasks.Task RefreshParent()
        {
            if (_receptionistParent != null)
            {
                await _receptionistParent.LoadPatients();
            }
            else if (_adminParent != null)
            {
                await _adminParent.LoadPatients();
            }
        }

        private void AddPatientForm_Load(object sender, EventArgs e) { }
    }
}