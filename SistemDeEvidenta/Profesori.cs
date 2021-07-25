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
    public partial class Profesori : Form
    {
        public static string CONSTRING = "Data Source=DESKTOP-OJJL6LL\\SEBISERVER;Initial Catalog=logindb;Integrated Security=True";
        SqlConnection con = new SqlConnection(CONSTRING);

        public Profesori()
        {
            InitializeComponent();
        }

        private void BGolire_Click(object sender, EventArgs e)
        {
            RBMasc.Checked = RBFem.Checked = false;
            TBEmail.Text = TBTlf.Text = "";
            TBAdresa.Text = "";
            TBNume.Text = TBPrenume.Text = "";
            DatePickerNastere.Value = DateTime.Now;
            LElev.Text = "";
            CBExperienta.SelectedIndex = -1;
            try
            {
                PuneJudete();
                PuneMaterii();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void BBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["FereastraPrincipala"].Show();
        }

        private void Profesori_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
                return;
            else
                Application.OpenForms["FereastraPrincipala"].Close();
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
            CBJudet_SelectionChangeCommitted(this, EventArgs.Empty);
            CBJudet.SelectedIndex = -1;
        }
        public void PuneMaterii()
        {
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand("select materie from materii order by materie asc", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("materie", typeof(string));
            dt.Load(rdr);
            CBMaterii.ValueMember = "materie";
            CBMaterii.DataSource = dt;
            con.Close();
            CBMaterii.SelectedIndex = -1;
        }
        private void Profesori_Load(object sender, EventArgs e)
        {
            try
            {
                PuneJudete();
                PuneMaterii();
                CBJudet.SelectedIndex = -1;
                CBOras.SelectedIndex = -1;
                CBMaterii.SelectedIndex = -1;
                CBExperienta.SelectedIndex = -1;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        public int GetIdOras()
        {
            string oras = CBOras.Text;
            if (con.State != ConnectionState.Open)
                con.Open();
            string sqr = $"select id from orase where oras='{oras}'";
            SqlCommand cmd = new SqlCommand(sqr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Load(rdr);
            int id = Int32.Parse(dt.Rows[0]["id"].ToString());
            return id;
        }
        public int GetIdJudet()
        {
            string judet = CBJudet.Text;
            if (con.State != ConnectionState.Open)
                con.Open();
            string sqr = $"select id from judete where judet='{judet}'";
            SqlCommand cmd = new SqlCommand(sqr, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Load(rdr);
            int id = Int32.Parse(dt.Rows[0]["id"].ToString());
            return id;
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
                int idjud = Int32.Parse(dt.Rows[0]["id"].ToString());

                sqr = $"select oras from orase where idjudet={idjud} order by oras asc";
                SqlCommand ncmd = new SqlCommand(sqr, con);
                SqlDataReader nrdr = ncmd.ExecuteReader();
                DataTable ndt = new DataTable();
                ndt.Columns.Add("oras", typeof(string));
                ndt.Load(nrdr);
                CBOras.ValueMember = "oras";
                CBOras.DataSource = ndt;
                con.Close();
                CBOras.SelectedIndex = -1;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void Bstergere_Click(object sender, EventArgs e)
        {

        }
        public bool VerifSex()
        {
            if (!RBMasc.Checked && !RBFem.Checked)
                return false;
            return true;
        }
        public bool ValidareDate()
        {
            if (!VerifSex())
            {
                MessageBox.Show("Nu ati introdus sexul.", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifNume(TBNume.Text))
            {
                MessageBox.Show("Nume invalid", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifPrenume(TBPrenume.Text))
            {
                MessageBox.Show("Prenume invalid", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifEmail(TBEmail.Text))
            {
                MessageBox.Show("Email invalid", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifNrtlf(TBTlf.Text))
            {
                MessageBox.Show("Numar de telefon invalid", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifAdresa(TBAdresa.Text))
            {
                MessageBox.Show("Adresa invalida", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifData(DatePickerNastere))
            {
                MessageBox.Show("Data de nastere invalida", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifCB(CBJudet))
            {
                MessageBox.Show("Judet invalid", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifCB(CBOras))
            {
                MessageBox.Show("Oras invalid", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifCB(CBMaterii))
            {
                MessageBox.Show("Materie invalida", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            if (!ClasaValidareDate.VerifCB(CBExperienta))
            {
                MessageBox.Show("Experienta invalida", "Eroare", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        private void BAdaugare_Click(object sender, EventArgs e)
        {
            bool ok = ValidareDate();
            if (!ok) return;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string sqr = "insert into profesori values(" +
                    "@materie," +
                    "@sex," +
                    "@nume," +
                    "@prenume," +
                    "@email," +
                    "@nrtlf," +
                    "@adresa," +
                    "@datanast," +
                    "@experienta," +
                    "@judet," +
                    "@idjud," +
                    "@oras," +
                    "@idoras" +
                    ")";

                SqlCommand cmd;
                try
                {
                    cmd = new SqlCommand(sqr, con);
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    return;
                }
                string materie = CBMaterii.Text;
                cmd.Parameters.AddWithValue("@materie", materie);

                bool sex;
                if (RBMasc.Checked == true)
                    sex = true;
                else sex = false;
                cmd.Parameters.AddWithValue("@sex", sex);

                string nume = TBNume.Text;
                cmd.Parameters.AddWithValue("@nume", nume);

                string prenume = TBPrenume.Text;
                cmd.Parameters.AddWithValue("@prenume", prenume);

                string email = TBEmail.Text;
                cmd.Parameters.AddWithValue("@email", email);

                string nrtlf = TBTlf.Text;
                cmd.Parameters.AddWithValue("@nrtlf", nrtlf);

                string adresa = TBAdresa.Text;
                cmd.Parameters.AddWithValue("@adresa", adresa);

                string dnast = DatePickerNastere.Value.ToString("MM-dd-yyyy");
                cmd.Parameters.AddWithValue("@datanast", dnast);

                string experienta = CBExperienta.Text;
                cmd.Parameters.AddWithValue("@experienta", experienta);

                string judet = CBJudet.Text;
                cmd.Parameters.AddWithValue("@judet", judet);
                string oras = CBOras.Text;
                cmd.Parameters.AddWithValue("@oras", oras);

                int idjudet = -1;
                try
                {
                    idjudet = GetIdJudet();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    return;
                }
                cmd.Parameters.AddWithValue("@idjud", idjudet);

                int idoras = -1;
                try
                {
                    idoras = GetIdOras();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    return;
                }
                cmd.Parameters.AddWithValue("@idoras", idoras);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Adaugare reusita.", "OK", MessageBoxButtons.OK);
                BGolire_Click(this, EventArgs.Empty);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void BCautare_Click(object sender, EventArgs e)
        {
            var mmap = new Dictionary<string, string>(){
    { "Nume", "nume" },
    { "Prenume", "prenume" },
    { "Clasa", "clasa" },
    { "Nr. Tlf.", "nrtlf" },
    {"Materie","materie" },
    {"Experienta","experienta" },
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

                SqlDataAdapter adp = new SqlDataAdapter($"select id, nume as 'Nume',prenume as 'Prenume',materie as 'Materie',nrtlf as 'Nr. de tlf.',email as 'Email',judet as 'Judet',oras as 'Oras',adresa as 'Adresa'" +
                    $",sex as 'Sex',dnastere as 'Data de nastere',experienta as 'Experienta' from profesori where {mmap[CBCriteriu.Text]}=@val", con);
                adp.SelectCommand.Parameters.AddWithValue("@val", TBCriteriu.Text);
                System.Data.DataTable tabel = new System.Data.DataTable();
                adp.Fill(tabel);
                con.Close();
                DGVCriteriu.DataSource = tabel;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void DGVCriteriu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
