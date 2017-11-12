using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;
namespace DAO
{
    public class clsDanhMuc_DAO
    {
        public static DataTable LayBangDanhMuc()
        {
            string query = "SELECT DanhMuc.MaDanhMuc,TenDanhMuc,count(TenSP) as TongSP from DanhMuc LEFT JOIN SanPham ON DanhMuc.MaDanhMuc = SanPham.MaDanhMuc WHERE TrangThai = 1 GROUP BY TenDanhMuc,DanhMuc.MaDanhMuc";
            return XuLyDuLieu.LayBang(query);
        }

        public static bool KiemTraTonTaiTenDanhMuc(string TenDanhMuc)
        {
            string query =string.Format("SELECT count(TenDanhMuc) FROM DanhMuc WHERE TenDanhMuc = N'{0}'",TenDanhMuc);
            return XuLyDuLieu.ThucThiCauLenhWithScalar(query) >= 1;
        }

        public static object ThemDanhMuc(clsDanhMuc_DTO danhmuc)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = "INSERT INTO DanhMuc(TenDanhMuc,TrangThai) VALUES(@TenDanhMuc,@TrangThai)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@TenDanhMuc", SqlDbType.NVarChar).Value = danhmuc.TenDanhMuc;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = danhmuc.TrangThai;
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

        
        public static object SuaDanhMuc(clsDanhMuc_DTO danhmuc)
        {

            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = "UPDATE DanhMuc SET TenDanhMuc =@TenDanhMuc WHERE MaDanhMuc = @MaDanhMuc";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@TenDanhMuc", SqlDbType.NVarChar).Value = danhmuc.TenDanhMuc;
                cmd.Parameters.Add("@MaDanhMuc", SqlDbType.Int).Value = danhmuc.MaDanhMuc;
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

        public static object XoaDanhMuc(clsDanhMuc_DTO danhmuc)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = "UPDATE DanhMuc SET TrangThai = 0 WHERE MaDanhMuc = @MaDanhMuc";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaDanhMuc", SqlDbType.Int).Value = danhmuc.MaDanhMuc;
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
