using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class clsChiTietSanPham_DAO
    {
        public static object ThemChiTietSanPham(clsChiTietSP_DTO chiTietSanPham)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("INSERT INTO ChiTietSanPham(MaSP,MaCTSP,MauSac,SoLuong,MaHinhAnh,TrangThai) VALUES(@MaSP,@MaCTSP,@MauSac,@SoLuong,@MaHinhAnh,@TrangThai)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaSP", SqlDbType.Char).Value = chiTietSanPham.MaSP;
                cmd.Parameters.Add("@MaCTSP", SqlDbType.Char).Value = chiTietSanPham.MaCTSP;
                cmd.Parameters.Add("@MauSac", SqlDbType.NVarChar).Value = chiTietSanPham.MauSac;
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = chiTietSanPham.SoLuong;
                cmd.Parameters.Add("@MaHinhAnh", SqlDbType.Int).Value = chiTietSanPham.MaHinhAnh;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = chiTietSanPham.TrangThai;
                cmd.CommandType = CommandType.Text;
                try
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (SqlException e)
                {
                    return e.Message.ToString();
                }
            }
        }
    }
}
