using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create an int guess variable to track what part of the pattern the user is at
        int guess;

        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1
            //TODO: refresh
            //TODO: pause for a bit
            //TODO: run ComputerTurn()

            Form1.pattern.Clear();
            Form1.score = 0;
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //green = 1 red = 2 blue = 3 yellow = 4


            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list. Each number represents a button. For example, 0 may be green, 1 may be blue, etc.

            Form1.pattern.Add(randGen.Next(1, 5));

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button

            for (int i = 0; i < Form1.pattern.Count; i++)
            {
                if (Form1.pattern[i] == 1)
                {
                    greenButton.BackColor = Color.Lime;
                    this.Refresh();
                    Thread.Sleep(500);
                    greenButton.BackColor = Color.ForestGreen;
                }
                if (Form1.pattern[i] == 2)
                {
                    redButton.BackColor = Color.Red;
                    this.Refresh();
                    Thread.Sleep(500);
                    redButton.BackColor = Color.DarkRed;
                }
                if (Form1.pattern[i] == 3)
                {
                    blueButton.BackColor = Color.Blue;
                    this.Refresh();
                    Thread.Sleep(500);
                    blueButton.BackColor = Color.DarkBlue;
                }
                if (Form1.pattern[i] == 4)
                {
                    yellowButton.BackColor = Color.Yellow;
                    this.Refresh();
                    Thread.Sleep(500);
                    yellowButton.BackColor = Color.Goldenrod;
                }
            }
               this.Refresh();
            guess = 0;
        }
                
        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            ButtonClick(1);
            //TODO: is the value in the pattern list at index [guess] equal to a green?
            // change button color
            // play sound
            // refresh
            // pause
            // set button colour back to original
            // add one to the guess variable

            //TODO:check to see if we are at the end of the pattern, (guess is the same as pattern list count).
            // call ComputerTurn() method
            // else call GameOver method
        }
        private void redButton_Click(object sender, EventArgs e)
        {
            ButtonClick(2); 
        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            ButtonClick(3); 
        }
        private void yellowButton_Click(object sender, EventArgs e)
        {
            ButtonClick(4);
        }
        public void ButtonClick(int color)
        {
            for (int i = 0; 0 < Form1.pattern.Count(); i++)
            {
                if (color == Form1.pattern[i])
                {
                    Form1.score++;
                    ComputerTurn();
                }
                else
                {
                    GameOver();
                }
            }
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen
            Form f = FindForm();
            f.Close();
        }

        
        
    }
}
