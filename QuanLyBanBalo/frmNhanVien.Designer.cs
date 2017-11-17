namespace QuanLyBanBalo
{
    partial class frmNhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBangTaiKhoan = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.cboLoaiTK = new System.Windows.Forms.ComboBox();
            this.lblHoten = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblQueQuan = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDangNhap = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.pictureHinhAnh = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pckNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtQueQuan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbTenDangNhap = new System.Windows.Forms.RadioButton();
            this.txtTraCuuTen = new System.Windows.Forms.TextBox();
            this.rdbMaNhanVien = new System.Windows.Forms.RadioButton();
            this.txtTraCuuMa = new System.Windows.Forms.TextBox();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewImageColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QueQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayKhoiTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastLogon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangTaiKhoan)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHinhAnh)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBangTaiKhoan
            // 
            this.dgvBangTaiKhoan.AllowUserToAddRows = false;
            this.dgvBangTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvBangTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBangTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBangTaiKhoan.ColumnHeadersHeight = 50;
            this.dgvBangTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBangTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.Url,
            this.HoTen,
            this.NgaySinh,
            this.QueQuan,
            this.DiaChi,
            this.TenTaiKhoan,
            this.MatKhau,
            this.MoTa,
            this.NgayKhoiTao,
            this.LastLogon,
            this.TrangThai});
            this.dgvBangTaiKhoan.EnableHeadersVisualStyles = false;
            this.dgvBangTaiKhoan.Location = new System.Drawing.Point(13, 382);
            this.dgvBangTaiKhoan.MultiSelect = false;
            this.dgvBangTaiKhoan.Name = "dgvBangTaiKhoan";
            this.dgvBangTaiKhoan.ReadOnly = true;
            this.dgvBangTaiKhoan.RowHeadersVisible = false;
            this.dgvBangTaiKhoan.RowTemplate.Height = 70;
            this.dgvBangTaiKhoan.Size = new System.Drawing.Size(1106, 261);
            this.dgvBangTaiKhoan.TabIndex = 1;
            this.dgvBangTaiKhoan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dgvBangTaiKhoan.DoubleClick += new System.EventHandler(this.dgvBangTaiKhoan_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 827);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 92;
            this.button1.Text = "Lưu lại";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTenDangNhap);
            this.groupBox2.Controls.Add(this.lblMatKhau);
            this.groupBox2.Controls.Add(this.lblDiaChi);
            this.groupBox2.Controls.Add(this.cboLoaiTK);
            this.groupBox2.Controls.Add(this.lblHoten);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblSDT);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblQueQuan);
            this.groupBox2.Controls.Add(this.txtMatKhau);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDangNhap);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.txtHoTen);
            this.groupBox2.Controls.Add(this.pictureHinhAnh);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtSoDienThoai);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.pckNgaySinh);
            this.groupBox2.Controls.Add(this.txtQueQuan);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(457, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 364);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin cá nhân";
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.ForeColor = System.Drawing.Color.Red;
            this.lblTenDangNhap.Location = new System.Drawing.Point(478, 159);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(157, 20);
            this.lblTenDangNhap.TabIndex = 100;
            this.lblTenDangNhap.Text = "Không được để trống";
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.ForeColor = System.Drawing.Color.Red;
            this.lblMatKhau.Location = new System.Drawing.Point(478, 209);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(157, 20);
            this.lblMatKhau.TabIndex = 99;
            this.lblMatKhau.Text = "Không được để trống";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.ForeColor = System.Drawing.Color.Red;
            this.lblDiaChi.Location = new System.Drawing.Point(122, 159);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(157, 20);
            this.lblDiaChi.TabIndex = 104;
            this.lblDiaChi.Text = "Không được để trống";
            // 
            // cboLoaiTK
            // 
            this.cboLoaiTK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboLoaiTK.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiTK.FormattingEnabled = true;
            this.cboLoaiTK.Location = new System.Drawing.Point(481, 230);
            this.cboLoaiTK.Name = "cboLoaiTK";
            this.cboLoaiTK.Size = new System.Drawing.Size(163, 27);
            this.cboLoaiTK.TabIndex = 78;
            // 
            // lblHoten
            // 
            this.lblHoten.AutoSize = true;
            this.lblHoten.ForeColor = System.Drawing.Color.Red;
            this.lblHoten.Location = new System.Drawing.Point(122, 56);
            this.lblHoten.Name = "lblHoten";
            this.lblHoten.Size = new System.Drawing.Size(157, 20);
            this.lblHoten.TabIndex = 103;
            this.lblHoten.Text = "Không được để trống";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(336, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 24);
            this.label12.TabIndex = 97;
            this.label12.Text = "Loại TK";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.ForeColor = System.Drawing.Color.Red;
            this.lblSDT.Location = new System.Drawing.Point(478, 109);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(157, 20);
            this.lblSDT.TabIndex = 102;
            this.lblSDT.Text = "Không được để trống";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(336, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 24);
            this.label10.TabIndex = 94;
            this.label10.Text = "Mật khẩu";
            // 
            // lblQueQuan
            // 
            this.lblQueQuan.AutoSize = true;
            this.lblQueQuan.ForeColor = System.Drawing.Color.Red;
            this.lblQueQuan.Location = new System.Drawing.Point(478, 60);
            this.lblQueQuan.Name = "lblQueQuan";
            this.lblQueQuan.Size = new System.Drawing.Size(157, 20);
            this.lblQueQuan.TabIndex = 101;
            this.lblQueQuan.Text = "Không được để trống";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(481, 180);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(163, 26);
            this.txtMatKhau.TabIndex = 93;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(481, 279);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(163, 51);
            this.btnThem.TabIndex = 93;
            this.btnThem.Text = "Tạo tài khoản";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(336, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 24);
            this.label9.TabIndex = 92;
            this.label9.Text = "Tên đăng nhập";
            // 
            // txtDangNhap
            // 
            this.txtDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDangNhap.Location = new System.Drawing.Point(481, 130);
            this.txtDangNhap.Name = "txtDangNhap";
            this.txtDangNhap.Size = new System.Drawing.Size(163, 26);
            this.txtDangNhap.TabIndex = 91;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(125, 130);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(166, 26);
            this.txtDiaChi.TabIndex = 92;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHoTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(124, 30);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(167, 26);
            this.txtHoTen.TabIndex = 74;
            // 
            // pictureHinhAnh
            // 
            this.pictureHinhAnh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureHinhAnh.Image = global::QuanLyBanBalo.Properties.Resources.User;
            this.pictureHinhAnh.InitialImage = null;
            this.pictureHinhAnh.Location = new System.Drawing.Point(125, 180);
            this.pictureHinhAnh.Name = "pictureHinhAnh";
            this.pictureHinhAnh.Size = new System.Drawing.Size(113, 150);
            this.pictureHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureHinhAnh.TabIndex = 89;
            this.pictureHinhAnh.TabStop = false;
            this.pictureHinhAnh.Click += new System.EventHandler(this.pictureHinhAnh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 24);
            this.label8.TabIndex = 88;
            this.label8.Text = "Hình ảnh";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSoDienThoai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(481, 80);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(163, 26);
            this.txtSoDienThoai.TabIndex = 87;
            this.txtSoDienThoai.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            this.txtSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoDienThoai_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(336, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 24);
            this.label7.TabIndex = 86;
            this.label7.Text = "Số điện thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 85;
            this.label6.Text = "Địa chỉ";
            // 
            // pckNgaySinh
            // 
            this.pckNgaySinh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pckNgaySinh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pckNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pckNgaySinh.Location = new System.Drawing.Point(124, 80);
            this.pckNgaySinh.Name = "pckNgaySinh";
            this.pckNgaySinh.Size = new System.Drawing.Size(167, 26);
            this.pckNgaySinh.TabIndex = 84;
            // 
            // txtQueQuan
            // 
            this.txtQueQuan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQueQuan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueQuan.Location = new System.Drawing.Point(481, 30);
            this.txtQueQuan.Name = "txtQueQuan";
            this.txtQueQuan.Size = new System.Drawing.Size(163, 26);
            this.txtQueQuan.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(336, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 24);
            this.label5.TabIndex = 82;
            this.label5.Text = "Quê quán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 81;
            this.label4.Text = "Ngày sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 78;
            this.label1.Text = "Họ tên";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbTenDangNhap);
            this.groupBox1.Controls.Add(this.txtTraCuuTen);
            this.groupBox1.Controls.Add(this.rdbMaNhanVien);
            this.groupBox1.Controls.Add(this.txtTraCuuMa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 239);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // rdbTenDangNhap
            // 
            this.rdbTenDangNhap.AutoSize = true;
            this.rdbTenDangNhap.Checked = true;
            this.rdbTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTenDangNhap.Location = new System.Drawing.Point(38, 83);
            this.rdbTenDangNhap.Name = "rdbTenDangNhap";
            this.rdbTenDangNhap.Size = new System.Drawing.Size(159, 28);
            this.rdbTenDangNhap.TabIndex = 78;
            this.rdbTenDangNhap.TabStop = true;
            this.rdbTenDangNhap.Text = "Tên đăng nhập";
            this.rdbTenDangNhap.UseVisualStyleBackColor = true;
            this.rdbTenDangNhap.CheckedChanged += new System.EventHandler(this.rdbTenDangNhap_CheckedChanged);
            // 
            // txtTraCuuTen
            // 
            this.txtTraCuuTen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTraCuuTen.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraCuuTen.Location = new System.Drawing.Point(215, 83);
            this.txtTraCuuTen.Name = "txtTraCuuTen";
            this.txtTraCuuTen.Size = new System.Drawing.Size(167, 26);
            this.txtTraCuuTen.TabIndex = 79;
            this.txtTraCuuTen.TextChanged += new System.EventHandler(this.txtTraCuuTen_TextChanged);
            // 
            // rdbMaNhanVien
            // 
            this.rdbMaNhanVien.AutoSize = true;
            this.rdbMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMaNhanVien.Location = new System.Drawing.Point(38, 131);
            this.rdbMaNhanVien.Name = "rdbMaNhanVien";
            this.rdbMaNhanVien.Size = new System.Drawing.Size(142, 28);
            this.rdbMaNhanVien.TabIndex = 80;
            this.rdbMaNhanVien.Text = "Mã nhân viên";
            this.rdbMaNhanVien.UseVisualStyleBackColor = true;
            this.rdbMaNhanVien.CheckedChanged += new System.EventHandler(this.rdbMaNhanVien_CheckedChanged);
            // 
            // txtTraCuuMa
            // 
            this.txtTraCuuMa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTraCuuMa.Enabled = false;
            this.txtTraCuuMa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraCuuMa.Location = new System.Drawing.Point(215, 133);
            this.txtTraCuuMa.Name = "txtTraCuuMa";
            this.txtTraCuuMa.Size = new System.Drawing.Size(167, 26);
            this.txtTraCuuMa.TabIndex = 81;
            this.txtTraCuuMa.TextChanged += new System.EventHandler(this.txtTraCuuMa_TextChanged);
            // 
            // MaNV
            // 
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã NV";
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "Hình đại diện";
            this.Url.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HoTen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // QueQuan
            // 
            this.QueQuan.DataPropertyName = "QueQuan";
            this.QueQuan.HeaderText = "Quê quán";
            this.QueQuan.Name = "QueQuan";
            this.QueQuan.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // TenTaiKhoan
            // 
            this.TenTaiKhoan.DataPropertyName = "TenTaiKhoan";
            this.TenTaiKhoan.HeaderText = "Tên đăng nhập";
            this.TenTaiKhoan.Name = "TenTaiKhoan";
            this.TenTaiKhoan.ReadOnly = true;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật khẩu";
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.ReadOnly = true;
            this.MatKhau.Visible = false;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Loại TK";
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            this.MoTa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MoTa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NgayKhoiTao
            // 
            this.NgayKhoiTao.DataPropertyName = "NgayKhoiTao";
            this.NgayKhoiTao.HeaderText = "Ngày tạo";
            this.NgayKhoiTao.Name = "NgayKhoiTao";
            this.NgayKhoiTao.ReadOnly = true;
            // 
            // LastLogon
            // 
            this.LastLogon.DataPropertyName = "LastLogon";
            this.LastLogon.HeaderText = "Lần đăng nhập cuối";
            this.LastLogon.Name = "LastLogon";
            this.LastLogon.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Visible = false;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 702);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvBangTaiKhoan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QUẢN LÍ NHÂN VIÊN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmNhanVien_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVien_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNhanVien_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangTaiKhoan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHinhAnh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvBangTaiKhoan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboLoaiTK;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDangNhap;
        private System.Windows.Forms.PictureBox pictureHinhAnh;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker pckNgaySinh;
        private System.Windows.Forms.TextBox txtQueQuan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbTenDangNhap;
        private System.Windows.Forms.TextBox txtTraCuuTen;
        private System.Windows.Forms.RadioButton rdbMaNhanVien;
        private System.Windows.Forms.TextBox txtTraCuuMa;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblHoten;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblQueQuan;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewImageColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn QueQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayKhoiTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastLogon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}