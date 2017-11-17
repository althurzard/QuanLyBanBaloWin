using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsChiTietPhieuNhapKho_DTO
    {
        string _MaChiTiet;
        string _MaSanPham;
        int _SoLuong;
        string _MaPhieuNhapKho;

        public clsChiTietPhieuNhapKho_DTO()
        {

        }

        public clsChiTietPhieuNhapKho_DTO(string MaChiTiet, string MaSanPham, int SoLuong, string MaPhieuNhapKho)
        {
             _MaChiTiet = MaChiTiet;
             _MaSanPham = MaSanPham;
             _SoLuong = SoLuong;
             _MaPhieuNhapKho = MaPhieuNhapKho;
        }

        public string MaChiTiet { get => _MaChiTiet; set => _MaChiTiet = value; }
        public string MaSanPham { get => _MaSanPham; set => _MaSanPham = value; }
        public int SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public string MaPhieuNhapKho { get => _MaPhieuNhapKho; set => _MaPhieuNhapKho = value; }
    }
}
