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
            return random.Next(1, 9); //9 not included
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayFruit(pictureBox1, random.Next(1, 9));
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
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;

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
                //FirstNumber.Text = n1.ToString();
                DisplayFruit(pictureBox1, n1);
                //SecondNumber.Text = n2.ToString();
                DisplayFruit(pictureBox2, n2);
                //ThirdNumber.Text = n3.ToString();
                DisplayFruit(pictureBox3, n3);
                //calculate the results
                bet = CheckResults();
                money += bet;
                CurrentMoney.Text = money.ToString();
                ResultDisplay.Text = message;
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
            }
        }

        private void DisplayFruit(PictureBox img, int number)
        {
            switch (number)
            {
                case 1:
                    img.BackgroundImage = Properties.Resources.apple1;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
                case 2:
                    img.BackgroundImage = Properties.Resources.orange2;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
                case 3:
                    img.BackgroundImage = Properties.Resources.watermellon3;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
                case 4:
                    img.BackgroundImage = Properties.Resources.carrot4;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
                case 5:
                    img.BackgroundImage = Properties.Resources.pear5;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
                case 6:
                    img.BackgroundImage = Properties.Resources.grapes6;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
                case 7:
                    img.BackgroundImage = Properties.Resources.strawberry7;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
                case 8:
                    img.BackgroundImage = Properties.Resources.banana8;
                    img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    break;
            }
        }
    }
}
