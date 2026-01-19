namespace OnlineClinicClient.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();

            // 1. Patients Tab
            this.patientsTab = new System.Windows.Forms.TabPage();
            this.patientsGrid = new System.Windows.Forms.DataGridView();
            this.addPatientBtn = new System.Windows.Forms.Button();
            this.editPatientBtn = new System.Windows.Forms.Button();
            this.deletePatientBtn = new System.Windows.Forms.Button();

            // 2. Appointments Tab
            this.appointmentsTab = new System.Windows.Forms.TabPage();
            this.appointmentsGrid = new System.Windows.Forms.DataGridView();
            this.addAppointmentBtn = new System.Windows.Forms.Button();
            this.rescheduleBtn = new System.Windows.Forms.Button();
            this.cancelAppointmentBtn = new System.Windows.Forms.Button();

            // 3. Doctors Tab (Now with Buttons!)
            this.doctorsTab = new System.Windows.Forms.TabPage();
            this.doctorsGrid = new System.Windows.Forms.DataGridView();
            this.addDoctorBtn = new System.Windows.Forms.Button();
            this.editDoctorBtn = new System.Windows.Forms.Button();
            this.deleteDoctorBtn = new System.Windows.Forms.Button();

            // 4. Users Tab (New)
            this.usersTab = new System.Windows.Forms.TabPage();
            this.usersGrid = new System.Windows.Forms.DataGridView();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();

            this.tabControl.SuspendLayout();
            this.patientsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientsGrid)).BeginInit();
            this.appointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).BeginInit();
            this.doctorsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).BeginInit();
            this.usersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).BeginInit();
            this.SuspendLayout();

            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.patientsTab);
            this.tabControl.Controls.Add(this.appointmentsTab);
            this.tabControl.Controls.Add(this.doctorsTab);
            this.tabControl.Controls.Add(this.usersTab); // Users is the 4th tab
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 600);
            this.tabControl.TabIndex = 0;

            // --- TAB 1: PATIENTS ---
            this.patientsTab.Controls.Add(this.patientsGrid);
            this.patientsTab.Controls.Add(this.addPatientBtn);
            this.patientsTab.Controls.Add(this.editPatientBtn);
            this.patientsTab.Controls.Add(this.deletePatientBtn);
            this.patientsTab.Location = new System.Drawing.Point(4, 25);
            this.patientsTab.Name = "patientsTab";
            this.patientsTab.Padding = new System.Windows.Forms.Padding(3);
            this.patientsTab.Size = new System.Drawing.Size(992, 571);
            this.patientsTab.Text = "Patients";
            this.patientsTab.UseVisualStyleBackColor = true;

            this.patientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patientsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientsGrid.Location = new System.Drawing.Point(3, 3);
            this.patientsGrid.Size = new System.Drawing.Size(986, 400);
            this.patientsGrid.TabIndex = 0;

            this.addPatientBtn.Location = new System.Drawing.Point(20, 443);
            this.addPatientBtn.Name = "addPatientBtn";
            this.addPatientBtn.Size = new System.Drawing.Size(120, 40);
            this.addPatientBtn.Text = "Add Patient";
            this.addPatientBtn.UseVisualStyleBackColor = true;
            this.addPatientBtn.Click += new System.EventHandler(this.addPatientBtn_Click);

            this.editPatientBtn.Location = new System.Drawing.Point(160, 443);
            this.editPatientBtn.Name = "editPatientBtn";
            this.editPatientBtn.Size = new System.Drawing.Size(120, 40);
            this.editPatientBtn.Text = "Edit Patient";
            this.editPatientBtn.UseVisualStyleBackColor = true;
            this.editPatientBtn.Click += new System.EventHandler(this.editPatientBtn_Click);

            this.deletePatientBtn.Location = new System.Drawing.Point(300, 443);
            this.deletePatientBtn.Name = "deletePatientBtn";
            this.deletePatientBtn.Size = new System.Drawing.Size(120, 40);
            this.deletePatientBtn.Text = "Delete Patient";
            this.deletePatientBtn.UseVisualStyleBackColor = true;
            this.deletePatientBtn.Click += new System.EventHandler(this.deletePatientBtn_Click);

            // --- TAB 2: APPOINTMENTS ---
            this.appointmentsTab.Controls.Add(this.appointmentsGrid);
            this.appointmentsTab.Controls.Add(this.addAppointmentBtn);
            this.appointmentsTab.Controls.Add(this.rescheduleBtn);
            this.appointmentsTab.Controls.Add(this.cancelAppointmentBtn);
            this.appointmentsTab.Location = new System.Drawing.Point(4, 25);
            this.appointmentsTab.Name = "appointmentsTab";
            this.appointmentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.appointmentsTab.Size = new System.Drawing.Size(992, 571);
            this.appointmentsTab.Text = "Appointments";
            this.appointmentsTab.UseVisualStyleBackColor = true;

            this.appointmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.appointmentsGrid.Location = new System.Drawing.Point(3, 3);
            this.appointmentsGrid.Size = new System.Drawing.Size(986, 400);
            this.appointmentsGrid.TabIndex = 0;

            this.addAppointmentBtn.Location = new System.Drawing.Point(20, 443);
            this.addAppointmentBtn.Name = "addAppointmentBtn";
            this.addAppointmentBtn.Size = new System.Drawing.Size(120, 40);
            this.addAppointmentBtn.Text = "Add Appointment";
            this.addAppointmentBtn.UseVisualStyleBackColor = true;
            this.addAppointmentBtn.Click += new System.EventHandler(this.addAppointmentBtn_Click);

            this.rescheduleBtn.Location = new System.Drawing.Point(160, 443);
            this.rescheduleBtn.Name = "rescheduleBtn";
            this.rescheduleBtn.Size = new System.Drawing.Size(120, 40);
            this.rescheduleBtn.Text = "Reschedule";
            this.rescheduleBtn.UseVisualStyleBackColor = true;
            this.rescheduleBtn.Click += new System.EventHandler(this.rescheduleBtn_Click);

            this.cancelAppointmentBtn.Location = new System.Drawing.Point(300, 443);
            this.cancelAppointmentBtn.Name = "cancelAppointmentBtn";
            this.cancelAppointmentBtn.Size = new System.Drawing.Size(140, 40);
            this.cancelAppointmentBtn.Text = "Cancel Appointment";
            this.cancelAppointmentBtn.UseVisualStyleBackColor = true;
            this.cancelAppointmentBtn.Click += new System.EventHandler(this.cancelAppointmentBtn_Click);

            // --- TAB 3: DOCTORS (Updated with Buttons) ---
            this.doctorsTab.Controls.Add(this.doctorsGrid);
            this.doctorsTab.Controls.Add(this.addDoctorBtn);
            this.doctorsTab.Controls.Add(this.editDoctorBtn);
            this.doctorsTab.Controls.Add(this.deleteDoctorBtn);
            this.doctorsTab.Location = new System.Drawing.Point(4, 25);
            this.doctorsTab.Name = "doctorsTab";
            this.doctorsTab.Padding = new System.Windows.Forms.Padding(3);
            this.doctorsTab.Size = new System.Drawing.Size(992, 571);
            this.doctorsTab.Text = "Doctors";
            this.doctorsTab.UseVisualStyleBackColor = true;

            this.doctorsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.doctorsGrid.Location = new System.Drawing.Point(3, 3);
            this.doctorsGrid.Size = new System.Drawing.Size(986, 400);
            this.doctorsGrid.TabIndex = 0;

            // Added these buttons so you can edit doctors
            this.addDoctorBtn.Location = new System.Drawing.Point(20, 443);
            this.addDoctorBtn.Name = "addDoctorBtn";
            this.addDoctorBtn.Size = new System.Drawing.Size(120, 40);
            this.addDoctorBtn.Text = "Add Doctor";
            this.addDoctorBtn.UseVisualStyleBackColor = true;
            this.addDoctorBtn.Click += new System.EventHandler(this.addDoctorBtn_Click); // Make sure you have this method in .cs

            this.editDoctorBtn.Location = new System.Drawing.Point(160, 443);
            this.editDoctorBtn.Name = "editDoctorBtn";
            this.editDoctorBtn.Size = new System.Drawing.Size(120, 40);
            this.editDoctorBtn.Text = "Edit Doctor";
            this.editDoctorBtn.UseVisualStyleBackColor = true;
            this.editDoctorBtn.Click += new System.EventHandler(this.editDoctorBtn_Click); // Make sure you have this method in .cs

            this.deleteDoctorBtn.Location = new System.Drawing.Point(300, 443);
            this.deleteDoctorBtn.Name = "deleteDoctorBtn";
            this.deleteDoctorBtn.Size = new System.Drawing.Size(120, 40);
            this.deleteDoctorBtn.Text = "Delete Doctor";
            this.deleteDoctorBtn.UseVisualStyleBackColor = true;
            this.deleteDoctorBtn.Click += new System.EventHandler(this.deleteDoctorBtn_Click); // Make sure you have this method in .cs


            // --- TAB 4: USERS (New) ---
            this.usersTab.Controls.Add(this.usersGrid);
            this.usersTab.Controls.Add(this.deleteUserBtn);
            this.usersTab.Controls.Add(this.addUserBtn);
            this.usersTab.Location = new System.Drawing.Point(4, 25);
            this.usersTab.Name = "usersTab";
            this.usersTab.Padding = new System.Windows.Forms.Padding(3);
            this.usersTab.Size = new System.Drawing.Size(992, 571);
            this.usersTab.Text = "Users";
            this.usersTab.UseVisualStyleBackColor = true;

            this.usersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.usersGrid.Location = new System.Drawing.Point(3, 3);
            this.usersGrid.Size = new System.Drawing.Size(986, 400);
            this.usersGrid.TabIndex = 0;

            this.deleteUserBtn.Location = new System.Drawing.Point(20, 443);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(120, 40);
            this.deleteUserBtn.Text = "Delete User";
            this.deleteUserBtn.UseVisualStyleBackColor = true;

            this.addUserBtn.Location = new System.Drawing.Point(160, 443); // Next to Delete button
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(120, 40);
            this.addUserBtn.Text = "Add User";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // Wire this up later in your .cs file
            // this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);

            // 
            // Common Controls
            // 
            this.logoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoutBtn.Location = new System.Drawing.Point(0, 570);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(1000, 30);
            this.logoutBtn.Text = "Logout";
            this.logoutBtn.UseVisualStyleBackColor = true;

            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.statusLabel.Location = new System.Drawing.Point(0, 576);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.statusLabel.Size = new System.Drawing.Size(1000, 24);
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.tabControl);
            this.Name = "AdminForm";
            this.Text = "Admin Dashboard";
            this.tabControl.ResumeLayout(false);

            this.patientsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientsGrid)).EndInit();

            this.appointmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).EndInit();

            this.doctorsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).EndInit();

            this.usersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;

        // Tab 1: Patients
        private System.Windows.Forms.TabPage patientsTab;
        private System.Windows.Forms.DataGridView patientsGrid;
        private System.Windows.Forms.Button addPatientBtn;
        private System.Windows.Forms.Button editPatientBtn;
        private System.Windows.Forms.Button deletePatientBtn;

        // Tab 2: Appointments
        private System.Windows.Forms.TabPage appointmentsTab;
        private System.Windows.Forms.DataGridView appointmentsGrid;
        private System.Windows.Forms.Button addAppointmentBtn;
        private System.Windows.Forms.Button rescheduleBtn;
        private System.Windows.Forms.Button cancelAppointmentBtn;

        // Tab 3: Doctors
        private System.Windows.Forms.TabPage doctorsTab;
        private System.Windows.Forms.DataGridView doctorsGrid;
        private System.Windows.Forms.Button addDoctorBtn;
        private System.Windows.Forms.Button editDoctorBtn;
        private System.Windows.Forms.Button deleteDoctorBtn;

        // Tab 4: Users
        private System.Windows.Forms.TabPage usersTab;
        private System.Windows.Forms.DataGridView usersGrid;
        private System.Windows.Forms.Button deleteUserBtn;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Label statusLabel;
    }
}