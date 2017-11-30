using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBalo
{
    public partial class frmInBaoCaoDoanhThu : Form
    {
        public frmInBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        string tuNgay = "";
        string denNgay = "";
        string doanhThu = "";
        string loiNhuan = "";
        private DataTable bangThongKe;

        public frmInBaoCaoDoanhThu(DataTable dt, string tuNgay, string denNgay, string doanhThu, string loiNhuan)
        {
            this.tuNgay = tuNgay;
            this.denNgay = denNgay;
            this.doanhThu = doanhThu;
            this.loiNhuan = loiNhuan;
            bangThongKe = dt;
            InitializeComponent();
        }

        private void frmInBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            this.rptBCDT.LocalReport.ReportEmbeddedResource = "QuanLyBanBalo.rptBaoCaoDoanhThu.rdlc";

            this.rptBCDT.LocalReport.DataSources.Add(new ReportDataSource("dataBaoCaoDoanhThu", bangThongKe));

            this.rptBCDT.LocalReport.SetParameters(new ReportParameter("TuNgay", tuNgay, false));

            this.rptBCDT.LocalReport.SetParameters(new ReportParameter("DenNgay", denNgay, false));

            this.rptBCDT.LocalReport.SetParameters(new ReportParameter("TongDoanhThu", doanhThu, false));

            this.rptBCDT.LocalReport.SetParameters(new ReportParameter("TongLoiNhuan", loiNhuan, false));

            this.rptBCDT.RefreshReport();
        }
    }
}
