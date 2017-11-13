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
    public class clsTaiKhoan_BUS
    {
        public static object ThemTaiKhoan(clsTaiKhoan_DTO taiKhoan)
        {
            return clsTaiKhoan_DAO.ThemTaiKhoan(taiKhoan);
        }


        public static bool KiemTraTaiKhoanDaTonTai(string tenTaiKhoan)
        {
            return clsTaiKhoan_DAO.KiemTraTaiKhoanDaTonTai(tenTaiKhoan);
        }

        public static DataTable LayBang()
        {
            return clsTaiKhoan_DAO.LayBang();
        }

        public static clsTaiKhoan_DTO LayTaiKhoan(string MaNV)
        {
            return clsTaiKhoan_DAO.LayTaiKhoan(MaNV);
        }

        public static object SuaTaiKhoan(clsTaiKhoan_DTO taiKhoan)
        {
            return clsTaiKhoan_DAO.SuaTaiKhoan(taiKhoan);
        }

        public static bool XoaTaiKhoan(string tenTaiKhoan)
        {
            return clsTaiKhoan_DAO.XoaTaiKhoan(tenTaiKhoan);
        }
        
    }
}
