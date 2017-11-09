using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.IO;

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
            loadLoaiTK();
            showValidateLabel(false);
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

        private void loadLoaiTK()
        {
            DataTable phanLoaiTKTable = clsPhanLoaiTK_BUS.LayBang();
            cboLoaiTK.DataSource = phanLoaiTKTable;
            cboLoaiTK.ValueMember = "MaPhanLoaiTK";
            cboLoaiTK.DisplayMember = "MoTa";
        }

        private void themHinhAnh()
        {
            string filePath = Helper.layHinhAnh();
            if (filePath != null)
            {
                lblChonAnh.Visible = false;
                pictureHinhAnh.ImageLocation = filePath;
            }
        }

        private void showValidateLabel(bool willShow)
        {
            lblHoten.Visible = willShow;
            lblDiaChi.Visible = willShow;
            lblMatKhau.Visible = willShow;
            lblNhapLaiMK.Visible = willShow;
            lblQueQuan.Visible = willShow;
            lblSDT.Visible = willShow;
            lblTenDangNhap.Visible = willShow;
            lblChonAnh.Visible = willShow;
        }

        private bool kiemTraTextbox()
        {
            bool hopLe = true;
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                hopLe = false;
                lblHoten.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtQueQuan.Text))
            {
                hopLe = false;
                lblQueQuan.Visible = true;
            }
            if(string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                hopLe = false;
                lblSDT.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                hopLe = false;
                lblDiaChi.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtDangNhap.Text))
            {
                hopLe = false;
                lblTenDangNhap.Visible = true;
            }
            if(string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                hopLe = false;
                lblMatKhau.Visible = true;
            }
            if (txtMatKhau.Text != txtNhapLaiMK.Text || string.IsNullOrWhiteSpace(txtNhapLaiMK.Text))
            {
                hopLe = false;
                lblNhapLaiMK.Visible = true;
            }
            if (pictureHinhAnh.Image == null)
            {
                hopLe = false;
                lblChonAnh.Visible = true;
            }

            return hopLe;

        }


        private void taoTaiKhoan()
        {
            showValidateLabel(false);

            if (kiemTraTextbox())
            {
                // Hop le
                if (clsTaiKhoan_BUS.KiemTraTaiKhoanDaTonTai(txtDangNhap.Text))
                {
                    // tai khoan da ton tai
                    DialogResult = MessageBox.Show("Tên tài khoản đã tồn tại, vui lòng nhập tên khác.", "Thông báo", MessageBoxButtons.OK);
                    if (DialogResult == DialogResult.OK)
                    {
                        txtDangNhap.Text = "";
                    }

                }
                else
                {
                    // Lưu ảnh vào database 
                    clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(pictureHinhAnh.ImageLocation, clsHinhAnh_DTO.LoaiHinhAnh.Avatar);
                    object resultHinhAnh = clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);

                    if (resultHinhAnh is int)
                    {
                        hinhAnh.MaHinhAnh = (int)resultHinhAnh;
                        // Lưu nhân viên vào database
                        clsNhanVien_DTO nhanVien = new clsNhanVien_DTO(Helper.GetTimestamp(DateTime.Now), txtHoTen.Text, pckNgaySinh.Value, txtQueQuan.Text, txtDiaChi.Text, txtSoDienThoai.Text, hinhAnh, DateTime.Now);
                        object resultThemNV = clsNhanVien_BUS.ThemNhanVien(nhanVien);
                        if (resultThemNV is bool)
                        {
                            // Lưu Tài Khoản vào database
                            int maLoaiTK = (int)cboLoaiTK.SelectedValue;
                            string moTa = ((DataRowView)cboLoaiTK.Items[cboLoaiTK.SelectedIndex])["MoTa"].ToString();
                            clsTaiKhoan_DTO taiKhoan = new clsTaiKhoan_DTO(txtDangNhap.Text, txtMatKhau.Text, nhanVien, new clsPhanLoaiTK_DTO(maLoaiTK, moTa));
                            object resultThemTaiKhoan = clsTaiKhoan_BUS.ThemTaiKhoan(taiKhoan);

                            if (resultThemTaiKhoan is bool)
                            {
                                if ((bool)resultThemTaiKhoan)
                                {
                                    // Copy image file vào folder data/avatar
                                    string fileName = Path.GetFileName(pictureHinhAnh.ImageLocation);
                                    string destPath = Directory.GetCurrentDirectory() + "\\data\\avatar\\" + fileName;
                                    File.Copy(pictureHinhAnh.ImageLocation, destPath, true);

                                    MessageBox.Show("Tạo tài khoản thành công");
                                }
                                else
                                {
                                    MessageBox.Show("Tạo tài khoản thất bại");
                                }


                            }
                            else
                            {
                                MessageBox.Show((string)resultThemTaiKhoan);
                            }
                        }
                        else
                        {
                            MessageBox.Show((string)resultThemNV);
                        }
                    }
                    else
                    {
                        MessageBox.Show((string)resultHinhAnh);
                    }
                }
            }
            else
            {
                DialogResult = MessageBox.Show("Đã xảy ra lỗi, vui lòng kiểm tra lại thông tin nhập.", "Thông báo", MessageBoxButtons.OK);
            }

        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            themHinhAnh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            taoTaiKhoan();
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

    }
}
