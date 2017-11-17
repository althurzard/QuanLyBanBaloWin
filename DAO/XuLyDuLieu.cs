using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{

    public class XuLyDuLieu
    {
        private static string StringConn1 = @"Data Source=.\SQLExpress;Initial Catalog=db_baloshop;Integrated Security=True";
        private static string StringConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\data\\db_baloshop.mdf;Integrated Security=True; Connect Timeout = 30";
        public static SqlConnection MoKetNoi
        {
            get
            {
                SqlConnection conn = new SqlConnection(StringConn1);
                conn.Open();
                return conn;
            }
            
        }

        //Hàm truy vấn cơ sở dữ liệu thực hiện câu lênh SQL Thêm-Xóa-Sửa
        public static int ThucThiCauLenh(string stringQuery)
        {
            SqlConnection conn = XuLyDuLieu.MoKetNoi;
            SqlCommand cmd = new SqlCommand(stringQuery, conn);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }

        public static int ThucThiCauLenhWithScalar(string stringQuery)
        {
            SqlConnection conn = XuLyDuLieu.MoKetNoi;
            SqlCommand cmd = new SqlCommand(stringQuery, conn);
            int i = (int)cmd.ExecuteScalar();
            conn.Close();
            return i;
        }


        //Hàm lấy bảng từ sql 
        public static DataTable LayBang(string stringQuery)
        {
            SqlConnection conn = XuLyDuLieu.MoKetNoi;
            SqlCommand cmd = new SqlCommand(stringQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static SqlDataReader LayDuLieu(string sql)
        {

            SqlConnection conn = XuLyDuLieu.MoKetNoi;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

    
}
}
