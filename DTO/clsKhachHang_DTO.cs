using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsKhachHang_DTO
    {
        private string _maKH;
        private string _tenKH;
        private string _SDT;


        public clsKhachHang_DTO()
        {

        }

        public clsKhachHang_DTO(string tenKH, string SDT, string maKH)
        {
            _tenKH = tenKH;
            _SDT = SDT;
            _maKH = maKH;
        }

        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string SDT { get => _SDT; set => _SDT = value; }
        public string MaKH { get => _maKH; set => _maKH = value; }
    }
}
