using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace QuanLyBanBalo
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private bool kiemTraTextbox()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                return false;
            }
            return true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (kiemTraTextbox())
            {
                clsTaiKhoan_DTO taiKhoan = new clsTaiKhoan_DTO();
                taiKhoan.TenTaiKhoan = txtTenDangNhap.Text;
                taiKhoan.MatKhau = txtMatKhau.Text;
                taiKhoan.TrangThai = 0;
                taiKhoan = clsTaiKhoan_BUS.LayTaiKhoan(taiKhoan);
               
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tên đăng nhập/ Mật khẩu không đúng, vui lòng nhập lại.");
                } else if (taiKhoan.TrangThai == 0)
                {
                    MessageBox.Show("Tài khoản đã bị khóa, vui lòng liên hệ Admin để mở khóa.");

                } else
                {
                    Validation.nhanVien = taiKhoan;
                    frmMain main = new frmMain();
                    main.Show();
                    Hide();
                }
            } else
            {
                MessageBox.Show("Tên đăng nhập/Mật khẩu không được để trống.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
