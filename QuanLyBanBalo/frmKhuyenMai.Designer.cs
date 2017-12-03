namespace QuanLyBanBalo
{
    partial class frmKhuyenMai
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbThuCong = new System.Windows.Forms.RadioButton();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTenCTKM = new System.Windows.Forms.Label();
            this.ckbGioiHanTG = new System.Windows.Forms.CheckBox();
            this.grpThoiGian = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.rdbApDungHD = new System.Windows.Forms.RadioButton();
            this.txtTenCTKM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.MaKhuyenMai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhuyenMai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApDungHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbThuCong);
            this.groupBox1.Controls.Add(this.lblMoTa);
            this.groupBox1.Controls.Add(this.lblTenCTKM);
            this.groupBox1.Controls.Add(this.ckbGioiHanTG);
            this.groupBox1.Controls.Add(this.grpThoiGian);
            this.groupBox1.Controls.Add(this.rdbApDungHD);
            this.groupBox1.Controls.Add(this.txtTenCTKM);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 461);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khuyến mại";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdbThuCong
            // 
            this.rdbThuCong.AutoSize = true;
            this.rdbThuCong.Location = new System.Drawing.Point(128, 249);
            this.rdbThuCong.Name = "rdbThuCong";
            this.rdbThuCong.Size = new System.Drawing.Size(187, 24);
            this.rdbThuCong.TabIndex = 121;
            this.rdbThuCong.Text = "Tôi muốn làm thủ công";
            this.rdbThuCong.UseVisualStyleBackColor = true;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.Color.Red;
            this.lblMoTa.Location = new System.Drawing.Point(125, 150);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(121, 15);
            this.lblMoTa.TabIndex = 120;
            this.lblMoTa.Text = "Không được để trống";
            this.lblMoTa.Visible = false;
            // 
            // lblTenCTKM
            // 
            this.lblTenCTKM.AutoSize = true;
            this.lblTenCTKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCTKM.ForeColor = System.Drawing.Color.Red;
            this.lblTenCTKM.Location = new System.Drawing.Point(126, 84);
            this.lblTenCTKM.Name = "lblTenCTKM";
            this.lblTenCTKM.Size = new System.Drawing.Size(121, 15);
            this.lblTenCTKM.TabIndex = 119;
            this.lblTenCTKM.Text = "Không được để trống";
            this.lblTenCTKM.Visible = false;
            // 
            // ckbGioiHanTG
            // 
            this.ckbGioiHanTG.AutoSize = true;
            this.ckbGioiHanTG.Location = new System.Drawing.Point(119, 334);
            this.ckbGioiHanTG.Name = "ckbGioiHanTG";
            this.ckbGioiHanTG.Size = new System.Drawing.Size(15, 14);
            this.ckbGioiHanTG.TabIndex = 118;
            this.ckbGioiHanTG.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ckbGioiHanTG.UseVisualStyleBackColor = true;
            this.ckbGioiHanTG.CheckedChanged += new System.EventHandler(this.ckbGioiHanTG_CheckedChanged);
            // 
            // grpThoiGian
            // 
            this.grpThoiGian.Controls.Add(this.label4);
            this.grpThoiGian.Controls.Add(this.label2);
            this.grpThoiGian.Controls.Add(this.dtpDenNgay);
            this.grpThoiGian.Controls.Add(this.dtpTuNgay);
            this.grpThoiGian.Enabled = false;
            this.grpThoiGian.Location = new System.Drawing.Point(129, 334);
            this.grpThoiGian.Name = "grpThoiGian";
            this.grpThoiGian.Size = new System.Drawing.Size(281, 100);
            this.grpThoiGian.TabIndex = 115;
            this.grpThoiGian.TabStop = false;
            this.grpThoiGian.Text = "Giới hạn thời gian";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 24);
            this.label4.TabIndex = 120;
            this.label4.Text = "Đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 24);
            this.label2.TabIndex = 119;
            this.label2.Text = "Từ";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDenNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(94, 68);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(181, 26);
            this.dtpDenNgay.TabIndex = 110;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpTuNgay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(94, 25);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(181, 26);
            this.dtpTuNgay.TabIndex = 109;
            // 
            // rdbApDungHD
            // 
            this.rdbApDungHD.AutoSize = true;
            this.rdbApDungHD.Checked = true;
            this.rdbApDungHD.Location = new System.Drawing.Point(128, 206);
            this.rdbApDungHD.Name = "rdbApDungHD";
            this.rdbApDungHD.Size = new System.Drawing.Size(182, 24);
            this.rdbApDungHD.TabIndex = 116;
            this.rdbApDungHD.TabStop = true;
            this.rdbApDungHD.Text = "Áp dụng cho Hóa đơn";
            this.rdbApDungHD.UseVisualStyleBackColor = true;
            // 
            // txtTenCTKM
            // 
            this.txtTenCTKM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTenCTKM.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCTKM.Location = new System.Drawing.Point(129, 55);
            this.txtTenCTKM.Name = "txtTenCTKM";
            this.txtTenCTKM.Size = new System.Drawing.Size(181, 26);
            this.txtTenCTKM.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 102;
            this.label1.Text = "Tên CT KM";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMoTa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(128, 118);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(181, 26);
            this.txtMoTa.TabIndex = 101;
            this.txtMoTa.TextChanged += new System.EventHandler(this.txtMoTa_TextChanged);
            this.txtMoTa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoTa_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 100;
            this.label3.Text = "Mô tả";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 20);
            this.label11.TabIndex = 80;
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.AllowUserToAddRows = false;
            this.dgvKhuyenMai.AllowUserToDeleteRows = false;
            this.dgvKhuyenMai.AllowUserToResizeColumns = false;
            this.dgvKhuyenMai.AllowUserToResizeRows = false;
            this.dgvKhuyenMai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhuyenMai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhuyenMai,
            this.TenKhuyenMai,
            this.MoTa,
            this.ApDungHD,
            this.NgayBatDau,
            this.NgayKetThuc,
            this.TrangThai});
            this.dgvKhuyenMai.Location = new System.Drawing.Point(457, 24);
            this.dgvKhuyenMai.MultiSelect = false;
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhuyenMai.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKhuyenMai.RowHeadersVisible = false;
            this.dgvKhuyenMai.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvKhuyenMai.RowTemplate.Height = 40;
            this.dgvKhuyenMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(755, 293);
            this.dgvKhuyenMai.TabIndex = 95;
            this.dgvKhuyenMai.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhuyenMai_CellDoubleClick);
            this.dgvKhuyenMai.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvKhuyenMai_CellFormatting);
            this.dgvKhuyenMai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvKhuyenMai_KeyDown);
            this.dgvKhuyenMai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvKhuyenMai_KeyPress);
            // 
            // MaKhuyenMai
            // 
            this.MaKhuyenMai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MaKhuyenMai.DataPropertyName = "MaKhuyenMai";
            this.MaKhuyenMai.HeaderText = "Mã khuyến mại";
            this.MaKhuyenMai.Name = "MaKhuyenMai";
            this.MaKhuyenMai.ReadOnly = true;
            this.MaKhuyenMai.Width = 118;
            // 
            // TenKhuyenMai
            // 
            this.TenKhuyenMai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenKhuyenMai.DataPropertyName = "TenKhuyenMai";
            this.TenKhuyenMai.HeaderText = "Tên Chương trình KM";
            this.TenKhuyenMai.Name = "TenKhuyenMai";
            this.TenKhuyenMai.ReadOnly = true;
            // 
            // MoTa
            // 
            this.MoTa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            this.MoTa.Width = 52;
            // 
            // ApDungHD
            // 
            this.ApDungHD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ApDungHD.DataPropertyName = "ApDungHD";
            this.ApDungHD.HeaderText = "Áp dụng cho HĐ";
            this.ApDungHD.Name = "ApDungHD";
            this.ApDungHD.ReadOnly = true;
            this.ApDungHD.Width = 105;
            // 
            // NgayBatDau
            // 
            this.NgayBatDau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NgayBatDau.DataPropertyName = "NgayBatDau";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.NgayBatDau.DefaultCellStyle = dataGridViewCellStyle2;
            this.NgayBatDau.HeaderText = "Ngày bắt đầu";
            this.NgayBatDau.Name = "NgayBatDau";
            this.NgayBatDau.ReadOnly = true;
            this.NgayBatDau.Width = 85;
            // 
            // NgayKetThuc
            // 
            this.NgayKetThuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NgayKetThuc.DataPropertyName = "NgayKetThuc";
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.NgayKetThuc.DefaultCellStyle = dataGridViewCellStyle3;
            this.NgayKetThuc.HeaderText = "Ngày kết thúc";
            this.NgayKetThuc.Name = "NgayKetThuc";
            this.NgayKetThuc.ReadOnly = true;
            this.NgayKetThuc.Width = 84;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(457, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "(*) Double click để sửa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(457, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "(*) Bấm nút Delete để xóa";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Image = global::QuanLyBanBalo.Properties.Resources.icon_refresh;
            this.btnLamMoi.Location = new System.Drawing.Point(972, 422);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(200, 51);
            this.btnLamMoi.TabIndex = 100;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::QuanLyBanBalo.Properties.Resources.icon_plus_math;
            this.btnThem.Location = new System.Drawing.Point(544, 422);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(200, 51);
            this.btnThem.TabIndex = 97;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::QuanLyBanBalo.Properties.Resources.icon_edit;
            this.btnSua.Location = new System.Drawing.Point(758, 422);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(200, 51);
            this.btnSua.TabIndex = 96;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 681);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmKhuyenMai";
            this.Text = "QUẢN LÝ KHUYẾN MẠI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpThoiGian.ResumeLayout(false);
            this.grpThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.TextBox txtTenCTKM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpThoiGian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.CheckBox ckbGioiHanTG;
        private System.Windows.Forms.RadioButton rdbApDungHD;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblTenCTKM;
        private System.Windows.Forms.RadioButton rdbThuCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhuyenMai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhuyenMai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApDungHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}