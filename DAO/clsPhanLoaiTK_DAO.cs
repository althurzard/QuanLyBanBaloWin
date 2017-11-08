using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DAO
{
    public class clsPhanLoaiTK_DAO
    {
        public static DataTable LayBang()
        {
            string query = "Select * from PhanLoaiTaiKhoan";
            return XuLyDuLieu.LayBang(query);
        }
    }
}
