using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
namespace BUS
{
    public class clsSanPham_BUS
    {
        public DataTable LayTatCaSanPham()
        {
            clsSanPham_DAO dao = new clsSanPham_DAO();
            DataTable dt = new DataTable();
            dt = dao.LayTatCaSanPham();
            return dt;
        }
        public DataTable LayTatCaDanhMuc()
        {
            clsSanPham_DAO dao = new clsSanPham_DAO();
            DataTable dt = new DataTable();
            dt = dao.LayTatCaMauMa();
            return dt;
        }
    }
}
