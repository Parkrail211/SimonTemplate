using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            //TODO: show the length of the pattern
            lengthLabel.Text = $"{Form1.length}";
            Form1.highScoreList.Add(Form1.length);
            Form1.highScoreList.Sort();
            Form1.highScoreList.Reverse();

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    highScoreLabel.Text += $"\n- {Form1.highScoreList[i]}";
                }
                catch
                {
                    break;
                }
            }
           
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //TODO: close this screen and open the MenuScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
            ms.Location = new Point((f.Width - ms.Width) / 2, (f.Height - ms.Height) / 2);
        }

        private void patternLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
