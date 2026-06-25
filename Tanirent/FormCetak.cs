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
    public partial class FormCetak : Form
    {
        Koneksi koneksi = new Koneksi();
        SqlDataAdapter da;
        DataTable dtTransaksi;

        public FormCetak()
        {
            InitializeComponent();
            btnCetak.Enabled = false;
        }



        private void btnCetak_Click(object sender, EventArgs e)
        {
            CetakTransaksi frmPreview = new CetakTransaksi(dtTransaksi);
            frmPreview.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = koneksi.GetConn();

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                SqlCommand cmd = new SqlCommand("sp_ReportTransaksi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da = new SqlDataAdapter(cmd);

                dtTransaksi = new DataTable();
                da.Fill(dtTransaksi);

                conn.Close();

                dataGridView1.DataSource = dtTransaksi; 

                if (dtTransaksi.Rows.Count > 0)
                {
                    btnCetak.Enabled = true;
                }
                else
                {
                    btnCetak.Enabled = false;
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load data: " + ex.Message);
            }
        }
    }
}
