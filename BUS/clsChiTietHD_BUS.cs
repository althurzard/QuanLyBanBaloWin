using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class clsChiTietHD_BUS
    {
        public static bool Them(clsChiTietHD_DTO CTHD)
        {
            return clsChiTietHD_DAO.Them(CTHD);
        }
    }
}
