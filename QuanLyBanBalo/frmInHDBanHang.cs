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
    public partial class frmInHDBanHang : Form
    {
        private DataTable dtSanPham;
        private clsHoaDon_DTO hoaDon;

        public frmInHDBanHang(DataTable dt,clsHoaDon_DTO hd)
        {
            dtSanPham = dt.Copy();
            hoaDon = hd;
            CapNhatLaiTenSP();
            InitializeComponent();
        }

        private void CapNhatLaiTenSP()
        {
            foreach(DataRow row in dtSanPham.Rows)
            {
                row["TenSP"] = string.Format("{0}-{1}-{2}", row["TenSP"].ToString(), row["ThuongHieu"].ToString(), row["MauSac"].ToString());
            }
        }

        private void frmInHDBanHang_Load(object sender, EventArgs e)
        {

            this.rptHDBH.LocalReport.ReportEmbeddedResource = "QuanLyBanBalo.rptHDBanHang.rdlc";

            this.rptHDBH.LocalReport.DataSources.Add(new ReportDataSource("dataHDBanHang", dtSanPham));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("TenKH", hoaDon.TenKH, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("SDT", hoaDon.SDT, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("TenNV", Validation.nhanVien.NhanVien.HoTen, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("MaHD", hoaDon.MaHD, false));

            this.rptHDBH.RefreshReport();
           
        }
    }
}
