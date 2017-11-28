using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class clsChiTietHD_BUS
    {
        public static bool Them(clsChiTietHD_DTO CTHD)
        {
            return clsChiTietHD_DAO.Them(CTHD);
        }

        public static DataTable LayChiTiet(string MaHD)
        {
            return clsChiTietHD_DAO.LayChiTiet(MaHD);
        }
    }
}
