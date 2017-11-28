using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class clsChiTietPhieuNhapKho_BUS
    {
        public static object ThemChiTietPhieuNhapKho(clsChiTietPhieuNhapKho_DTO chiTiet)
        {
            return clsChiTietPhieuNhapKho_DAO.ThemChiTietPhieuNhapKho(chiTiet);
        }

        public static clsChiTietPhieuNhapKho_DTO LayChiTiet(string maPhieuNK)
        {
            return clsChiTietPhieuNhapKho_DAO.LayChiTiet(maPhieuNK);
        }
    }
}
