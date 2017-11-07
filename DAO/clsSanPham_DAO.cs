using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class clsSanPham_DAO
    {
        public DataTable LayTatCaSanPham()
        {
            DataTable dt = new DataTable();
            string query = "SELECT SanPham.MaSP, SanPham.TenSP, SanPham.ThuongHieu,SanPham.ChatLieu,SanPham.GiaVon,SanPham.GiaBanLe,SanPham.ChongNuoc,SanPham.SoNamBH, DanhMuc.* , ChiTietSanPham.MauSac, ChiTietSanPham.SoLuong, HinhAnh.Url " +
                "FROM SanPham, DanhMuc, ChiTietSanPham, HinhAnh " +
                "WHERE SanPham.MaDanhMuc = DanhMuc.MaDanhMuc AND ChiTietSanPham.MaSP = SanPham.MaSP AND ChiTietSanPham.MaHinhAnh = HinhAnh.MaHinhAnh ";
            dt = XuLyDuLieu.LayBang(query);
            return dt;
        }
    }
}
