﻿namespace Exit_Room_Server
{
    partial class EditTimerForm
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
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dtpCountdownTimer = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpCountdownTimer
            // 
            this.dtpCountdownTimer.CustomFormat = "";
            this.dtpCountdownTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCountdownTimer.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCountdownTimer.Location = new System.Drawing.Point(53, 108);
            this.dtpCountdownTimer.Name = "dtpCountdownTimer";
            this.dtpCountdownTimer.ShowUpDown = true;
            this.dtpCountdownTimer.Size = new System.Drawing.Size(165, 44);
            this.dtpCountdownTimer.TabIndex = 5;
            // 
            // EditTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dtpCountdownTimer);
            this.Controls.Add(this.button1);
            this.Name = "EditTimerForm";
            this.Text = "EditTimerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtpCountdownTimer;
    }
}