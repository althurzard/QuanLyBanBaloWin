using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsKhuyenMai_DTO
    {
        private int _maKhuyenMai;
        private string _tenKhuyenMai;
        private string _moTa;
        private DateTime? _ngayBatDau = null;
        private DateTime? _ngayKetThuc = null;
        private int _trangThai;
        private bool _apDungHD;

        public clsKhuyenMai_DTO()
        {

        }
        public clsKhuyenMai_DTO(
            string tenKhuyenMai,
            string moTa,
            bool apDungHD,
            DateTime? ngayBatDau = null,
            DateTime? ngayKetThuc = null,
            int trangThai = 1, 
            int maKhuyenMai = 1)
        {
            _tenKhuyenMai = tenKhuyenMai;
            _moTa = moTa;
            _ngayBatDau = ngayBatDau;
            _ngayKetThuc = ngayKetThuc;
            _trangThai = trangThai;
            _apDungHD = apDungHD;
            _maKhuyenMai = maKhuyenMai;
        }

        public int MaKhuyenMai { get => _maKhuyenMai; set => _maKhuyenMai = value; }
        public string TenKhuyenMai { get => _tenKhuyenMai; set => _tenKhuyenMai = value; }
        public string MoTa { get => _moTa; set => _moTa = value; }
        public DateTime? NgayBatDau { get => _ngayBatDau; set => _ngayBatDau = value; }
        public DateTime? NgayKetThuc { get => _ngayKetThuc; set => _ngayKetThuc = value; }
        public int TrangThai { get => _trangThai; set => _trangThai = value; }
        public bool ApDungHD { get => _apDungHD; set => _apDungHD = value; }
    }
}
