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
        /*
         * Cài đặt autocomplete cho textbox
         */
         public static void SetAutocomplete(TextBox textBox,string[] collection)
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(collection);
            textBox.AutoCompleteCustomSource = source;
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        /*
         * Định dạng tiền cho text box
         */
         public static void MoneyFormat(TextBox textBox)
        {
            textBox.Select(textBox.TextLength, 0);
            string strTemp = textBox.Text;
            if (string.IsNullOrWhiteSpace(strTemp)) return;

            double DinhDangTien = double.Parse(strTemp.Trim(','));

            //Định dạng lại textbox
            textBox.Text = DinhDangTien.ToString("0,00.##") == "000" ? "" : DinhDangTien.ToString("0,00.##");
        }
    }
}
