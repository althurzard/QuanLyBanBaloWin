using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBalo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MessageBoxManager.OK = "Đồng ý";
            MessageBoxManager.Yes ="Có";
            MessageBoxManager.No = "Không";
            MessageBoxManager.Cancel = "Huỷ bỏ";
            MessageBoxManager.Register();
            Application.Run(new frmMain());
        }

    }
}
