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
    public partial class MainForm : Form
    {
        Koneksi konn = new Koneksi();
       
        BindingSource bs = new BindingSource(); 

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (cbKategori.Items.Count == 0)
            {
                cbKategori.Items.AddRange(new string[] { "Traktor", "Drone", "Mesin Panen" });
            }

            if (cbKondisi.Items.Count == 0)
            {
                cbKondisi.Items.AddRange(new string[] { "Baik", "Rusak", "Perawatan" });
            }

            if (cbStatus.Items.Count == 0)
            {
                cbStatus.Items.AddRange(new string[] { "Tersedia", "Disewa" });
            }

            if (cbSearch.Items.Count == 0)
            {
                cbSearch.Items.AddRange(new string[] { "Semua Data", "Baik", "Rusak", "Perawatan" });
                cbSearch.SelectedIndex = 0;
            }

            TampilkanData();
            BindControls();

            bs.ResetBindings(false);
        }

        void TampilkanData()
        {
            string connectionString = konn.GetConn().ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM vw_DaftarAlat";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    bs.DataSource = dt;
                    dgvAlat.DataSource = bs;
                    bindingNavigator1.BindingSource = bs;

                    lblTotal.Text = "Total Data: " + dt.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Tampil: " + ex.Message);
            }
        }

        void BersihkanForm()
        {
            txtNamaAlat.Clear();
            txtHarga.Clear();
            cbKategori.SelectedIndex = -1;
            cbKondisi.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            cbSearch.SelectedIndex = 0;
            txtNamaAlat.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string connectionString = konn.GetConn().ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertAlat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_kat", cbKategori.Text == "Traktor" ? 1 : 2);
                        cmd.Parameters.AddWithValue("@nama_alat", txtNamaAlat.Text);
                        cmd.Parameters.AddWithValue("@merk", "Umum");
                        cmd.Parameters.AddWithValue("@tipe", "Standar");
                        cmd.Parameters.AddWithValue("@harga_sewa", decimal.Parse(txtHarga.Text));
                        cmd.Parameters.AddWithValue("@status_kondisi", cbKondisi.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Berhasil Tambah Data!");
                        TampilkanData();
                        BersihkanForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Simpan: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAlat.CurrentRow == null) return;
            string connectionString = konn.GetConn().ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateAlat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_alat", dgvAlat.CurrentRow.Cells["id_alat"].Value);
                        cmd.Parameters.AddWithValue("@nama_alat", txtNamaAlat.Text);
                        cmd.Parameters.AddWithValue("@harga_sewa", decimal.Parse(txtHarga.Text));
                        cmd.Parameters.AddWithValue("@status_kondisi", cbKondisi.Text);
                        cmd.Parameters.AddWithValue("@status_ketersediaan", cbStatus.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data Berhasil Diupdate!");
                        TampilkanData();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error Update: " + ex.Message); }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvAlat.CurrentRow == null) return;
            string connectionString = konn.GetConn().ConnectionString;

            if (MessageBox.Show("Yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_DeleteAlat", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_alat", dgvAlat.CurrentRow.Cells["id_alat"].Value);

                            conn.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Data berhasil dihapus");
                            TampilkanData();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.Text == "Semua Data")
            {
                TampilkanData();
                return;
            }

            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM Alat_Mesin WHERE status_kondisi = @kondisi";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@kondisi", cbSearch.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr); 
                dgvAlat.DataSource = dt;

                dr.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Filter: " + ex.Message); }
            finally { conn.Close(); }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        
            string connectionString = konn.GetConn().ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand("sp_SearchAlat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; 

                        cmd.Parameters.AddWithValue("@keyword", cbSearch.Text);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd)) 
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt); 

                           
                            bs.DataSource = dt;
                            dgvAlat.DataSource = bs;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private void dgvAlat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAlat.Rows[e.RowIndex];
                txtNamaAlat.Text = row.Cells["nama_alat"].Value.ToString();
                txtHarga.Text = row.Cells["harga_sewa"].Value.ToString();
                cbKondisi.Text = row.Cells["status_kondisi"].Value.ToString();
                cbStatus.Text = row.Cells["status_ketersediaan"].Value.ToString();
            }
        }

        private void btnTampilData_Click(object sender, EventArgs e)
        {
            TampilkanData();
            BersihkanForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin Logout?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Form1 login = new Form1();
                login.Show();
            }
        }


        private void btnPenyewa_Click(object sender, EventArgs e)
        {
            Form_Penyewa fPenyewa = new Form_Penyewa();
            fPenyewa.ShowDialog();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            Form_Transaksi fTransaksi = new Form_Transaksi();
            fTransaksi.ShowDialog();
        }

        void BindControls()
        {
            txtNamaAlat.DataBindings.Clear();
            txtHarga.DataBindings.Clear();
            cbKondisi.DataBindings.Clear();
            cbStatus.DataBindings.Clear();

            txtNamaAlat.DataBindings.Add("Text", bs, "nama_alat", true);
            txtHarga.DataBindings.Add("Text", bs, "harga_sewa", true);

            cbKondisi.DataBindings.Add("Text", bs, "status_kondisi", true);
            cbStatus.DataBindings.Add("Text", bs, "status_ketersediaan", true);
        }
    }
}