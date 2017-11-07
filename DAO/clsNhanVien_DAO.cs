using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Data.SqlClient;
namespace DAO
{
    public class clsNhanVien_DAO
    {

        public static DataTable LayBangNhanVien()
        {
            string query = "SELECT HoTen,NgaySinh,DiaChi,QueQuan,SoDienThoai,NgayKhoiTao,Url,MoTa " +
                "from NhanVien,HinhAnh,TaiKhoan,PhanLoaiTaiKhoan where " +
                "NhanVien.MaHinhAnh = HinhAnh.MaHinhAnh AND NhanVien.MaNV = TaiKhoan.MaNV and TaiKhoan.MaPhanLoaiTK = PhanLoaiTaiKhoan.MaPhanLoaiTK ";
            return XuLyDuLieu.LayBang(query);
        }

        /*
         Hàm thêm Nhân viên Trả về 2 kết quả
         - Nếu thêm thành công sẽ trả về true
         - Thất bại sẽ trả về exception(string)
             */
        public static object ThemNhanVien(clsNhanVien_DTO nhanVien)
        {
            
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format(
                "Insert into NhanVien (MaNV,HoTen,NgaySinh,QueQuan,DiaChi,SoDienThoai,TrangThai,NgayKhoiTao,MaHinhAnh,LastUpdated) " +
                "values (@MaNV,@HoTen,@NgaySinh,@QueQuan,@DiaChi,@SoDienThoai,@TrangThai,@NgayKhoiTao,@MaHinhAnh,@LastUpdated)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nhanVien.MaNV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nhanVien.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = nhanVien.NgaySinh;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = nhanVien.QueQuan;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.DiaChi;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.Char).Value = nhanVien.SoDienThoai;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NgayKhoiTao", SqlDbType.Date).Value = nhanVien.NgayKhoiTao;
                cmd.Parameters.Add("@MaHinhAnh", SqlDbType.Int).Value = nhanVien.HinhAnh.MaHinhAnh;
                cmd.Parameters.Add("@LastUpdated", SqlDbType.DateTime).Value = DateTime.Now;
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
