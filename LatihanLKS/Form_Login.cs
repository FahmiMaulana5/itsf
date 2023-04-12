using System;
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
    public partial class Form_Login : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=lat_lks");
        public Form_Login()
        {
            InitializeComponent();
        }


        void Login()
        {
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT Id_User, Nama_User, Tipe_User FROM tbl_user WHERE Username = '" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    
                    foreach(DataRow dr in dt.Rows)
                    {
                        Pegawai.NamaPegawai = dr["Nama_User"].ToString();
                        Pegawai.IdPegawai = dr["Id_User"].ToString();

                        if (dr["Tipe_User"].ToString() == "Admin")
                        {
                            this.Hide();
                            new Admin_Navigation_Form().Show();
                        }else if (dr["Tipe_User"].ToString() == "Apoteker")
                        {
                            this.Hide();
                            new Form_Kelola_Resep().Show();
                        }
                        else if (dr["Tipe_User"].ToString() == "Kasir")
                        {
                            this.Hide();
                            new Form_Kelola_Transaksi().Show();
                        }
                    }

                    insert_log();
                }
                else
                {
                    MessageBox.Show("username atau password yang anda masukkan tidak sesuai !");
                }
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

        void insert_log()
        {
            
                DateTime time = DateTime.Now;

                //conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_log (waktu, aktifitas, Id_User) VALUES (@time,'login', @id_user)", conn);
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@id_user", Pegawai.IdPegawai);
                cmd.ExecuteNonQuery();
                //conn.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername is null ||  txtPassword is null)
            {
                MessageBox.Show("Semua kolom harus di isi");

            }
            else
            {
                Login();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
