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
    public partial class frmBaoHanh : Form
    {
        public frmBaoHanh()
        {
            InitializeComponent();
        }
        private static frmBaoHanh _Instance = null;

        public static frmBaoHanh Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmBaoHanh();
                return _Instance;
            }
        }

        private void frmBaoHanh_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmBaoHanh_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }
    }
}
