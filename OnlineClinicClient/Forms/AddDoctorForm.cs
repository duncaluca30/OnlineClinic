using OnlineClinicClient.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace OnlineClinicClient.Forms
{
    public partial class AddDoctorForm : Form
    {
        private readonly HttpClient _httpClient;
        private readonly Doctor _doctor; // Null if adding, Set if editing

        // UI Controls (You can drag these in Designer or use this code)
        private TextBox txtName, txtSpecialty, txtEmail, txtPhone, txtPrice;
        private Button btnSave, btnCancel;
        private Label lblName, lblSpecialty, lblEmail, lblPhone, lblPrice;

        public AddDoctorForm(HttpClient httpClient, Doctor doctor = null)
        {
            InitializeComponent();
            InitializeCustomUI(); // Create UI fields manually if not using Designer

            _httpClient = httpClient;
            _doctor = doctor;

            if (_doctor != null)
            {
                this.Text = "Edit Doctor";
                txtName.Text = _doctor.Name;
                txtSpecialty.Text = _doctor.Specialty;
                txtEmail.Text = _doctor.Email;
                txtPhone.Text = _doctor.Phone;
                txtPrice.Text = _doctor.Price.ToString();
            }
            else
            {
                this.Text = "Add New Doctor";
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            var doctorData = new Doctor
            {
                Id = _doctor?.Id ?? 0, // Keep ID if editing
                Name = txtName.Text,
                Specialty = txtSpecialty.Text,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,
                Price = price
            };

            HttpResponseMessage response;
            if (_doctor == null)
            {
                // POST: Create New
                response = await _httpClient.PostAsJsonAsync("/api/doctors", doctorData);
            }
            else
            {
                // PUT: Update Existing
                response = await _httpClient.PutAsJsonAsync($"/api/doctors/{_doctor.Id}", doctorData);
            }

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Doctor saved successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save doctor.");
            }
        }

        // --- Quick UI Setup (If you don't want to use the Designer) ---
        private void InitializeCustomUI()
        {
            this.Size = new System.Drawing.Size(400, 350);

            lblName = new Label { Text = "Name:", Top = 20, Left = 20 };
            txtName = new TextBox { Top = 20, Left = 120, Width = 200 };

            lblSpecialty = new Label { Text = "Specialty:", Top = 60, Left = 20 };
            txtSpecialty = new TextBox { Top = 60, Left = 120, Width = 200 };

            lblEmail = new Label { Text = "Email:", Top = 100, Left = 20 };
            txtEmail = new TextBox { Top = 100, Left = 120, Width = 200 };

            lblPhone = new Label { Text = "Phone:", Top = 140, Left = 20 };
            txtPhone = new TextBox { Top = 140, Left = 120, Width = 200 };

            lblPrice = new Label { Text = "Price (RON):", Top = 180, Left = 20 };
            txtPrice = new TextBox { Top = 180, Left = 120, Width = 200 };

            btnSave = new Button { Text = "Save", Top = 230, Left = 120, DialogResult = DialogResult.OK };
            btnSave.Click += btnSave_Click;

            btnCancel = new Button { Text = "Cancel", Top = 230, Left = 210, DialogResult = DialogResult.Cancel };

            this.Controls.Add(lblName); this.Controls.Add(txtName);
            this.Controls.Add(lblSpecialty); this.Controls.Add(txtSpecialty);
            this.Controls.Add(lblEmail); this.Controls.Add(txtEmail);
            this.Controls.Add(lblPhone); this.Controls.Add(txtPhone);
            this.Controls.Add(lblPrice); this.Controls.Add(txtPrice);
            this.Controls.Add(btnSave); this.Controls.Add(btnCancel);
        }
    }
}