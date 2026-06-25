using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Tanirent
{
    public partial class Dasboard : Form
    {
        DAL dal = new DAL();
        bool isInitializing = true;
        int button = 0;

        
        public Dasboard()
        {
            InitializeComponent(); 

            
            dtpTahun.Format = DateTimePickerFormat.Custom;
            dtpTahun.CustomFormat = "MMMM yyyy";
            dtpTahun.ShowUpDown = true;

            
            cmbTipe.DropDownStyle = ComboBoxStyle.DropDownList;
            var items = new List<KeyValuePair<string, SeriesChartType>>
            {
                new KeyValuePair<string, SeriesChartType>("Kolom", SeriesChartType.Column),
                new KeyValuePair<string, SeriesChartType>("Pie", SeriesChartType.Pie)
            };

            isInitializing = true;
            cmbTipe.DataSource = items;
            cmbTipe.DisplayMember = "Key";
            cmbTipe.ValueMember = "Value";
            cmbTipe.SelectedIndex = 0;
            isInitializing = false;

            
            LoadChartPenyewa();
        }

     
       
        private void Dasboard_Load(object sender, EventArgs e)
        {
            
        }

        void LoadChartPenyewa()
        {
            try
            {
               
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Legends.Clear();
                chart1.ChartAreas.Clear();

                
                ChartArea ca = new ChartArea("MainArea");
                ca.AxisX.Title = "Bulan";
                ca.AxisY.Title = "Pendapatan";
                ca.BackColor = Color.Transparent;
                chart1.ChartAreas.Add(ca);

                DataTable dt;


                if (button == 1)
                {
                  
                    dt = dal.getDataChartByTahun(dtpTahun.Value.Year);
                }
                else
                {
                 
                    dt = dal.getAllDataChart();
                }
                if (dt == null || dt.Rows.Count == 0)
                {
                    chart1.Titles.Add("Tidak ada data pendapatan untuk periode ini.");
                    return; 
                }

               
                SeriesChartType tipe = (SeriesChartType)cmbTipe.SelectedValue;
                Series s = new Series("Pendapatan");
                s.ChartType = tipe;

                if (tipe == SeriesChartType.Pie)
                {
                    s.IsValueShownAsLabel = true;
                    s.Label = "#VAL";
                    s.LegendText = "#AXISLABEL"; 
                }

                
                foreach (DataRow row in dt.Rows)
                {
                    string bulanNama = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Convert.ToInt32(row["Bulan"]));
                    decimal pendapatan = Convert.ToDecimal(row["TotalPendapatan"]);

                    s.Points.AddXY(bulanNama, pendapatan);
                }
                chart1.Series.Add(s);

               
                Title title = new Title("Grafik Pendapatan", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.DarkBlue);
                chart1.Titles.Add(title);

                Legend legend = new Legend("MainLegend");
                legend.Docking = Docking.Right;
                chart1.Legends.Add(legend);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal load chart: " + ex.Message);
            }
        }

       
        private void btnLoad_Click(object sender, EventArgs e)
        {
            button = 1; 
            LoadChartPenyewa();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            button = 0; 
            LoadChartPenyewa();
        }

        private void btnDataPenyewa_Click(object sender, EventArgs e)
        {
            Form_Penyewa frm1 = new Form_Penyewa();
            frm1.Show();
            this.Hide();
        }

        private void cmbTipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isInitializing) 
            return; 
            LoadChartPenyewa();
        }
    }
}