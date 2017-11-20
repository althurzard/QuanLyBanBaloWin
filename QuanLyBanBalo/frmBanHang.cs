﻿using System;
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
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
            MessageBox.Show(Validation.LayMaNhanVien());
        }
        private static frmBanHang _Instance = null;

        public static frmBanHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmBanHang();
                return _Instance;
            }
        }
        private void frmXuatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmXuatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

    }
}