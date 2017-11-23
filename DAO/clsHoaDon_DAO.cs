using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class clsHoaDon_DAO
    {
        public static bool Them(clsHoaDon_DTO hoaDon)
        {
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                string query = "Insert into HoaDon(MaHD,SDT,TenKH,MaNV,NgayKhoiTao,MaKhuyenMai,GiamTru,GhiChu,ThanhTien) values (@MaHD,@SDT,@TenKH,@MaNV,@NgayKhoiTao,@MaKhuyenMai,@GiamTru,@GhiChu,@ThanhTien) ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MaHD", SqlDbType.Char).Value = hoaDon.MaHD;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = hoaDon.SDT;
                cmd.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = hoaDon.TenKH;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = hoaDon.MaNV;
                cmd.Parameters.Add("@NgayKhoiTao", SqlDbType.DateTime).Value = hoaDon.NgayKhoiTao;
                cmd.Parameters.Add("@MaKhuyenMai", SqlDbType.Int).Value = hoaDon.KhuyenMai.MaKhuyenMai;
                cmd.Parameters.Add("@GiamTru", SqlDbType.Money).Value = hoaDon.GiamTru;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = hoaDon.GhiChu;
                cmd.Parameters.Add("@ThanhTien", SqlDbType.Money).Value = hoaDon.ThanhTien;
                cmd.CommandType = CommandType.Text;
                try
                {
                    return cmd.ExecuteNonQuery() >= 1;
                }
                catch (SqlException e)
                {
                    throw e;
                }

            }
        }
    }
}
