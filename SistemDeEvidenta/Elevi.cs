using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemDeEvidenta
{
    public partial class Elevi : Form
    {
        public Elevi()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-29JAFDS\\SEBISERVER;Initial Catalog=mydb;Integrated Security=True");
        private void BBack_Click(object sender, EventArgs e)
        {
            this.Close();
            FereastraPrincipala nfrm = new FereastraPrincipala();
            nfrm.Show();
        }
        public void PuneJudete()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("select judet from judete order by judet asc", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("judet", typeof(string));
            dt.Load(rdr);
            CBJudet.ValueMember = "judet";
            CBJudet.DataSource = dt;
            con.Close();

            CBJudet_SelectionChangeCommitted(this,EventArgs.Empty);
        }
        private void Elevi_Load(object sender, EventArgs e)
        {
            try
            {
                PuneJudete();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void CBJudet_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            
        }

        private void CBJudet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            string judet = CBJudet.Text;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string sqr = $"select id from judete where judet='{judet}'";
                SqlCommand cmd = new SqlCommand(sqr, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Load(rdr);
                int idjud=Int32.Parse(dt.Rows[0]["id"].ToString());
               
               /* sqr = $"select oras from orase where idjudet={idjud} order by oras asc";
                SqlCommand ncmd = new SqlCommand(sqr, con);
                SqlDataReader nrdr = ncmd.ExecuteReader();
                DataTable ndt = new DataTable();
                ndt.Columns.Add("oras", typeof(string));
               // ndt.Load(nrdr);
                CBOras.ValueMember = "oras";
                CBOras.DataSource = ndt;
                
    */
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void BGolire_Click(object sender, EventArgs e)
        {
            TBClasa.Text = "";
            RBMasc.Checked = RBFem.Checked = false;
            TBEmail.Text = TBTlf.Text = "";
            TBAdresa.Text = "";
            TBNume.Text = TBPrenume.Text = "";
            DatePickerNastere.Value = DateTime.Now;
            DateTimeInreg.Value = DateTime.Now;
            PuneJudete();
            
        }
        public void AdaugaDate()
        {

        }
        public bool  ValidareDate()
        {
            return true;
        }
        private void BAdaugare_Click(object sender, EventArgs e)
        {
            bool MergeBoxa = ValidareDate();
            if (MergeBoxa)
                AdaugaDate();
            else
                MessageBox.Show("Date Invalide", "Eroare", MessageBoxButtons.OK);

            
        }

        
    }
}
