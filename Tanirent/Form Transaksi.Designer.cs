namespace Tanirent
{
    partial class Form_Transaksi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Transaksi));
            this.cbAlat = new System.Windows.Forms.ComboBox();
            this.transaksiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBsewataniDataSet1 = new Tanirent.DBsewataniDataSet1();
            this.dtpPinjam = new System.Windows.Forms.DateTimePicker();
            this.dtpKembali = new System.Windows.Forms.DateTimePicker();
            this.btnPinjam = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNama = new System.Windows.Forms.ComboBox();
            this.transaksiTableAdapter = new Tanirent.DBsewataniDataSet1TableAdapters.TransaksiTableAdapter();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tableAdapterManager = new Tanirent.DBsewataniDataSet1TableAdapters.TableAdapterManager();
            this.dgvTransaksi = new System.Windows.Forms.DataGridView();
            this.id_transaksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_petani = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_alat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_sewa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgl_kembali = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_bayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRekapData = new System.Windows.Forms.Button();
            this.btnAlat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBsewataniDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAlat
            // 
            this.cbAlat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "nama_alat", true));
            this.cbAlat.FormattingEnabled = true;
            this.cbAlat.Location = new System.Drawing.Point(207, 133);
            this.cbAlat.Name = "cbAlat";
            this.cbAlat.Size = new System.Drawing.Size(121, 24);
            this.cbAlat.TabIndex = 1;
            // 
            // transaksiBindingSource
            // 
            this.transaksiBindingSource.DataMember = "Transaksi";
            this.transaksiBindingSource.DataSource = this.dBsewataniDataSet1;
            // 
            // dBsewataniDataSet1
            // 
            this.dBsewataniDataSet1.DataSetName = "DBsewataniDataSet1";
            this.dBsewataniDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dtpPinjam
            // 
            this.dtpPinjam.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "tgl_sewa", true));
            this.dtpPinjam.Location = new System.Drawing.Point(207, 177);
            this.dtpPinjam.MaxDate = new System.DateTime(2026, 10, 24, 0, 0, 0, 0);
            this.dtpPinjam.MinDate = new System.DateTime(2026, 5, 14, 0, 0, 0, 0);
            this.dtpPinjam.Name = "dtpPinjam";
            this.dtpPinjam.Size = new System.Drawing.Size(200, 22);
            this.dtpPinjam.TabIndex = 2;
            this.dtpPinjam.Value = new System.DateTime(2026, 5, 14, 0, 0, 0, 0);
            // 
            // dtpKembali
            // 
            this.dtpKembali.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "tgl_kembali", true));
            this.dtpKembali.Location = new System.Drawing.Point(207, 222);
            this.dtpKembali.MaxDate = new System.DateTime(2026, 10, 24, 0, 0, 0, 0);
            this.dtpKembali.MinDate = new System.DateTime(2026, 5, 14, 0, 0, 0, 0);
            this.dtpKembali.Name = "dtpKembali";
            this.dtpKembali.Size = new System.Drawing.Size(200, 22);
            this.dtpKembali.TabIndex = 3;
            this.dtpKembali.Value = new System.DateTime(2026, 5, 14, 0, 0, 0, 0);
            // 
            // btnPinjam
            // 
            this.btnPinjam.BackColor = System.Drawing.Color.Red;
            this.btnPinjam.Location = new System.Drawing.Point(66, 384);
            this.btnPinjam.Name = "btnPinjam";
            this.btnPinjam.Size = new System.Drawing.Size(130, 34);
            this.btnPinjam.TabIndex = 7;
            this.btnPinjam.Text = "Submit";
            this.btnPinjam.UseVisualStyleBackColor = false;
            this.btnPinjam.Click += new System.EventHandler(this.btnPinjam_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Location = new System.Drawing.Point(63, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nama Penyewa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Location = new System.Drawing.Point(63, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Alat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label4.Location = new System.Drawing.Point(63, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tanggal Pinjam";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label5.Location = new System.Drawing.Point(63, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tanggal Kembali";
            // 
            // cmbNama
            // 
            this.cmbNama.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "nama_petani", true));
            this.cmbNama.FormattingEnabled = true;
            this.cmbNama.Location = new System.Drawing.Point(207, 86);
            this.cmbNama.Name = "cmbNama";
            this.cmbNama.Size = new System.Drawing.Size(121, 24);
            this.cmbNama.TabIndex = 16;
            this.cmbNama.SelectedIndexChanged += new System.EventHandler(this.cmbNama_SelectedIndexChanged);
            // 
            // transaksiTableAdapter
            // 
            this.transaksiTableAdapter.ClearBeforeFill = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BackColor = System.Drawing.Color.OliveDrab;
            this.bindingNavigator1.BindingSource = this.transaksiBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1239, 31);
            this.bindingNavigator1.TabIndex = 19;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Tanirent.DBsewataniDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dgvTransaksi
            // 
            this.dgvTransaksi.AutoGenerateColumns = false;
            this.dgvTransaksi.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            this.dgvTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaksi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_transaksi,
            this.nama_petani,
            this.nama_alat,
            this.tgl_sewa,
            this.tgl_kembali,
            this.total_bayar});
            this.dgvTransaksi.DataSource = this.transaksiBindingSource;
            this.dgvTransaksi.Location = new System.Drawing.Point(434, 54);
            this.dgvTransaksi.Name = "dgvTransaksi";
            this.dgvTransaksi.RowHeadersWidth = 51;
            this.dgvTransaksi.RowTemplate.Height = 24;
            this.dgvTransaksi.Size = new System.Drawing.Size(773, 445);
            this.dgvTransaksi.TabIndex = 19;
            this.dgvTransaksi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransaksi_CellClick);
            // 
            // id_transaksi
            // 
            this.id_transaksi.DataPropertyName = "id_transaksi";
            this.id_transaksi.HeaderText = "id_transaksi";
            this.id_transaksi.MinimumWidth = 6;
            this.id_transaksi.Name = "id_transaksi";
            this.id_transaksi.ReadOnly = true;
            this.id_transaksi.Width = 125;
            // 
            // nama_petani
            // 
            this.nama_petani.DataPropertyName = "nama_petani";
            this.nama_petani.HeaderText = "nama_petani";
            this.nama_petani.MinimumWidth = 6;
            this.nama_petani.Name = "nama_petani";
            this.nama_petani.Width = 125;
            // 
            // nama_alat
            // 
            this.nama_alat.DataPropertyName = "nama_alat";
            this.nama_alat.HeaderText = "nama_alat";
            this.nama_alat.MinimumWidth = 6;
            this.nama_alat.Name = "nama_alat";
            this.nama_alat.Width = 125;
            // 
            // tgl_sewa
            // 
            this.tgl_sewa.DataPropertyName = "tgl_sewa";
            this.tgl_sewa.HeaderText = "tgl_sewa";
            this.tgl_sewa.MinimumWidth = 6;
            this.tgl_sewa.Name = "tgl_sewa";
            this.tgl_sewa.Width = 125;
            // 
            // tgl_kembali
            // 
            this.tgl_kembali.DataPropertyName = "tgl_kembali";
            this.tgl_kembali.HeaderText = "tgl_kembali";
            this.tgl_kembali.MinimumWidth = 6;
            this.tgl_kembali.Name = "tgl_kembali";
            this.tgl_kembali.Width = 125;
            // 
            // total_bayar
            // 
            this.total_bayar.DataPropertyName = "total_bayar";
            this.total_bayar.HeaderText = "total_bayar";
            this.total_bayar.MinimumWidth = 6;
            this.total_bayar.Name = "total_bayar";
            this.total_bayar.Width = 125;
            // 
            // txtTotal
            // 
            this.txtTotal.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.transaksiBindingSource, "total_bayar", true));
            this.txtTotal.Location = new System.Drawing.Point(207, 273);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 22);
            this.txtTotal.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Location = new System.Drawing.Point(63, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Total Bayar";
            // 
            // btnRekapData
            // 
            this.btnRekapData.Location = new System.Drawing.Point(236, 384);
            this.btnRekapData.Name = "btnRekapData";
            this.btnRekapData.Size = new System.Drawing.Size(159, 35);
            this.btnRekapData.TabIndex = 22;
            this.btnRekapData.Text = "Rekap Data";
            this.btnRekapData.UseVisualStyleBackColor = true;
            this.btnRekapData.Click += new System.EventHandler(this.btnRekapData_Click);
            // 
            // btnAlat
            // 
            this.btnAlat.Location = new System.Drawing.Point(136, 464);
            this.btnAlat.Name = "btnAlat";
            this.btnAlat.Size = new System.Drawing.Size(159, 35);
            this.btnAlat.TabIndex = 23;
            this.btnAlat.Text = "Data Alat";
            this.btnAlat.UseVisualStyleBackColor = true;
            this.btnAlat.Click += new System.EventHandler(this.btnAlat_Click);
            // 
            // Form_Transaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1239, 541);
            this.Controls.Add(this.btnAlat);
            this.Controls.Add(this.btnRekapData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dgvTransaksi);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.cmbNama);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPinjam);
            this.Controls.Add(this.dtpKembali);
            this.Controls.Add(this.dtpPinjam);
            this.Controls.Add(this.cbAlat);
            this.Name = "Form_Transaksi";
            this.Text = "Form_Transaksi";
            this.Load += new System.EventHandler(this.Form_Transaksi_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.transaksiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBsewataniDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbAlat;
        private System.Windows.Forms.DateTimePicker dtpPinjam;
        private System.Windows.Forms.DateTimePicker dtpKembali;
        private System.Windows.Forms.Button btnPinjam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNama;
        private DBsewataniDataSet1 dBsewataniDataSet1;
        private System.Windows.Forms.BindingSource transaksiBindingSource;
        private DBsewataniDataSet1TableAdapters.TransaksiTableAdapter transaksiTableAdapter;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DBsewataniDataSet1TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dgvTransaksi;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRekapData;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_transaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_petani;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_alat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_sewa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgl_kembali;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_bayar;
        private System.Windows.Forms.Button btnAlat;
    }
}