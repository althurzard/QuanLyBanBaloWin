using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBalo
{
    public class Helper
    {

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("HHmmssffff");
        }

        /*
         * Trả về đường dẫn của hình ảnh
         */
        public static string layHinhAnh()
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            of.Multiselect = false;
            if (of.ShowDialog() == DialogResult.OK)
            {

                return of.FileName;

            }
            return null;
        }
    }
}
