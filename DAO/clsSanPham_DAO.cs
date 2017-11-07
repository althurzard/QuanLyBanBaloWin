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
        DataTable dtSanPham;
        public DataTable LayTatCaSanPham()
        {
            string query = "SELECT SanPham.MaSP, SanPham.TenSP, SanPham.ThuongHieu,SanPham.ChatLieu,SanPham.GiaVon,SanPham.GiaBanLe,SanPham.ChongNuoc,SanPham.SoNamBH, DanhMuc.* , ChiTietSanPham.MauSac, ChiTietSanPham.SoLuong, HinhAnh.Url " +
                "FROM SanPham, DanhMuc, ChiTietSanPham, HinhAnh " +
                "WHERE SanPham.MaDanhMuc = DanhMuc.MaDanhMuc AND ChiTietSanPham.MaSP = SanPham.MaSP AND ChiTietSanPham.MaHinhAnh = HinhAnh.MaHinhAnh ";
            dtSanPham = XuLyDuLieu.LayBang(query);
            return dtSanPham;
        }

        public DataTable LayTatCaMauMa()
        {
            string query = "SELECT * FROM DanhMuc";
            dtSanPham = XuLyDuLieu.LayBang(query);
            return dtSanPham;
        }
    }
}
