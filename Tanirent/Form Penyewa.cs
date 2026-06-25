using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;

namespace Tanirent
{
    public partial class Form_Penyewa : Form
    {
        DAL dal = new DAL();

        public Form_Penyewa()
        {
            InitializeComponent();
        }

        void TampilkanPenyewa()
        {
            DataTable dt = dal.TampilPenyewa();

            penyewaBindingSource.DataSource = dt;
            dgvPenyewa.DataSource = penyewaBindingSource;

            dgvPenyewa.ReadOnly = true;
            dgvPenyewa.AllowUserToAddRows = false;
            dgvPenyewa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvPenyewa.Columns.Count > 0)
            {
                dgvPenyewa.Columns[0].HeaderText = "ID";
                dgvPenyewa.Columns[1].HeaderText = "Nama Petani";
                dgvPenyewa.Columns[2].HeaderText = "No HP";
                dgvPenyewa.Columns[3].HeaderText = "Alamat";

                dgvPenyewa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaPetani.Text) || string.IsNullOrWhiteSpace(txtNoHp.Text))
            {
                MessageBox.Show("Nama dan No HP wajib diisi, Bang!", "Peringatan");
                return;
            }
            int hasil = dal.InsertPenyewa(txtNamaPetani.Text, txtNoHp.Text, txtAlamat.Text);

            if (hasil > 0)
            {

                MessageBox.Show("Data Penyewa Berhasil Disimpan!");

                TampilkanPenyewa();
            }
            else
            {
                MessageBox.Show("Data gagal disimpan");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPenyewa.CurrentRow == null)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }
            int id = Convert.ToInt32(dgvPenyewa.CurrentRow.Cells[0].Value);
            int hasil = dal.UpdatePenyewa(id, txtNamaPetani.Text, txtNoHp.Text, txtAlamat.Text);
            if (hasil > 0)
            {
                MessageBox.Show("Data berhasil diperbarui");
                TampilkanPenyewa();
            }
            else
            {
                MessageBox.Show("Update gagal");
            }
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
            if (dgvPenyewa.CurrentRow == null)
            {
                MessageBox.Show("Pilih data dulu!");
                return;
            }
            if (MessageBox.Show(
                "Yakin ingin menghapus?",
                "Konfirmasi",
                MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvPenyewa.CurrentRow.Cells[0].Value);
                int hasil = dal.DeletePenyewa(id);
                if (hasil > 0)
                {
                    MessageBox.Show("Data berhasil dihapus");
                    TampilkanPenyewa();
                }
                else
                {
                    MessageBox.Show("Gagal hapus data");
                }
            }
        }

        private void dgvPenyewa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPenyewa.CurrentRow != null && dgvPenyewa.CurrentRow.Index >= 0)
            {
                try
                {
                    DataGridViewRow row = dgvPenyewa.CurrentRow;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn == null) continue;

                        string colName = cell.OwningColumn.Name.ToLower();
                        string colHeader = cell.OwningColumn.HeaderText.ToLower();
                        string nilaiCell = cell.Value?.ToString() ?? "";

                        if (colName.Contains("nama") || colHeader.Contains("nama"))
                            txtNamaPetani.Text = nilaiCell;
                        else if (colName.Contains("hp") || colHeader.Contains("hp") || colName.Contains("telepon"))
                            txtNoHp.Text = nilaiCell;
                        else if (colName.Contains("alamat") || colHeader.Contains("alamat"))
                            txtAlamat.Text = nilaiCell;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error SelectionChanged: " + ex.Message);
                }
            }
        }

        private void btnTampilData_Click(object sender, EventArgs e)
        {
            dgvPenyewa.DataSource = null;
            TampilkanPenyewa();
        }

        private void Form_Penyewa_Load_1(object sender, EventArgs e)
        {
            this.penyewaTableAdapter.Fill(this.dBsewataniDataSet.Penyewa);

            penyewaBindingSource.ResetBindings(false);

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new Koneksi().GetConn())
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
            catch (SqlException ex)
            {

                dal.SimpanLog(ex.Message);
                MessageBox.Show("Serangan Digagalkan SQL: \n" + ex.Message, "Trigger Aktif!");
            }
            catch (Exception ex)
            {
                dal.SimpanLog(ex.Message);
                MessageBox.Show("Error Aplikasi: " + ex.Message);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            try
            {
                dal.ResetPenyewa();
                MessageBox.Show("Data Penyewa berhasil direset ke kondisi backup!");
                TampilkanPenyewa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reset gagal: " + ex.Message);
            }
        }

        private void btnDataAlat_Click(object sender, EventArgs e)
        {
            MainForm fMainform = new MainForm();
            fMainform.Show();
            this.Hide();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Workbook| *. xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            DataTable dt = result.Tables[0];

                           
                            penyewaBindingSource.DataSource = dt;
                            dgvPenyewa.DataSource = penyewaBindingSource;

                            dgvPenyewa.Enabled = true;

                            btnImportDB.Enabled = true;

                            btnImportDB.Enabled = true;
                            btnSimpan.Enabled = true;
                            btnEdit.Enabled = true;
                            btnHapus.Enabled = true;
                            btnTampilData.Enabled = true;
                            btnTest.Enabled = true;
                            btnreset.Enabled = true;
                            btnDataAlat.Enabled = true;
                        }
                    }
                }
            }
        }

        private void btnImportDB_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)penyewaBindingSource.DataSource;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diimport.");
                    return;
                }

                int sukses = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string NamaPetani = "";
                    string NoHp = "";
                    string Alamat = "";

                    foreach (DataColumn col in dt.Columns)
                    {
                        string colName = col.ColumnName.ToLower();
                        if (colName.Contains("nama")) NamaPetani = row[col].ToString();
                        else if (colName.Contains("hp") || colName.Contains("telepon")) NoHp = row[col].ToString();
                        else if (colName.Contains("alamat")) Alamat = row[col].ToString();
                    }

                    if (string.IsNullOrEmpty(NamaPetani))
                        continue;

                    dal.InsertPenyewa(NamaPetani.Trim(), NoHp.Trim(), Alamat.Trim());
                    sukses++;
                }
                MessageBox.Show("Data Penyewa berhasil ditambahkan");
                TampilkanPenyewa();
            }
            catch (Exception ex)
            {
                dal.SimpanLog("Error Import: " + ex.Message);
                MessageBox.Show("Gagal import data: " + ex.Message);
            }
        }
    }
}