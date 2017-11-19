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
        public static bool KiemTraTonTaiMau(string maSanPham, string mauSac)
        {
            
             string query = string.Format("SELECT count(MaSP) FROM ChiTietSanPham WHERE MauSac = N'{0}' AND MaSP = '{1}'",mauSac,maSanPham);
             return XuLyDuLieu.ThucThiCauLenhWithScalar(query)>=1 ;
        }

        public static object CapNhatSoLuong(clsChiTietSP_DTO chiTietSanPham)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("UPDATE ChiTietSanPham SET SoLuong =  @SoLuong WHERE MaSP = @MaSP AND MauSac = @MauSac");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaSP", SqlDbType.Char).Value = chiTietSanPham.MaSP;
                cmd.Parameters.Add("@MauSac", SqlDbType.NVarChar).Value = chiTietSanPham.MauSac;
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = chiTietSanPham.SoLuong;
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

        public static SqlDataReader LayChiTiet(string maSp,string mauSac)
        {
            SqlDataReader drChiTiet;
            string query = string.Format("SELECT * FROM ChiTietSanPham WHERE MaSP = '{0}' and MauSac = N'{1}'",maSp,mauSac);
            drChiTiet = XuLyDuLieu.LayDuLieu(query);
            return drChiTiet;
        }

        public static List<string> LayMauSac()
        {
            List<string> listMauSac = new List<string>();
            string query = string.Format("Select DISTINCT MauSac from ChiTietSanPham ORDER BY MauSac");
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listMauSac.Add(reader["MauSac"].ToString());
                    }

                }
                conn.Close();
            }

            return listMauSac;
        }
    }
}
