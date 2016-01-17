namespace Exit_Room_Server
{
    partial class ExitRoomServer
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
            this.countdownTimerLabel = new System.Windows.Forms.Label();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.btnPauseGame = new System.Windows.Forms.Button();
            this.btnStopGame = new System.Windows.Forms.Button();
            this.hintGroupBox = new System.Windows.Forms.GroupBox();
            this.btnSendHint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newHintTextBox = new System.Windows.Forms.TextBox();
            this.btnEditTime = new System.Windows.Forms.Button();
            this.logListBox = new System.Windows.Forms.ListBox();
            this.hintGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // countdownTimerLabel
            // 
            this.countdownTimerLabel.AutoSize = true;
            this.countdownTimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countdownTimerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.countdownTimerLabel.Location = new System.Drawing.Point(12, 9);
            this.countdownTimerLabel.Name = "countdownTimerLabel";
            this.countdownTimerLabel.Size = new System.Drawing.Size(417, 108);
            this.countdownTimerLabel.TabIndex = 0;
            this.countdownTimerLabel.Text = "00:00:00";
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(30, 120);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(75, 23);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "Start game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // btnPauseGame
            // 
            this.btnPauseGame.Location = new System.Drawing.Point(111, 120);
            this.btnPauseGame.Name = "btnPauseGame";
            this.btnPauseGame.Size = new System.Drawing.Size(75, 23);
            this.btnPauseGame.TabIndex = 2;
            this.btnPauseGame.Text = "Pause game";
            this.btnPauseGame.UseVisualStyleBackColor = true;
            this.btnPauseGame.Click += new System.EventHandler(this.btnPauseGame_Click);
            // 
            // btnStopGame
            // 
            this.btnStopGame.Location = new System.Drawing.Point(192, 120);
            this.btnStopGame.Name = "btnStopGame";
            this.btnStopGame.Size = new System.Drawing.Size(75, 23);
            this.btnStopGame.TabIndex = 3;
            this.btnStopGame.Text = "Stop game";
            this.btnStopGame.UseVisualStyleBackColor = true;
            this.btnStopGame.Click += new System.EventHandler(this.btnStopGame_Click);
            // 
            // hintGroupBox
            // 
            this.hintGroupBox.Controls.Add(this.btnSendHint);
            this.hintGroupBox.Controls.Add(this.label1);
            this.hintGroupBox.Controls.Add(this.newHintTextBox);
            this.hintGroupBox.Location = new System.Drawing.Point(12, 191);
            this.hintGroupBox.Name = "hintGroupBox";
            this.hintGroupBox.Size = new System.Drawing.Size(984, 311);
            this.hintGroupBox.TabIndex = 4;
            this.hintGroupBox.TabStop = false;
            this.hintGroupBox.Text = "Hints";
            // 
            // btnSendHint
            // 
            this.btnSendHint.Location = new System.Drawing.Point(432, 20);
            this.btnSendHint.Name = "btnSendHint";
            this.btnSendHint.Size = new System.Drawing.Size(75, 23);
            this.btnSendHint.TabIndex = 2;
            this.btnSendHint.Text = "Send hint";
            this.btnSendHint.UseVisualStyleBackColor = true;
            this.btnSendHint.Click += new System.EventHandler(this.btnSendHint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hint";
            // 
            // newHintTextBox
            // 
            this.newHintTextBox.Location = new System.Drawing.Point(47, 19);
            this.newHintTextBox.Multiline = true;
            this.newHintTextBox.Name = "newHintTextBox";
            this.newHintTextBox.Size = new System.Drawing.Size(378, 96);
            this.newHintTextBox.TabIndex = 0;
            // 
            // btnEditTime
            // 
            this.btnEditTime.Location = new System.Drawing.Point(435, 54);
            this.btnEditTime.Name = "btnEditTime";
            this.btnEditTime.Size = new System.Drawing.Size(75, 23);
            this.btnEditTime.TabIndex = 5;
            this.btnEditTime.Text = "Edit time";
            this.btnEditTime.UseVisualStyleBackColor = true;
            this.btnEditTime.Click += new System.EventHandler(this.btnEditTime_Click);
            // 
            // logListBox
            // 
            this.logListBox.FormattingEnabled = true;
            this.logListBox.HorizontalScrollbar = true;
            this.logListBox.Location = new System.Drawing.Point(10, 508);
            this.logListBox.Name = "logListBox";
            this.logListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.logListBox.Size = new System.Drawing.Size(986, 199);
            this.logListBox.TabIndex = 3;
            // 
            // ExitRoomServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.logListBox);
            this.Controls.Add(this.btnEditTime);
            this.Controls.Add(this.hintGroupBox);
            this.Controls.Add(this.btnStopGame);
            this.Controls.Add(this.btnPauseGame);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.countdownTimerLabel);
            this.Name = "ExitRoomServer";
            this.Text = "Exit-Room Server";
            this.hintGroupBox.ResumeLayout(false);
            this.hintGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label countdownTimerLabel;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnPauseGame;
        private System.Windows.Forms.Button btnStopGame;
        private System.Windows.Forms.GroupBox hintGroupBox;
        private System.Windows.Forms.Button btnSendHint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newHintTextBox;
        private System.Windows.Forms.Button btnEditTime;
        private System.Windows.Forms.ListBox logListBox;
    }
}

