using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class clsKhachHang_BUS
    {
        public static bool Them(clsKhachHang_DTO kh)
        {
            return clsKhachHang_DAO.Them(kh);
        }

        public static clsKhachHang_DTO LayThongTin(string sdt)
        {
            return clsKhachHang_DAO.LayThongTin(sdt);
        }
    }
}
