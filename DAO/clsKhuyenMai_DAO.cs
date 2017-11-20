using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Data.SqlClient;
namespace DAO
{
    public class clsKhuyenMai_DAO
    {
        public static DataTable LayBangKhuyenMai()
        {
            string query = "Select * from KhuyenMai where TrangThai = 1";
            return XuLyDuLieu.LayBang(query);
        }

        public static int Them(clsKhuyenMai_DTO khuyenMai)
        {
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                string query = "Insert into KhuyenMai(NgayBatDau,NgayKetThuc,ApDungHD,TenKhuyenMai,MoTa) values (@NgayBatDau,@NgayKetThuc,@ApDungHD,@TenKhuyenMai,@MoTa) SELECT CAST(scope_identity() AS int)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@NgayBatDau", SqlDbType.Date).Value = khuyenMai.NgayBatDau == null ? DBNull.Value : (object)khuyenMai.NgayBatDau;
                cmd.Parameters.Add("@NgayKetThuc", SqlDbType.Date).Value = khuyenMai.NgayKetThuc == null ? DBNull.Value : (object)khuyenMai.NgayKetThuc;
                cmd.Parameters.Add("@ApDungHD", SqlDbType.Bit).Value = khuyenMai.ApDungHD;
                cmd.Parameters.Add("@TenKhuyenMai", SqlDbType.NVarChar).Value = khuyenMai.TenKhuyenMai;
                cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = khuyenMai.MoTa;
                cmd.CommandType = CommandType.Text;
                try
                {
                    return (int)cmd.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    throw e;
                }
                
            }
        }

        public static bool Sua(clsKhuyenMai_DTO khuyenMai)
        {
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                string query = "UPDATE KhuyenMai Set NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, ApDungHD = @ApDungHD, TenKhuyenMai = @TenKhuyenMai, MoTa = @MoTa where MaKhuyenMai = @MaKhuyenMai";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@NgayBatDau", SqlDbType.Date).Value = khuyenMai.NgayBatDau == null ? DBNull.Value : (object)khuyenMai.NgayBatDau;
                cmd.Parameters.Add("@NgayKetThuc", SqlDbType.Date).Value = khuyenMai.NgayKetThuc == null ? DBNull.Value : (object)khuyenMai.NgayKetThuc;
                cmd.Parameters.Add("@ApDungHD", SqlDbType.Bit).Value = khuyenMai.ApDungHD;
                cmd.Parameters.Add("@TenKhuyenMai", SqlDbType.NVarChar).Value = khuyenMai.TenKhuyenMai;
                cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = khuyenMai.MoTa;
                cmd.Parameters.Add("@MaKhuyenMai", SqlDbType.Int).Value = khuyenMai.MaKhuyenMai;
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

        public static bool Xoa(int _maKhuyenMai)
        {
            string query = string.Format("UPDATE KhuyenMai set TrangThai = 0 where MaKhuyenMai = '{0}'",_maKhuyenMai);
            return XuLyDuLieu.ThucThiCauLenh(query) >= 1;
        }


    }
}
