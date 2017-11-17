using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class clsPhieuNhapKho_BUS
    {
        public static object ThemPhieuNhapKho(clsPhieuNhapKho_DTO phieuNhapKho)
        {
            return clsPhieuNhapKho_DAO.ThemPhieuNhapKho(phieuNhapKho);
        }
    }
}
