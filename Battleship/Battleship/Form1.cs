﻿using System;
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

            gl = new GameLogic();
            this.Controls.Add(gl.p1);
            this.Controls.Add(gl.p2);
        }

        

        private void START_Click(object sender, EventArgs e)
        {
            gl.p2.CreateBotShips();
        }

        
    }
}
