using OnlineClinicClient.Forms;
using OnlineClinicClient.Models;
using OnlineClinicClient.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineClinicClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            var authService = new AuthService();
            User user = await authService.LoginAsync(username, password);

            if (user != null)
            {
                await ShowStatusMessage("Login successful!", Color.DarkGreen);
                await Task.Delay(2000);

                // Role-based navigation
                switch (user.Role.ToLower())
                {
                    case "doctor":
                        new DoctorForm(user).Show();
                        break;
                    case "patient":
                        MessageBox.Show("Access Restricted");
                        break;
                    case "receptionist":
                        new ReceptionistForm(user).Show();
                        break;
                    case "admin":
                        new AdminForm(user).Show();
                        break;
                }
                this.Hide(); // hide login form after success
            }
            else
            {
                await ShowStatusMessage("Login failed!", Color.DarkRed);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private async Task ShowStatusMessage(string message, Color color)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = color;
        }
    }
}
