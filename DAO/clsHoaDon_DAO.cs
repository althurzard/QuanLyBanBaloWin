﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class clsHoaDon_DAO
    {
        public static bool Them(clsHoaDon_DTO hoaDon)
        {
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                string query = "Insert into HoaDon(MaHD,MaNV,MaKH,NgayKhoiTao,MaKhuyenMai,GiamTru,GhiChu,ThanhTien) values (@MaHD,@MaNV,@MaKH,@NgayKhoiTao,@MaKhuyenMai,@GiamTru,@GhiChu,@ThanhTien) ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = hoaDon.MaHD;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = hoaDon.MaNV;
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = hoaDon.KhachHang.MaKH;
                cmd.Parameters.Add("@NgayKhoiTao", SqlDbType.DateTime).Value = hoaDon.NgayKhoiTao;
                cmd.Parameters.Add("@MaKhuyenMai", SqlDbType.Int).Value = hoaDon.KhuyenMai.MaKhuyenMai;
                cmd.Parameters.Add("@GiamTru", SqlDbType.Money).Value = hoaDon.GiamTru;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = hoaDon.GhiChu;
                cmd.Parameters.Add("@ThanhTien", SqlDbType.Money).Value = hoaDon.ThanhTien;
                cmd.CommandType = CommandType.Text;
                try
                {
                    return cmd.ExecuteNonQuery() >= 1;
                }
                catch (SqlException e)
                {
                    throw e;
                }

            }
        }

        public static DataTable LayHoaDonTheoMaKH(string maKH)
        {
            string query = string.Format("SELECT MaHD,MaNV,KhachHang.MaKH as MaKhachHang,TenKH,SDT,HoaDon.NgayKhoiTao as NgayKhoiTao,TenKhuyenMai,GiamTru,GhiChu,ThanhTien FROM HoaDon,KhuyenMai,KhachHang WHERE HoaDon.MaKH = '{0}' AND KhuyenMai.MaKhuyenMai = HoaDon.MaKhuyenMai AND HoaDon.MaKH = KhachHang.MaKH ORDER BY HoaDon.NgayKhoiTao DESC", maKH);
            return XuLyDuLieu.LayBang(query);
        }

        public static DataTable LayHoaDonTheoMaHD(string maHD)
        {
            string query = string.Format("SELECT MaHD,MaNV,HoaDon.MaKH as MaKhachHang,TenKH,SDT,HoaDon.NgayKhoiTao as NgayKhoiTao,TenKhuyenMai,GiamTru,GhiChu,ThanhTien FROM HoaDon,KhuyenMai,KhachHang WHERE HoaDon.MaHD = '{0}' AND KhuyenMai.MaKhuyenMai = HoaDon.MaKhuyenMai AND KhachHang.MaKH = HoaDon.MaKH ORDER BY HoaDon.NgayKhoiTao DESC", maHD);
            return XuLyDuLieu.LayBang(query);
        }

        public static DataTable LayBangSanPhamTuHDBan(string tuNgay, string denNgay)
        {
            string query = string.Format("Select sp.MaDanhMuc as MaDanhMuc,TenDanhMuc,Url, sp.MaSP as MaSP, TenSP, MauSac, ThuongHieu, ChongNuoc, TrongLuong, ChatLieu, GiaVon, GiaBanLe, cthd.SoLuong as SoLuong, cthd.GiamTru as GiamTru, cthd.TongTien as TongTien" +
                " from HoaDon as hd, ChiTietHoaDon as cthd, SanPham as sp, ChiTietSanPham as ctsp, HinhAnh as ha, DanhMuc as dm" +
                " where hd.NgayKhoiTao >= '{0}' AND hd.NgayKhoiTao <= dateadd(day,1,'{1}') AND hd.MaHD = cthd.MaHD AND cthd.MaCTSP = ctsp.MaCTSP AND ctsp.MaSP = sp.MaSP AND ctsp.MaHinhAnh = ha.MaHinhAnh AND dm.MaDanhMuc = sp.MaDanhMuc ORDER BY hd.NgayKhoiTao DESC", tuNgay, denNgay);
            return XuLyDuLieu.LayBang(query);
        }
    }
}
