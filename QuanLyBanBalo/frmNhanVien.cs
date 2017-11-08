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

            
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            of.Multiselect = false;
            if (of.ShowDialog() == DialogResult.OK)
            {
                // Copy file vào folder data
                string fileName = Path.GetFileName(of.FileName);
                string destPath = Directory.GetCurrentDirectory() + "\\data\\avatar\\" + fileName;
                File.Copy(of.FileName, destPath, true);

                pictureHinhAnh.ImageLocation = destPath;
                

            }
        }

        private void taoTaiKhoan()
        {
            string tenHinh = Path.GetFileNameWithoutExtension(pictureHinhAnh.ImageLocation);
            string url = "data/avatar/" + Path.GetFileName(pictureHinhAnh.ImageLocation);
            clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(tenHinh, url);
            object resultHinhAnh = clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);
            if (resultHinhAnh is int)
            {
                hinhAnh.MaHinhAnh = (int)resultHinhAnh;
                clsNhanVien_DTO nhanVien = new clsNhanVien_DTO(Helper.GetTimestamp(DateTime.Now), txtHoTen.Text, pckNgaySinh.Value, txtQueQuan.Text, txtDiaChi.Text, txtSoDienThoai.Text, hinhAnh, DateTime.Now);
                object resultThemNV = clsNhanVien_BUS.ThemNhanVien(nhanVien);
                if (resultThemNV is bool)
                {
                    int maLoaiTK = (int)cboLoaiTK.SelectedValue;
                    string moTa = ((DataRowView)cboLoaiTK.Items[cboLoaiTK.SelectedIndex])["MoTa"].ToString();
                    clsTaiKhoan_DTO taiKhoan = new clsTaiKhoan_DTO(txtDangNhap.Text, txtMatKhau.Text, nhanVien, new clsPhanLoaiTK_DTO(maLoaiTK,moTa));
                    object resultThemTaiKhoan = clsTaiKhoan_BUS.ThemTaiKhoan(taiKhoan);
                    if (resultThemTaiKhoan is bool)
                    {
                        MessageBox.Show("Tạo tài khoản thành công");
                    } else
                    {
                        MessageBox.Show((string)resultThemTaiKhoan);
                    }
                } else
                {
                    MessageBox.Show((string)resultThemNV);
                }
            } else
            {
                MessageBox.Show((string)resultHinhAnh);
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
    }
}
