using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exit_Room_Server
{
    public partial class EditTimerForm : Form
    {

        private int hours;
        private int minutes;
        private int seconds;

        public int totalSeconds { get; set; }
        
        public EditTimerForm(long remainingsecs)
        {
            InitializeComponent();
            hours = (int)((remainingsecs / 60) / 60) % 24;
            minutes = (int)(remainingsecs / 60) % 60;
            seconds = (int)remainingsecs % 60;
            dtpCountdownTimer.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, seconds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            totalSeconds += (dtpCountdownTimer.Value.Hour * 3600);
            totalSeconds += (dtpCountdownTimer.Value.Minute * 60);
            totalSeconds += (dtpCountdownTimer.Value.Second);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
