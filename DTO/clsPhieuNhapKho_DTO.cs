using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsPhieuNhapKho_DTO
    {
        string _maPhieuNhapKho;
        string _maNhanVien;
        string _ghiChu;
        DateTime _ngayKhoiTao;
        int _trangThai;
        string _maNhaCungCap;

        public clsPhieuNhapKho_DTO()
        {

        }
        public clsPhieuNhapKho_DTO(string maPhieuNhapKho,string maNhanVien,string ghiChu,DateTime ngayKhoiTao,int trangThai, string maNhaCungCap)
        {
             _maPhieuNhapKho = maPhieuNhapKho;
             _maNhanVien = maNhanVien;
             _ghiChu = ghiChu;
             _ngayKhoiTao = ngayKhoiTao;
             _trangThai = trangThai;
             _maNhaCungCap = maNhaCungCap;
        }

        public string MaPhieuNhapKho { get => _maPhieuNhapKho; set => _maPhieuNhapKho = value; }
        public string MaNhanVien { get => _maNhanVien; set => _maNhanVien = value; }
        public string GhiChu { get => _ghiChu; set => _ghiChu = value; }
        public DateTime NgayKhoiTao { get => _ngayKhoiTao; set => _ngayKhoiTao = value; }
        public int TrangThai { get => _trangThai; set => _trangThai = value; }
        public string MaNhaCungCap { get => _maNhaCungCap; set => _maNhaCungCap = value; }
    }
}
