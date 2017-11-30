namespace QuanLyBanBalo
{
    partial class frmMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.nhapHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.matHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhaCungCapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baoHanhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khuyenMaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baoCaoToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.nhapHangToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troGiupToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.cáchSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vềChúngTôiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.baoCaoToolStripDropDownButton,
            this.troGiupToolStripDropDownButton,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(154, 414);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhapHangToolStripMenuItem,
            this.banHangToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::QuanLyBanBalo.Properties.Resources.Carrycart;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(151, 54);
            this.toolStripDropDownButton1.Text = "Nghiệp vụ";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // nhapHangToolStripMenuItem
            // 
            this.nhapHangToolStripMenuItem.Name = "nhapHangToolStripMenuItem";
            this.nhapHangToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.nhapHangToolStripMenuItem.Text = "Nhập hàng";
            this.nhapHangToolStripMenuItem.Click += new System.EventHandler(this.nhapHangToolStripMenuItem_Click);
            // 
            // banHangToolStripMenuItem
            // 
            this.banHangToolStripMenuItem.Name = "banHangToolStripMenuItem";
            this.banHangToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.banHangToolStripMenuItem.Text = "Bán hàng";
            this.banHangToolStripMenuItem.Click += new System.EventHandler(this.banHangToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matHangToolStripMenuItem,
            this.nhanVienToolStripMenuItem,
            this.nhaCungCapToolStripMenuItem,
            this.baoHanhToolStripMenuItem,
            this.khuyenMaiToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::QuanLyBanBalo.Properties.Resources.Paperdesk;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(151, 54);
            this.toolStripDropDownButton2.Text = "Quản Lý";
            // 
            // matHangToolStripMenuItem
            // 
            this.matHangToolStripMenuItem.Name = "matHangToolStripMenuItem";
            this.matHangToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.matHangToolStripMenuItem.Text = "Mặt hàng";
            this.matHangToolStripMenuItem.Click += new System.EventHandler(this.mặtHàngToolStripMenuItem_Click);
            // 
            // nhanVienToolStripMenuItem
            // 
            this.nhanVienToolStripMenuItem.Name = "nhanVienToolStripMenuItem";
            this.nhanVienToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.nhanVienToolStripMenuItem.Text = "Nhân viên";
            this.nhanVienToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // nhaCungCapToolStripMenuItem
            // 
            this.nhaCungCapToolStripMenuItem.Name = "nhaCungCapToolStripMenuItem";
            this.nhaCungCapToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.nhaCungCapToolStripMenuItem.Text = "Nhà Cung Cấp";
            this.nhaCungCapToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);
            // 
            // baoHanhToolStripMenuItem
            // 
            this.baoHanhToolStripMenuItem.Name = "baoHanhToolStripMenuItem";
            this.baoHanhToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.baoHanhToolStripMenuItem.Text = "Bảo hành";
            this.baoHanhToolStripMenuItem.Click += new System.EventHandler(this.bảoHànhToolStripMenuItem_Click);
            // 
            // khuyenMaiToolStripMenuItem
            // 
            this.khuyenMaiToolStripMenuItem.Name = "khuyenMaiToolStripMenuItem";
            this.khuyenMaiToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.khuyenMaiToolStripMenuItem.Text = "Khuyến mại";
            this.khuyenMaiToolStripMenuItem.Click += new System.EventHandler(this.khuyếnMạiToolStripMenuItem_Click);
            // 
            // baoCaoToolStripDropDownButton
            // 
            this.baoCaoToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhapHangToolStripMenuItem1,
            this.doanhThuToolStripMenuItem});
            this.baoCaoToolStripDropDownButton.Image = global::QuanLyBanBalo.Properties.Resources.Notifications;
            this.baoCaoToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.baoCaoToolStripDropDownButton.Name = "baoCaoToolStripDropDownButton";
            this.baoCaoToolStripDropDownButton.Size = new System.Drawing.Size(151, 54);
            this.baoCaoToolStripDropDownButton.Text = "Báo cáo";
            // 
            // nhapHangToolStripMenuItem1
            // 
            this.nhapHangToolStripMenuItem1.Name = "nhapHangToolStripMenuItem1";
            this.nhapHangToolStripMenuItem1.Size = new System.Drawing.Size(165, 26);
            this.nhapHangToolStripMenuItem1.Text = "Nhập hàng";
            this.nhapHangToolStripMenuItem1.Click += new System.EventHandler(this.nhapHangToolStripMenuItem1_Click);
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(165, 26);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // troGiupToolStripDropDownButton
            // 
            this.troGiupToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cáchSửDụngToolStripMenuItem,
            this.vềChúngTôiToolStripMenuItem});
            this.troGiupToolStripDropDownButton.Image = global::QuanLyBanBalo.Properties.Resources.Book;
            this.troGiupToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.troGiupToolStripDropDownButton.Name = "troGiupToolStripDropDownButton";
            this.troGiupToolStripDropDownButton.Size = new System.Drawing.Size(151, 54);
            this.troGiupToolStripDropDownButton.Text = "Trợ giúp";
            // 
            // cáchSửDụngToolStripMenuItem
            // 
            this.cáchSửDụngToolStripMenuItem.Name = "cáchSửDụngToolStripMenuItem";
            this.cáchSửDụngToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.cáchSửDụngToolStripMenuItem.Text = "Cách sử dụng";
            // 
            // vềChúngTôiToolStripMenuItem
            // 
            this.vềChúngTôiToolStripMenuItem.Name = "vềChúngTôiToolStripMenuItem";
            this.vềChúngTôiToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.vềChúngTôiToolStripMenuItem.Text = "Về chúng tôi";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = global::QuanLyBanBalo.Properties.Resources.if_close_1282956;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(151, 54);
            this.toolStripButton1.Text = "Đăng Xuất";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbcMain
            // 
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.ItemSize = new System.Drawing.Size(0, 15);
            this.tbcMain.Location = new System.Drawing.Point(154, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.Padding = new System.Drawing.Point(10, 3);
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(790, 414);
            this.tbcMain.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbcMain.TabIndex = 2;
            this.tbcMain.DoubleClick += new System.EventHandler(this.tbcMain_DoubleClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(944, 414);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ BÁN BALO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem nhapHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem matHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhaCungCapToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton baoCaoToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem nhapHangToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton troGiupToolStripDropDownButton;
        private System.Windows.Forms.ToolStripMenuItem cáchSửDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vềChúngTôiToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem baoHanhToolStripMenuItem;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.ToolStripMenuItem khuyenMaiToolStripMenuItem;
    }
}

