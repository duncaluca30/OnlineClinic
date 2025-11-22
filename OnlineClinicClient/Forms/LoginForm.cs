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
                MessageBox.Show($"Welcome {user.Username}, role: {user.Role}");

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
                MessageBox.Show("Invalid username or password",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
