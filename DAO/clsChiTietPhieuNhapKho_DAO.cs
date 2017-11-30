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
    public class clsChiTietPhieuNhapKho_DAO
    {
        public static object ThemChiTietPhieuNhapKho(clsChiTietPhieuNhapKho_DTO chiTiet)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("INSERT INTO ChiTietPhieuNhapKho(MaCTPhieuNhapKho,MaCTSP,SoLuong,MaPhieuNhapKho) VALUES (@MaCTPhieuNhapKho,@MaCTSP,@SoLuong,@MaPhieuNhapKho)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaCTPhieuNhapKho", SqlDbType.Char).Value = chiTiet.MaChiTiet;
                cmd.Parameters.Add("@MaCTSP", SqlDbType.Char).Value = chiTiet.MaCTSanPham;
                cmd.Parameters.Add("@SoLuong", SqlDbType.Int).Value = chiTiet.SoLuong;
                cmd.Parameters.Add("@MaPhieuNhapKho", SqlDbType.NVarChar).Value = chiTiet.MaPhieuNhapKho;
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

        public static clsChiTietPhieuNhapKho_DTO LayChiTiet(string maPhieuNK)
        {
            clsChiTietPhieuNhapKho_DTO ctnk = null;
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from ChiTietPhieuNhapKho where MaPhieuNhapKho = '{0}' ", maPhieuNK);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ctnk = new clsChiTietPhieuNhapKho_DTO();
                        ctnk.MaChiTiet = reader["MaCTPhieuNhapKho"].ToString();
                        ctnk.MaCTSanPham = reader["MaCTSP"].ToString();
                        ctnk.SoLuong = (int)reader["SoLuong"];
                        ctnk.MaPhieuNhapKho = maPhieuNK;
                    }
                }

            }

            return ctnk;
        }

        public static List<clsChiTietPhieuNhapKho_DTO> LayDanhSach(string maPhieuNK)
        {
            List<clsChiTietPhieuNhapKho_DTO> list = new List<clsChiTietPhieuNhapKho_DTO>();
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from ChiTietPhieuNhapKho where MaPhieuNhapKho = '{0}' ", maPhieuNK);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsChiTietPhieuNhapKho_DTO ctnk = new clsChiTietPhieuNhapKho_DTO();
                        ctnk.MaChiTiet = reader["MaCTPhieuNhapKho"].ToString();
                        ctnk.MaCTSanPham = reader["MaCTSP"].ToString();
                        ctnk.SoLuong = (int)reader["SoLuong"];
                        ctnk.MaPhieuNhapKho = maPhieuNK;
                        list.Add(ctnk);
                    }
                }

            }

            return list;
        }
    }
}
