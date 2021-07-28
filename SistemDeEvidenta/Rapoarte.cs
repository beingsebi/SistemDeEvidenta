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
using System.Data.SqlTypes;
using System.Diagnostics;

namespace SistemDeEvidenta
{
    public partial class Rapoarte : Form
    {
        public Rapoarte()
        {
            InitializeComponent();
        }
        readonly SqlConnection con = new SqlConnection(ClasaConString.ConString());
        private void BBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["FereastraPrincipala"].Show();
        }
        private void Rapoarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
                return;
            else
                Application.OpenForms["FereastraPrincipala"].Close();
        }

        private void BElevi_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                LV.BackgroundImage = null;
                LV.Columns.Clear();
                LV.Items.Clear();
                LV.Columns.Add("Nume", 120, HorizontalAlignment.Center);
                LV.Columns.Add("Prenume", 120, HorizontalAlignment.Center);
                LV.Columns.Add("Clasa", 50, HorizontalAlignment.Center);
                LV.Columns.Add("Email", 120, HorizontalAlignment.Center);
                LV.Columns.Add("Nr. de Tlf.", 120, HorizontalAlignment.Center);
                LV.Columns.Add("Judet", 120, HorizontalAlignment.Center);
                LV.Columns.Add("Oras", 120, HorizontalAlignment.Center);
                LV.View = View.Details;
                SqlCommand cmd = new SqlCommand("select nume,prenume,clasa,"+
                    " email,nrtlf,judet,oras from elevi order by nume asc", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "test");
                DataTable dt = ds.Tables["test"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LV.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    for(int j=1;j<=6;j++)
                        LV.Items[i].SubItems.Add(dt.Rows[i].ItemArray[j].ToString());
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        private void BProf_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                LV.BackgroundImage = null;
                LV.Columns.Clear();
                LV.Items.Clear();
                LV.Columns.Add("Nume", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Prenume", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Materia", 103, HorizontalAlignment.Center);
                LV.Columns.Add("Experienta", 80, HorizontalAlignment.Center);
                LV.Columns.Add("Email", 110, HorizontalAlignment.Center);
                LV.Columns.Add("Nr. de Tlf.", 100, HorizontalAlignment.Center);
                LV.Columns.Add("Judet", 100, HorizontalAlignment.Center);
                LV.Columns.Add("Oras", 100, HorizontalAlignment.Center);
                LV.View = View.Details;
                SqlCommand cmd = new SqlCommand("select nume,prenume,materie,experienta," +
                    " email,nrtlf,judet,oras from profesori order by nume asc", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "test");
                DataTable dt = ds.Tables["test"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LV.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    for (int j = 1; j <= 7; j++)
                        LV.Items[i].SubItems.Add(dt.Rows[i].ItemArray[j].ToString());
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        private void BTaxe_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                LV.Columns.Clear();
                LV.Items.Clear();
                LV.BackgroundImage = null;
                LV.Columns.Add("Nume", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Prenume", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Email", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Nr. de Tlf.", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Taxa", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Valoare", 90, HorizontalAlignment.Center);
                LV.Columns.Add("Platit", 90, HorizontalAlignment.Center);
                LV.View = View.Details;
                SqlCommand cmd = new SqlCommand("select elevi.nume,elevi.prenume,elevi.email,elevi.nrtlf,tiptaxe.denumire,taxe.valoare,taxe.platit from taxe left join elevi on taxe.idelev = elevi.id left join tiptaxe on tiptaxe.id = taxe.idtaxa", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "test");
                DataTable dt = ds.Tables["test"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LV.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    for (int j = 1; j <= 6; j++)
                        LV.Items[i].SubItems.Add(dt.Rows[i].ItemArray[j].ToString());
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

    }
}
