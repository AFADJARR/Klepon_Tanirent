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
                string query = "SELECT * FROM vw_DaftarPenyewa";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                
                dgvPenyewa.DataSource = null;
                dgvPenyewa.DataSource = dt;

                
                if (dgvPenyewa.Columns.Count > 0)
                {
                    if (dgvPenyewa.Columns.Contains("id_penyewa"))
                        dgvPenyewa.Columns["id_penyewa"].HeaderText = "ID";

                    if (dgvPenyewa.Columns.Contains("nama_petani"))
                        dgvPenyewa.Columns["nama_petani"].HeaderText = "Nama Petani";

                    if (dgvPenyewa.Columns.Contains("no_hp"))
                        dgvPenyewa.Columns["no_hp"].HeaderText = "No. HP";

                    if (dgvPenyewa.Columns.Contains("alamat"))
                        dgvPenyewa.Columns["alamat"].HeaderText = "Alamat";

                    dgvPenyewa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Tampil: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaPetani.Text) || string.IsNullOrWhiteSpace(txtNoHp.Text))
            {
                MessageBox.Show("Nama dan No HP wajib diisi, Bang!", "Peringatan");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(konn.GetConn().ConnectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_InsertPenyewa", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        
                        cmd.Parameters.Add("@NamaPetani", SqlDbType.VarChar).Value = txtNamaPetani.Text;
                        cmd.Parameters.Add("@NoHp", SqlDbType.VarChar).Value = txtNoHp.Text;
                        cmd.Parameters.Add("@Alamat", SqlDbType.Text).Value = txtAlamat.Text;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Penyewa Berhasil Disimpan via SP!");
                        TampilkanPenyewa();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

    }
}