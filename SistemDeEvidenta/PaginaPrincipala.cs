using System;
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

        public FereastraPrincipala()
        {
            InitializeComponent();
        }
        
        private void BElevi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Elevi form2 = new Elevi();
            form2.Show();
    }

        private void BProfesori_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profesori form2 = new Profesori();
            form2.Show();
        }

        private void BTaxa_Click(object sender, EventArgs e)
        {
            this.Hide();
            Taxe form2 = new Taxe();
            form2.Show();
        }

        private void BRapoarte_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rapoarte form2 = new Rapoarte();
            form2.Show();
        }

        private void BAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin form2 = new Admin();
            form2.Show();
        }
    }
}
