using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class clsPhieuNhapKho_DAO
    {
        public static object ThemPhieuNhapKho(clsPhieuNhapKho_DTO phieuNhapKho)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("INSERT INTO PhieuNhapKho(MaPhieuNhapKho, MaNV, GhiChu, NgayKhoiTao, TrangThai, MaNhaCungCap) VALUES(@MaPhieuNhapKho, @MaNV, @GhiChu, @NgayKhoiTao, @TrangThai, @MaNhaCungCap)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaPhieuNhapKho", SqlDbType.Char).Value = phieuNhapKho.MaPhieuNhapKho;
                cmd.Parameters.Add("@MaNV", SqlDbType.Char).Value = phieuNhapKho.MaNhanVien;
                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = phieuNhapKho.GhiChu;
                cmd.Parameters.Add("@NgayKhoiTao", SqlDbType.Date).Value = phieuNhapKho.NgayKhoiTao;
                cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = phieuNhapKho.TrangThai;
                cmd.Parameters.Add("@MaNhaCungCap", SqlDbType.Char).Value = phieuNhapKho.MaNhaCungCap;
                cmd.CommandType = CommandType.Text;
                try
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (SqlException e)
                {
                    return e.Message.ToString();
                }
            }
        }

        public static DataTable LayBang(string tuNgay, string denNgay)
        {
            string query = string.Format("Select MaPhieuNhapKho, HoTen, PhieuNhapKho.NgayKhoiTao as NgayKhoiTao,GhiChu, TenNhaCungCap" +
                " from PhieuNhapKho,NhanVien,NhaCungCap" +
                " where PhieuNhapKho.MaNV = NhanVien.MaNV AND PhieuNhapKho.MaNhaCungCap = NhaCungCap.MaNhaCungCap AND PhieuNhapKho.NgayKhoiTao >= '{0}' AND PhieuNhapKho.NgayKhoiTao <= dateadd(day,1,'{1}')", tuNgay, denNgay);
            return XuLyDuLieu.LayBang(query);
        }
    }
}
