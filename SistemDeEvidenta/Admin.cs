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
    public partial class Admin : Form
    {
        readonly SqlConnection con = new SqlConnection(ClasaConString.ConString());
        public Admin()
        {
            InitializeComponent();
        }
        private void BBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["FereastraPrincipala"].Show();
        }
        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
                return;
            else
                Application.OpenForms["FereastraPrincipala"].Close();
        }
        public void PuneTaxe()
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                LV.BackgroundImage = null;
                LV.Columns.Clear();
                LV.Items.Clear();
                LV.Columns.Add("ID", 40, HorizontalAlignment.Center);
                LV.Columns.Add("Denumire", 220, HorizontalAlignment.Center);
                LV.Columns.Add("Descriere",220, HorizontalAlignment.Center);
                LV.View = View.Details;
                SqlCommand cmd = new SqlCommand("select *from tiptaxe order by denumire asc", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "test");
                DataTable dt = ds.Tables["test"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LV.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    LV.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    LV.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        private void BAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(TBDenumire.Text))
                {
                    MessageBox.Show("Nu ati introdus denumire", "Eroare", MessageBoxButtons.OK);
                    return;
                }
                if (String.IsNullOrEmpty(TBDescriere.Text))
                {
                    MessageBox.Show("Nu ati introdus descriere", "Eroare", MessageBoxButtons.OK);
                    return;
                }
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand($"insert into tiptaxe values(@den,@des)", con);
                cmd.Parameters.AddWithValue("@den", TBDenumire.Text);
                cmd.Parameters.AddWithValue("@des", TBDescriere.Text);
                cmd.ExecuteNonQuery();
                TBDenumire.Text = "";
                TBDescriere.Text = "";
                PuneTaxe();
                MessageBox.Show("Taxa adaugata cu succes");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            PuneTaxe();
        }
    }
}
