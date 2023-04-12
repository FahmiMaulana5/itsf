using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LatihanLKS
{
    public partial class Form_Kelola_Obat : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=lat_lks");

        public Form_Kelola_Obat()
        {
            InitializeComponent();
        }

        void tambah()
        {
            try
            {

                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_obat(Kode_Obat, Nama_Obat, Expired_Date, Jumlah, Harga) VALUES ('"+txtKode.Text+"', '"+txtNama.Text+"', '"+this.dt.Text+"', '"+txtJumlah.Text+"', '"+txtHarga.Text+"')", conn);
                cmd.ExecuteNonQuery();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally { 
                conn.Close();
            }
        }

        void edit()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tbl_obat SET Nama_Obat = '"+txtNama.Text+"', Expired_Date = '"+dt.Text+"', Jumlah = '"+txtJumlah.Text+"', Harga = '"+txtHarga.Text+"' WHERE Kode_Obat = '"+txtKode.Text+"'", conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        void hapus()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_obat WHERE Kode_Obat = '" + txtKode.Text + "'", conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        void tampil()
        {
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM tbl_obat WHERE Nama_Obat LIKE '"+txtCari.Text+"%'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView2.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {

        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
              
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {


        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtHarga_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled= true;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
          
            
            
        }

        private void Form_Kelola_Obat_Load(object sender, EventArgs e)
        {
            tampil();
           
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            tampil();
        }

        private void btnKelolaUser_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_User().Show();
        }

        private void btnKelolaLaporan_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_Laporan().Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Login().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click_1(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Apakah anda yakin?", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (d == DialogResult.Yes)
            {
                tambah();
                tampil();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (txtKode.Text == "" || txtNama.Text == "" || dt.Text == "" || txtJumlah.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Semua kolom harus di isi");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (d == DialogResult.Yes)
                {
                    edit();
                    tampil();
                }

            }
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (txtKode.Text == "" || txtNama.Text == "" || dt.Text == "" || txtJumlah.Text == "" || txtHarga.Text == "")
            {
                MessageBox.Show("Semua kolom harus di isi");
            }
            else
            {

                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (d == DialogResult.Yes)
                {
                    hapus();
                    tampil();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];

            txtKode.Text = row.Cells["Kode_Obat"].Value.ToString();
            txtNama.Text = row.Cells["Nama_Obat"].Value.ToString();
            dt.Text = row.Cells["Expired_Date"].Value.ToString();
            txtJumlah.Text = row.Cells["Jumlah"].Value.ToString();
            txtHarga.Text = row.Cells["Harga"].Value.ToString();
        }
    }
}
