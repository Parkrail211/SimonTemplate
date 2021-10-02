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
        Random rnd = new Random();
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);
        SoundPlayer gameOverSound = new SoundPlayer(Properties.Resources.mistake);

        int maxTimer = 10;
        int currentTimer;

        


        //TODO: create guess variable to track what part of the pattern the user is at
        int cGuess = 0;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            
            




            Form1.patternList.Clear();
            Refresh();
            Thread.Sleep(500);
            ComputerTurn();
            
        }

        private void ComputerTurn()
        {

            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            Form1.patternList.Add(rnd.Next(0, 4));
            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.patternList.Count(); i++)
            {
                switch (Form1.patternList[i]) {
                    case 0:
                        greenButton.BackColor = Color.Green;
                        greenSound.Play();
                        Refresh();
                        Thread.Sleep(1000);
                        greenButton.BackColor = Color.Black;
                        break;
                    case 1:
                        redButton.BackColor = Color.Red;
                        redSound.Play();
                        Refresh();
                        Thread.Sleep(1000);
                        redButton.BackColor = Color.Black;
                        break;
                    case 2:
                        yellowButton.BackColor = Color.Yellow;
                        yellowSound.Play();
                        Refresh();
                        Thread.Sleep(1000);
                        yellowButton.BackColor = Color.Black;
                        break;
                    case 3:
                        blueButton.BackColor = Color.Blue;
                        blueSound.Play();
                        Refresh();
                        Thread.Sleep(1000);
                        blueButton.BackColor = Color.Black;
                        break;
                }
            }
            //TODO: get guess index value back to 0
            cGuess = 0;
            currentTimer = maxTimer;
           // tickTimer.Enabled = true;
            
        }

        public void GameOver()
        {
            //TODO: Play a game over sound
            gameOverSound.Play();
            //TODO: close this screen and open the GameOverScreen
            Form1.length = Form1.patternList.Count() - 1;
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameOverScreen gos = new GameOverScreen();
            f.Controls.Add(gos);
            gos.Location = new Point((f.Width - gos.Width) / 2, (f.Height - gos.Height) / 2);

        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value at current guess index equal to a green. If so:
            // light up button, play sound, and pause
            // set button colour back to original
            // add one to the guess index
            // check to see if we are at the end of the pattern. If so:
            // call ComputerTurn() method
            // else call GameOver method
            

                greenButton.BackColor = Color.Green;
            greenSound.Play();
                Refresh();
                Thread.Sleep(1000);
                greenButton.BackColor = Color.Black;
            if (Form1.patternList[cGuess] == 0)
            {
               
               
                
                    cGuess++;
                if (cGuess >= Form1.patternList.Count)
                {
                   // tickTimer.Enabled = false;
                    ComputerTurn();
                }

            }
            else
            {
                GameOver();
            }
           
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            

                redButton.BackColor = Color.Red;
            redSound.Play();
                Refresh();
                Thread.Sleep(1000);
                redButton.BackColor = Color.Black;
            if (Form1.patternList[cGuess] == 1)
            {
                
                
                
                    cGuess++;
                if (cGuess >= Form1.patternList.Count)
                {
                 //   tickTimer.Enabled = false;
                    ComputerTurn();
                    
                }
            }
            else
            {
                GameOver();
            }
            
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            yellowButton.BackColor = Color.Yellow;
            yellowSound.Play();
            Refresh();
            Thread.Sleep(1000);
            yellowButton.BackColor = Color.Black;
            if (Form1.patternList[cGuess] == 2)
            {
               
               
                    cGuess++;
                if (cGuess >= Form1.patternList.Count)
                {
                   // tickTimer.Enabled = false;
                    ComputerTurn();
                    
                }
            }
            else
            {
                GameOver();
            } 
              
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            blueButton.BackColor = Color.Blue;
            blueSound.Play();
            Refresh();
            Thread.Sleep(1000);
            blueButton.BackColor = Color.Black;
            if (Form1.patternList[cGuess] == 3)
            {
               
              
               
                    cGuess++;
                if (cGuess >= Form1.patternList.Count)
                {
                    //tickTimer.Enabled = false;
                    ComputerTurn();
                }
            }
            else
            {
                GameOver();
            } 
            
        }
        /*
        private void tickTimer_Tick(object sender, EventArgs e)
        {
            currentTimer--;
            timerLabel.Text = $"Time Left: {currentTimer}";
            if (currentTimer <= 0)
            {
                GameOver();
            }
            tickTimer.Enabled = false;
        }
        */
    }
}
