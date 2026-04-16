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

namespace Tanirent
{
    public partial class Form_Penyewa : Form
    {
        Koneksi konn = new Koneksi();

        public Form_Penyewa()
        {
            InitializeComponent();
        }

        private void Form_Penyewa_Load(object sender, EventArgs e)
        {
            TampilkanPenyewa();
        }

        void TampilkanPenyewa()
        {
            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string query = "SELECT id_penyewa, nama_petani, no_hp, alamat FROM Penyewa";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader(); 

                DataTable dt = new DataTable();
                dt.Load(dr); 
                dgvPenyewa.DataSource = dt;

                dgvPenyewa.Columns["id_penyewa"].HeaderText = "ID";
                dgvPenyewa.Columns["nama_petani"].HeaderText = "Nama Petani";
                dgvPenyewa.Columns["no_hp"].HeaderText = "No. HP";
                dgvPenyewa.Columns["alamat"].HeaderText = "Alamat";
                dgvPenyewa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dr.Close(); 
            }
            catch (Exception ex) { MessageBox.Show("Gagal Tampil: " + ex.Message); }
            finally { conn.Close(); }
        }

       
    }
}