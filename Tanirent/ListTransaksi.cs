using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanirent
{
    public class ListTransaksi : List<DataTransaksi>
    {
        public void SetDataSource(DataTable dt)
        {
            this.Clear();
            foreach (DataRow row in dt.Rows)
            {
                DataTransaksi item = new DataTransaksi
                {
                    IdTransaksi = Convert.ToInt32(row["id_transaksi"]),
                    NamaPetani = row["NamaPetani"].ToString(),
                    NamaAlat = row["NamaAlat"].ToString(),
                    TanggalSewa = Convert.ToDateTime(row["TanggalSewa"]),
                    TanggalKembali = Convert.ToDateTime(row["TanggalKembali"]),
                    TotalBayar = Convert.ToDecimal(row["TotalBayar"])
                };
                this.Add(item);
            }
        }
    }
}
