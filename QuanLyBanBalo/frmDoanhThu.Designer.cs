namespace QuanLyBanBalo
{
    partial class frmDoanhThu
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
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.pckNgayNhapBD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pckNgayNhapKT = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLocDL = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMaPhieuNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(372, 135);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(217, 26);
            this.txtMaPhieuNhap.TabIndex = 32;
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHoaDon.Location = new System.Drawing.Point(30, 37);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(117, 20);
            this.lblMaHoaDon.TabIndex = 33;
            this.lblMaHoaDon.Text = "Mã Phiếu Nhập";
            // 
            // pckNgayNhapBD
            // 
            this.pckNgayNhapBD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pckNgayNhapBD.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pckNgayNhapBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pckNgayNhapBD.Location = new System.Drawing.Point(371, 190);
            this.pckNgayNhapBD.Name = "pckNgayNhapBD";
            this.pckNgayNhapBD.Size = new System.Drawing.Size(217, 26);
            this.pckNgayNhapBD.TabIndex = 34;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayNhap.Location = new System.Drawing.Point(30, 96);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(85, 20);
            this.lblNgayNhap.TabIndex = 35;
            this.lblNgayNhap.Text = "Ngày nhập";
            this.lblNgayNhap.Click += new System.EventHandler(this.lblNgayNhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "đến";
            // 
            // pckNgayNhapKT
            // 
            this.pckNgayNhapKT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pckNgayNhapKT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pckNgayNhapKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pckNgayNhapKT.Location = new System.Drawing.Point(658, 190);
            this.pckNgayNhapKT.Name = "pckNgayNhapKT";
            this.pckNgayNhapKT.Size = new System.Drawing.Size(217, 26);
            this.pckNgayNhapKT.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "Lọc theo";
            // 
            // cboLocDL
            // 
            this.cboLocDL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboLocDL.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocDL.FormattingEnabled = true;
            this.cboLocDL.Location = new System.Drawing.Point(372, 245);
            this.cboLocDL.Name = "cboLocDL";
            this.cboLocDL.Size = new System.Drawing.Size(217, 27);
            this.cboLocDL.TabIndex = 39;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 310);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(726, 221);
            this.dataGridView1.TabIndex = 40;
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 681);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboLocDL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pckNgayNhapKT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pckNgayNhapBD);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.lblMaHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDoanhThu";
            this.Text = "DANH SÁCH HÓA ĐƠN NHẬP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDanhSachHDN_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDanhSachHDN_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.DateTimePicker pckNgayNhapBD;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker pckNgayNhapKT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLocDL;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}