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
    public partial class Taxe : Form
    {
        public static string CONSTRING = ClasaConString.ConString();
        //aduag asta aici ca sa fie
        readonly SqlConnection con = new SqlConnection(CONSTRING);
        public Taxe()
        {
            InitializeComponent();
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["FereastraPrincipala"].Show();
        }

        private void Taxe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
                return;
            else
                Application.OpenForms["FereastraPrincipala"].Close();
        }
        public void PuneTaxe()
        {
            int ind = Int32.Parse(LElev.Text);
            SqlDataAdapter adp = new SqlDataAdapter($"SELECT taxe.id as 'ID', elevi.nume as 'Nume', elevi.prenume as 'Prenume', taxe.valoare as 'Taxa', taxe.platit as 'Platit' FROM elevi LEFT JOIN taxe ON taxe.idelev = {ind} WHERE elevi.id = {ind}; ", con);
            System.Data.DataTable tabel = new System.Data.DataTable();
            adp.Fill(tabel);
            DGVTaxe.DataSource = tabel;
        }
        private void BCautare_Click(object sender, EventArgs e)
        {
            var mmap = new Dictionary<string, string>(){
    { "Nume", "nume" },
    { "Prenume", "prenume" },
    { "Clasa", "clasa" },
    { "Nr. Tlf.", "nrtlf" },
    { "Email", "email" },
    { "Judet", "judet" },
    { "Adresa", "adresa" },
    { "Sex", "sex" },
    { "Oras", "oras" }};
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                if (string.IsNullOrEmpty(CBCriteriu.Text) || CBCriteriu.SelectedIndex == -1)
                {
                    MessageBox.Show("Nu ati ales criteriu de cautare", "Eroare", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(TBCriteriu.Text))
                {
                    MessageBox.Show("Nu ati introdus date de cautare", "Eroare", MessageBoxButtons.OK);
                    return;
                }

                SqlDataAdapter adp = new SqlDataAdapter($"select id, nume as 'Nume',prenume as 'Prenume',clasa as 'Clasa',nrtlf as 'Nr. de tlf.',email as 'Email' from elevi where {mmap[CBCriteriu.Text]} like '%" + TBCriteriu.Text + "%'", con);
                System.Data.DataTable tabel = new System.Data.DataTable();
                adp.Fill(tabel);
                DGVCriteriu.DataSource = tabel;
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());   
            }
        }

        private void DGVCriteriu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            if (ind < 0) return;
            LElev.Text = DGVCriteriu.Rows[ind].Cells[0].Value.ToString();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                PuneTaxe();
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void DGVTaxe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            if (ind < 0) return;
            LTaxa.Text = DGVTaxe.Rows[ind].Cells[0].Value.ToString();
        }
        void GetVaP(ref int valoare,ref int plata)
        {
            int idp = Int16.Parse(LTaxa.Text);
            if (con.State != ConnectionState.Open)
                con.Open();
            string sqr = $"select valoare,platit from taxe where id={idp}";
            SqlCommand cmd = new SqlCommand(sqr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("valoare", typeof(int));
            dt.Columns.Add("platit", typeof(int));
            dt.Load(rdr);
            valoare = Int32.Parse(dt.Rows[0]["valoare"].ToString());
            plata = Int32.Parse(dt.Rows[0]["platit"].ToString());
        }
        bool ValidNr(string txt)
        {
            if (String.IsNullOrEmpty(txt))
                return false;
            for (int i = 0; i < txt.Length; i++)
                if (!Char.IsDigit(txt[i]))
                    return false;
            return true;
        }
        void AlterTaxa(int ind, int nval)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand($"update taxe set platit = {nval} where id = {ind}", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tranzactie inregistrata", "OK", MessageBoxButtons.OK);
                PuneTaxe();
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void BAnPlata_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LTaxa.Text))
            {
                MessageBox.Show("Nu ati selectat o taxa", "Eroare", MessageBoxButtons.OK);
                return;
            }
            int ind = Int16.Parse(LTaxa.Text);
            int valoare=0, platit=0;
            GetVaP(ref valoare,ref platit);
            if(!ValidNr(TBPlata.Text))
            {
                MessageBox.Show("Valoare invalida", "Eroare", MessageBoxButtons.OK);
                return;
            }
            int nval = Int32.Parse(TBPlata.Text);
            if(nval>platit)
            {
                MessageBox.Show("Suma este prea mare", "Eroare", MessageBoxButtons.OK);
                return;
            }
            nval = platit - nval;
            AlterTaxa(ind, nval);
        }

        private void BPlata_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(LTaxa.Text))
            {
                MessageBox.Show("Nu ati selectat o taxa", "Eroare", MessageBoxButtons.OK);
                return;
            }
            int ind = Int16.Parse(LTaxa.Text);
            int valoare = 0, platit = 0;
            GetVaP(ref valoare, ref platit);
            if (!ValidNr(TBPlata.Text))
            {
                MessageBox.Show("Valoare invalida", "Eroare", MessageBoxButtons.OK);
                return;
            }
            int nval = Int32.Parse(TBPlata.Text);
            if (nval +platit > valoare)
            {
                MessageBox.Show("Suma este prea mare", "Eroare", MessageBoxButtons.OK);
                return;
            }
            nval += platit;
            AlterTaxa(ind, nval);
            if(nval==valoare)
            {
                //sterge tranzactie
                //adauga in alta baza de date pt history
            }
        }

        private void BShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                
                SqlDataAdapter adp = new SqlDataAdapter($"select id, nume as 'Nume',prenume as 'Prenume',clasa as 'Clasa',nrtlf as 'Nr. de tlf.',email as 'Email' from elevi ", con);
                System.Data.DataTable tabel = new System.Data.DataTable();
                adp.Fill(tabel);
                DGVCriteriu.DataSource = tabel;
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void Taxe_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                listView1.Columns.Add("ID",30,HorizontalAlignment.Center);
                listView1.Columns.Add("Denumire",180,HorizontalAlignment.Center);
                listView1.Columns.Add("Descriere",332,HorizontalAlignment.Center);
                listView1.View = View.Details;
                SqlCommand cmd = new SqlCommand("select * from tiptaxe", con);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "test");
                DataTable dt = ds.Tables["test"];
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                }
                con.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void BATaxa_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedIndices.Count!=1)
            {
                MessageBox.Show("Nu ati selectat o taxa", "Eroare", MessageBoxButtons.OK);
                return;
            }
            if(!ValidNr(LElev.Text))
            {
                MessageBox.Show("Nu ati selectat un elev", "Eroare", MessageBoxButtons.OK);
                return;
            }
            if (!ValidNr(TBTaxa.Text))
            {
                MessageBox.Show("Valoare taxa invalida", "Eroare", MessageBoxButtons.OK);
                return;
            }
            DialogResult dr =  MessageBox.Show($"Adaugati o taxa in valoare de {TBTaxa.Text} lei elevului cu id-ul {LElev.Text}", "Confirmare", MessageBoxButtons.YesNo);
            if(dr==DialogResult.Yes)
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("insert into taxe values (@idelev, @idtaxa ,@valoare, 0)", con);
                    cmd.Parameters.AddWithValue("@idelev", Int16.Parse(LElev.Text));
                    int idtax = Int32.Parse(listView1.SelectedItems[0].Text); 
                    cmd.Parameters.AddWithValue("@idtaxa", idtax);
                    cmd.Parameters.AddWithValue("@valoare", Int32.Parse(TBTaxa.Text));
                    cmd.ExecuteNonQuery();
                    PuneTaxe();
                    con.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.ToString());
                }
            }
        }
    }
}
