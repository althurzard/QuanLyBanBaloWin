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
    public class clsNhanVien_BUS
    {

        public static object ThemNhanVien(clsNhanVien_DTO nhanVien)
        {
            return clsNhanVien_DAO.ThemNhanVien(nhanVien);
        }

        public static DataTable LayBangNhanVien()
        {
            return clsNhanVien_DAO.LayBangNhanVien();
        }

        public static clsNhanVien_DTO LayNhanVien(string MaNV)
        {
            return clsNhanVien_DAO.LayNhanVien(MaNV);
        }

        public static object SuaNhanVien(clsNhanVien_DTO nhanVien)
        {
            return clsNhanVien_DAO.SuaNhanVien(nhanVien);
        }
    }
}
