using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsPhanLoaiTK_DTO
    {
        private int _maPhanLoaiTK;
        private string _moTa;

        public clsPhanLoaiTK_DTO()
        {

        }

        public clsPhanLoaiTK_DTO(int maPhanLoaiTK, string moTa)
        {
            _maPhanLoaiTK = maPhanLoaiTK;
            _moTa = moTa;
        }

        public int MaPhanLoaiTK { get => _maPhanLoaiTK; set => _maPhanLoaiTK = value; }
        public string MoTa { get => _moTa; set => _moTa = value; }
    }
}
