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
    public class clsPhanLoaiTK_DAO
    {
        public static DataTable LayBang()
        {
            string query = "Select * from PhanLoaiTaiKhoan";
            return XuLyDuLieu.LayBang(query);
        }

        public static clsPhanLoaiTK_DTO LayLoaiTK(int MaPLTK)
        {
            clsPhanLoaiTK_DTO pltk = new clsPhanLoaiTK_DTO();
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from PhanLoaiTaiKhoan where MaPhanLoaiTK = {0}",MaPLTK);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pltk.MaPhanLoaiTK = (int)reader["MaPhanLoaiTK"];
                        pltk.MoTa = reader["MoTa"].ToString();
                       
                    }
                }

            }
            return pltk;
        }
    }
}
