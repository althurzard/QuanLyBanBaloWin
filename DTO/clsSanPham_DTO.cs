using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsSanPham_DTO
    {
        string _MaSP;
        string _TenSP;
        string _ThuongHieu;
        string _ChatLieu;
        decimal _GiaVon;
        decimal _GiaBanLe;
        bool _ChongNuoc;
        float _TrongLuong;
        int _MaDanhMuc;
        int _SoNamBH;

        public string MaSP { get => _MaSP; set => _MaSP = value; }
        public string TenSP { get => _TenSP; set => _TenSP = value; }
        public string ThuongHieu { get => _ThuongHieu; set => _ThuongHieu = value; }
        public string ChatLieu { get => _ChatLieu; set => _ChatLieu = value; }
        public decimal GiaVon { get => _GiaVon; set => _GiaVon = value; }
        public decimal GiaBanLe { get => _GiaBanLe; set => _GiaBanLe = value; }
        public bool ChongNuoc { get => _ChongNuoc; set => _ChongNuoc = value; }
        public float TrongLuong { get => _TrongLuong; set => _TrongLuong = value; }
        public int MaDanhMuc { get => _MaDanhMuc; set => _MaDanhMuc = value; }
        public int SoNamBH { get => _SoNamBH; set => _SoNamBH = value; }
    }
}
