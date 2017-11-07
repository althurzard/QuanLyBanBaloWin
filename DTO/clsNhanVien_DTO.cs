using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsNhanVien_DTO
    {
        private string _maNV;
        private string _hoTen;
        private DateTime _ngaySinh;
        private string _queQuan;
        private string _diaChi;
        private string _soDienThoai;
        private DateTime _ngayKhoiTao;
        private clsHinhAnh_DTO _hinhAnh;

        public clsNhanVien_DTO()
        {

        }


        public clsNhanVien_DTO(
            string maNV,
            string hoTen, 
            DateTime ngaySinh,
            string queQuan,
            string diaChi,
            string soDienThoai,
            clsHinhAnh_DTO hinhAnh,
            DateTime ngayKhoiTao)
        {
            _maNV = maNV;
            _hoTen = hoTen;
            _ngaySinh = ngaySinh;
            _queQuan = queQuan;
            _diaChi = diaChi;
            _soDienThoai = soDienThoai;
            _hinhAnh = hinhAnh;
            _ngayKhoiTao = ngayKhoiTao;
        }
        


        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string QueQuan { get => _queQuan; set => _queQuan = value; }
        public DateTime NgayKhoiTao { get => _ngayKhoiTao; set => _ngayKhoiTao = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }
        public clsHinhAnh_DTO HinhAnh { get => _hinhAnh; set => _hinhAnh = value; }
    }
}
