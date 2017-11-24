using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsKhachHang_DTO
    {
        private string _tenKH;
        private string _SDT;

        public clsKhachHang_DTO(string tenKH, string SDT)
        {
            _tenKH = tenKH;
            _SDT = SDT;
        }

        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
    }
}
