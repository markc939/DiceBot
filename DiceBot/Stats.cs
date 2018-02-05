using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiceBot
{
    public partial class Stats : Form
    {
        public  bool showRate = true;

        // MARKC
         public cDiceBot diceBot;

        public Stats()
        {
            InitializeComponent();

            // MARKC
            cDiceBot.updateRate();
            this.Text = "Stats BTC Rate $" + DiceBot.BTCRate.GetRate().ToString();
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
            cDiceBot.updateRate();
            this.Text = "Stats BTC Rate $" + DiceBot.BTCRate.GetRate().ToString();
        }

        private void btnShowDollar_Click(object sender, EventArgs e)
        {
            showRate = !showRate;
        }

        private void btnSpeedMode_Click(object sender, EventArgs e)
        {
            cDiceBot.SpeedMode = !cDiceBot.SpeedMode;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            diceBot.SaveCode();
            diceBot.Start(false);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            diceBot.Stop("Manual Stop");
        }

      
    }
}
