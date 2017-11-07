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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchHĐNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hóaĐơnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchHĐXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mặtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảoHànhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.nhậpHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtHàngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.cáchSửDụngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vềChúngTôiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton4,
            this.toolStripDropDownButton5,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(126, 414);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbcMain
            // 
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.ItemSize = new System.Drawing.Size(0, 15);
            this.tbcMain.Location = new System.Drawing.Point(126, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.Padding = new System.Drawing.Point(10, 3);
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(818, 414);
            this.tbcMain.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tbcMain.TabIndex = 2;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHàngToolStripMenuItem,
            this.xuấtHàngToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::QuanLyBanBalo.Properties.Resources.Carrycart;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(123, 54);
            this.toolStripDropDownButton1.Text = "Nghiệp vụ";
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hóaĐơnNhậpToolStripMenuItem,
            this.danhSáchHĐNToolStripMenuItem});
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nhậpHàngToolStripMenuItem.Text = "Nhập hàng";
            // 
            // hóaĐơnNhậpToolStripMenuItem
            // 
            this.hóaĐơnNhậpToolStripMenuItem.Name = "hóaĐơnNhậpToolStripMenuItem";
            this.hóaĐơnNhậpToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.hóaĐơnNhậpToolStripMenuItem.Text = "Hóa đơn Nhập";
            this.hóaĐơnNhậpToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnNhậpToolStripMenuItem_Click);
            // 
            // danhSáchHĐNToolStripMenuItem
            // 
            this.danhSáchHĐNToolStripMenuItem.Name = "danhSáchHĐNToolStripMenuItem";
            this.danhSáchHĐNToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.danhSáchHĐNToolStripMenuItem.Text = "Danh Sách HĐN";
            this.danhSáchHĐNToolStripMenuItem.Click += new System.EventHandler(this.danhSáchHĐNToolStripMenuItem_Click);
            // 
            // xuấtHàngToolStripMenuItem
            // 
            this.xuấtHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hóaĐơnXuấtToolStripMenuItem,
            this.danhSáchHĐXToolStripMenuItem});
            this.xuấtHàngToolStripMenuItem.Name = "xuấtHàngToolStripMenuItem";
            this.xuấtHàngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xuấtHàngToolStripMenuItem.Text = "Xuất hàng";
            // 
            // hóaĐơnXuấtToolStripMenuItem
            // 
            this.hóaĐơnXuấtToolStripMenuItem.Name = "hóaĐơnXuấtToolStripMenuItem";
            this.hóaĐơnXuấtToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.hóaĐơnXuấtToolStripMenuItem.Text = "Hóa đơn Xuất";
            this.hóaĐơnXuấtToolStripMenuItem.Click += new System.EventHandler(this.hóaĐơnXuấtToolStripMenuItem_Click);
            // 
            // danhSáchHĐXToolStripMenuItem
            // 
            this.danhSáchHĐXToolStripMenuItem.Name = "danhSáchHĐXToolStripMenuItem";
            this.danhSáchHĐXToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.danhSáchHĐXToolStripMenuItem.Text = "Danh Sách HĐX";
            this.danhSáchHĐXToolStripMenuItem.Click += new System.EventHandler(this.danhSáchHĐXToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mặtHàngToolStripMenuItem,
            this.nhânViênToolStripMenuItem,
            this.nhàCungCấpToolStripMenuItem,
            this.bảoHànhToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::QuanLyBanBalo.Properties.Resources.Paperdesk;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(123, 54);
            this.toolStripDropDownButton2.Text = "Danh Mục";
            // 
            // mặtHàngToolStripMenuItem
            // 
            this.mặtHàngToolStripMenuItem.Name = "mặtHàngToolStripMenuItem";
            this.mặtHàngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.mặtHàngToolStripMenuItem.Text = "Mặt hàng";
            this.mặtHàngToolStripMenuItem.Click += new System.EventHandler(this.mặtHàngToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà Cung Cấp";
            this.nhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);
            // 
            // bảoHànhToolStripMenuItem
            // 
            this.bảoHànhToolStripMenuItem.Name = "bảoHànhToolStripMenuItem";
            this.bảoHànhToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bảoHànhToolStripMenuItem.Text = "Bảo hành";
            this.bảoHànhToolStripMenuItem.Click += new System.EventHandler(this.bảoHànhToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton4
            // 
            this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpHàngToolStripMenuItem1,
            this.xuấtHàngToolStripMenuItem1,
            this.tồnKhoToolStripMenuItem,
            this.doanhThuToolStripMenuItem});
            this.toolStripDropDownButton4.Image = global::QuanLyBanBalo.Properties.Resources.Notifications;
            this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
            this.toolStripDropDownButton4.Size = new System.Drawing.Size(123, 54);
            this.toolStripDropDownButton4.Text = "Báo cáo";
            // 
            // nhậpHàngToolStripMenuItem1
            // 
            this.nhậpHàngToolStripMenuItem1.Name = "nhậpHàngToolStripMenuItem1";
            this.nhậpHàngToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.nhậpHàngToolStripMenuItem1.Text = "Nhập hàng";
            // 
            // xuấtHàngToolStripMenuItem1
            // 
            this.xuấtHàngToolStripMenuItem1.Name = "xuấtHàngToolStripMenuItem1";
            this.xuấtHàngToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.xuấtHàngToolStripMenuItem1.Text = "Xuất hàng";
            // 
            // tồnKhoToolStripMenuItem
            // 
            this.tồnKhoToolStripMenuItem.Name = "tồnKhoToolStripMenuItem";
            this.tồnKhoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tồnKhoToolStripMenuItem.Text = "Tồn kho";
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            // 
            // toolStripDropDownButton5
            // 
            this.toolStripDropDownButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cáchSửDụngToolStripMenuItem,
            this.vềChúngTôiToolStripMenuItem});
            this.toolStripDropDownButton5.Image = global::QuanLyBanBalo.Properties.Resources.Book;
            this.toolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            this.toolStripDropDownButton5.Size = new System.Drawing.Size(123, 54);
            this.toolStripDropDownButton5.Text = "Trợ giúp";
            // 
            // cáchSửDụngToolStripMenuItem
            // 
            this.cáchSửDụngToolStripMenuItem.Name = "cáchSửDụngToolStripMenuItem";
            this.cáchSửDụngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cáchSửDụngToolStripMenuItem.Text = "Cách sử dụng";
            // 
            // vềChúngTôiToolStripMenuItem
            // 
            this.vềChúngTôiToolStripMenuItem.Name = "vềChúngTôiToolStripMenuItem";
            this.vềChúngTôiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.vềChúngTôiToolStripMenuItem.Text = "Về chúng tôi";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = global::QuanLyBanBalo.Properties.Resources.if_close_1282956;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(123, 54);
            this.toolStripButton1.Text = "THOÁT";
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
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hóaĐơnXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem mặtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xuấtHàngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem cáchSửDụngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vềChúngTôiToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem danhSáchHĐNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchHĐXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bảoHànhToolStripMenuItem;
        private System.Windows.Forms.TabControl tbcMain;
    }
}

