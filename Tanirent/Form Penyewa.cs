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

        void Bersihkan()
        {
            txtNamaPetani.Clear();
            txtNoHp.Clear();
            txtAlamat.Clear();
            txtNamaPetani.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaPetani.Text) || string.IsNullOrWhiteSpace(txtNoHp.Text))
            {
                MessageBox.Show("Nama dan No HP wajib diisi, Bang!", "Peringatan");
                return;
            }

            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string sql = "INSERT INTO Penyewa (nama_petani, no_hp, alamat) VALUES (@nama, @nohp, @alamat)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", txtNamaPetani.Text);
                cmd.Parameters.AddWithValue("@nohp", txtNoHp.Text);
                cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);

                cmd.ExecuteNonQuery(); 
                MessageBox.Show("Data Penyewa Berhasil Disimpan!");
                TampilkanPenyewa();
                Bersihkan();
            }
            catch (Exception ex) { MessageBox.Show("Gagal Simpan: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPenyewa.CurrentRow == null) return;

            if (MessageBox.Show("Yakin mau ubah data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlConnection conn = konn.GetConn();
                try
                {
                    conn.Open();
                    string id = dgvPenyewa.CurrentRow.Cells["id_penyewa"].Value.ToString();
                    string sql = "UPDATE Penyewa SET nama_petani=@nama, no_hp=@nohp, alamat=@alamat WHERE id_penyewa=@id";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nama", txtNamaPetani.Text);
                    cmd.Parameters.AddWithValue("@nohp", txtNoHp.Text);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Berhasil Diperbarui!");
                    TampilkanPenyewa();
                    Bersihkan();
                }
                catch (Exception ex) { MessageBox.Show("Gagal Edit: " + ex.Message); }
                finally { conn.Close(); }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPenyewa.CurrentRow == null) return;

            if (MessageBox.Show("Hapus data penyewa ini?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection conn = konn.GetConn();
                try
                {
                    conn.Open();
                    string id = dgvPenyewa.CurrentRow.Cells["id_penyewa"].Value.ToString();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Penyewa WHERE id_penyewa=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Terhapus!");
                    TampilkanPenyewa();
                    Bersihkan();
                }
                catch (Exception ex) { MessageBox.Show("Gagal Hapus: " + ex.Message); }
                finally { conn.Close(); }
            }
        }

        private void btnBersihkan_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }

        private void dgvPenyewa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPenyewa.Rows[e.RowIndex];
                txtNamaPetani.Text = row.Cells["nama_petani"].Value.ToString();
                txtNoHp.Text = row.Cells["no_hp"].Value.ToString();
                txtAlamat.Text = row.Cells["alamat"].Value.ToString();
            }
        }
    }
}