using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanBalo
{
    public partial class frmMatHang : Form
    {
        public frmMatHang()
        {
            InitializeComponent();
        }
        private static frmMatHang _Instance = null;

        public static frmMatHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmMatHang();
                return _Instance;
            }
        }

        private void frmMatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void frmMatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
    }
}
