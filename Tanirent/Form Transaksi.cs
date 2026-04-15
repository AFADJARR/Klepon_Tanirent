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

       
    }
}