using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class clsHoaDon_BUS
    {
        public static bool Them(clsHoaDon_DTO hoaDon)
        {
            return clsHoaDon_DAO.Them(hoaDon);
        }
    }
}
