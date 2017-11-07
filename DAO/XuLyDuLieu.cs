using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class XuLyDuLieu
    {
        private static string StringConn = @"Data Source=DESKTOP-NG51H3P\SQLEXPRESS;Initial Catalog=db_baloshop;Integrated Security=True";
        public static SqlConnection KetNoi()
        {
            SqlConnection conn = new SqlConnection(StringConn);
            conn.Open();
            return conn;
        }

        public static void NgatKetNoi(SqlConnection conn)
        {
            conn.Close();
        }
        //Hàm truy vấn cơ sở dữ liệu thực hiện câu lênh SQL
        public static int ExcuteNoneQuery(string stringQuery)
        {
            SqlConnection conn = XuLyDuLieu.KetNoi();
            SqlCommand cmd = new SqlCommand(stringQuery, conn);
            int i = cmd.ExecuteNonQuery();
            XuLyDuLieu.NgatKetNoi(conn);
            return i;

        }

        //Hàm lấy bảng từ sql 
        public static DataTable LayBang(string stringQuery)
        {
            SqlConnection conn = XuLyDuLieu.KetNoi();
            SqlCommand cmd = new SqlCommand(stringQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
