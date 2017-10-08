using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino
{
    public partial class Form1 : Form
    {
        int n1=0, n2=0, n3=0;
        decimal bet, money;
        string message;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void SecondNumber_Click(object sender, EventArgs e)
        {

        }

        private int getRandom()
        {
            return random.Next(0, 8); //8 not included
        }

        private decimal CheckResults()
        {
            decimal t = bet; //temporary store the bet for calculations
            if(n1 == 7 || n2 == 7 || n3 == 7) //at least one result is 7
            {
                if ((n1 == 7 && n2 == 7) || (n1 == 7 && n3 == 7) || (n2 == 7 && n3 == 7)) //at least two results are 7
                {
                    if (n1 == 7 && n2 == 7 && n3 == 7) //snake eyes! (or whatever) all numbers are seven
                    {
                        message = "Awesome, you got all sevens! - your bet is tenfold!";
                        return bet * 10;
                    }

                    message = "Congratulations, you got two sevens! - your bet is tripled";
                    return bet * 3;
                }
                message = "Congratulations, you got a seven! - your bet is doubled";
                return bet * 2;
            }
            if(money == 0)
            {
                message = "You lucked out, I'm sorry but it's game over. (restart the app to play again)";
                PlayBtn.Enabled = false;
                CurrentBet.Enabled = false;
            }
            else
            {
                message = "Sorry, none of the numbers is a seven. Try again.";
            }
            return 0;
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            Boolean canPlay = true;

            if (CurrentBet.Value <= 0)
            {
                MessageBox.Show("Your bet needs to be higher than 0.");
                canPlay = false;
            }

            if(CurrentBet.Value > Int32.Parse(CurrentMoney.Text))
            {
                MessageBox.Show("You can't bet more than you have");
                canPlay = false;
            }

            if (canPlay)
            {
                money = Convert.ToDecimal(CurrentMoney.Text);
                bet = CurrentBet.Value;
                money = money - bet;
                //let's rool!
                n1 = getRandom();
                n2 = getRandom();
                n3 = getRandom();
                //show the results
                FirstNumber.Text = n1.ToString();
                SecondNumber.Text = n2.ToString();
                ThirdNumber.Text = n3.ToString();
                //calculate the results
                bet = CheckResults();
                money += bet;
                CurrentMoney.Text = money.ToString();
                ResultDisplay.Text = message;
            }
        }
    }
}
