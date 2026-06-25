namespace Tanirent
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamaAlat = new System.Windows.Forms.TextBox();
            this.alatMesinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBsewataniMainform = new Tanirent.DBsewataniMainform();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbKategori = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvAlat = new System.Windows.Forms.DataGridView();
            this.id_alat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.merk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.harga_sewa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_kondisi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_ketersediaan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama_alat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbKondisi = new System.Windows.Forms.ComboBox();
            this.btnTampilData = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnPenyewa = new System.Windows.Forms.Button();
            this.btnTransaksi = new System.Windows.Forms.Button();
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
            this.alat_MesinTableAdapter = new Tanirent.DBsewataniMainformTableAdapters.Alat_MesinTableAdapter();
            this.btnDashboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.alatMesinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBsewataniMainform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Location = new System.Drawing.Point(375, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard Sistem TaniRent";
            // 
            // txtNamaAlat
            // 
            this.txtNamaAlat.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alatMesinBindingSource, "nama_alat", true));
            this.txtNamaAlat.Location = new System.Drawing.Point(171, 69);
            this.txtNamaAlat.Name = "txtNamaAlat";
            this.txtNamaAlat.Size = new System.Drawing.Size(100, 22);
            this.txtNamaAlat.TabIndex = 1;
            // 
            // alatMesinBindingSource
            // 
            this.alatMesinBindingSource.DataMember = "Alat_Mesin";
            this.alatMesinBindingSource.DataSource = this.dBsewataniMainform;
            // 
            // dBsewataniMainform
            // 
            this.dBsewataniMainform.DataSetName = "DBsewataniMainform";
            this.dBsewataniMainform.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtHarga
            // 
            this.txtHarga.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alatMesinBindingSource, "harga_sewa", true));
            this.txtHarga.Location = new System.Drawing.Point(171, 117);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(100, 22);
            this.txtHarga.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Location = new System.Drawing.Point(68, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nama Alat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label4.Location = new System.Drawing.Point(68, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Harga Sewa";
            // 
            // cbKategori
            // 
            this.cbKategori.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alatMesinBindingSource, "id_kat", true));
            this.cbKategori.FormattingEnabled = true;
            this.cbKategori.Location = new System.Drawing.Point(171, 161);
            this.cbKategori.Name = "cbKategori";
            this.cbKategori.Size = new System.Drawing.Size(121, 24);
            this.cbKategori.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label5.Location = new System.Drawing.Point(71, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kategori";
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnSimpan.Location = new System.Drawing.Point(597, 104);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(105, 29);
            this.btnSimpan.TabIndex = 11;
            this.btnSimpan.Text = "Tambah Data";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnEdit.Location = new System.Drawing.Point(597, 139);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 25);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.Location = new System.Drawing.Point(597, 170);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(105, 30);
            this.btnHapus.TabIndex = 13;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // dgvAlat
            // 
            this.dgvAlat.AutoGenerateColumns = false;
            this.dgvAlat.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            this.dgvAlat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_alat,
            this.merk,
            this.tipe,
            this.harga_sewa,
            this.status_kondisi,
            this.status_ketersediaan,
            this.nama_alat});
            this.dgvAlat.DataSource = this.alatMesinBindingSource;
            this.dgvAlat.GridColor = System.Drawing.SystemColors.WindowText;
            this.dgvAlat.Location = new System.Drawing.Point(74, 297);
            this.dgvAlat.Name = "dgvAlat";
            this.dgvAlat.RowHeadersWidth = 51;
            this.dgvAlat.RowTemplate.Height = 24;
            this.dgvAlat.Size = new System.Drawing.Size(928, 200);
            this.dgvAlat.TabIndex = 14;
            this.dgvAlat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlat_CellClick);
            // 
            // id_alat
            // 
            this.id_alat.DataPropertyName = "id_alat";
            this.id_alat.HeaderText = "id_alat";
            this.id_alat.MinimumWidth = 6;
            this.id_alat.Name = "id_alat";
            this.id_alat.ReadOnly = true;
            this.id_alat.Width = 125;
            // 
            // merk
            // 
            this.merk.DataPropertyName = "merk";
            this.merk.HeaderText = "merk";
            this.merk.MinimumWidth = 6;
            this.merk.Name = "merk";
            this.merk.Width = 125;
            // 
            // tipe
            // 
            this.tipe.DataPropertyName = "tipe";
            this.tipe.HeaderText = "tipe";
            this.tipe.MinimumWidth = 6;
            this.tipe.Name = "tipe";
            this.tipe.Width = 125;
            // 
            // harga_sewa
            // 
            this.harga_sewa.DataPropertyName = "harga_sewa";
            this.harga_sewa.HeaderText = "harga_sewa";
            this.harga_sewa.MinimumWidth = 6;
            this.harga_sewa.Name = "harga_sewa";
            this.harga_sewa.Width = 125;
            // 
            // status_kondisi
            // 
            this.status_kondisi.DataPropertyName = "status_kondisi";
            this.status_kondisi.HeaderText = "status_kondisi";
            this.status_kondisi.MinimumWidth = 6;
            this.status_kondisi.Name = "status_kondisi";
            this.status_kondisi.Width = 125;
            // 
            // status_ketersediaan
            // 
            this.status_ketersediaan.DataPropertyName = "status_ketersediaan";
            this.status_ketersediaan.HeaderText = "status_ketersediaan";
            this.status_ketersediaan.MinimumWidth = 6;
            this.status_ketersediaan.Name = "status_ketersediaan";
            this.status_ketersediaan.Width = 125;
            // 
            // nama_alat
            // 
            this.nama_alat.DataPropertyName = "nama_alat";
            this.nama_alat.HeaderText = "nama_alat";
            this.nama_alat.MinimumWidth = 6;
            this.nama_alat.Name = "nama_alat";
            this.nama_alat.Width = 125;
            // 
            // cbStatus
            // 
            this.cbStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alatMesinBindingSource, "status_ketersediaan", true));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(171, 230);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 24);
            this.cbStatus.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label6.Location = new System.Drawing.Point(71, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Location = new System.Drawing.Point(68, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Kondisi";
            // 
            // cbKondisi
            // 
            this.cbKondisi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alatMesinBindingSource, "status_kondisi", true));
            this.cbKondisi.FormattingEnabled = true;
            this.cbKondisi.Location = new System.Drawing.Point(171, 194);
            this.cbKondisi.Name = "cbKondisi";
            this.cbKondisi.Size = new System.Drawing.Size(121, 24);
            this.cbKondisi.TabIndex = 18;
            // 
            // btnTampilData
            // 
            this.btnTampilData.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnTampilData.Location = new System.Drawing.Point(597, 65);
            this.btnTampilData.Name = "btnTampilData";
            this.btnTampilData.Size = new System.Drawing.Size(105, 34);
            this.btnTampilData.TabIndex = 19;
            this.btnTampilData.Text = "Tampil Data";
            this.btnTampilData.UseVisualStyleBackColor = false;
            this.btnTampilData.Click += new System.EventHandler(this.btnTampilData_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Gold;
            this.btnLogout.Location = new System.Drawing.Point(885, 533);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(117, 33);
            this.btnLogout.TabIndex = 20;
            this.btnLogout.Text = "Log out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label7.Location = new System.Drawing.Point(508, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "search";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblTotal.Location = new System.Drawing.Point(708, 75);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 16);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "Jumlah Data";
            // 
            // cbSearch
            // 
            this.cbSearch.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(470, 245);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(121, 24);
            this.cbSearch.TabIndex = 24;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnPenyewa
            // 
            this.btnPenyewa.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnPenyewa.Location = new System.Drawing.Point(597, 206);
            this.btnPenyewa.Name = "btnPenyewa";
            this.btnPenyewa.Size = new System.Drawing.Size(145, 30);
            this.btnPenyewa.TabIndex = 25;
            this.btnPenyewa.Text = "Kelola Penyewa";
            this.btnPenyewa.UseVisualStyleBackColor = false;
            this.btnPenyewa.Click += new System.EventHandler(this.btnPenyewa_Click);
            // 
            // btnTransaksi
            // 
            this.btnTransaksi.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnTransaksi.Location = new System.Drawing.Point(597, 242);
            this.btnTransaksi.Name = "btnTransaksi";
            this.btnTransaksi.Size = new System.Drawing.Size(145, 29);
            this.btnTransaksi.TabIndex = 26;
            this.btnTransaksi.Text = "Kelola Transaksi ";
            this.btnTransaksi.UseVisualStyleBackColor = false;
            this.btnTransaksi.Click += new System.EventHandler(this.btnTransaksi_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BackColor = System.Drawing.Color.OliveDrab;
            this.bindingNavigator1.BindingSource = this.alatMesinBindingSource;
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
            this.bindingNavigator1.Size = new System.Drawing.Size(1331, 31);
            this.bindingNavigator1.TabIndex = 28;
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
            // alat_MesinTableAdapter
            // 
            this.alat_MesinTableAdapter.ClearBeforeFill = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Gold;
            this.btnDashboard.Location = new System.Drawing.Point(722, 533);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(124, 33);
            this.btnDashboard.TabIndex = 29;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(1331, 602);
            this.Controls.Add(this.btnDashboard);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.btnTransaksi);
            this.Controls.Add(this.btnPenyewa);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTampilData);
            this.Controls.Add(this.cbKondisi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.dgvAlat);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbKategori);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtNamaAlat);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alatMesinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBsewataniMainform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamaAlat;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbKategori;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvAlat;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbKondisi;
        private System.Windows.Forms.Button btnTampilData;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Button btnPenyewa;
        private System.Windows.Forms.Button btnTransaksi;
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
        private DBsewataniMainform dBsewataniMainform;
        private System.Windows.Forms.BindingSource alatMesinBindingSource;
        private DBsewataniMainformTableAdapters.Alat_MesinTableAdapter alat_MesinTableAdapter;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_alat;
        private System.Windows.Forms.DataGridViewTextBoxColumn merk;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn harga_sewa;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_kondisi;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_ketersediaan;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama_alat;
    }
}