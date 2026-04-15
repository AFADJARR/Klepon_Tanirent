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
                    MainForm menuUtama = new MainForm();
                    menuUtama.Show();
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

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Koneksi konn = new Koneksi();
            SqlConnection conn = konn.GetConn();

            try
            {

                conn.Open();
                MessageBox.Show("Mantap Bang! Koneksi ke Database DBsewatani BERHASIL.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Waduh Gagal Connect Bang!\n\nError: " + ex.Message, "Koneksi Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            conn.ConnectionString = @"Data Source=JONNISHEREEE\FADJAR;Initial Catalog=DBsewatani;Integrated Security=True";
            return conn;
        }
    }
}