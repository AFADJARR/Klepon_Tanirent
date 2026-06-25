using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanirent
{
    public class DataTransaksi
    {
        public int IdTransaksi { get; set; }
        public string NamaPetani { get; set; }
        public string NamaAlat { get; set; }
        public DateTime TanggalSewa { get; set; }
        public DateTime TanggalKembali { get; set; }
        public decimal TotalBayar { get; set; }
    }
}
