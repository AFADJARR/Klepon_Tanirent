using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanirent
{
    internal class DAL
    {
        Koneksi konn = new Koneksi();

        public DataTable TampilData()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT * FROM vw_DaftarAlat",
                        conn
                    );

                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        // INSERT ALAT ( MAIN FORM )
        public int InsertAlat(int id_kat,string nama_alat,string merk,string tipe,decimal harga,string kondisi)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd =new SqlCommand("sp_InsertAlat",conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_kat", id_kat);
                    cmd.Parameters.AddWithValue("@nama_alat", nama_alat);
                    cmd.Parameters.AddWithValue("@merk", merk);
                    cmd.Parameters.AddWithValue("@tipe", tipe);
                    cmd.Parameters.AddWithValue("@harga_sewa", harga);
                    cmd.Parameters.AddWithValue("@status_kondisi", kondisi);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                throw;
            }
        }

        // UPDATE ALAT ( MAIN FORM )
        public int UpdateAlat(int id_alat,string nama_alat,decimal harga,string kondisi,string status)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd =new SqlCommand("sp_UpdateAlat",conn);

                    cmd.CommandType =CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_alat",id_alat);
                    cmd.Parameters.AddWithValue("@nama_alat",nama_alat);
                    cmd.Parameters.AddWithValue("@harga_sewa",harga);
                    cmd.Parameters.AddWithValue("@status_kondisi",kondisi);
                    cmd.Parameters.AddWithValue( "@status_ketersediaan",status);

                    conn.Open();

                    return cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                throw;
            }
        }

        // DELETE ALAT ( MAIN FORM )
        public int DeleteAlat(int id_alat)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd =new SqlCommand("sp_DeleteAlat",conn                    );

                    cmd.CommandType =CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_alat",id_alat);

                    conn.Open();
                    return cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                throw;
            }
        }

        public DataTable SearchAlat(string keyword)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd =new SqlCommand("sp_SearchAlat",conn);
                    cmd.CommandType =CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@keyword",keyword);

                    SqlDataAdapter da =
                    new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
            }
            return dt;
        }

        

        public DataTable FilterKondisi(string kondisi)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    string query =
                    "SELECT * FROM Alat_Mesin WHERE status_kondisi=@kondisi";

                    SqlCommand cmd =
                    new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kondisi",kondisi);

                    conn.Open();
                    SqlDataReader dr =cmd.ExecuteReader();
                    dt.Load(dr);
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
            }
            return dt;
        }

        // TAMPIL PENYEWA
        public DataTable TampilPenyewa()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlDataAdapter da =new SqlDataAdapter("SELECT * FROM vw_DaftarPenyewa",conn);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                MessageBox.Show(ex.Message);
            }
            return dt;
        }


        // INSERT PENYEWA
        public int InsertPenyewa(string nama,string nohp,string alamat)
        {

            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd =new SqlCommand("dbo.sp_InsertPenyewa",conn);

                    cmd.CommandType =CommandType.StoredProcedure;
                  
                    cmd.Parameters.Add("@NamaPetani",SqlDbType.VarChar).Value = nama;
                    cmd.Parameters.Add("@NoHp",SqlDbType.VarChar).Value = nohp;
                    cmd.Parameters.Add("@Alamat",SqlDbType.Text).Value = alamat;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                return 0;
            }

        }

        // UPDATE PENYEWA
        public int UpdatePenyewa(int id,string nama,string nohp,string alamat)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd =new SqlCommand("dbo.sp_UpdatePenyewa",conn);
                    cmd.CommandType =CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PenyewaID",SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@NamaPetani",SqlDbType.VarChar).Value = nama;
                    cmd.Parameters.Add("@NoHp",SqlDbType.VarChar).Value = nohp;
                    cmd.Parameters.Add("@Alamat",SqlDbType.Text).Value = alamat;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                return 0;
            }

        }


        public int ResetPenyewa()
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    string query = @"
                        IF OBJECT_ID('dbo.Penyewa_Backup') IS NOT NULL
                        BEGIN
                            DELETE FROM dbo.Transaksi;
                            DELETE FROM dbo.Penyewa;

                            SET IDENTITY_INSERT dbo.Penyewa ON;
                            INSERT INTO dbo.Penyewa (id_penyewa, nama_petani, no_hp, alamat)
                            SELECT id_penyewa, nama_petani, no_hp, alamat FROM dbo.Penyewa_Backup;
                            SET IDENTITY_INSERT dbo.Penyewa OFF;
                        END";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                throw;
            }
        }

        // DELETE PENYEWA
        public int DeletePenyewa(int id)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd =new SqlCommand("dbo.sp_DeletePenyewa",conn);
                    cmd.CommandType =CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PenyewaID",SqlDbType.Int).Value = id;

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
                return 0;
            }
        }


        // COMBO ALAT

        public DataTable GetAlatTersedia()
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = konn.GetConn())
            {
                string query = @"
                SELECT id_alat, nama_alat
                FROM Alat_Mesin
                WHERE UPPER(status_ketersediaan)='TERSEDIA'";

                SqlDataAdapter da =new SqlDataAdapter(query, conn);

                da.Fill(dt);
            }
            return dt;
        }

       
        // HARGA ALAT
        public decimal GetHargaAlat(int id)
        {
            decimal harga = 0;
            using (SqlConnection conn = konn.GetConn())
            {
                string query ="SELECT harga_sewa FROM Alat_Mesin WHERE id_alat=@id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                conn.Open();

                object hasil = cmd.ExecuteScalar();
                if (hasil != null)
                {
                    harga = Convert.ToDecimal(hasil);
                }
            }
            return harga;
        }

        
        // COMBO PENYEWA
        


        public DataTable GetPenyewa()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = konn.GetConn())
            {
                string query ="SELECT id_penyewa, nama_petani FROM Penyewa";
                SqlDataAdapter da =new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        
        // INSERT TRANSAKSI
        public int InsertTransaksi(int id_alat,int id_penyewa,DateTime tgl_sewa,DateTime tgl_kembali,decimal total)
        {
            using (SqlConnection conn = konn.GetConn())
            {
                SqlCommand cmd =new SqlCommand("sp_InsertTransaksi",conn);

                cmd.CommandType =CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_alat", SqlDbType.Int).Value = id_alat;
                cmd.Parameters.Add("@id_penyewa", SqlDbType.Int).Value = id_penyewa;
                cmd.Parameters.Add("@tgl_sewa", SqlDbType.Date).Value = tgl_sewa;
                cmd.Parameters.Add("@tgl_kembali", SqlDbType.Date).Value = tgl_kembali;
                cmd.Parameters.Add("@total_bayar", SqlDbType.Decimal).Value = total;

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // TAMPIL TRANSAKSI
        public DataTable getAllDataChart()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    SqlCommand cmd = new SqlCommand("sp_DashBoard", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
            }
            return dt;
        }

        public DataTable getDataChartByTahun(int tahun)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    
                    SqlCommand cmd = new SqlCommand("sp_DashBoardByTahun", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    
                    cmd.Parameters.AddWithValue("@inTahun", tahun);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                SimpanLog(ex.Message);
            }
            return dt;
        }

        public DataTable TampilTransaksi()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = konn.GetConn())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM vw_DaftarTransaksi",conn);
                da.Fill(dt);
            }
            return dt;
        }

        
        // LOG ERROR
        public void SimpanLog(string pesan)
        {
            try
            {
                using (SqlConnection conn = konn.GetConn())
                {
                    string query =
                    @"INSERT INTO LogError
                    (waktu,pesan_error)
                    VALUES(GETDATE(),@pesan)";

                    SqlCommand cmd =
                    new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@pesan", pesan);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }

    }

}
