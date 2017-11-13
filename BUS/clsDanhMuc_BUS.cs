using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using DTO;
namespace BUS
{
    public class clsDanhMuc_BUS
    {
        public static DataTable LayTatCaDanhMuc()
        {
            return clsDanhMuc_DAO.LayBangDanhMuc();
        }
        
        public static bool KiemTraTonTaiTenDanhMuc(string TenDanhMuc)
        {
            return clsDanhMuc_DAO.KiemTraTonTaiTenDanhMuc(TenDanhMuc);
        }

        public static object ThemDanhMuc(clsDanhMuc_DTO danhmuc)
        {
            return clsDanhMuc_DAO.ThemDanhMuc(danhmuc);
        }
        public static object SuaDanhMuc(clsDanhMuc_DTO danhmuc)
        {
            return clsDanhMuc_DAO.SuaDanhMuc(danhmuc);
        }
        public static object XoaDanhMuc(clsDanhMuc_DTO danhmuc)
        {
            return clsDanhMuc_DAO.XoaDanhMuc(danhmuc);
        }
    }
}
