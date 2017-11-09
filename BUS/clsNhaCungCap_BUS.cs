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
    public class clsNhaCungCap_BUS
    {
        public static DataTable LayNCC(){
            return clsNhaCungCap_DAO.LayNhaCC();
        }

        public static object ThemNhaCungCap(clsNhaCungCap_DTO nhaCC)
        {
            return clsNhaCungCap_DAO.ThemNhaCungCap(nhaCC);
        }
        public static bool KiemTraTonTaiTenNCC(string tenNhaCungCap)
        {
            return clsNhaCungCap_DAO.KiemTraTonTaiTenNCC(tenNhaCungCap);
        }
    }
}
