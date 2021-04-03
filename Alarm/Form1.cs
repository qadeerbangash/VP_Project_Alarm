using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alarm
{
    public partial class Form1 : Form
    {
        System.Timers.Timer timer;
        private object lblStatus;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            this.BackColor = Color.Gold;
            this.label1.BackColor = Color.White;
            this.label2.BackColor = Color.White;

        }
        delegate void updateLable(Label lbl, string value);

        void updateDataLable(Label lbl, string value)
        {
            lbl.Text = value;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = dateTimePicker1.Value;
            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute &&
                currentTime.Second == userTime.Second)
            {
                timer.Stop();
                try
                {
                    updateDataLable UpdateDataLable = null;
                    updateDataLable upd =UpdateDataLable;
                    if (label2.InvokeRequired)
                        Invoke(upd, lblStatus, "stop");
                    SoundPlayer player = new SoundPlayer();
                    player.SoundLocation = @"C:\Windows\Media\Alarm01.wav";
                    player.PlayLooping();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Invoke(updateDataLable upd, object lblStatus, string v)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            label2.Text = "Runing...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            label2.Text = "Stoping...";
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
