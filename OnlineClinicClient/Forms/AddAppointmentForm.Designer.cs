using System.Windows.Forms;

namespace OnlineClinicClient.Forms
{
    partial class AddAppointmentForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private System.Windows.Forms.ComboBox patientComboBox;
        private System.Windows.Forms.ComboBox doctorComboBox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label patientLabel;
        private System.Windows.Forms.Label doctorLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label priceLabel;


        private void InitializeComponent()
        {
            this.patientComboBox = new System.Windows.Forms.ComboBox();
            this.doctorComboBox = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.patientLabel = new System.Windows.Forms.Label();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // patientComboBox
            // 
            this.patientComboBox.Location = new System.Drawing.Point(140, 20);
            this.patientComboBox.Name = "patientComboBox";
            this.patientComboBox.Size = new System.Drawing.Size(200, 24);
            this.patientComboBox.TabIndex = 1;
            // 
            // doctorComboBox
            // 
            this.doctorComboBox.Location = new System.Drawing.Point(140, 60);
            this.doctorComboBox.Name = "doctorComboBox";
            this.doctorComboBox.Size = new System.Drawing.Size(200, 24);
            this.doctorComboBox.TabIndex = 3;
            // 
            // datePicker
            // 
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePicker.Location = new System.Drawing.Point(140, 100);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 22);
            this.datePicker.TabIndex = 5;
            // 
            // timePicker
            // 
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(140, 140);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(200, 22);
            this.timePicker.TabIndex = 7;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(140, 180);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(200, 22);
            this.priceTextBox.TabIndex = 9;
            this.priceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(140, 220);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(200, 30);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save Appointment";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.statusLabel.Location = new System.Drawing.Point(10, 337);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(478, 24);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // patientLabel
            // 
            this.patientLabel.Location = new System.Drawing.Point(20, 20);
            this.patientLabel.Name = "patientLabel";
            this.patientLabel.Size = new System.Drawing.Size(100, 20);
            this.patientLabel.TabIndex = 0;
            this.patientLabel.Text = "Select Patient:";
            // 
            // doctorLabel
            // 
            this.doctorLabel.Location = new System.Drawing.Point(20, 60);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(100, 20);
            this.doctorLabel.TabIndex = 2;
            this.doctorLabel.Text = "Select Doctor:";
            // 
            // dateLabel
            // 
            this.dateLabel.Location = new System.Drawing.Point(20, 100);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(120, 20);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Appointment Date:";
            // 
            // timeLabel
            // 
            this.timeLabel.Location = new System.Drawing.Point(20, 140);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(120, 20);
            this.timeLabel.TabIndex = 6;
            this.timeLabel.Text = "Appointment Time:";
            // 
            // priceLabel
            // 
            this.priceLabel.Location = new System.Drawing.Point(20, 180);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(100, 20);
            this.priceLabel.TabIndex = 8;
            this.priceLabel.Text = "Price:";
            // 
            // AddAppointmentForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.patientLabel);
            this.Controls.Add(this.patientComboBox);
            this.Controls.Add(this.doctorLabel);
            this.Controls.Add(this.doctorComboBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.statusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AddAppointmentForm";
            this.Text = "Add Appointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}