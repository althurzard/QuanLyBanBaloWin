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
    public class clsHoaDon_BUS
    {
        public static bool Them(clsHoaDon_DTO hoaDon)
        {
            return clsHoaDon_DAO.Them(hoaDon);
        }

        public static DataTable LayHoaDonTheoMaKH(string maKH)
        {
            return clsHoaDon_DAO.LayHoaDonTheoMaKH(maKH);
        }

        public static DataTable LayHoaDonTheoMaHD(string maHD)
        {
            return clsHoaDon_DAO.LayHoaDonTheoMaHD(maHD);
        }

        public static DataTable LayBangSanPhamTuHDBan(string tuNgay, string denNgay)
        {
            return clsHoaDon_DAO.LayBangSanPhamTuHDBan(tuNgay, denNgay);
        }

    }
}
