﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemDeEvidenta
{
    public partial class FereastraPrincipala : Form
    {
        public Elevi form2 = new Elevi();

        public FereastraPrincipala()
        {
            InitializeComponent();
        }

        private void FereastraPrincipala_Load(object sender, EventArgs e)
        {
            
        }

        private void BElevi_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2.Show();
        }
    }
}