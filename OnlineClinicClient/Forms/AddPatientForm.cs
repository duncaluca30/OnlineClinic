using OnlineClinicClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;

namespace OnlineClinicClient.Forms
{
    public partial class AddPatientForm : Form
    {
        private readonly ReceptionistForm parentForm;
        private readonly HttpClient httpClient;
        private Patient editingPatient;
        public AddPatientForm(ReceptionistForm parent, HttpClient client, Patient patientToEdit = null)
        {
            InitializeComponent();
            parentForm = parent;
            httpClient = client;
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
                // ADD mode
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
                    await parentForm.LoadPatients();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add patient.");
                }
            }
            else
            {
                // EDIT mode
                editingPatient.Name = nameTextBox.Text;
                editingPatient.Email = emailTextBox.Text;
                editingPatient.Phone = phoneTextBox.Text;
                editingPatient.DateOfBirth = dobPicker.Value;

                var response = await httpClient.PutAsJsonAsync($"/api/patients/{editingPatient.Id}", editingPatient);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Patient updated successfully!");
                    await parentForm.LoadPatients();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update patient.");
                }
            }
        }

        private void AddPatientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
