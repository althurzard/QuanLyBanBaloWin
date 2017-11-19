using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data.SqlClient;

namespace BUS
{
    public class clsChiTietSanPham_BUS
    {
        public static object ThemChiTietSanPham(clsChiTietSP_DTO chiTietSanPham)
        {
            return clsChiTietSanPham_DAO.ThemChiTietSanPham(chiTietSanPham);
        }
        public static bool KiemTraTonTaiMau(string maChiTiet, string mauSac)
        {
            return clsChiTietSanPham_DAO.KiemTraTonTaiMau(maChiTiet, mauSac);
        }
        public static object CapNhatSoLuong(clsChiTietSP_DTO chiTietSanPham)
        {
            return clsChiTietSanPham_DAO.CapNhatSoLuong(chiTietSanPham);
        }
        public static SqlDataReader LayChiTiet(string maSp, string mauSac)
        {
            return clsChiTietSanPham_DAO.LayChiTiet(maSp, mauSac);
        }

        public static List<string> LayMauSac()
        {
            return clsChiTietSanPham_DAO.LayMauSac();
        }

    }
}
