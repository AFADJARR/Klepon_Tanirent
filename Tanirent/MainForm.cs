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

    }
}