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
    public partial class Form_Kelola_User : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=lat_lks");
        public Form_Kelola_User()
        {
            InitializeComponent();
        }

        public static string TipeUser;



        void Tambah()
        {


            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO tbl_user (Tipe_User, Nama_User, Alamat, Telpon, Username, Password) VALUES ('"+CbTipeUser.Text+"', '" + txtNama.Text + "', '" + txtAlamat.Text + "', '" + txtTelepon.Text + "', '" + txtUserName.Text + "', '" + txtPassword.Text + "')", conn);
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

        void Edit()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE tbl_user SET Tipe_User = '"+CbTipeUser.Text+"', Nama_User = '"+txtNama.Text+"', Alamat = '"+txtAlamat.Text+"', Telpon = '"+txtTelepon.Text+ "',  Password = '"+txtPassword.Text+"' WHERE Username = '"+txtUserName.Text+"'", conn);
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

        void hapus()
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_user WHERE Username = '" + txtUserName.Text + "'", conn);
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
            try {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_user WHERE Nama_User LIKE '"+txtCari.Text+"%'", conn);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        

        void clear()
        {
            CbTipeUser.Text = "";
            txtNama.Text = "";
            txtTelepon.Text = "";
            txtAlamat.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form_Login().Show();
        }

        private void btnKelolaObat_Click(object sender, EventArgs e)
        {
             
        }

        private void btnKelolaLaporan_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CbTipeUser.Text == "" || txtNama.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "" || txtPassword.Text == "" || txtUserName.Text == "")
            {
                MessageBox.Show("Semuakolom harus di isi");
            }
            else
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Apakah anda yakin", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialog == DialogResult.Yes)
                {
                    hapus();
                    MessageBox.Show("Data berhasil di hapus");
                    clear();
                    tampil();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            //if(CbTipeUser is null && txtNama is null && txtTelepon is null && txtAlamat is null && txtPassword is null && txtUserName is null)
            DialogResult dialog;
            dialog = MessageBox.Show("Apakah anda yakin?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                Tambah();
                MessageBox.Show("Data berhasil ditambahkan");
                clear();
                tampil();
            }
            

            
        }

        private void Form_Kelola_User_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CbTipeUser.Text == "" || txtNama.Text == "" || txtTelepon.Text == "" || txtAlamat.Text == "" || txtPassword.Text == "" || txtUserName.Text == "")
            {
                MessageBox.Show("Semuakolom harus di isi");
            }
            else
            {
                DialogResult dialog;
                dialog = MessageBox.Show("Apakah anda yakin", "Informasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(dialog == DialogResult.Yes)
                {
                    Edit();
                    MessageBox.Show("Data berhasil di edit");
                    clear();
                    tampil();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
        }

        private void txtCari_KeyDown(object sender, KeyEventArgs e)
        {
            //tampil();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            tampil();
        }

        private void btnKelolaUser_Click(object sender, EventArgs e)
        {

        }

        private void btnKelolaObat_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_Obat().Show();
        }

        private void btnKelolaLaporan_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_Laporan().Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            new Form_Kelola_Laporan().Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                CbTipeUser.Text = row.Cells["Tipe_User"].Value.ToString();
                txtNama.Text = row.Cells["Nama_User"].Value.ToString();
                txtTelepon.Text = row.Cells["Telpon"].Value.ToString();
                txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
                txtUserName.Text = row.Cells["UserName"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
