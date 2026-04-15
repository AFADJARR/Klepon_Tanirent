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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TampilkanData();

            if (cbKategori.Items.Count == 0)
            {
                cbKategori.Items.Add("Traktor");
                cbKategori.Items.Add("Drone");
                cbKategori.Items.Add("Mesin Panen");
            }

            if (cbKondisi.Items.Count == 0)
            {
                cbKondisi.Items.Add("Baik");
                cbKondisi.Items.Add("Rusak");
                cbKondisi.Items.Add("Perawatan");
            }

            if (cbStatus.Items.Count == 0)
            {
                cbStatus.Items.Add("Tersedia");
                cbStatus.Items.Add("Disewa");
            }

            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("Semua Data");
                comboBox1.Items.Add("Baik");
                comboBox1.Items.Add("Rusak");
                comboBox1.Items.Add("Perawatan");
                comboBox1.SelectedIndex = 0;
            }
        }

    }
}