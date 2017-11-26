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
        string _MaCTSanPham;
        int _SoLuong;
        string _MaPhieuNhapKho;

        public clsChiTietPhieuNhapKho_DTO()
        {

        }

        public clsChiTietPhieuNhapKho_DTO(string MaChiTiet)
        {
            _MaChiTiet = MaChiTiet;
        }
        public clsChiTietPhieuNhapKho_DTO(string MaChiTiet, string MaCTSanPham, int SoLuong, string MaPhieuNhapKho)
        {
             _MaChiTiet = MaChiTiet;
             _MaCTSanPham = MaCTSanPham;
             _SoLuong = SoLuong;
             _MaPhieuNhapKho = MaPhieuNhapKho;
        }

        public string MaChiTiet { get => _MaChiTiet; set => _MaChiTiet = value; }
        public string MaCTSanPham { get => _MaCTSanPham; set => _MaCTSanPham = value; }
        public int SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public string MaPhieuNhapKho { get => _MaPhieuNhapKho; set => _MaPhieuNhapKho = value; }
    }
}
