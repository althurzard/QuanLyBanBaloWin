using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class clsChiTietSanPham_BUS
    {
        public static object ThemChiTietSanPham(clsChiTietSP_DTO chiTietSanPham)
        {
            return clsChiTietSanPham_DAO.ThemChiTietSanPham(chiTietSanPham);
        }
    }
}
