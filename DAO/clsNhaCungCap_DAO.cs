using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class clsNhaCungCap_DAO
    {
        public static DataTable LayNhaCC()
        {
            string query = "SELECT NhaCungCap.*,HinhAnh.Url FROM NhaCungCap,HinhAnh WHERE NhaCungCap.TrangThai = 1 AND NhaCungCap.MaHinhAnh = HinhAnh.MaHinhAnh ";
            return XuLyDuLieu.LayBang(query);
        }
        public static bool KiemTraTonTaiTenNCC(string tenNhaCungCap)
        {
            string query = string.Format("select count(TenNhaCungCap) from NhaCungCap where TenNhaCungCap = '{0}'", tenNhaCungCap);
            return XuLyDuLieu.ThucThiCauLenhWithScalar(query) >= 1;
        }

        public static object ThemNhaCungCap(clsNhaCungCap_DTO nhaCC)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("INSERT INTO NhaCungCap(MaNhaCungCap,TenNhaCungCap,MaHinhAnh,SoDienThoai,DiaChi,TrangThai) VALUES (@MaNhaCungCap, @TenNhaCungCap, @MaHinhAnh, @SoDienThoai, @DiaChi, @TrangThai)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaNhaCungCap", SqlDbType.Char).Value = nhaCC.MaNhaCungCap;
                cmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar).Value = nhaCC.TenNhaCungCap;
                cmd.Parameters.Add("@MaHinhAnh", SqlDbType.Int).Value = nhaCC.MaHinhAnh;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.Int).Value = nhaCC.SoDienThoai;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhaCC.DiaChi;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = nhaCC.TrangThai;
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
        public static object SuaNhaCungCap(clsNhaCungCap_DTO nhaCC)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("UPDATE NhaCungCap SET TenNhaCungCap = @TenNhaCungCap, MaHinhAnh = @MaHinhAnh, SoDienThoai = @SoDienThoai, DiaChi = @DiaChi WHERE MaNhaCungCap = @MaNhaCungCap");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaNhaCungCap", SqlDbType.Char).Value = nhaCC.MaNhaCungCap;
                cmd.Parameters.Add("@TenNhaCungCap", SqlDbType.NVarChar).Value = nhaCC.TenNhaCungCap;
                cmd.Parameters.Add("@MaHinhAnh", SqlDbType.Int).Value = nhaCC.MaHinhAnh;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.Int).Value = nhaCC.SoDienThoai;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhaCC.DiaChi;
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
        public static int XoaNhaCungCap(string MaNhaCungCap)
        {
            string query =string.Format("UPDATE NhaCungCap Set TrangThai = 0 WHERE MaNhaCungCap = '{0}'",MaNhaCungCap);
            return XuLyDuLieu.ThucThiCauLenh(query);
        }
    }
}
