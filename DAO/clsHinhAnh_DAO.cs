using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class clsHinhAnh_DAO
    {
        /*
         Hàm thêm hình ảnh Trả về 2 kết quả
         - Nếu thành công sẽ trả về ID của hình ảnh (MaHinhAnh)
         - Thất bại sẽ trả về exception(string)
             */
        public static object ThemHinhAnh(clsHinhAnh_DTO hinhAnh)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format(
                "Insert into HinhAnh (TenHinhAnh,Url,TrangThai) " +
                "values (@TenHinhAnh,@Url,@TrangThai) SELECT CAST(scope_identity() AS int)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@TenHinhAnh", SqlDbType.NChar).Value = hinhAnh.TenHinhAnh;
                cmd.Parameters.Add("@Url", SqlDbType.NVarChar).Value = hinhAnh.Url;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = 1;
                cmd.CommandType = CommandType.Text;
                try
                {
                    return (int)cmd.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    return e.Message.ToString();
                }

            }
        }
    }
}
