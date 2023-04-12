using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LatihanLKS
{
    public partial class Admin_Navigation_Form : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=lat_lks");
        public Admin_Navigation_Form()
        {
            InitializeComponent();
        }

        public void tampil()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT a.Id_Log, b.Username, a.waktu, a.aktifitas FROM tbl_log a INNER JOIN tbl_user b ON a.Id_User = b.Id_User WHERE waktu LIKE '%"+dateTimePicker1.Text+"%' ", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form_Login().Show();
        }

        private void Admin_Navigation_Form_Load(object sender, EventArgs e)
        {
            try
            { 
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT a.Id_Log, b.Username, a.waktu, a.aktifitas FROM tbl_log a INNER JOIN tbl_user b ON a.Id_User = b.Id_User ", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            tampil();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_User().Show();
        }

        private void btnKelolaObat_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_Obat().Show();
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_Laporan().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
