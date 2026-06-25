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
    public partial class MainForm : Form
    {
        DAL dal = new DAL();
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

            bindingNavigator1.BindingSource = bs;
            bs.ResetBindings(false);
        }

        void TampilkanData()
        {
            DataTable dt = dal.TampilData();

            bs.DataSource = dt;

            dgvAlat.AutoGenerateColumns = true;
            dgvAlat.DataSource = null;
            dgvAlat.DataSource = bs;

            dgvAlat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvAlat.Columns.Contains("id_kat"))
            {
                dgvAlat.Columns["id_kat"].Visible = true;
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
            try
            {
                int id_kat = cbKategori.Text == "Traktor" ? 1 : 2;
                dal.InsertAlat(id_kat, txtNamaAlat.Text, "Standar", "Tinggi", decimal.Parse(txtHarga.Text), cbKondisi.Text);

                MessageBox.Show("Berhasil Tambah Data!");
                TampilkanData();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal dari Database: " + ex.Message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAlat.CurrentRow == null) return;

            try
            {
                int id = Convert.ToInt32(dgvAlat.CurrentRow.Cells["id_alat"].Value);
                int hasil = dal.UpdateAlat(id, txtNamaAlat.Text, decimal.Parse(txtHarga.Text), cbKondisi.Text, cbStatus.Text);

                    TampilkanData();
                    BersihkanForm();
            }

            catch (SqlException ex) 
            {
                MessageBox.Show(ex.Message, "Peringatan Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error C#: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvAlat.CurrentRow == null) return;

            if (MessageBox.Show("Yakin ingin menghapus?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvAlat.CurrentRow.Cells["id_alat"].Value);
                    int hasil = dal.DeleteAlat(id);

                    if (hasil > 0)
                    {
                        MessageBox.Show("Data berhasil dihapus");
                        TampilkanData();
                        BersihkanForm();
                    }
                }
                catch (SqlException ex)     
                {
                    MessageBox.Show(ex.Message, "Peringatan Hapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error C#: " + ex.Message, "Error Sistem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSearch.Text == "Semua Data")
                {
                    TampilkanData();
                    return;
                }
                DataTable dt = dal.FilterKondisi(cbSearch.Text);

                bs.DataSource = dt;
                dgvAlat.DataSource = bs;

                if (dgvAlat.Columns.Contains("id_kat"))
                {
                    dgvAlat.Columns["id_kat"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat filter: " + ex.Message);
            }

        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            DataTable dt =dal.SearchAlat(cbSearch.Text);
            bs.DataSource = dt;
            dgvAlat.DataSource = bs;
        }

        private void dgvAlat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAlat.CurrentRow != null && dgvAlat.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvAlat.Rows[e.RowIndex];

                if (row.Cells["id_alat"].Value == DBNull.Value || row.Cells["id_alat"].Value == null) return;

                txtNamaAlat.Text = row.Cells["nama_alat"].Value?.ToString() ?? "";
                txtHarga.Text = row.Cells["harga_sewa"].Value?.ToString() ?? "";
                cbKondisi.Text = row.Cells["status_kondisi"].Value?.ToString() ?? "";
                cbStatus.Text = row.Cells["status_ketersediaan"].Value?.ToString() ?? "";
                    

                string idKat = row.Cells["id_kat"].Value?.ToString() ?? "";
                cbKategori.Text = (idKat == "1") ? "Traktor" : (idKat == "2" ? "Drone" : "Mesin Panen");
            }
        }

        private void btnTampilData_Click(object sender, EventArgs e)
        {
            TampilkanData();
            BersihkanForm();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ingin Logout?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form1 login = new Form1()
;               login.Show();
                this.Hide();
            }
        }
        private void btnPenyewa_Click(object sender, EventArgs e)
        {
            Form_Penyewa fPenyewa = new Form_Penyewa();
            fPenyewa.Show();
            this.Hide();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            Form_Transaksi fTransaksi = new Form_Transaksi();
            fTransaksi.Show();
            this.Hide();
        }

        void BindControls()
        {
            txtNamaAlat.DataBindings.Clear();
            txtHarga.DataBindings.Clear();
            cbKondisi.DataBindings.Clear();
            cbStatus.DataBindings.Clear();


            DataTable dt = bs.DataSource as DataTable;

            if (dt == null) return;

            if (dt.Columns.Contains("nama_alat"))
            {
                txtNamaAlat.DataBindings.Add("Text", bs, "nama_alat", true, DataSourceUpdateMode.Never);
            }

            if (dt.Columns.Contains("harga_sewa"))
            {
                txtHarga.DataBindings.Add("Text", bs, "harga_sewa", true, DataSourceUpdateMode.Never);
            }

            if (dt.Columns.Contains("status_kondisi"))
            {
                cbKondisi.DataBindings.Add("Text", bs, "status_kondisi", true, DataSourceUpdateMode.Never);
            }

            if (dt.Columns.Contains("status_ketersediaan"))
            {
                cbStatus.DataBindings.Add("Text", bs, "status_ketersediaan", true, DataSourceUpdateMode.Never);
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dasboard fDasboard = new Dasboard();
            fDasboard.Show();
            this.Hide();
        }
    }
}