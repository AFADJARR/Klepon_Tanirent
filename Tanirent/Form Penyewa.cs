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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPenyewa.CurrentRow != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(konn.GetConn().ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.sp_UpdatePenyewa", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            int id = Convert.ToInt32(dgvPenyewa.CurrentRow.Cells[0].Value);

                            cmd.Parameters.Add("@PenyewaID", SqlDbType.Int).Value = id;
                            cmd.Parameters.Add("@NamaPetani", SqlDbType.VarChar).Value = txtNamaPetani.Text;
                            cmd.Parameters.Add("@NoHp", SqlDbType.VarChar).Value = txtNoHp.Text;
                            cmd.Parameters.Add("@Alamat", SqlDbType.Text).Value = txtAlamat.Text;

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data berhasil diperbarui via bray");
                            TampilkanPenyewa();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (dgvPenyewa.CurrentRow != null)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(konn.GetConn().ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.sp_DeletePenyewa", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            int id = Convert.ToInt32(dgvPenyewa.CurrentRow.Cells[0].Value);
                            cmd.Parameters.Add("@PenyewaID", SqlDbType.Int).Value = id;

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data berhasil dihapus bray");
                            TampilkanPenyewa();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
            }
        }

        private void dgvPenyewa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvPenyewa.Rows[e.RowIndex];

                    txtNamaPetani.Text = row.Cells["nama_petani"].Value.ToString();
                    txtNoHp.Text = row.Cells["no_hp"].Value.ToString();
                    txtAlamat.Text = row.Cells["alamat"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error klik: " + ex.Message);
                }
            }
        }

        private void btnTampilData_Click(object sender, EventArgs e)
        {
            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string query = "SELECT id_penyewa, nama_petani, no_hp, alamat FROM Penyewa ORDER BY id_penyewa DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt); 

                dgvPenyewa.DataSource = dt;

                if (dgvPenyewa.Columns.Count > 0)
                {
                    dgvPenyewa.Columns[0].HeaderText = "ID";
                    dgvPenyewa.Columns[1].HeaderText = "Nama Petani";
                    dgvPenyewa.Columns[2].HeaderText = "No. HP";
                    dgvPenyewa.Columns[3].HeaderText = "Alamat";
                    dgvPenyewa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Load Data: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void Form_Penyewa_Load_1(object sender, EventArgs e)
        {
            this.penyewaTableAdapter.Fill(this.dBsewataniDataSet.Penyewa);

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    conn.Open();
                    string query = "UPDATE Penyewa SET nama_petani='HACKED' WHERE id_penyewa='"
                        + txtNamaPetani.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " baris terupdate");
                    }
                }
                TampilkanPenyewa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    conn.Open();
                    string query = @"IF OBJECT_ID('dbo.Penyewa_Backup') IS NOT NULL AND OBJECT_ID('dbo.Transaksi_Backup') IS NOT NULL
                BEGIN
                    
                    DELETE FROM dbo.Transaksi
                    DELETE FROM dbo.Penyewa;

                    SET IDENTITY_INSERT dbo.Penyewa ON;
                    INSERT INTO dbo.Penyewa (id_penyewa, nama_petani, no_hp, alamat) 
                    SELECT id_penyewa, nama_petani, no_hp, alamat FROM dbo.Penyewa_Backup;
                    SET IDENTITY_INSERT dbo.Penyewa OFF;

                    SET IDENTITY_INSERT dbo.Transaksi ON;
                    INSERT INTO dbo.Transaksi (id_transaksi, id_alat, id_penyewa, tgl_sewa, tgl_kembali, total_bayar) 
                    SELECT id_transaksi, id_alat, id_penyewa, tgl_sewa, tgl_kembali, total_bayar FROM dbo.Transaksi_Backup;
                    SET IDENTITY_INSERT dbo.Transaksi OFF;
                END";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data Berhasil Direset! Semua transaksi dan penyewa telah kembali ke kondisi backup.");
                TampilkanPenyewa(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
        }
    }
}