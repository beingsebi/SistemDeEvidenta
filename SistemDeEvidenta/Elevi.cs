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
    public partial class Elevi : Form
    {
        public static string CONSTRING = ClasaConString.ConString();
        //aduag asta aici ca sa fie
        readonly SqlConnection con = new SqlConnection(CONSTRING);
        public Elevi()
        {
            InitializeComponent();
        }
        private void BBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms["FereastraPrincipala"].Show();
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
                CBJudet.SelectedIndex = -1;
                CBOras.SelectedIndex = -1;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
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
            LElev.Text = "";
            try
            {
                PuneJudete();
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
            int id= Int32.Parse(dt.Rows[0]["id"].ToString());
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
        public bool VerifSex()
        {
            if (!RBMasc.Checked && !RBFem.Checked)
                return false;
            return true;
        }
        public bool ValidareDate()
        {
            if (!ClasaValidareDate.VerifClasa(TBClasa.Text))
            {
                MessageBox.Show("Clasa invalida.", "Eroare", MessageBoxButtons.OK);
                return false;
            }
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
            if (!ClasaValidareDate.VerifData(DateTimeInreg))
            {
                MessageBox.Show("Data de Inregistrare invalida", "Eroare", MessageBoxButtons.OK);
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
                string sqr = "insert into elevi values(" +
                    "@clasa," +
                    "@sex," +
                    "@nume," +
                    "@prenume," +
                    "@email," +
                    "@nrtlf," +
                    "@adresa," +
                    "@datanast," +
                    "@datainreg," +
                    "@judet," +
                    "@idjud," +
                    "@oras," +
                    "@idoras" +
                    ")";

                SqlCommand cmd;
                try
                {
                    cmd= new SqlCommand(sqr, con);
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    return;
                }
                int clasa = Int16.Parse(TBClasa.Text);
                cmd.Parameters.AddWithValue("@clasa", clasa);

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

                string dinreg = DateTimeInreg.Value.ToString("MM-dd-yyyy");
                cmd.Parameters.AddWithValue("@datainreg", dinreg);

                string judet = CBJudet.Text;
                cmd.Parameters.AddWithValue("@judet", judet);
                string oras = CBOras.Text;
                cmd.Parameters.AddWithValue("@oras", oras);

                try
                {
                    int idjudet = -1;
                    idjudet = GetIdJudet();
                    cmd.Parameters.AddWithValue("@idjud", idjudet);
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    return;
                }

                try
                {
                    int idoras = -1;
                    idoras = GetIdOras();
                    cmd.Parameters.AddWithValue("@idoras", idoras);
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.ToString());
                    return;
                }
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Adaugare reusita.", "OK", MessageBoxButtons.OK);
                BGolire_Click(this, EventArgs.Empty);
                BDate_Click(this, EventArgs.Empty);
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
                    MessageBox.Show("Nu ati ales criteriu de cautare","Eroare",MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(TBCriteriu.Text))
                {
                    MessageBox.Show("Nu ati introdus date de cautare", "Eroare", MessageBoxButtons.OK);
                    return;
                }

                SqlDataAdapter adp = new SqlDataAdapter($"select id, nume as 'Nume',prenume as 'Prenume',clasa as 'Clasa',nrtlf as 'Nr. de tlf.',email as 'Email',judet as 'Judet',oras as 'Oras',adresa as 'Adresa'" +
                    $",sex as 'Sex',dnastere as 'Data de nastere',dinregistrare as 'Data de inregistrare' from elevi where {mmap[CBCriteriu.Text]} like '%"+ TBCriteriu.Text+"%'", con);
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
            int ind = e.RowIndex;
            if (ind < 0) return;
            LElev.Text = DGVCriteriu.Rows[ind].Cells[0].Value.ToString();

            TBClasa.Text = DGVCriteriu.Rows[ind].Cells[3].Value.ToString();

            bool valsex =(bool) DGVCriteriu.Rows[ind].Cells[9].Value;
            if (valsex)
            {
                RBMasc.Checked = true;
                RBFem.Checked = false;
            }
            else
            {
                RBMasc.Checked = false;
                RBFem.Checked = true;
            }

            TBNume.Text = DGVCriteriu.Rows[ind].Cells[1].Value.ToString();
            TBPrenume.Text = DGVCriteriu.Rows[ind].Cells[2].Value.ToString();
            TBEmail.Text = DGVCriteriu.Rows[ind].Cells[5].Value.ToString();
            TBTlf.Text = DGVCriteriu.Rows[ind].Cells[4].Value.ToString();
            TBAdresa.Text = DGVCriteriu.Rows[ind].Cells[8].Value.ToString();
            DatePickerNastere.Value = Convert.ToDateTime( DGVCriteriu.Rows[ind].Cells[10].Value);
            DateTimeInreg.Value = Convert.ToDateTime( DGVCriteriu.Rows[ind].Cells[11].Value);
            CBJudet.SelectedIndex = CBJudet.FindStringExact(DGVCriteriu.Rows[ind].Cells[6].Value.ToString());
            CBJudet_SelectionChangeCommitted(this, EventArgs.Empty);
            CBOras.SelectedIndex = CBOras.FindStringExact(DGVCriteriu.Rows[ind].Cells[7].Value.ToString());
        }

        private void Bstergere_Click(object sender, EventArgs e)
        {
            string text = LElev.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Nu ati selectat niciun elev.", "Eroare", MessageBoxButtons.OK);
                return;
            }
            try
            {
                int id = Int16.Parse(LElev.Text);
                DialogResult dr = MessageBox.Show($"Stergeti elevul cu id-ul {id}?", "Confirmare", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlCommand cmd = new SqlCommand($"delete from elevi where id={id}", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stergere reusita");
                    BDate_Click(this, EventArgs.Empty);
                    con.Close();
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void BActualizare_Click(object sender, EventArgs e)
        {
            string text = LElev.Text;
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Nu ati selectat niciun elev.", "Eroare", MessageBoxButtons.OK);
                return;
            }
            bool ok = ValidareDate();
            if (!ok) return;
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                string sqr = "update elevi set " +
                    "clasa=@clasa," +
                    "sex=@sex," +
                    "nume=@nume," +
                    "prenume=@prenume," +
                    "email=@email," +
                    "nrtlf=@nrtlf," +
                    "adresa=@adresa," +
                    "dnastere=@datanast," +
                    "dinregistrare=@datainreg," +
                    "judet=@judet," +
                    "idjudet=@idjud," +
                    "oras=@oras," +
                    "idoras=@idoras" +
                    " where id=@id";

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
                int clasa = Int16.Parse(TBClasa.Text);
                cmd.Parameters.AddWithValue("@clasa", clasa);

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

                string dinreg = DateTimeInreg.Value.ToString("MM-dd-yyyy");
                cmd.Parameters.AddWithValue("@datainreg", dinreg);

                string judet = CBJudet.Text;
                cmd.Parameters.AddWithValue("@judet", judet);
                string oras = CBOras.Text;
                cmd.Parameters.AddWithValue("@oras", oras);
                cmd.Parameters.AddWithValue("@id", Int16.Parse(LElev.Text));
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
                MessageBox.Show("Actualizare reusita.", "OK", MessageBoxButtons.OK);
                BDate_Click(this, EventArgs.Empty);
            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void BDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlDataAdapter adp = new SqlDataAdapter($"select id, nume as 'Nume',prenume as 'Prenume',clasa as 'Clasa',nrtlf as 'Nr. de tlf.',email as 'Email',judet as 'Judet',oras as 'Oras',adresa as 'Adresa'" +
                    $",sex as 'Sex',dnastere as 'Data de nastere',dinregistrare as 'Data de inregistrare' from elevi", con);
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

        private void Elevi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close"))
                return;
            else
                Application.OpenForms["FereastraPrincipala"].Close();
        }
    }
}
