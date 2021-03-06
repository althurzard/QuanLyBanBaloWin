﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class clsChiTietHD_DAO
    {
        public static bool Them(clsChiTietHD_DTO CTHD)
        {
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                string query = "Insert into ChiTietHoaDon(MaCTHD,MaHD,MaCTSP,GiamTru,SoLuong,MaKhuyenMai,TongTien) values (@MaCTHD,@MaHD,@MaCTSP,@GiamTru,@SoLuong,@MaKhuyenMai,@TongTien)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MaCTHD", SqlDbType.Char).Value = CTHD.MaCTHD;
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = CTHD.HoaDon.MaHD;
                cmd.Parameters.Add("@MaCTSP", SqlDbType.Char).Value = CTHD.MaCTSP;
                cmd.Parameters.Add("@GiamTru", SqlDbType.Money).Value = CTHD.GiamTru;
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = CTHD.SoLuong;
                cmd.Parameters.Add("@MaKhuyenMai", SqlDbType.Int).Value = CTHD.KhuyenMai.MaKhuyenMai;
                cmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = CTHD.TongTien;
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

        public static DataTable LayChiTiet(string maHD)
        {
            string query = string.Format("select Url,TenSP,ChiTietSanPham.MaCTSP as MaCTSP,MauSac,ThuongHieu,GiaBanLe,TenKhuyenMai,GiamTru,SoNamBH,ChiTietHoaDon.SoLuong as SoLuong,TongTien from SanPham,ChiTietHoaDon,ChiTietSanPham,HinhAnh,KhuyenMai where ChiTietHoaDon.MaHD = '{0}' AND ChiTietHoaDon.MaCTSP = ChiTietSanPham.MaCTSP AND ChiTietSanPham.MaHinhAnh = HinhAnh.MaHinhAnh AND ChiTietSanPham.MaSP = SanPham.MaSP AND ChiTietHoaDon.MaKhuyenMai = KhuyenMai.MaKhuyenMai",maHD);
            return XuLyDuLieu.LayBang(query);
        }
    }
}
