using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace DiceBot
{
    public partial class Stats : Form
    {
        public  bool showRate = true;
        public bool slowSim = false;
        // MARKC
        public cDiceBot diceBot;

        private Boolean updateRate = false;
        private System.Timers.Timer RateTimer = null;

        public Stats()
        {
            InitializeComponent();

            // MARKC
            cDiceBot.updateRate();
            this.Text = "Stats BTC Rate $" + DiceBot.BTCRate.GetRate().ToString();

            RateTimer = new System.Timers.Timer();
            RateTimer.Elapsed += new ElapsedEventHandler(UpdateRate);
            RateTimer.Interval = 900000;

            btnUpdateRate.BackColor = Color.Red;
            btnSpeedMode.BackColor = Color.Red;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            base.OnClosing(e);
        }
        private void btnResetStats_Click(object sender, EventArgs e)
        {

        }

        private void btnHideStats_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateRate_Click(object sender, EventArgs e)
        {
            updateRate = !updateRate;
            if (updateRate)
            {
                btnUpdateRate.BackColor = Color.Green;
                btnUpdateRate.Text = "Update Rate On";
                RateTimer.Enabled = true;
                UpdateRate(sender, null);
            }
            else
            {
                btnUpdateRate.Text = "Update Rate Off";
                btnUpdateRate.BackColor = Color.Red;
                RateTimer.Enabled = false;
            }

        }

        delegate void dUpdateRate(object source, ElapsedEventArgs e);
        private void UpdateRate(object source, ElapsedEventArgs e)
        {

            if (InvokeRequired)
                Invoke(new dUpdateRate(UpdateRate), source, e);
            else
            {
                cDiceBot.updateRate();
                this.Text = "Stats BTC Rate $" + DiceBot.BTCRate.GetRate().ToString();
            }
        }

        private void btnShowDollar_Click(object sender, EventArgs e)
        {
            showRate = !showRate;
            if(showRate)
            {
                btnShowDollar.BackColor = Color.Green;
            }
            else
            {
                btnShowDollar.BackColor = Color.Red;
            }
        }

        private void btnSpeedMode_Click(object sender, EventArgs e)
        {
            cDiceBot.SpeedMode = !cDiceBot.SpeedMode;

            if (cDiceBot.SpeedMode)
            {
                btnSpeedMode.BackColor = Color.Green;
                btnSpeedMode.Text = "Speed Mode On";
            }
            else
            {
                btnSpeedMode.BackColor = Color.Red;
                btnSpeedMode.Text = "Speed Mode Off";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            diceBot.SaveCode();
            diceBot.Start(false);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            diceBot.stoponwin = true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            diceBot.Stop("Manual Stop");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            slowSim = !slowSim;
            diceBot.SlowSpeed(slowSim);

            if (slowSim)
            {
                button3.BackColor = Color.Green;
                button3.Text = "Slow Sim On";
            }
            else
            {
                button3.BackColor = Color.Red;
                button3.Text = "Slow Sim Off";
            }
        }

        private void streak1_Click(object sender, EventArgs e)
        {

        }
    }
}
