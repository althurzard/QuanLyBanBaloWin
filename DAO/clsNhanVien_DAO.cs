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
                "Insert into NhanVien (MaNV,HoTen,NgaySinh,QueQuan,DiaChi,SoDienThoai,TrangThai,NgayKhoiTao,MaHinhAnh) " +
                "values (@MaNV,@HoTen,@NgaySinh,@QueQuan,@DiaChi,@SoDienThoai,@TrangThai,@NgayKhoiTao,@MaHinhAnh)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nhanVien.MaNV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nhanVien.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = nhanVien.NgaySinh.Date;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = nhanVien.QueQuan;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.DiaChi;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.Char).Value = nhanVien.SoDienThoai;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@NgayKhoiTao", SqlDbType.Date).Value = nhanVien.NgayKhoiTao.Date;
                cmd.Parameters.Add("@MaHinhAnh", SqlDbType.Int).Value = nhanVien.HinhAnh.MaHinhAnh;
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

        public static clsNhanVien_DTO LayNhanVien(string MaNV)
        {
            clsNhanVien_DTO nv = new clsNhanVien_DTO();
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from NhanVien,HinhAnh where MaNV = '{0}' AND NhanVien.MaHinhAnh = HinhAnh.MaHinhAnh", MaNV);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nv.MaNV = reader["MaNV"].ToString();
                        nv.HoTen = reader["HoTen"].ToString();
                        nv.QueQuan = reader["QueQuan"].ToString();
                        nv.SoDienThoai = reader["SoDienThoai"].ToString();
                        nv.DiaChi = reader["DiaChi"].ToString();
                        nv.NgaySinh = (DateTime)reader["NgaySinh"];
                        nv.NgayKhoiTao = (DateTime)reader["NgayKhoiTao"];
                        nv.HinhAnh = clsHinhAnh_DAO.LayHinhAnh((int)reader["MaHinhAnh"]);
                    }
                }
            }

            return nv;
        }

        public static object SuaNhanVien(clsNhanVien_DTO nhanVien)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                //cập nhật vào bảng sản phẩm
                string query = string.Format("UPDATE NhanVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, QueQuan = @QueQuan, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, MaHinhAnh = @MaHinhAnh where MaNV = @MaNV");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nhanVien.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = nhanVien.NgaySinh.Date;
                cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = nhanVien.QueQuan;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.DiaChi;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.Char).Value = nhanVien.SoDienThoai;
                cmd.Parameters.Add("@MaHinhAnh", SqlDbType.Int).Value = nhanVien.HinhAnh.MaHinhAnh;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = nhanVien.MaNV;
                cmd.CommandType = CommandType.Text;
                try
                {
                    return cmd.ExecuteNonQuery() >= 1;

                }
                catch (SqlException e)
                {
                    return e.Message.ToString();
                }
            }
        }


    }
}
