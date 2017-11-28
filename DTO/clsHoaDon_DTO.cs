using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsHoaDon_DTO
    {
        private string _maHD;
        private string _maNV;
        private clsKhuyenMai_DTO _khuyenMai;
        private clsKhachHang_DTO _khachHang;
        private double _giamTru;
        private string _ghiChu = "Không";
        private double _thanhTien;
        private DateTime _ngayKhoiTao;

        public clsHoaDon_DTO()
        {

        }

        public clsHoaDon_DTO(
            string maHD,
            string maNV,
            string ghiChu,
            double giamTru,
            double thanhTien,
           clsKhachHang_DTO khachHang = null,
           clsKhuyenMai_DTO khuyenMai = null
            )
        {
            _maHD = maHD;
            _maNV = maNV;
            _ghiChu = ghiChu;
            _giamTru = giamTru;
            _thanhTien = thanhTien;
            _khuyenMai = khuyenMai;
            _khachHang = khachHang;
            _ngayKhoiTao = DateTime.Now;
        }

        public string MaHD { get => _maHD; set => _maHD = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }
        public clsKhuyenMai_DTO KhuyenMai { get => _khuyenMai; set => _khuyenMai = value; }
        public double GiamTru { get => _giamTru; set => _giamTru = value; }
        public string GhiChu { get => _ghiChu; set => _ghiChu = value; }
        public double ThanhTien { get => _thanhTien; set => _thanhTien = value; }
        public DateTime NgayKhoiTao { get => _ngayKhoiTao; set => _ngayKhoiTao = value; }
        public clsKhachHang_DTO KhachHang { get => _khachHang; set => _khachHang = value; }
    }
}
