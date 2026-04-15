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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TampilkanData();

            if (cbKategori.Items.Count == 0)
            {
                cbKategori.Items.Add("Traktor");
                cbKategori.Items.Add("Drone");
                cbKategori.Items.Add("Mesin Panen");
            }

            if (cbKondisi.Items.Count == 0)
            {
                cbKondisi.Items.Add("Baik");
                cbKondisi.Items.Add("Rusak");
                cbKondisi.Items.Add("Perawatan");
            }

            if (cbStatus.Items.Count == 0)
            {
                cbStatus.Items.Add("Tersedia");
                cbStatus.Items.Add("Disewa");
            }

            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Semua Data");
                comboBox1.Items.Add("Baik");
                comboBox1.Items.Add("Rusak");
                comboBox1.Items.Add("Perawatan");
                comboBox1.SelectedIndex = 0;
            }
        }

        void TampilkanData()
        {
            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string query = @"SELECT id_alat, id_kat, nama_alat, merk, tipe, 
                                harga_sewa, status_kondisi, status_ketersediaan 
                                FROM Alat_Mesin";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader(); 

                DataTable dt = new DataTable();
                dt.Load(dr); 
                dgvAlat.DataSource = dt;

                dgvAlat.Columns["id_alat"].HeaderText = "ID";
                dgvAlat.Columns["id_kat"].Visible = false;
                dgvAlat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dr.Close(); 

                SqlCommand cmdHitung = new SqlCommand("SELECT COUNT(*) FROM Alat_Mesin", conn);
                int jumlahData = (int)cmdHitung.ExecuteScalar();
                lblTotal.Text = "Total Data: " + jumlahData.ToString();
            }
            catch (Exception ex) { MessageBox.Show("Error Tampil: " + ex.Message); }
            finally { conn.Close(); }
        }

        void BersihkanForm()
        {
            txtNamaAlat.Clear();
            txtHarga.Clear();
            cbKategori.SelectedIndex = -1;
            cbKondisi.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
            comboBox1.SelectedIndex = 0;
            txtNamaAlat.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamaAlat.Text) || string.IsNullOrEmpty(txtHarga.Text) || string.IsNullOrEmpty(cbKategori.Text))
            {
                MessageBox.Show("Field Penting Tidak Boleh Kosong!", "Peringatan");
                return;
            }

            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string merkOto = ""; string tipeOto = "";
                if (cbKategori.Text == "Traktor") { merkOto = "Yanmar"; tipeOto = "Hand Traktor G1000"; }
                else if (cbKategori.Text == "Drone") { merkOto = "DJI"; tipeOto = "Agras T20"; }
                else { merkOto = "Umum"; tipeOto = "Standar"; }

                string sql = @"INSERT INTO Alat_Mesin (id_kat, nama_alat, merk, tipe, harga_sewa, status_kondisi, status_ketersediaan) 
                               VALUES (@idkat, @nama, @merk, @tipe, @harga, @kondisi, @status)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idkat", cbKategori.Text == "Traktor" ? 1 : 2);
                cmd.Parameters.AddWithValue("@nama", txtNamaAlat.Text);
                cmd.Parameters.AddWithValue("@merk", merkOto);
                cmd.Parameters.AddWithValue("@tipe", tipeOto);
                cmd.Parameters.AddWithValue("@harga", decimal.Parse(txtHarga.Text));
                cmd.Parameters.AddWithValue("@kondisi", cbKondisi.Text);
                cmd.Parameters.AddWithValue("@status", cbStatus.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Tambah Data!");
                TampilkanData();
                BersihkanForm();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAlat.CurrentRow == null) return;

            if (MessageBox.Show("Yakin ingin mengubah data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection conn = konn.GetConn();
                try
                {
                    conn.Open();
                    string idAlat = dgvAlat.CurrentRow.Cells["id_alat"].Value.ToString();
                    string sql = @"UPDATE Alat_Mesin SET nama_alat=@nama, harga_sewa=@harga, status_kondisi=@kondisi, status_ketersediaan=@status 
                                   WHERE id_alat=@id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", idAlat);
                    cmd.Parameters.AddWithValue("@nama", txtNamaAlat.Text);
                    cmd.Parameters.AddWithValue("@harga", decimal.Parse(txtHarga.Text));
                    cmd.Parameters.AddWithValue("@kondisi", cbKondisi.Text);
                    cmd.Parameters.AddWithValue("@status", cbStatus.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diupdate!");
                    TampilkanData();
                    BersihkanForm();
                }
                catch (Exception ex) { MessageBox.Show("Error Update: " + ex.Message); }
                finally { conn.Close(); }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvAlat.CurrentRow == null) return;
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection conn = konn.GetConn();
                try
                {
                    conn.Open();
                    string id = dgvAlat.CurrentRow.Cells["id_alat"].Value.ToString();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Alat_Mesin WHERE id_alat=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    TampilkanData();
                    BersihkanForm();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conn.Close(); }
            }
        }

    }
}