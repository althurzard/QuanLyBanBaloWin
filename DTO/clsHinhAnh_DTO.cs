using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsHinhAnh_DTO
    {
        public enum LoaiHinhAnh
        {
            Icon,
            Avatar,
            Product
        }

        private string _tenHinhAnh;
        private string _url;
        private int _maHinhAnh;

        public clsHinhAnh_DTO()
        {

        }
        //DuLieu/hinh/hinhanh.abc
        public clsHinhAnh_DTO(string imageLocation, LoaiHinhAnh loaiAnh, int maHinhAnh = -1 /*Gia trị mặc định khi khởi tạo image - chưa có mã hình ảnh */)
        {
            _tenHinhAnh = Path.GetFileNameWithoutExtension(imageLocation);

            string path = "images/";
            if (loaiAnh == LoaiHinhAnh.Avatar)
                path = "data/avatar/";
            else if (loaiAnh == LoaiHinhAnh.Icon)
                path = "data/icon/";
            else
                path = "data/product/";
            
            _url = path + Path.GetFileName(imageLocation);
            _maHinhAnh = maHinhAnh;
        }

        public clsHinhAnh_DTO(string tenHinhAnh, string url, int maHinhAnh = -1 /*Gia trị mặc định khi khởi tạo image - chưa có mã hình ảnh */)
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
