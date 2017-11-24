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
                string query = string.Format("UPDATE ChiTietSanPham SET SoLuong =  @SoLuong WHERE MaCTSP = @MaCTSP AND MauSac = @MauSac");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaCTSP", SqlDbType.Char).Value = chiTietSanPham.MaCTSP;
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

<<<<<<< HEAD
        public static SqlDataReader LayChiTiet(string maSP,string mauSac)
=======
        public static bool CapNhatSoLuong(string maCTSP, int soLuong)
        {
            clsChiTietSP_DTO chiTiet = LayChiTiet(maCTSP);
            if (chiTiet != null)
            {
                int tongSLSP = chiTiet.SoLuong - soLuong;
                string query = string.Format("UPDATE ChiTietSanPham SET SoLuong = {0} WHERE MaCTSP = '{1}'", tongSLSP, maCTSP);
                return XuLyDuLieu.ThucThiCauLenh(query) >= 1;

            } else
            {
                return false;
            }
           
        }

        public static SqlDataReader LayChiTiet(string maSp,string mauSac)
>>>>>>> upstream/master
        {
            SqlDataReader drChiTiet;
            string query = string.Format("SELECT * FROM ChiTietSanPham WHERE MaSP = '{0}' AND MauSac =N'{1}'", maSP, mauSac);
            drChiTiet = XuLyDuLieu.LayDuLieu(query);
            return drChiTiet;
        }

        public static clsChiTietSP_DTO LayChiTiet(string maCTSP)
        {
            clsChiTietSP_DTO ctsp = null;
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from ChiTietSanPham where MaCTSP = '{0}' ", maCTSP);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ctsp = new clsChiTietSP_DTO();
                        ctsp.MaCTSP = maCTSP;
                        ctsp.MaHinhAnh = int.Parse(reader["MaHinhAnh"].ToString());
                        ctsp.MaSP = reader["MaSP"].ToString();
                        ctsp.MauSac = reader["MauSac"].ToString();
                        ctsp.TrangThai = int.Parse(reader["TrangThai"].ToString());
                        ctsp.SoLuong = int.Parse(reader["SoLuong"].ToString());
                    }
                }

            }

            return ctsp;
        }
        public static bool KiemTraTonTaiMaCT(string _maCT)
        {
            string query = string.Format("select count(*) from ChiTietSanPham where MaCTSP = '{0}'", _maCT);
            return XuLyDuLieu.ThucThiCauLenhWithScalar(query) >= 1;
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

        public static List<string> LayMaCTSP()
        {
            List<string> listMa = new List<string>();
            string query = string.Format("Select DISTINCT MaCTSP from ChiTietSanPham where SoLuong > 0 ORDER BY MaCTSP");
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listMa.Add(reader["MaCTSP"].ToString());
                    }

                }
                conn.Close();
            }

            return listMa;
        }
    }
}
