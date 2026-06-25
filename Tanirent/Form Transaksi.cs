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

        BindingSource bs = new BindingSource();
        DAL dal = new DAL();

        public Form_Transaksi()
        {
            InitializeComponent();
        }

        void IsiComboAlat()
        {
            DataTable dt = dal.GetAlatTersedia();


            cbAlat.DataSource = dt;
            cbAlat.DisplayMember = "nama_alat";
            cbAlat.ValueMember = "id_alat";
            cbAlat.SelectedIndex = -1;
        }

        private void cbAlat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAlat.SelectedIndex != -1&& cbAlat.SelectedValue != null)
            {

                if (cbAlat.SelectedValue is DataRowView)
                    return;

                int id = Convert.ToInt32(cbAlat.SelectedValue);
                decimal harga = dal.GetHargaAlat(id);

                txtTotal.Text = harga.ToString();
                HitungTotal();
            }
        }

        void HitungTotal()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTotal.Text))
                {
                    TimeSpan ts = dtpKembali.Value.Date - dtpPinjam.Value.Date;
                    int hari = ts.Days;

                    
                    if (hari < 0)
                    {
                        txtTotal.Text = "0";
                        return;
                    }
                    if (hari == 0) hari = 1; 

                    decimal harga = decimal.Parse(txtTotal.Text);
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
                MessageBox.Show("Pilih data penyewa", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                dal.InsertTransaksi(Convert.ToInt32(cbAlat.SelectedValue),Convert.ToInt32(cmbNama.SelectedValue),
                    dtpPinjam.Value,dtpKembali.Value,decimal.Parse(txtTotal.Text));

                MessageBox.Show("Transaksi berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TampilkanTransaksi();
                IsiComboAlat();
                BersihkanForm();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Peringatan Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal sistem: " + ex.Message, "Error C#", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void BersihkanForm()
        {
            cmbNama.SelectedIndex = -1;
            txtTotal.Clear();
            txtTotal.Clear();
            cbAlat.SelectedIndex = -1;
            dtpPinjam.Value = DateTime.Now;
            dtpKembali.Value = DateTime.Now.AddDays(1);
        }

        void IsiComboPenyewa()
        {
            DataTable dt = dal.GetPenyewa();

            cmbNama.DataSource = dt;
            cmbNama.DisplayMember ="nama_petani";
            cmbNama.ValueMember ="id_penyewa";
            cmbNama.SelectedIndex = -1;
        }

        void TampilkanTransaksi()
        {
            DataTable dt = dal.TampilTransaksi();

            bs.DataSource = dt; 
            dgvTransaksi.DataSource = bs; 
            dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }



        private void Form_Transaksi_Load_1(object sender, EventArgs e)
        {
            this.transaksiTableAdapter.Fill(this.dBsewataniDataSet1.Transaksi);
            IsiComboAlat();
            IsiComboPenyewa();
            TampilkanTransaksi();

            bindingNavigator1.BindingSource = bs;

            dtpPinjam.Value =DateTime.Now;
            dtpKembali.Value =DateTime.Now.AddDays(1);
            dgvTransaksi.CellClick += new DataGridViewCellEventHandler(dgvTransaksi_CellClick);
        }

        private void cmbNama_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRekapData_Click(object sender, EventArgs e)
        {
            FormCetak frmCetak = new FormCetak();
            frmCetak.Show();
        }

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTransaksi.CurrentRow != null && dgvTransaksi.CurrentRow.Index >= 0)
                {
                    DataGridViewRow row = dgvTransaksi.CurrentRow;

                    if (row.Cells[0].Value == DBNull.Value || row.Cells[0].Value == null) return;
                    dtpPinjam.Value = Convert.ToDateTime(row.Cells[3].Value);
                    dtpKembali.Value = Convert.ToDateTime(row.Cells[4].Value);
                    cmbNama.Text = row.Cells[1].Value.ToString();
                    cbAlat.Text = row.Cells[2].Value.ToString();
                    txtTotal.Text = row.Cells[5].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("tidak ada data di tabel " + ex.Message);
            }
        }

        private void btnAlat_Click(object sender, EventArgs e)
        {
            MainForm fMainform = new MainForm();
            fMainform.Show();
            this.Hide();
        }
    }
}