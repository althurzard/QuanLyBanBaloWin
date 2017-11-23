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

        public static bool CapNhatSoLuong(string maCTSP, int soLuong)
        {
            return clsChiTietSanPham_DAO.CapNhatSoLuong(maCTSP, soLuong);
        }

        public static SqlDataReader LayChiTiet(string maSp, string mauSac)
        {
            return clsChiTietSanPham_DAO.LayChiTiet(maSp, mauSac);
        }

        public static clsChiTietSP_DTO LayChiTiet(string maCTSP)
        {
            return clsChiTietSanPham_DAO.LayChiTiet(maCTSP);
        }

        public static List<string> LayMauSac()
        {
            return clsChiTietSanPham_DAO.LayMauSac();
        }

        public static List<string> LayMaCTSP()
        {
            return clsChiTietSanPham_DAO.LayMaCTSP();
        }

    }
}
