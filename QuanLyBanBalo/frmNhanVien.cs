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
    public partial class frmNhanVien : Form
    {
        private static frmNhanVien _Instance = null;

        public static frmNhanVien Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmNhanVien();
                return _Instance;
            }
        }

            
            

            
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void frmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }
    }
}
