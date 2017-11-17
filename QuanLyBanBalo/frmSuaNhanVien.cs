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
namespace QuanLyBanBalo
{
    public partial class frmSuaNhanVien : Form
    {
        private bool DaSuaHinh = false;
        private clsTaiKhoan_DTO taiKhoan;
        public frmSuaNhanVien()
        {
            InitializeComponent();
        }

        public frmSuaNhanVien(string  MaNV)
        {
            InitializeComponent();
            loadLoaiTK();
            LoadData(MaNV);

        }

        public void LoadData(string MaNV)
        {
             taiKhoan = clsTaiKhoan_BUS.LayTaiKhoan(MaNV);

            lblMaNV.Text = taiKhoan.NhanVien.MaNV;
            txtHoTen.Text = taiKhoan.NhanVien.HoTen;
            pckNgaySinh.Value = taiKhoan.NhanVien.NgaySinh;
            txtDiaChi.Text = taiKhoan.NhanVien.DiaChi;
            txtMatKhau.Text = taiKhoan.MatKhau;
            txtQueQuan.Text = taiKhoan.NhanVien.QueQuan;
            txtSoDienThoai.Text = taiKhoan.NhanVien.SoDienThoai;
            lblTenDangNhap.Text = taiKhoan.TenTaiKhoan;
            lblNgayKhoiTao.Text = taiKhoan.NhanVien.NgayKhoiTao.ToString("dd/MM/yyyy hh:mm:ss");
            lblMaNV.Text = taiKhoan.NhanVien.MaNV;
            lblLastLogon.Text = taiKhoan.LastLogon.ToString("dd/MM/yyyy hh:mm:ss");
            cboLoaiTK.SelectedValue = taiKhoan.LoaiTK.MaPhanLoaiTK;
            pictureHinhAnh.ImageLocation = taiKhoan.NhanVien.HinhAnh.Url;

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
                pictureHinhAnh.ImageLocation = filePath;
                DaSuaHinh = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureHinhAnh_Click(object sender, EventArgs e)
        {
            themHinhAnh();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
            clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(pictureHinhAnh.ImageLocation, clsHinhAnh_DTO.LoaiHinhAnh.Avatar, this.taiKhoan.NhanVien.HinhAnh.MaHinhAnh);
            if (DaSuaHinh)
            {
                // Lưu ảnh vào database 
                clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);

            } 
            clsNhanVien_DTO nhanVien = new clsNhanVien_DTO(lblMaNV.Text, txtHoTen.Text, pckNgaySinh.Value, txtQueQuan.Text, txtDiaChi.Text, txtSoDienThoai.Text, hinhAnh, DateTime.Now);
            clsTaiKhoan_DTO taiKhoan = new clsTaiKhoan_DTO(lblTenDangNhap.Text, txtMatKhau.Text, nhanVien, null);
            object resultTaiKhoan = clsTaiKhoan_BUS.SuaTaiKhoan(taiKhoan);
            object resultNhanVien = clsNhanVien_BUS.SuaNhanVien(nhanVien);

            if (resultNhanVien is bool && resultTaiKhoan is bool)
            {
                MessageBox.Show("Cập nhật thành công");
            } else
            {
                MessageBox.Show((string)resultNhanVien);
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool result = clsTaiKhoan_BUS.XoaTaiKhoan(this.taiKhoan.TenTaiKhoan);
            string text = "";
            if (result)
            {
                text = "Xóa thành công";
            }
            else
            {
                text = "Xóa thất bại";
            }

            DialogResult dialog = MessageBox.Show(text, "Thông Báo", MessageBoxButtons.OK);

            if (dialog == DialogResult.OK)
            {
                Close();
            }

        }

        private void frmSuaNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is frmNhanVien)
                {
                    ((frmNhanVien)frm).loadBangTK();
                }
            }
        }
    }
}
