﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DM_Tool
{
    public partial class DiceRolls : Form
    {
        // just a window to see the dice rolls seperate from the main form
        public DiceRolls()
        {
            InitializeComponent();
            tbDiceBox.Text = DiceRoller.DiceRolls;
        }
    }
}
