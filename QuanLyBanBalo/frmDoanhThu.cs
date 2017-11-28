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
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void lblNgayNhap_Click(object sender, EventArgs e)
        {

        }
        private static frmDoanhThu _Instance = null;

        public static frmDoanhThu Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmDoanhThu();
                return _Instance;
            }
        }

        private void frmDanhSachHDN_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmDanhSachHDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }
    }
}
