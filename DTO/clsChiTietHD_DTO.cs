using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsChiTietHD_DTO
    {
        private string _maCTHD;
        private clsHoaDon_DTO _hoaDon;
        private string _maCTSP;
        private double _giamTru;
        private int _soLuong;
        private clsKhuyenMai_DTO _khuyenMai;
        private double _tongTien;

        public clsChiTietHD_DTO()
        {

        }

        public clsChiTietHD_DTO(
            string maCTHD,
            string maCTSP,
            double giamTru,
            double tongTien,
            int soLuong,
            clsKhuyenMai_DTO khuyenMai = null,
            clsHoaDon_DTO hoaDon = null
            )
        {
            _maCTHD = maCTHD;
            _maCTSP = maCTSP;
            _giamTru = giamTru;
            _soLuong = soLuong;
            _tongTien = tongTien;
            _khuyenMai = khuyenMai;
            _hoaDon = hoaDon;
        }

        public string MaCTHD { get => _maCTHD; set => _maCTHD = value; }
        public clsHoaDon_DTO HoaDon { get => _hoaDon; set => _hoaDon = value; }
        public string MaCTSP { get => _maCTSP; set => _maCTSP = value; }
        public double GiamTru { get => _giamTru; set => _giamTru = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public clsKhuyenMai_DTO KhuyenMai { get => _khuyenMai; set => _khuyenMai = value; }
        public double TongTien { get => _tongTien; set => _tongTien = value; }
    }
}
