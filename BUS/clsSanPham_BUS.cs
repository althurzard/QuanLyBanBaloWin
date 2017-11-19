using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data.SqlClient;

namespace BUS
{
    public class clsSanPham_BUS
    {
       
        public static  DataTable LayTatCaSanPham()
        {
            return clsSanPham_DAO.LayTatCaSanPham();
        }
        public static DataTable LayTatCaMauMa()
        {
            return clsSanPham_DAO.LayTatCaMauMa();
        }
        public static int XoaSanPham(string idSanPham)
        {
            return clsSanPham_DAO.XoaSanPham(idSanPham);
        }
        public static SqlDataReader LayThongTinMotSanPham(string idSanPham,string idChiTiet)
        {
            return clsSanPham_DAO.LayThongTinMotSanPham(idSanPham,idChiTiet);
        }
        
        public static object SuaSanPham(clsSanPham_DTO sanPham, clsChiTietSP_DTO chiTietSP)
        {
            return clsSanPham_DAO.SuaSanPham(sanPham,chiTietSP);
        }

        public static object ThemSanPham(clsSanPham_DTO sanPham)
        {
            return clsSanPham_DAO.ThemSanPham(sanPham);
        }

        public static bool KiemTraTrungSanPham(string tenSanPham)
        {
            return clsSanPham_DAO.KiemTraTrungSanPham(tenSanPham);
        }

        public static DataTable LayBangSanPham()
        {
            return clsSanPham_DAO.LayBangSanPham();
        }

        public static List<string> LayThuongHieu()
        {
            return clsSanPham_DAO.LayThuongHieu();
        }

        public static List<string> LayChatLieu()
        {
            return clsSanPham_DAO.LayChatLieu();
        }

        public static List<string> LayTenSP()
        {
            return clsSanPham_DAO.LayTenSP();
        }
    }
}
