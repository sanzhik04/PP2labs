using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        GameLogic gl;
        
        public Form1()
        {
            InitializeComponent();
            
            gl = new GameLogic(CheckGameOver);
            this.Controls.Add(gl.p1);
            this.Controls.Add(gl.p2);
        }
        public void CheckGameOver()
        {
            if (gl.p1.brain.leftShips == 0)
            {
                MessageBox.Show("ПОРАЖЕНИЕ");
            }
            if (gl.p2.brain.leftShips == 0)
            {
                MessageBox.Show("ПОБЕДА");
            }
        }



        private void START_Click(object sender, EventArgs e)
        {
            gl.p2.CreateBotShips();
            MessageBox.Show("GAME IS STARTED! YOU GO FIRST!");

        }

        private void Horizontal_Click(object sender, EventArgs e)
        {
            gl.p1.brain.Direction = "Horizontal";
            label1.Text = "Horizontal";

        }

        private void Vertical_Click(object sender, EventArgs e)
        {
            gl.p1.brain.Direction = "Vertical";
            label1.Text = "Vertical";
        }

        
    }
}
