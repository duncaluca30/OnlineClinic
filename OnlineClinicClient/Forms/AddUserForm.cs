using OnlineClinicClient.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace OnlineClinicClient.Forms
{
    public partial class AddUserForm : Form
    {
        private readonly HttpClient _httpClient;

        // UI Controls
        private Label lblUser, lblPass, lblRole;
        private TextBox txtUsername, txtPassword;
        private ComboBox cmbRole;
        private Button btnSave, btnCancel;

        public AddUserForm(HttpClient httpClient)
        {
            InitializeComponent();
            InitializeCustomUI();
            _httpClient = httpClient;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validation
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // 2. Create the Object (Clean & Type-Safe)
            var newUser = new User
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text, // The model handles the lowercase mapping now
                Role = cmbRole.Text
            };

            try
            {
                // 3. Send it automatically
                // No manual string building needed!
                var response = await _httpClient.PostAsJsonAsync("/api/users", newUser);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("User created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Failed: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
            }
        }

        private void InitializeCustomUI()
        {
            this.Text = "Add New User";
            this.Size = new System.Drawing.Size(400, 300); // Made form slightly wider
            this.StartPosition = FormStartPosition.CenterParent;

            // --- ROW 1: USERNAME ---
            lblUser = new Label { Text = "Username:", Top = 30, Left = 30, AutoSize = true };
            // Changed Left from 120 -> 160 to prevent overlap
            txtUsername = new TextBox { Top = 28, Left = 160, Width = 180 };

            // --- ROW 2: PASSWORD ---
            lblPass = new Label { Text = "Password:", Top = 70, Left = 30, AutoSize = true };
            // Changed Left from 120 -> 160
            txtPassword = new TextBox { Top = 68, Left = 160, Width = 180, PasswordChar = '*' };

            // --- ROW 3: ROLE ---
            lblRole = new Label { Text = "Role:", Top = 110, Left = 30, AutoSize = true };
            // Changed Left from 120 -> 160
            cmbRole = new ComboBox { Top = 108, Left = 160, Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbRole.Items.AddRange(new object[] { "ADMIN", "DOCTOR", "PATIENT", "RECEPTIONIST" });
            cmbRole.SelectedIndex = 0;

            // --- BUTTONS ---
            btnSave = new Button { Text = "Create User", Top = 180, Left = 60, Width = 100, BackColor = System.Drawing.Color.LightGreen };
            btnSave.Click += btnSave_Click;

            btnCancel = new Button { Text = "Cancel", Top = 180, Left = 200, Width = 100 };
            btnCancel.Click += (s, e) => this.Close();

            // Add controls to form
            this.Controls.Add(lblUser); this.Controls.Add(txtUsername);
            this.Controls.Add(lblPass); this.Controls.Add(txtPassword);
            this.Controls.Add(lblRole); this.Controls.Add(cmbRole);
            this.Controls.Add(btnSave); this.Controls.Add(btnCancel);
        }
    }
}