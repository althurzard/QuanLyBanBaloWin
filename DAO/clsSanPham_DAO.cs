using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class clsSanPham_DAO
    {
        private static DataTable dtSanPham;
        private static SqlDataReader drSanPham;

        public static  DataTable LayTatCaSanPham(bool SanPhamTonKho = true)
        {
            string query = "";
            if (SanPhamTonKho)
            {
               query = "SELECT SanPham.MaSP, SanPham.TenSP, SanPham.ThuongHieu,SanPham.ChatLieu,SanPham.GiaVon,SanPham.GiaBanLe,SanPham.ChongNuoc,SanPham.SoNamBH, DanhMuc.* ,ChiTietSanPham.MaCTSP, ChiTietSanPham.MauSac, ChiTietSanPham.TrangThai, ChiTietSanPham.SoLuong, HinhAnh.Url FROM SanPham, DanhMuc, ChiTietSanPham, HinhAnh  WHERE SanPham.MaDanhMuc = DanhMuc.MaDanhMuc AND ChiTietSanPham.MaSP = SanPham.MaSP AND ChiTietSanPham.MaHinhAnh = HinhAnh.MaHinhAnh AND ChiTietSanPham.TrangThai = 1 ";
            } else
            {
               query = "SELECT SanPham.MaSP, SanPham.TenSP, SanPham.ThuongHieu,SanPham.ChatLieu,SanPham.GiaVon,SanPham.GiaBanLe,SanPham.ChongNuoc,SanPham.SoNamBH, DanhMuc.* ,ChiTietSanPham.MaCTSP, ChiTietSanPham.MauSac, ChiTietSanPham.TrangThai, ChiTietSanPham.SoLuong, HinhAnh.Url FROM SanPham, DanhMuc, ChiTietSanPham, HinhAnh  WHERE SanPham.MaDanhMuc = DanhMuc.MaDanhMuc AND ChiTietSanPham.MaSP = SanPham.MaSP AND ChiTietSanPham.MaHinhAnh = HinhAnh.MaHinhAnh AND ChiTietSanPham.TrangThai = 1 AND ChiTietSanPham.SoLuong > 0 ";
            }
            
            dtSanPham = XuLyDuLieu.LayBang(query);
            return dtSanPham;
        }

        public static SqlDataReader LayThongTinMotSanPham(string idSanPham,string idChiTiet)
        {
            string query =string.Format("SELECT SanPham.*,DanhMuc.*,ChiTietSanPham.*,HinhAnh.Url,HinhAnh.MaHinhAnh FROM SanPham, DanhMuc, ChiTietSanPham, HinhAnh  WHERE SanPham.MaDanhMuc = DanhMuc.MaDanhMuc AND ChiTietSanPham.MaSP = SanPham.MaSP AND ChiTietSanPham.MaHinhAnh = HinhAnh.MaHinhAnh AND SanPham.MaSP='{0}' AND ChiTietSanPham.MaCTSP ='{1}'", idSanPham,idChiTiet);
            drSanPham = XuLyDuLieu.LayDuLieu(query);
            return drSanPham;
        }

        public static DataTable LayTatCaMauMa()
        {
            string query = "SELECT * FROM DanhMuc";
            dtSanPham = XuLyDuLieu.LayBang(query);
            return dtSanPham;
        }

        public static int XoaSanPham(string idSanPham)
        {
            string query = string.Format("UPDATE ChiTietSanPham SET TrangThai = 0 WHERE MaCTSP ='{0}'", idSanPham);
            return XuLyDuLieu.ThucThiCauLenh(query);
        }

        public static object SuaSanPham(clsSanPham_DTO sanPham, clsChiTietSP_DTO chiTietSP)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                //cập nhật vào bảng sản phẩm
                string query = string.Format("UPDATE SanPham SET TenSP = @TenSP , ThuongHieu = @ThuongHieu, ChatLieu = @ChatLieu, GiaVon = @GiaVon, GiaBanLe = @GiaBanLe, ChongNuoc = @ChongNuoc, TrongLuong = @TrongLuong, MaDanhMuc = @MaDanhMuc, SoNamBH = @SoNamBH WHERE MaSP = @MaSP");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaSP", SqlDbType.Char).Value = sanPham.MaSP;
                cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = sanPham.TenSP;
                cmd.Parameters.Add("@ThuongHieu", SqlDbType.NVarChar).Value = sanPham.ThuongHieu;
                cmd.Parameters.Add("@ChatLieu", SqlDbType.NVarChar).Value = sanPham.ChatLieu;
                cmd.Parameters.Add("@GiaVon", SqlDbType.Money).Value = sanPham.GiaVon;
                cmd.Parameters.Add("@GiaBanLe", SqlDbType.Money).Value = sanPham.GiaBanLe;
                cmd.Parameters.Add("@ChongNuoc", SqlDbType.Bit).Value = sanPham.ChongNuoc;
                cmd.Parameters.Add("@TrongLuong", SqlDbType.Float).Value = sanPham.TrongLuong;
                cmd.Parameters.Add("@MaDanhMuc", SqlDbType.Int).Value = sanPham.MaDanhMuc;
                cmd.Parameters.Add("@SoNamBH", SqlDbType.Int).Value = sanPham.SoNamBH;
                cmd.CommandType = CommandType.Text;

                //cập nhật bảng chi tiết sản phẩm
                string queryDanhMuc = string.Format("UPDATE ChiTietSanPham SET MauSac = @MauSac, SoLuong = @SoLuong, MaHinhAnh = @MaHinhAnh WHERE MaCTSP = @MaCTSP");
                SqlCommand cmdDanhMuc = new SqlCommand(queryDanhMuc, connection);
                cmdDanhMuc.Parameters.Add("@MaCTSP", SqlDbType.Char).Value = chiTietSP.MaCTSP;
                cmdDanhMuc.Parameters.Add("@MauSac", SqlDbType.NVarChar).Value = chiTietSP.MauSac;
                cmdDanhMuc.Parameters.Add("@SoLuong", SqlDbType.Int).Value = chiTietSP.SoLuong;
                cmdDanhMuc.Parameters.Add("@MaHinhAnh", SqlDbType.Int).Value = chiTietSP.MaHinhAnh;
                cmdDanhMuc.CommandType = CommandType.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                    cmdDanhMuc.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException e)
                {
                    return e.Message.ToString();
                }
            }
        }

        public static object ThemSanPham(clsSanPham_DTO sanPham)
        {
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("INSERT INTO SanPham(MaSP,TenSP,ThuongHieu,ChatLieu,GiaVon,GiaBanLe,ChongNuoc,TrongLuong,MaDanhMuc,SoNamBH) VALUES(@MaSP,@TenSP,@ThuongHieu,@ChatLieu,@GiaVon,@GiaBanLe,@ChongNuoc,@TrongLuong,@MaDanhMuc,@SoNamBH)");
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@MaSP", SqlDbType.Char).Value = sanPham.MaSP;
                cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = sanPham.TenSP;
                cmd.Parameters.Add("@ThuongHieu", SqlDbType.NVarChar).Value = sanPham.ThuongHieu;
                cmd.Parameters.Add("@ChatLieu", SqlDbType.NVarChar).Value = sanPham.ChatLieu;
                cmd.Parameters.Add("@GiaVon", SqlDbType.Money).Value = sanPham.GiaVon;
                cmd.Parameters.Add("@GiaBanLe", SqlDbType.Money).Value = sanPham.GiaBanLe;
                cmd.Parameters.Add("@ChongNuoc", SqlDbType.Bit).Value = sanPham.ChongNuoc;
                cmd.Parameters.Add("@TrongLuong", SqlDbType.Float).Value = sanPham.TrongLuong;
                cmd.Parameters.Add("@MaDanhMuc", SqlDbType.Int).Value = sanPham.MaDanhMuc;
                cmd.Parameters.Add("@SoNamBH", SqlDbType.Int).Value = sanPham.SoNamBH;
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

        public static clsSanPham_DTO LaySanPham(string maSP)
        {
            clsSanPham_DTO sanPham = null;
            using (SqlConnection connection = XuLyDuLieu.MoKetNoi)
            {
                string query = string.Format("Select * from SanPham where MaSP = '{0}' ", maSP);
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sanPham = new clsSanPham_DTO();
                        sanPham.MaKhuyenMai = (int)reader["MaKhuyenMai"];
                        sanPham.ChatLieu = reader["ChatLieu"].ToString();
                        sanPham.ChongNuoc = (bool)reader["ChongNuoc"];
                        sanPham.GiaBanLe = decimal.Parse(reader["GiaBanLe"].ToString());
                        sanPham.GiaVon = decimal.Parse(reader["GiaVon"].ToString());
                        sanPham.MaDanhMuc = (int)reader["MaDanhMuc"];
                        sanPham.MaSP = maSP;
                        sanPham.SoNamBH = (int)reader["SoNamBH"];
                        sanPham.TenSP = reader["TenSP"].ToString();
                        sanPham.ThuongHieu = reader["ThuongHieu"].ToString();
                        sanPham.TrongLuong = float.Parse(reader["TrongLuong"].ToString());

                    }
                }

            }

            return sanPham;
        }

        public static bool KiemTraTrungSanPham(string tenSanPham)
        {
            string query = string.Format("SELECT count(TenSP) FROM SanPham WHERE TenSP = N'{0}'", tenSanPham);
            return XuLyDuLieu.ThucThiCauLenhWithScalar(query) >= 1;
        }

        public static DataTable LayBangSanPham()
        {
            string query = string.Format("SELECT * FROM SanPham");
            return XuLyDuLieu.LayBang(query);
        }

        public static bool CapNhatKhuyenMai(int maKhuyenMai)
        {
            string query = string.Format("Update SanPham set MaKhuyenMai = {0}", maKhuyenMai);
            return XuLyDuLieu.ThucThiCauLenh(query) >= 1;
        }

        public static List<string> LayThuongHieu()
        {
            List<string> listThuongHieu = new List<string>();
            string query = string.Format("Select DISTINCT ThuongHieu from SanPham ORDER BY ThuongHieu");
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        listThuongHieu.Add(reader["ThuongHieu"].ToString());
                    }

                }
                conn.Close();
            }

            return listThuongHieu;
        }

        public static List<string> LayChatLieu()
        {
            List<string> listChatLieu = new List<string>();
            string query = string.Format("Select DISTINCT ChatLieu from SanPham ORDER BY ChatLieu");
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listChatLieu.Add(reader["ChatLieu"].ToString());
                    }

                }
                conn.Close();
            }

            return listChatLieu;
        }

        public static List<string> LayTenSP()
        {
            List<string> listChatLieu = new List<string>();
            string query = string.Format("Select DISTINCT TenSP from SanPham ORDER BY TenSP");
            using (SqlConnection conn = XuLyDuLieu.MoKetNoi)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listChatLieu.Add(reader["TenSP"].ToString());
                    }

                }
                conn.Close();
            }

            return listChatLieu;
        }




    }
}
