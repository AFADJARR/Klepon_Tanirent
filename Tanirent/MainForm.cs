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
    }
}