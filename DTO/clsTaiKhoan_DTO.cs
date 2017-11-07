using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsTaiKhoan_DTO
    {
        private string _tenTaiKhoan;
        private string _matKhau;
        private clsNhanVien_DTO _nhanVien;
        private clsPhanLoaiTK _loaiTK;

        public clsTaiKhoan_DTO()
        {

        }

        public clsTaiKhoan_DTO(string tenTaiKhoan, string matKhau, clsNhanVien_DTO nhanVien, clsPhanLoaiTK loaiTK)
        {
            _tenTaiKhoan = tenTaiKhoan;
            _matKhau = matKhau;
            _nhanVien = nhanVien;
            _loaiTK = loaiTK;
        }

        public string TenTaiKhoan { get => _tenTaiKhoan; set => _tenTaiKhoan = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public clsNhanVien_DTO NhanVien { get => _nhanVien; set => _nhanVien = value; }
        public clsPhanLoaiTK LoaiTK { get => _loaiTK; set => _loaiTK = value; }
    }
}
