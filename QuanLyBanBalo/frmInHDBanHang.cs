﻿using System;
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
using System.Globalization;

namespace QuanLyBanBalo
{
    public partial class frmInHDBanHang : Form
    {
        private DataTable dtSanPham;
        private clsHoaDon_DTO hoaDon;
        private clsKhuyenMai_DTO khuyenMai;
        private string thanhTien;

        public frmInHDBanHang(DataTable dt,clsHoaDon_DTO hd,clsKhuyenMai_DTO km, string tongTien)
        {
            dtSanPham = dt.Copy();
            hoaDon = hd;
            khuyenMai = km;
            tongTien = tongTien.Trim(',');
            this.thanhTien = Helper.ChuyenSo(new string((from c in tongTien
                                                         where char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)
                                                         select c).ToArray()));
            this.thanhTien = new CultureInfo("vn-VN").TextInfo.ToTitleCase(this.thanhTien) + ".";
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

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("TenKH", hoaDon.KhachHang.TenKH, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("SDT", hoaDon.KhachHang.SDT, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("TenNV", Validation.nhanVien.NhanVien.HoTen, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("MaHD", hoaDon.MaHD, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("HDKhuyenMai", khuyenMai.MoTa, false));

            this.rptHDBH.LocalReport.SetParameters(new ReportParameter("ThanhTienBangChu", thanhTien, false));

            this.rptHDBH.RefreshReport();
           
        }
    }
}
