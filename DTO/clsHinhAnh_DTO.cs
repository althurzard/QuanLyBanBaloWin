using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsHinhAnh_DTO
    {
        private string _tenHinhAnh;
        private string _url;
        private int _maHinhAnh;

        public clsHinhAnh_DTO()
        {

        }

        public clsHinhAnh_DTO(string tenHinhAnh, string url, int maHinhAnh)
        {
            _tenHinhAnh = tenHinhAnh;
            _url = url;
            _maHinhAnh = maHinhAnh;
        }

        public string TenHinhAnh { get => _tenHinhAnh; set => _tenHinhAnh = value; }
        public string Url { get => _url; set => _url = value; }
        public int MaHinhAnh { get => _maHinhAnh; set => _maHinhAnh = value; }
    }
}
