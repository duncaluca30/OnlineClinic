using System.Windows.Forms;

namespace OnlineClinicClient.Forms
{
    partial class ReceptionistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage patientsTab;
        private System.Windows.Forms.TabPage appointmentsTab;
        private System.Windows.Forms.TabPage doctorsTab;

        private System.Windows.Forms.DataGridView patientsGrid;
        private System.Windows.Forms.Button addPatientBtn;
        private System.Windows.Forms.Button editPatientBtn;
        private System.Windows.Forms.Button deletePatientBtn;

        private System.Windows.Forms.DataGridView appointmentsGrid;
        private System.Windows.Forms.Button addAppointmentBtn;
        private System.Windows.Forms.Button rescheduleBtn;
        private System.Windows.Forms.Button cancelAppointmentBtn;

        private System.Windows.Forms.DataGridView doctorsGrid;

        private System.Windows.Forms.Button logoutBtn;


        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.patientsTab = new System.Windows.Forms.TabPage();
            this.patientsGrid = new System.Windows.Forms.DataGridView();
            this.addPatientBtn = new System.Windows.Forms.Button();
            this.editPatientBtn = new System.Windows.Forms.Button();
            this.deletePatientBtn = new System.Windows.Forms.Button();
            this.appointmentsTab = new System.Windows.Forms.TabPage();
            this.appointmentsGrid = new System.Windows.Forms.DataGridView();
            this.addAppointmentBtn = new System.Windows.Forms.Button();
            this.rescheduleBtn = new System.Windows.Forms.Button();
            this.cancelAppointmentBtn = new System.Windows.Forms.Button();
            this.doctorsTab = new System.Windows.Forms.TabPage();
            this.doctorsGrid = new System.Windows.Forms.DataGridView();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.patientsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patientsGrid)).BeginInit();
            this.appointmentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).BeginInit();
            this.doctorsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.patientsTab);
            this.tabControl.Controls.Add(this.appointmentsTab);
            this.tabControl.Controls.Add(this.doctorsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 600);
            this.tabControl.TabIndex = 0;
            // 
            // patientsTab
            // 
            this.patientsTab.Controls.Add(this.patientsGrid);
            this.patientsTab.Controls.Add(this.addPatientBtn);
            this.patientsTab.Controls.Add(this.editPatientBtn);
            this.patientsTab.Controls.Add(this.deletePatientBtn);
            this.patientsTab.Location = new System.Drawing.Point(4, 25);
            this.patientsTab.Name = "patientsTab";
            this.patientsTab.Size = new System.Drawing.Size(992, 571);
            this.patientsTab.TabIndex = 0;
            this.patientsTab.Text = "Patients";
            // 
            // patientsGrid
            // 
            this.patientsGrid.ColumnHeadersHeight = 29;
            this.patientsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.patientsGrid.Location = new System.Drawing.Point(0, 0);
            this.patientsGrid.Name = "patientsGrid";
            this.patientsGrid.RowHeadersWidth = 51;
            this.patientsGrid.Size = new System.Drawing.Size(992, 400);
            this.patientsGrid.TabIndex = 0;
            // 
            // addPatientBtn
            // 
            this.addPatientBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPatientBtn.Location = new System.Drawing.Point(20, 443);
            this.addPatientBtn.Name = "addPatientBtn";
            this.addPatientBtn.Size = new System.Drawing.Size(120, 40);
            this.addPatientBtn.TabIndex = 1;
            this.addPatientBtn.Text = "Add Patient";
            // 
            // editPatientBtn
            // 
            this.editPatientBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editPatientBtn.Location = new System.Drawing.Point(160, 443);
            this.editPatientBtn.Name = "editPatientBtn";
            this.editPatientBtn.Size = new System.Drawing.Size(120, 40);
            this.editPatientBtn.TabIndex = 2;
            this.editPatientBtn.Text = "Edit Patient";
            // 
            // deletePatientBtn
            // 
            this.deletePatientBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletePatientBtn.Location = new System.Drawing.Point(300, 443);
            this.deletePatientBtn.Name = "deletePatientBtn";
            this.deletePatientBtn.Size = new System.Drawing.Size(120, 40);
            this.deletePatientBtn.TabIndex = 3;
            this.deletePatientBtn.Text = "Delete Patient";
            // 
            // appointmentsTab
            // 
            this.appointmentsTab.Controls.Add(this.appointmentsGrid);
            this.appointmentsTab.Controls.Add(this.addAppointmentBtn);
            this.appointmentsTab.Controls.Add(this.rescheduleBtn);
            this.appointmentsTab.Controls.Add(this.cancelAppointmentBtn);
            this.appointmentsTab.Location = new System.Drawing.Point(4, 25);
            this.appointmentsTab.Name = "appointmentsTab";
            this.appointmentsTab.Size = new System.Drawing.Size(992, 571);
            this.appointmentsTab.TabIndex = 1;
            this.appointmentsTab.Text = "Appointments";
            // 
            // appointmentsGrid
            // 
            this.appointmentsGrid.ColumnHeadersHeight = 29;
            this.appointmentsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.appointmentsGrid.Location = new System.Drawing.Point(0, 0);
            this.appointmentsGrid.Name = "appointmentsGrid";
            this.appointmentsGrid.RowHeadersWidth = 51;
            this.appointmentsGrid.Size = new System.Drawing.Size(992, 400);
            this.appointmentsGrid.TabIndex = 0;
            // 
            // addAppointmentBtn
            // 
            this.addAppointmentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAppointmentBtn.Location = new System.Drawing.Point(20, 443);
            this.addAppointmentBtn.Name = "addAppointmentBtn";
            this.addAppointmentBtn.Size = new System.Drawing.Size(120, 40);
            this.addAppointmentBtn.TabIndex = 1;
            this.addAppointmentBtn.Text = "Add Appointment";
            // 
            // rescheduleBtn
            // 
            this.rescheduleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rescheduleBtn.Location = new System.Drawing.Point(160, 443);
            this.rescheduleBtn.Name = "rescheduleBtn";
            this.rescheduleBtn.Size = new System.Drawing.Size(120, 40);
            this.rescheduleBtn.TabIndex = 2;
            this.rescheduleBtn.Text = "Reschedule";
            // 
            // cancelAppointmentBtn
            // 
            this.cancelAppointmentBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelAppointmentBtn.Location = new System.Drawing.Point(300, 443);
            this.cancelAppointmentBtn.Name = "cancelAppointmentBtn";
            this.cancelAppointmentBtn.Size = new System.Drawing.Size(140, 40);
            this.cancelAppointmentBtn.TabIndex = 3;
            this.cancelAppointmentBtn.Text = "Cancel Appointment";
            // 
            // doctorsTab
            // 
            this.doctorsTab.Controls.Add(this.doctorsGrid);
            this.doctorsTab.Location = new System.Drawing.Point(4, 25);
            this.doctorsTab.Name = "doctorsTab";
            this.doctorsTab.Size = new System.Drawing.Size(992, 571);
            this.doctorsTab.TabIndex = 2;
            this.doctorsTab.Text = "Doctors";
            // 
            // doctorsGrid
            // 
            this.doctorsGrid.ColumnHeadersHeight = 29;
            this.doctorsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doctorsGrid.Location = new System.Drawing.Point(0, 0);
            this.doctorsGrid.Name = "doctorsGrid";
            this.doctorsGrid.RowHeadersWidth = 51;
            this.doctorsGrid.Size = new System.Drawing.Size(992, 571);
            this.doctorsGrid.TabIndex = 0;
            // 
            // logoutBtn
            // 
            this.logoutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.logoutBtn.Location = new System.Drawing.Point(0, 570);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(1000, 30);
            this.logoutBtn.TabIndex = 1;
            this.logoutBtn.Text = "Logout";
            // 
            // ReceptionistForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.tabControl);
            this.Name = "ReceptionistForm";
            this.Text = "Receptionist Dashboard";
            this.tabControl.ResumeLayout(false);
            this.patientsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patientsGrid)).EndInit();
            this.appointmentsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).EndInit();
            this.doctorsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
    }
}