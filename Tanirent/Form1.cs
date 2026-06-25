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

namespace Tanirent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Username dan Password harus diisi, Bang!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Koneksi konn = new Koneksi();
            SqlConnection conn = konn.GetConn();
            

            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Admin WHERE username = @user AND password_hash = @pass";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", txtUser.Text);
                cmd.Parameters.AddWithValue("@pass", txtPass.Text);

                int hasil = (int)cmd.ExecuteScalar();

                if (hasil > 0)
                {
                    MessageBox.Show("Login Sukses! Selamat Datang Admin.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username atau Password salah! Periksa kembali.", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtUser.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Error: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }



    class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=192.168.1.82;Initial Catalog=DBsewatani;User ID=sa;Password=Afadjarr67688;";
            return conn;
        }
    }


}