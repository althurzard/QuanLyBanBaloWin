using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class clsKhachHang_DAO
    {
        public static bool Them(clsKhachHang_DTO khachHang)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format(
                "Insert into KhachHang (MaKH,TenKH,SDT,NgayKhoiTao) " +
                "values (@MaKH,@TenKH,@SDT,@NgayKhoiTao)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaKH", SqlDbType.Char).Value = khachHang.MaKH;
                cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = khachHang.TenKH;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = khachHang.SDT;
                cmd.Parameters.Add("@NgayKhoiTao", SqlDbType.DateTime).Value = DateTime.Now;
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

        public static clsKhachHang_DTO LayThongTin(string sdt)
        {
            clsKhachHang_DTO khachHang = null;
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from KhachHang where SDT = '{0}' AND TrangThai = 1", sdt);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        khachHang = new clsKhachHang_DTO();
                        khachHang.MaKH = reader["MaKH"].ToString();
                        khachHang.TenKH = reader["TenKH"].ToString();
                        khachHang.SDT = reader["SDT"].ToString();
                    }
                }

            }
            return khachHang;
        }
    }
}
