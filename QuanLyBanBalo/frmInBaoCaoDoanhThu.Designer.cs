namespace QuanLyBanBalo
{
    partial class frmInBaoCaoDoanhThu
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
            this.rptBCDT = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptBCDT
            // 
            this.rptBCDT.Location = new System.Drawing.Point(1, 1);
            this.rptBCDT.Name = "rptBCDT";
            this.rptBCDT.ServerReport.BearerToken = null;
            this.rptBCDT.Size = new System.Drawing.Size(961, 528);
            this.rptBCDT.TabIndex = 0;
            // 
            // frmInBaoCaoDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 527);
            this.Controls.Add(this.rptBCDT);
            this.Name = "frmInBaoCaoDoanhThu";
            this.Text = "BÁO CÁO DOANH THU";
            this.Load += new System.EventHandler(this.frmInBaoCaoDoanhThu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptBCDT;
    }
}