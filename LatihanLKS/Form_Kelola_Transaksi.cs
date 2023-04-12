using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;

namespace LatihanLKS
{
    public partial class Form_Kelola_Transaksi : Form
    {
        

        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=lat_lks");
        DateTime time = DateTime.Now;
        int i = 0;
        
        public Form_Kelola_Transaksi()
        {
            InitializeComponent();
            lblUsername.Text = Pegawai.NamaPegawai;
            lblTanggal.Text = time.ToString();

            
        }
        

        void clear()
        {
            cbTyperesep.Text = "";
            txtNoresep.Text = "";
            dtTgl.Text = "";
            txtNamapas.Text = "";
            txtNamadok.Text = "";
            txtNamaOb.Text = "";
            txtHarga.Text = "";
            txtQuantity.Text = "";
        }

       
        void adddb()
        {
            try
            {
                conn.Open();
                foreach(DataGridViewRow dr in dataGridView1.Rows)
                {
                    if (dr.Cells[1].Value != null && dr.Cells[2].Value != null && dr.Cells[3].Value != null && dr.Cells[4].Value != null && dr.Cells[5].Value != null && dr.Cells[6].Value != null)
                    {
                        string no = dr.Cells[1].Value.ToString();
                        string tgl = dr.Cells[2].Value.ToString();
                        string nd = dr.Cells[4].Value.ToString();
                        string np = dr.Cells[3].Value.ToString();
                        string nob = dr.Cells[5].Value.ToString();
                        string jm = dr.Cells[7].Value.ToString();

                        MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_resep (No_Resep, Tgl_Resep, Nama_Dokter, Nama_Pasien, Nama_ObatDibeli, Jumlah_ObatDibeli, Id_Pasien) VALUES ('" + no + "', '" + tgl + "', '" + nd + "', '" + np + "', '" + nob + "', '" + jm + "', (SELECT Id_User FROM tbl_user WHERE Nama_User = '" + np + "'))", conn);
                        cmd.ExecuteNonQuery();
                    }
                }

               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            { 
                conn.Close();
            }
        }

        public void addinv()
        {
            // C# translation of the VB code
            // Declare a new packetDataset and a new DataTable
            packetDataSet1 ds = new packetDataSet1();
            DataTable dt = new DataTable();

            // Set dt to packetDataTable1 in ds
            dt = ds.Tables["packetDataTable1"];

            // Loop through each row in DataGridView1 and add its cells to dt
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dt.Rows.Add(
                dataGridView1.Rows[i].Cells[0].Value,
                dataGridView1.Rows[i].Cells[1].Value,
                dataGridView1.Rows[i].Cells[2].Value,
                dataGridView1.Rows[i].Cells[3].Value,
                dataGridView1.Rows[i].Cells[4].Value,
                dataGridView1.Rows[i].Cells[5].Value,
                dataGridView1.Rows[i].Cells[6].Value,
                dataGridView1.Rows[i].Cells[7].Value
                );
            }

            Form_Invoice Form2 = new Form_Invoice();

            // Set up the report viewer in Form2
            Form2.reportViewer1.LocalReport.ReportPath = "D:\\dev\\PBO\\LatihanLKS\\LatihanLKS\\Report2.rdlc";
            Form2.reportViewer1.LocalReport.DataSources.Clear();
            Form2.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("myDataSet1", dt));

            // Show Form2 and refresh the report viewer
            Form2.Show();
            Form2.reportViewer1.RefreshReport();

        }


        void addtroli()
        {
            // Mengambil nilai dari masing-masing textbox
            string textBox1Value = cbTyperesep.Text;
            string textBox2Value = txtNoresep.Text;
            string textBox3Value = dtTgl.Text;
            string textBox4Value = txtNamapas.Text;
            string textBox5Value = txtNamadok.Text;
            string textBox6Value = txtNamaOb.Text;
            string textBox7Value = txtHarga.Text;
            string textBox8Value = txtQuantity.Text;

            // Menambahkan baris baru pada datagridview
            dataGridView1.Rows.Add();


            // Menambahkan nilai dari masing-masing textbox pada kolom yang sesuai pada baris yang baru ditambahkan
            dataGridView1.Rows[i].Cells[0].Value = textBox1Value;
            dataGridView1.Rows[i].Cells[1].Value = textBox2Value;
            dataGridView1.Rows[i].Cells[2].Value = textBox3Value;
            dataGridView1.Rows[i].Cells[3].Value = textBox4Value;
            dataGridView1.Rows[i].Cells[4].Value = textBox5Value;
            dataGridView1.Rows[i].Cells[5].Value = textBox6Value;
            dataGridView1.Rows[i].Cells[6].Value = textBox7Value;
            dataGridView1.Rows[i].Cells[7].Value = textBox8Value;

            // Menambahkan satu pada variabel nomor urut
            i++;
        }

        

        private void Form_Kelola_Transaksi_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
           
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
            double nilai1 = 0;
            Double.TryParse(txtQuantity.Text, out nilai1);

            // Ubah nilai TextBox2 menjadi double
            double nilai2 = 0;
            Double.TryParse(txtHarga.Text, out nilai2);

            // Hitung hasil perkalian
            double hasil = nilai1 * nilai2;

            // Perbarui nilai Label1
            lblTotal.Text = hasil.ToString();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            double nilai1 = 0;
            Double.TryParse(txtQuantity.Text, out nilai1);

            // Ubah nilai TextBox2 menjadi double
            double nilai2 = 0;
            Double.TryParse(txtHarga.Text, out nilai2);

            // Hitung hasil perkalian
            double hasil = nilai1 * nilai2;

            // Perbarui nilai Label1
            lblTotal.Text = hasil.ToString();
        }

        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtHarga_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            

            double a = 0;

            Double.TryParse(txtBayar.Text, out a);

            double b = Convert.ToDouble(lblTotal.Text);

            double kembali = a - b;

            lblKembali.Text = kembali.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtBayar.Text = "";
            lblKembali.Text = "0";
            lblTotal.Text = "0";
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            DialogResult d;

            d = MessageBox.Show("Apakah anda yakin?", "Informasi", MessageBoxButtons.YesNo);

            if(d == DialogResult.Yes)
            {
                addtroli();
                clear();
            }
            
        }

        private void btnKosong_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Apakah anda yakin?", "Informasi", MessageBoxButtons.YesNo);

            if (d == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                i = 0;
                clear();
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            adddb();
            addinv();
        }

        private void cbTyperesep_TextChanged(object sender, EventArgs e)
        {
            if (cbTyperesep.Text == "Non Resep")
            {
                txtNoresep.Enabled = false;
                dtTgl.Enabled = false;
                txtNamapas.Enabled = false;
                txtNamadok.Enabled = false;
                txtHarga.Enabled = false;
            }
            else
            {
                txtNoresep.Enabled = true;
                dtTgl.Enabled = true;
                txtNamapas.Enabled = true;
                txtNamadok.Enabled = true;
                txtHarga.Enabled = true;
                
            }
        }

        private void lblTanggal_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form_Login().Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            cbTyperesep.Text = row.Cells[0].Value.ToString();
            txtNoresep.Text = row.Cells[1].Value.ToString();
            dtTgl.Text = row.Cells[2].Value.ToString();
            txtNamapas.Text = row.Cells[3].Value.ToString();
            txtNamadok.Text = row.Cells[4].Value.ToString();
            txtNamaOb.Text = row.Cells[5].Value.ToString();
            txtHarga.Text = row.Cells[6].Value.ToString();
            txtQuantity.Text = row.Cells[7].Value.ToString();
        }
    } 

}
