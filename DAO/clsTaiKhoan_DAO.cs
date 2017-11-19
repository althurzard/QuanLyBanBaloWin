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
    public class clsTaiKhoan_DAO
    {

        /*
         Hàm thêm tài khoản Trả về 2 kết quả:
         - Nếu thêm thành công sẽ trả về true
         - Thất bại sẽ trả về exception(string)
             */
        public static object ThemTaiKhoan(clsTaiKhoan_DTO taiKhoan)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format(
                "Insert into TaiKhoan (TenTaiKhoan,MatKhau,TrangThai,MaPhanLoaiTK,MaNV) " +
                "values (@TenTaiKhoan,@MatKhau,@TrangThai,@MaPhanLoaiTK,@MaNV)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@TenTaiKhoan", SqlDbType.NVarChar).Value = taiKhoan.TenTaiKhoan;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = taiKhoan.MatKhau;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@MaPhanLoaiTK", SqlDbType.Int).Value = taiKhoan.LoaiTK.MaPhanLoaiTK;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = taiKhoan.NhanVien.MaNV;
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

        public static clsTaiKhoan_DTO LayTaiKhoan(string MaNV)
        {
            clsTaiKhoan_DTO tk = null;
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from TaiKhoan where MaNV = '{0}' AND TrangThai=1 ",MaNV);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        tk = new clsTaiKhoan_DTO();
                        tk.TenTaiKhoan = reader["TenTaiKhoan"].ToString();
                        tk.MatKhau = reader["MatKhau"].ToString();
                        tk.TrangThai = (int)reader["TrangThai"];
                        if (reader["LastLogon"] is DateTime)
                        {
                            tk.LastLogon = (DateTime)reader["LastLogon"];
                        }

                        tk.NhanVien = clsNhanVien_DAO.LayNhanVien(MaNV);
                        tk.LoaiTK = clsPhanLoaiTK_DAO.LayLoaiTK((int)reader["MaPhanLoaiTK"]);
                    }
                }
             
            }

            return tk;
        }

        public static clsTaiKhoan_DTO LayTaiKhoan(clsTaiKhoan_DTO taiKhoan)
        {
            clsTaiKhoan_DTO tk = null;
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from TaiKhoan where  TenTaiKhoan = '{0}' AND MatKhau = '{1}' ", taiKhoan.TenTaiKhoan,taiKhoan.MatKhau);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tk = new clsTaiKhoan_DTO();
                        tk.TenTaiKhoan = reader["TenTaiKhoan"].ToString();
                        tk.MatKhau = reader["MatKhau"].ToString();
                        tk.TrangThai = (int)reader["TrangThai"];
                        if (reader["LastLogon"] is DateTime)
                        {
                            tk.LastLogon = (DateTime)reader["LastLogon"];
                        }

                        tk.NhanVien = clsNhanVien_DAO.LayNhanVien(reader["MaNV"].ToString());
                        tk.LoaiTK = clsPhanLoaiTK_DAO.LayLoaiTK((int)reader["MaPhanLoaiTK"]);
                    }
                }

            }

            return tk;
        }

        public static bool KiemTraTaiKhoanDaTonTai(string tenTaiKhoan)
        {
            string query = string.Format("select count(*) from TaiKhoan where TenTaiKhoan = '{0}'", tenTaiKhoan);
            return XuLyDuLieu.ThucThiCauLenhWithScalar(query) >= 1;
        }

        public static bool CapNhatDangNhap(string maNV)
        {
            string query = string.Format("Update TaiKhoan Set LastLogon = '{0}' where MaNV = '{1}'", DateTime.Now, maNV);
            return XuLyDuLieu.ThucThiCauLenh(query) >= 1;
        }

        public static DataTable LayBang()
        {
            string query = "Select Url,NhanVien.MaNV as MaNV,HoTen,NgaySinh,QueQuan,DiaChi,NgayKhoiTao,LastLogon,TenTaiKhoan,MatKhau,PhanLoaiTaiKhoan.MoTa as MoTa,TaiKhoan.TrangThai as TrangThai from TaiKhoan, NhanVien, HinhAnh, PhanLoaiTaiKhoan where TaiKhoan.MaNV = NhanVien.MaNV AND NhanVien.MaHinhAnh = HinhAnh.MaHinhAnh AND TaiKhoan.MaPhanLoaiTK = PhanLoaiTaiKhoan.MaPhanLoaiTK AND TaiKhoan.TrangThai = 1";
            return XuLyDuLieu.LayBang(query);
        }

        public static bool XoaTaiKhoan(string tenTaiKhoan)
        {
            string query = string.Format("UPDATE TaiKhoan SET TrangThai = 0 WHERE TenTaiKhoan ='{0}'", tenTaiKhoan);
            return XuLyDuLieu.ThucThiCauLenh(query) >= 1;
        }

        public static object SuaTaiKhoan(clsTaiKhoan_DTO taiKhoan)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                //cập nhật vào bảng sản phẩm
                string query = string.Format("UPDATE TaiKhoan SET MatKhau = @MatKhau where TenTaiKhoan = @TenTaiKhoan");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = taiKhoan.MatKhau;
                cmd.Parameters.Add("@TenTaiKhoan", SqlDbType.NVarChar).Value = taiKhoan.TenTaiKhoan;
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
