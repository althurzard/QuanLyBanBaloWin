﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
    public class clsKhuyenMai_BUS
    {
        public static DataTable LayBangKhuyenMai(bool apDungHD = true)
        {
            return clsKhuyenMai_DAO.LayBangKhuyenMai(apDungHD);
        }

        public static clsKhuyenMai_DTO LayKhuyenMai(int maKM)
        {
            return clsKhuyenMai_DAO.LayKhuyenMai(maKM);
        }

        public static bool Them(clsKhuyenMai_DTO khuyenMai)
        {
            int result = clsKhuyenMai_DAO.Them(khuyenMai);
            if (result >= 1)
            {
                khuyenMai.MaKhuyenMai = result;
            }
            return result >= 1;
        }

        public static bool Sua(clsKhuyenMai_DTO khuyenMai)
        {
            return clsKhuyenMai_DAO.Sua(khuyenMai);
        }

        public static bool Xoa(int maKM)
        {
            return clsKhuyenMai_DAO.Xoa(maKM);
        }

        public static List<clsKhuyenMai_DTO> LayKhuyenMaiTheoHD()
        {
            return clsKhuyenMai_DAO.LayKhuyenMaiTheoHD();
        }

        
    }
}
