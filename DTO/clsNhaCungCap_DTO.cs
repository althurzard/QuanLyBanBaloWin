using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsNhaCungCap_DTO
    {
        private string _MaNhaCungCap;
        private string _TenNhaCungCap;
        private int _MaHinhAnh;
        private int _SoDienThoai;
        private string _DiaChi;
        private int _TrangThai;

        public string MaNhaCungCap { get => _MaNhaCungCap; set => _MaNhaCungCap = value; }
        public string TenNhaCungCap { get => _TenNhaCungCap; set => _TenNhaCungCap = value; }
        public int MaHinhAnh { get => _MaHinhAnh; set => _MaHinhAnh = value; }
        public int SoDienThoai { get => _SoDienThoai; set => _SoDienThoai = value; }
        public string DiaChi { get => _DiaChi; set => _DiaChi = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
    }
}
