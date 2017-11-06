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
    public partial class frmDanhSachHDX : Form
    {
        public frmDanhSachHDX()
        {
            InitializeComponent();
        }

        private static frmDanhSachHDX _Instance = null;

        public static frmDanhSachHDX Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmDanhSachHDX();
                return _Instance;
            }
        }

        private void frmDanhSachHDX_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmDanhSachHDX_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }
    }
}
