namespace Tanirent
{
    partial class Dasboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTahun = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDataPenyewa = new System.Windows.Forms.Button();
            this.cmbTipe = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(83, 99);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(836, 419);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tahun Penyewaan";
            // 
            // dtpTahun
            // 
            this.dtpTahun.Location = new System.Drawing.Point(205, 54);
            this.dtpTahun.Name = "dtpTahun";
            this.dtpTahun.Size = new System.Drawing.Size(200, 22);
            this.dtpTahun.TabIndex = 2;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(425, 54);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(517, 56);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDataPenyewa
            // 
            this.btnDataPenyewa.Location = new System.Drawing.Point(796, 539);
            this.btnDataPenyewa.Name = "btnDataPenyewa";
            this.btnDataPenyewa.Size = new System.Drawing.Size(123, 23);
            this.btnDataPenyewa.TabIndex = 5;
            this.btnDataPenyewa.Text = "Data Penyewa";
            this.btnDataPenyewa.UseVisualStyleBackColor = true;
            this.btnDataPenyewa.Click += new System.EventHandler(this.btnDataPenyewa_Click);
            // 
            // cmbTipe
            // 
            this.cmbTipe.FormattingEnabled = true;
            this.cmbTipe.Location = new System.Drawing.Point(652, 51);
            this.cmbTipe.Name = "cmbTipe";
            this.cmbTipe.Size = new System.Drawing.Size(121, 24);
            this.cmbTipe.TabIndex = 6;
            this.cmbTipe.SelectedIndexChanged += new System.EventHandler(this.cmbTipe_SelectedIndexChanged);
            // 
            // Dasboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 592);
            this.Controls.Add(this.cmbTipe);
            this.Controls.Add(this.btnDataPenyewa);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.dtpTahun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "Dasboard";
            this.Text = "Dasboard";
            this.Load += new System.EventHandler(this.Dasboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTahun;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDataPenyewa;
        private System.Windows.Forms.ComboBox cmbTipe;
    }
}