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
    public partial class Form_Kelola_Laporan : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=lat_lks");
        public Form_Kelola_Laporan()
        {
            InitializeComponent();
        }

        private void dtSampai_ValueChanged(object sender, EventArgs e)
        {

        }

        void tampildg()
        {
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Tgl_Transaksi AS Tgl_Transaksi1, Total_Bayar AS TotalBayar FROM tbl_transaksi WHERE Tgl_Transaksi BETWEEN '"+dtDari.Text+"' AND '"+dtSampai.Text+"'", conn);
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

        void tampilchar()
        {
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT SUM(Total_Bayar) as total_bayar, DATE_FORMAT(Tgl_Transaksi, '%d/%m/%Y') as tgl FROM tbl_transaksi  WHERE Tgl_Transaksi BETWEEN '"+dtDari.Text+"' AND '"+dtSampai.Text+"' GROUP BY DATE_FORMAT(Tgl_Transaksi, '%d/%m/%Y')", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                chart1.DataSource = dt;
                chart1.Series[0].XValueMember = "tgl";
                chart1.Series[0].YValueMembers = "total_bayar";
                chart1.DataBind();

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
            tampildg();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tampilchar();
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {
           
        }

        private void btnKelolaObat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_Kelola_Laporan_Load(object sender, EventArgs e)
        {

        }

        private void btnKelolaUser_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_User().Show();
        }

        private void btnKelolaObat_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_Obat().Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Login().Show();
        }
    }
}
