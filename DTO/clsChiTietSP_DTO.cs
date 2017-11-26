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

        public clsChiTietSP_DTO()
        {

        }
        public clsChiTietSP_DTO(string maCTSP)
        {
            _MaCTSP = maCTSP;
        }
       
        public clsChiTietSP_DTO(string maSP,string maCTSP, string mauSac, int soLuong, int maHinhAnh, int trangThai)
        {
             _MaSP = maSP;
             _MaCTSP = maCTSP;
             _MauSac = mauSac;
             _SoLuong = soLuong;
             _MaHinhAnh = maHinhAnh;
             _TrangThai= trangThai;
        }
        public clsChiTietSP_DTO(string maCTSP,string mauSac, int soLuong)
        {
            _MaCTSP = maCTSP;
            _MauSac = mauSac;
            _SoLuong = soLuong;
        }

        public string MaSP { get => _MaSP; set => _MaSP = value; }
        public string MaCTSP { get => _MaCTSP; set => _MaCTSP = value; }
        public string MauSac { get => _MauSac; set => _MauSac = value; }
        public int SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public int MaHinhAnh { get => _MaHinhAnh; set => _MaHinhAnh = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
    }
}
