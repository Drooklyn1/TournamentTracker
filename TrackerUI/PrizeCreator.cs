using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;
using TrackerUI.Interfaces;

namespace TrackerUI
{
    public partial class PrizeCreator : Form
    {
        IPrizeRequestor callingRequestor;

        public PrizeCreator(IPrizeRequestor caller)
        {
            InitializeComponent();

            callingRequestor = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateNewPrizeForm())
            {
                Prize newPrize = new Prize(placeNameBox.Text, placeNumberBox.Text, prizeAmountBox.Text, prizePercentageBox.Text);

                // ID will be added to the Prize object during creation
                GlobalConfig.Connection.CreatePrize(newPrize);

                callingRequestor.PrizeCompleted(newPrize);

                this.Close();

                //placeNameBox.Text = "";
                //placeNumberBox.Text = "";
                //prizeAmountBox.Text = "";
                //prizePercentageBox.Text = "";
            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }
        }

        private bool ValidateNewPrizeForm()
        {
            bool output = true;

            //Check Place Number
            bool placeNumberValid = int.TryParse(placeNumberBox.Text, out int placeNumber);

            if (!placeNumberValid)
            {
                output = false;
            }
            else if (placeNumber < 1)
            {
                output = false;
            }

            //Check Place Name
            if (placeNameBox.Text.Length == 0)
            {
                output = false;
            }

            //Check Price Amount and Percentage
            bool priceAmountValid = decimal.TryParse(prizeAmountBox.Text, out decimal prizeAmount);
            bool pricePercentageValid = double.TryParse(prizePercentageBox.Text, out double prizePercentage);

            if (!priceAmountValid && !pricePercentageValid)
            {
                output = false;
            }
            else if (prizeAmount <= 0 && (prizePercentage <= 0 || prizePercentage > 100))
            {
                output = false;
            }

            return output;
        }

    }
}
