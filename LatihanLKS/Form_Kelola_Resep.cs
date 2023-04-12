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
    public partial class Form_Kelola_Resep : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=lat_lks");
        public Form_Kelola_Resep()
        {
            InitializeComponent();
        }

        void edit()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tbl_resep SET Tgl_Resep = '"+dtTanggal.Text+"', Nama_Dokter = '"+txtNamaDok.Text+"', Nama_Pasien = '"+txtNama.Text+"', Nama_ObatDibeli = '"+txtNamaOb.Text+"', Jumlah_ObatDibeli = '"+txtJum.Text+ "' WHERE No_Resep = '"+txtNo.Text+"'", conn);
                cmd.ExecuteNonQuery();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally { 
                conn.Close();
            }
        }

        void hapus()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_resep WHERE No_Resep='"+txtNo.Text+"'", conn);
                cmd.ExecuteNonQuery();
            }catch(Exception ex)
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
            conn.Open();

            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM tbl_resep WHERE Nama_ObatDibeli LIKE '"+txtCari.Text+"%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.DataSource= dt;

            conn.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form_Login().Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtNo.Text == "" || dtTanggal.Text == "" || txtNama.Text == "" || txtNamaDok.Text == "" || txtNamaOb.Text == "" || txtJum.Text == "")
            {
                MessageBox.Show("Semua kolom harus di isi");
            }
            else
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Apakah anda yakin?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    edit();
                    tampil();
                }

            }
        }

        private void txtJum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)){
                e.Handled = true;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtNo.Text == "" || dtTanggal.Text == "" || txtNama.Text == "" || txtNamaDok.Text == "" || txtNamaOb.Text == "" || txtJum.Text == "")
            {
                MessageBox.Show("Semua kolom harus di isi");
            }
            else
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Apakah anda yakin?", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialog == DialogResult.Yes)
                {
                    hapus();
                    tampil();
                }

            }
        }

        private void Form_Kelola_Resep_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            tampil();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            txtNo.Text = row.Cells["No_Resep"].Value.ToString();
            dtTanggal.Text = row.Cells["Tgl_Resep"].Value.ToString();
            txtNama.Text = row.Cells["Nama_Pasien"].Value.ToString();
            txtNamaDok.Text = row.Cells["Nama_Dokter"].Value.ToString();
            txtNamaOb.Text = row.Cells["Nama_ObatDibeli"].Value.ToString();
            txtJum.Text = row.Cells["Jumlah_ObatDibeli"].Value.ToString();
        }
    }
}
