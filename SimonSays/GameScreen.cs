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
using System.IO;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create an int guess variable to track what part of the pattern the user is at
        int guess;

        //set up for later 
        Random randGen = new Random();
        SoundPlayer red = new SoundPlayer(Properties.Resources.red);
        SoundPlayer blue = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer yellow = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer green = new SoundPlayer(Properties.Resources.green);
        SoundPlayer mistake = new SoundPlayer(Properties.Resources.mistake);

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

            
            //making the buttons look fancy

            GraphicsPath buttonRegion = new GraphicsPath();
            buttonRegion.AddEllipse(5, 5, greenButton.Width*2, greenButton.Height*2);
            greenButton.Region = new Region(buttonRegion);
            

            buttonRegion = new GraphicsPath();
            buttonRegion.AddEllipse(5, -5 - greenButton.Height, greenButton.Width * 2, greenButton.Height * 2);
            yellowButton.Region = new Region(buttonRegion);


            buttonRegion = new GraphicsPath();
            buttonRegion.AddEllipse(-5-greenButton.Width, 5, greenButton.Width * 2, greenButton.Height * 2);
            redButton.Region = new Region(buttonRegion);

            buttonRegion = new GraphicsPath();
            buttonRegion.AddEllipse(-5 - greenButton.Width, -5 - greenButton.Height, greenButton.Width * 2, greenButton.Height * 2);
            blueButton.Region = new Region(buttonRegion);

            //buttonRegion.Reset();


            Matrix yRotation = new Matrix();
           // yRotation.RotateAt(0, new PointF(0, 0));
           // yellowButton.Region = new Region(buttonRegion);
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

            //plays the computers turn
            for (int i = 0; i < Form1.pattern.Count; i++)
            {
                if (Form1.pattern[i] == 1)
                {
                    greenButton.BackColor = Color.Lime;
                    this.Refresh();
                    Thread.Sleep(250);
                    greenButton.BackColor = Color.ForestGreen;
                }
                if (Form1.pattern[i] == 2)
                {
                    redButton.BackColor = Color.Red;
                    this.Refresh();
                    Thread.Sleep(250);
                    redButton.BackColor = Color.DarkRed;
                }
                if (Form1.pattern[i] == 3)
                {
                    blueButton.BackColor = Color.Blue;
                    this.Refresh();
                    Thread.Sleep(250);
                    blueButton.BackColor = Color.DarkBlue;
                }
                if (Form1.pattern[i] == 4)
                {
                    yellowButton.BackColor = Color.Yellow;
                    this.Refresh();
                    Thread.Sleep(250);
                    yellowButton.BackColor = Color.Goldenrod;
                }
                this.Refresh();
                Thread.Sleep(250); 
            }
               
            guess = 0;
        }
                
        //TODO: create one of these event methods for each button

        //player turn
        private void greenButton_Click(object sender, EventArgs e)
        {
            sound("green");
            ButtonClick(1);
        }
        private void redButton_Click(object sender, EventArgs e)
        {
            sound("red");
            ButtonClick(2); 
        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            sound("blue");
            ButtonClick(3); 
        }
        private void yellowButton_Click(object sender, EventArgs e)
        {
            sound("yellow");
            ButtonClick(4);
        }
        public async void ButtonClick(int color)
        {
            //checks to see if the player failed or moves on
            if (color == Form1.pattern[guess])
            {
                guess++; 
                if (guess == Form1.pattern.Count())
                {
                    Refresh();
                    Form1.score++;
                    ComputerTurn();
                }
            }
            else
            {
                mistake.Play();
                GameOver();
            }
           
        }

        public void GameOver()
        {
            //TODO: Play a game over sound

            //TODO: close this screen and open the GameOverScreen
            Form f = FindForm();
            f.Controls.Remove(this);

            GameOverScreen gos = new GameOverScreen();
            gos.Location = new Point((f.ClientSize.Width - gos.Width) / 2, (f.ClientSize.Height - gos.Height) / 2);
            gos.Focus();
            f.Controls.Add(gos);
        }

        public void sound(string name)
        {
            //allows for overlaping sounds
            var sound = new System.Windows.Media.MediaPlayer();
            sound.Open(new Uri(Application.StartupPath + $"/Resources/{name}.wav"));
            sound.Play();
        }
    }
}
