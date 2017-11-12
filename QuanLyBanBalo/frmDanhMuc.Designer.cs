namespace QuanLyBanBalo
{
    partial class frmDanhMuc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbDanhMuc = new System.Windows.Forms.GroupBox();
            this.lbTenDanhMuc = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTKTenDanhMuc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTKMaDanhMuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.colMaDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongSoSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDemDanhMuc = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grbDanhMuc.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDanhMuc
            // 
            this.grbDanhMuc.Controls.Add(this.lbTenDanhMuc);
            this.grbDanhMuc.Controls.Add(this.btnSua);
            this.grbDanhMuc.Controls.Add(this.btnThem);
            this.grbDanhMuc.Controls.Add(this.txtTenDanhMuc);
            this.grbDanhMuc.Controls.Add(this.label1);
            this.grbDanhMuc.Location = new System.Drawing.Point(12, 12);
            this.grbDanhMuc.Name = "grbDanhMuc";
            this.grbDanhMuc.Size = new System.Drawing.Size(495, 158);
            this.grbDanhMuc.TabIndex = 0;
            this.grbDanhMuc.TabStop = false;
            this.grbDanhMuc.Text = "Thêm Danh Mục";
            // 
            // lbTenDanhMuc
            // 
            this.lbTenDanhMuc.AutoSize = true;
            this.lbTenDanhMuc.BackColor = System.Drawing.SystemColors.Control;
            this.lbTenDanhMuc.ForeColor = System.Drawing.Color.Red;
            this.lbTenDanhMuc.Location = new System.Drawing.Point(114, 67);
            this.lbTenDanhMuc.Name = "lbTenDanhMuc";
            this.lbTenDanhMuc.Size = new System.Drawing.Size(109, 13);
            this.lbTenDanhMuc.TabIndex = 4;
            this.lbTenDanhMuc.Text = "Không được để trống";
            this.lbTenDanhMuc.Visible = false;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(226, 85);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(307, 85);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDanhMuc.Location = new System.Drawing.Point(114, 33);
            this.txtTenDanhMuc.Multiline = true;
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(268, 28);
            this.txtTenDanhMuc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên danh mục";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTKTenDanhMuc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTKMaDanhMuc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(513, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 158);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm";
            // 
            // txtTKTenDanhMuc
            // 
            this.txtTKTenDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTKTenDanhMuc.Location = new System.Drawing.Point(117, 67);
            this.txtTKTenDanhMuc.Multiline = true;
            this.txtTKTenDanhMuc.Name = "txtTKTenDanhMuc";
            this.txtTKTenDanhMuc.Size = new System.Drawing.Size(268, 28);
            this.txtTKTenDanhMuc.TabIndex = 5;
            this.txtTKTenDanhMuc.TextChanged += new System.EventHandler(this.txtTKTenDanhMuc_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên danh mục";
            // 
            // txtTKMaDanhMuc
            // 
            this.txtTKMaDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTKMaDanhMuc.Location = new System.Drawing.Point(117, 33);
            this.txtTKMaDanhMuc.Multiline = true;
            this.txtTKMaDanhMuc.Name = "txtTKMaDanhMuc";
            this.txtTKMaDanhMuc.Size = new System.Drawing.Size(268, 28);
            this.txtTKMaDanhMuc.TabIndex = 3;
            this.txtTKMaDanhMuc.TextChanged += new System.EventHandler(this.txtTKMaDanhMuc_TextChanged);
            this.txtTKMaDanhMuc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTKMaDanhMuc_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Danh Mục";
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.AllowUserToAddRows = false;
            this.dgvDanhMuc.AllowUserToResizeColumns = false;
            this.dgvDanhMuc.AllowUserToResizeRows = false;
            this.dgvDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDanhMuc.ColumnHeadersHeight = 50;
            this.dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDanhMuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDanhMuc,
            this.colTenDanhMuc,
            this.colTongSoSP});
            this.dgvDanhMuc.Location = new System.Drawing.Point(12, 203);
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.ReadOnly = true;
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.RowHeadersWidth = 70;
            this.dgvDanhMuc.RowTemplate.Height = 70;
            this.dgvDanhMuc.Size = new System.Drawing.Size(980, 331);
            this.dgvDanhMuc.TabIndex = 2;
            this.dgvDanhMuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhMuc_CellClick);
            this.dgvDanhMuc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDanhMuc_KeyDown);
            // 
            // colMaDanhMuc
            // 
            this.colMaDanhMuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaDanhMuc.DataPropertyName = "MaDanhMuc";
            this.colMaDanhMuc.HeaderText = "Mã Danh Mục";
            this.colMaDanhMuc.Name = "colMaDanhMuc";
            this.colMaDanhMuc.ReadOnly = true;
            // 
            // colTenDanhMuc
            // 
            this.colTenDanhMuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.colTenDanhMuc.HeaderText = "Tên Danh Mục";
            this.colTenDanhMuc.Name = "colTenDanhMuc";
            this.colTenDanhMuc.ReadOnly = true;
            // 
            // colTongSoSP
            // 
            this.colTongSoSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTongSoSP.DataPropertyName = "TongSP";
            this.colTongSoSP.HeaderText = "Tổng Số Sản Phẩm Hiện Có";
            this.colTongSoSP.Name = "colTongSoSP";
            this.colTongSoSP.ReadOnly = true;
            // 
            // lbDemDanhMuc
            // 
            this.lbDemDanhMuc.AutoSize = true;
            this.lbDemDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDemDanhMuc.Location = new System.Drawing.Point(9, 187);
            this.lbDemDanhMuc.Name = "lbDemDanhMuc";
            this.lbDemDanhMuc.Size = new System.Drawing.Size(64, 13);
            this.lbDemDanhMuc.TabIndex = 6;
            this.lbDemDanhMuc.Text = "Danh mục";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 537);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "(*) Bấm nút Delete để xóa";
            // 
            // frmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 576);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbDemDanhMuc);
            this.Controls.Add(this.dgvDanhMuc);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbDanhMuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmDanhMuc";
            this.Text = "QUẢN LÍ DANH MỤC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDanhMuc_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDanhMuc_FormClosed);
            this.Load += new System.EventHandler(this.frmDanhMuc_Load);
            this.grbDanhMuc.ResumeLayout(false);
            this.grbDanhMuc.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDanhMuc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.TextBox txtTKTenDanhMuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTKMaDanhMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongSoSP;
        private System.Windows.Forms.Label lbDemDanhMuc;
        private System.Windows.Forms.Label lbTenDanhMuc;
        private System.Windows.Forms.Label label7;
    }
}