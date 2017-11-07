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
                "Insert into TaiKhoan (TenTaiKhoan,MatKhau,TrangThai,MaPhanLoaiTK,MaNV,LastLogin) " +
                "values (@TenTaiKhoan,@MatKhau,@TrangThai,@MaPhanLoaiTK,@MaNV,@LastLogin)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@TenTaiKhoan", SqlDbType.NVarChar).Value = taiKhoan.TenTaiKhoan;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = taiKhoan.MatKhau;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@MaPhanLoaiTK", SqlDbType.Int).Value = taiKhoan.LoaiTK.MaPhanLoaiTK;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = taiKhoan.NhanVien.MaNV;
                cmd.Parameters.Add("@LastLogin", SqlDbType.DateTime).Value = DateTime.Now;
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
