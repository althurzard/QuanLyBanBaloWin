using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsDanhMuc_DTO
    {
        private int _MaDanhMuc;
        private string _TenDanhMuc;
        private int _TrangThai;

        public int MaDanhMuc { get => _MaDanhMuc; set => _MaDanhMuc = value; }
        public string TenDanhMuc { get => _TenDanhMuc; set => _TenDanhMuc = value; }
        public int TrangThai { get => _TrangThai; set => _TrangThai = value; }
    }
}
