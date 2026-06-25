using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanirent
{
    public partial class CetakTransaksi : Form
    {
        private DataTable dtTransaksi;

        public CetakTransaksi(DataTable data)
        {
            InitializeComponent();
            dtTransaksi = data;
            TampilkanReport();
        }


        private void TampilkanReport()
        {
            try
            {
                ListTransaksi listTransaksi = new ListTransaksi();
                listTransaksi.SetDataSource(dtTransaksi);

                RptTransaksi report = new RptTransaksi();
                report.SetDataSource(listTransaksi);

                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan report: " + ex.Message);
            }
        }
    }
}
