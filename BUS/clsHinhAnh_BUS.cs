using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class clsHinhAnh_BUS
    {
        public static object ThemHinhAnh(clsHinhAnh_DTO hinhAnh)
        {
            object result = clsHinhAnh_DAO.ThemHinhAnh(hinhAnh);
            if (result is int)
            {
                hinhAnh.MaHinhAnh = (int)result;
                return result;
            }
            return true;
            
        }
    }
}
