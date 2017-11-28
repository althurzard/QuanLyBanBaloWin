namespace QuanLyBanBalo
{
    partial class frmInHDBanHang
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
            this.rptHDBH = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptHDBH
            // 
            this.rptHDBH.Location = new System.Drawing.Point(1, 2);
            this.rptHDBH.Name = "rptHDBH";
            this.rptHDBH.ServerReport.BearerToken = null;
            this.rptHDBH.Size = new System.Drawing.Size(860, 538);
            this.rptHDBH.TabIndex = 0;
            // 
            // frmInHDBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 541);
            this.Controls.Add(this.rptHDBH);
            this.Name = "frmInHDBanHang";
            this.Text = "frmInHDBanHang";
            this.Load += new System.EventHandler(this.frmInHDBanHang_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptHDBH;
    }
}