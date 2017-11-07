using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class clsTaiKhoan_BUS
    {
        public static object ThemTaiKhoan(clsTaiKhoan_DTO taiKhoan)
        {
            return clsTaiKhoan_DAO.ThemTaiKhoan(taiKhoan);
        }
    }
}
