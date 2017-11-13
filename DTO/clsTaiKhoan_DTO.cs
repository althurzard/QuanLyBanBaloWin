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
        private int _trangThai;
        private clsNhanVien_DTO _nhanVien;
        private clsPhanLoaiTK_DTO _loaiTK;
        private DateTime _lastLogon;

        public clsTaiKhoan_DTO()
        {

        }

        public clsTaiKhoan_DTO(string tenTaiKhoan, string matKhau, clsNhanVien_DTO nhanVien, clsPhanLoaiTK_DTO loaiTK, int trangThai = 1)
        {
            _tenTaiKhoan = tenTaiKhoan;
            _matKhau = matKhau;
            _nhanVien = nhanVien;
            _loaiTK = loaiTK;
            _trangThai = trangThai;
        }

        public string TenTaiKhoan { get => _tenTaiKhoan; set => _tenTaiKhoan = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public clsNhanVien_DTO NhanVien { get => _nhanVien; set => _nhanVien = value; }
        public clsPhanLoaiTK_DTO LoaiTK { get => _loaiTK; set => _loaiTK = value; }
        public DateTime LastLogon { get => _lastLogon; set => _lastLogon = value; }
        public int TrangThai { get => _trangThai; set => _trangThai = value; }
    }
}
