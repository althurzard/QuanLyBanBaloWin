using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
namespace BUS
{
    public class clsPhanLoaiTK_BUS
    {
        public static DataTable LayBang()
        {
            return clsPhanLoaiTK_DAO.LayBang();
        }
    }
}
