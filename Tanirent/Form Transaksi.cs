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
                string sql = @"SELECT id_alat, nama_alat 
                       FROM Alat_Mesin 
                       WHERE UPPER(status_ketersediaan) = 'TERSEDIA'";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                if (dt.Rows.Count > 0)
                {
                    cbAlat.DataSource = dt;
                    cbAlat.DisplayMember = "nama_alat";
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

                    
                    if (hari < 0)
                    {
                        txtTotal.Text = "0";
                        return;
                    }
                    if (hari == 0) hari = 1; 

                    decimal harga = decimal.Parse(txtHarga.Text);
                    decimal total = hari * harga;

                    
                    if (total < 0) total = 0;

                    txtTotal.Text = total.ToString();
                }
            }
            catch { }
        }

        private void btnPinjam_Click(object sender, EventArgs e)
        {
            if (cmbNama.SelectedIndex == -1 || cbAlat.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Penyewa dan Alat dulu, Bang!");
                return;
            }

            string connectionString = konn.GetConn().ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertTransaksi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_alat", cbAlat.SelectedValue);
                        cmd.Parameters.AddWithValue("@id_penyewa", cmbNama.SelectedValue);
                        cmd.Parameters.AddWithValue("@tgl_sewa", dtpPinjam.Value);
                        cmd.Parameters.AddWithValue("@tgl_kembali", dtpKembali.Value);
                        cmd.Parameters.AddWithValue("@total_bayar", decimal.Parse(txtTotal.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Sukses! Data transaksi berhasil ditambahkan .");

                        TampilkanTransaksi(); 
                        IsiComboAlat();      
                        BersihkanForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal Simpan! Pesan dari Database: " + ex.Message);
            }
        }

        void BersihkanForm()
        {
            cmbNama.SelectedIndex = -1;
            txtHarga.Clear();
            txtTotal.Clear();
            cbAlat.SelectedIndex = -1;
            dtpPinjam.Value = DateTime.Now;
            dtpKembali.Value = DateTime.Now.AddDays(1);
        }

        void IsiComboPenyewa()
        {
            SqlConnection conn = konn.GetConn();
            try
            {
                conn.Open();
                string sql = "SELECT id_penyewa, nama_petani FROM Penyewa";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbNama.DataSource = dt;
                cmbNama.DisplayMember = "nama_petani"; 
                cmbNama.ValueMember = "id_penyewa";    
                cmbNama.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
        }

        void TampilkanTransaksi()
        {
            string connectionString = konn.GetConn().ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    
                    string query = "SELECT * FROM vw_DaftarTransaksi";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    transaksiBindingSource.DataSource = dt;
                    dgvTransaksi.DataSource = transaksiBindingSource;
                    dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Gagal Refresh Grid: " + ex.Message); }
        }

        private void Form_Transaksi_Load_1(object sender, EventArgs e)
        {
            this.transaksiTableAdapter.Fill(this.dBsewataniDataSet1.Transaksi);

            IsiComboAlat();
            IsiComboPenyewa();
            TampilkanTransaksi();

            dtpPinjam.Value = DateTime.Now;
            dtpKembali.Value = DateTime.Now.AddDays(1);
        }

        private void cmbNama_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}