using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsChiTietSP_DTO
    {
        string _MaSP;
        string _MaCTSP;
        string _MauSac;
        int _SoLuong;
        int _MaHinhAnh;
        int _TrangThai;

        public string MaSP { get => _MaSP; set => _MaSP = value; }
        public string MaCTSP { get => _MaCTSP; set => _MaCTSP = value; }
        public string MauSac { get => _MauSac; set => _MauSac = value; }
        public int SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public int MaHinhAnh { get => _MaHinhAnh; set => _MaHinhAnh = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
    }
}
