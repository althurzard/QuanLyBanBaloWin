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
    }
}
