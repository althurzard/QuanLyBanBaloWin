using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices;
using DTO;
namespace QuanLyBanBalo
{
    public partial class frmInThongKeChiTietPNK : Form
    {
        string tuNgay = "";
        string denNgay = "";
        string tongCong = "";
        private DataTable bangThongKe;

        public frmInThongKeChiTietPNK()
        {
            InitializeComponent();
        }

        public frmInThongKeChiTietPNK(DataTable dt, string tuNgay, string denNgay, string tongCong)
        {
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.tongCong = tongCong;
            bangThongKe = dt;
            InitializeComponent();
        }


        private void frmThongKeChiTietPNK_Load(object sender, EventArgs e)
        {
            this.rptTKCTPNK.LocalReport.ReportEmbeddedResource = "QuanLyBanBalo.rptThongKeChiTietPNK.rdlc";

            this.rptTKCTPNK.LocalReport.DataSources.Add(new ReportDataSource("dataThongKeChiTietPNK", bangThongKe));

            this.rptTKCTPNK.LocalReport.SetParameters(new ReportParameter("TuNgay", tuNgay, false));

            this.rptTKCTPNK.LocalReport.SetParameters(new ReportParameter("DenNgay", denNgay, false));

            this.rptTKCTPNK.LocalReport.SetParameters(new ReportParameter("TongCong", tongCong, false));

            this.rptTKCTPNK.RefreshReport();
        }
    }
}
