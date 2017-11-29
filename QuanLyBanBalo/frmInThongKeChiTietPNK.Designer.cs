namespace QuanLyBanBalo
{
    partial class frmInThongKeChiTietPNK
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
            this.rptTKCTPNK = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptTKCTPNK
            // 
            this.rptTKCTPNK.Location = new System.Drawing.Point(0, 1);
            this.rptTKCTPNK.Name = "rptTKCTPNK";
            this.rptTKCTPNK.ServerReport.BearerToken = null;
            this.rptTKCTPNK.Size = new System.Drawing.Size(901, 526);
            this.rptTKCTPNK.TabIndex = 0;
            // 
            // frmThongKeChiTietPNK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 527);
            this.Controls.Add(this.rptTKCTPNK);
            this.Name = "frmThongKeChiTietPNK";
            this.Text = "Thống kê chi tiết phiếu nhập kho";
            this.Load += new System.EventHandler(this.frmThongKeChiTietPNK_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptTKCTPNK;
    }
}