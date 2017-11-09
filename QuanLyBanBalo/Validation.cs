using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBalo
{
    public class Validation
    {
        /*
         Validate
         Trả về true false và câu thông báo
        */

        /*
         * kiểm tra có để trống không
         */
        public static bool NotEmptyTextBox(string textBox , out string errorMSG)
        {
            if(string.IsNullOrWhiteSpace(textBox))
            {
                errorMSG = "Không được để trống ô này";
                return false;
            }
            else
            {
                errorMSG = "";
                return true;
            }
        }

        /*
         * Kiểm tra phải số không
         */
        public static bool IsNumberic(string textBox, out string errorMSG)
        {
            //kiểm tra có để trống không
           if(NotEmptyTextBox(textBox, out errorMSG))
           {
                //kiểm tra chuỗi với regex
                Regex regx = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                if (!regx.IsMatch(textBox))
                {
                    errorMSG = "Vui lòng nhập số";
                    return false;
                }
                errorMSG = "";
                return true;
            }
            else
            {
                return NotEmptyTextBox(textBox, out errorMSG);
            }
           
        }


        

        /*
         * Kiểm tra phải số không với sự kiện KeyPress
         * example: e.Handled = !Validation.IsNumberic(e)
         */
        public static bool IsNumberic(KeyPressEventArgs e)
        {
            return Char.IsControl(e.KeyChar) ? Char.IsControl(e.KeyChar) : Char.IsDigit(e.KeyChar);
        }

        
    }
}
