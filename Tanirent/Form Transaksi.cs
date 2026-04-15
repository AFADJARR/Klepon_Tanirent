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
    public partial class Form_Transaksi : Form
    {
        Koneksi konn = new Koneksi();

        public Form_Transaksi()
        {
            InitializeComponent();
        }

        void IsiComboAlat()
        {
            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string sql = @"SELECT id_alat, 
                               ISNULL(nama_alat, 'Alat') + ' - ' + ISNULL(merk, '') + ' ' + ISNULL(tipe, '') as nama_lengkap 
                               FROM Alat_Mesin 
                               WHERE UPPER(status_ketersediaan) = 'TERSEDIA'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr); 

                if (dt.Rows.Count > 0)
                {
                    cbAlat.DataSource = dt;
                    cbAlat.DisplayMember = "nama_lengkap";
                    cbAlat.ValueMember = "id_alat";
                    cbAlat.SelectedIndex = -1;
                }
                dr.Close();
            }
            catch (Exception ex) { MessageBox.Show("Gagal ambil data alat: " + ex.Message); }
            finally { conn.Close(); }
        }

        private void cbAlat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAlat.SelectedIndex != -1 && cbAlat.SelectedValue != null)
            {
                if (cbAlat.SelectedValue is DataRowView) return;

                SqlConnection conn = konn.GetConn();
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT harga_sewa FROM Alat_Mesin WHERE id_alat = @id", conn);
                    cmd.Parameters.AddWithValue("@id", cbAlat.SelectedValue);

                    object harga = cmd.ExecuteScalar();
                    if (harga != null)
                    {
                        txtHarga.Text = harga.ToString();
                        HitungTotal();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error Harga: " + ex.Message); }
                finally { conn.Close(); }
            }
        }

        void HitungTotal()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtHarga.Text))
                {
                    TimeSpan ts = dtpKembali.Value.Date - dtpPinjam.Value.Date;
                    int hari = ts.Days;
                    if (hari <= 0) hari = 1;

                    decimal harga = decimal.Parse(txtHarga.Text);
                    decimal total = hari * harga;
                    txtTotal.Text = total.ToString();
                }
            }
            catch { }
        }

        private void dtpKembali_ValueChanged(object sender, EventArgs e) { HitungTotal(); }
        private void dtpPinjam_ValueChanged(object sender, EventArgs e) { HitungTotal(); }

        private void btnPinjam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || cbAlat.SelectedIndex == -1)
            {
                MessageBox.Show("Lengkapi Nama Penyewa dan Pilih Alat!", "Validasi");
                return;
            }

            SqlConnection conn = konn.GetConn();
            SqlTransaction trans = null;

            try
            {
                conn.Open();

                SqlCommand cmdCariUser = new SqlCommand("SELECT id_penyewa FROM Penyewa WHERE nama_petani = @nama", conn);
                cmdCariUser.Parameters.AddWithValue("@nama", txtNama.Text);
                object result = cmdCariUser.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Penyewa '" + txtNama.Text + "' tidak ketemu!", "Error");
                    return;
                }

                int idPenyewa = (int)result;
                trans = conn.BeginTransaction();

                string sqlTrans = @"INSERT INTO Transaksi (id_alat, id_penyewa, id_admin, tgl_sewa, tgl_kembali, total_bayar) 
                                   VALUES (@id_alat, @id_penyewa, 1, @tgl_sewa, @tgl_kembali, @total)";

                SqlCommand cmdTrans = new SqlCommand(sqlTrans, conn, trans);
                cmdTrans.Parameters.AddWithValue("@id_alat", cbAlat.SelectedValue);
                cmdTrans.Parameters.AddWithValue("@id_penyewa", idPenyewa);
                cmdTrans.Parameters.AddWithValue("@tgl_sewa", dtpPinjam.Value);
                cmdTrans.Parameters.AddWithValue("@tgl_kembali", dtpKembali.Value);
                cmdTrans.Parameters.AddWithValue("@total", decimal.Parse(txtTotal.Text));
                cmdTrans.ExecuteNonQuery();

                string sqlUpdate = "UPDATE Alat_Mesin SET status_ketersediaan = 'Disewa' WHERE id_alat = @id";
                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn, trans);
                cmdUpdate.Parameters.AddWithValue("@id", cbAlat.SelectedValue);
                cmdUpdate.ExecuteNonQuery();

                trans.Commit();
                MessageBox.Show("Sukses! Alat sudah dipinjam.");

                TampilkanTransaksi();
                IsiComboAlat();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                MessageBox.Show("Gagal Simpan: " + ex.Message);
            }
            finally { conn.Close(); }
        }

        void BersihkanForm()
        {
            txtNama.Clear();
            txtHarga.Clear();
            txtTotal.Clear();
            cbAlat.SelectedIndex = -1;
            dtpPinjam.Value = DateTime.Now;
            dtpKembali.Value = DateTime.Now.AddDays(1);
        }

      
    }
}