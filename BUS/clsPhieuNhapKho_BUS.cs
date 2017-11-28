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
    public class clsPhieuNhapKho_BUS
    {
        public static object ThemPhieuNhapKho(clsPhieuNhapKho_DTO phieuNhapKho)
        {
            return clsPhieuNhapKho_DAO.ThemPhieuNhapKho(phieuNhapKho);
        }

        public static DataTable LayBang(string tuNgay, string denNgay)
        {
            return clsPhieuNhapKho_DAO.LayBang(tuNgay, denNgay);
        }

    }
}
