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
using System.Data;
namespace QuanLyBanBalo
{
    public partial class frmBaoHanh : Form
    {
        private DataView dvHoaDon;
        private DataTable dtHoaDon;
        private DataTable dtSanPham;
        private DataView dvSanPham;
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

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (rdbSDT.Checked)
            {
                clsKhachHang_DTO khachHang = clsKhachHang_BUS.LayThongTin(txtSDT.Text);

                if (khachHang != null)
                {
                    dtHoaDon = clsHoaDon_BUS.LayHoaDonTheoMaKH(khachHang.MaKH);
                    dvHoaDon = new DataView(dtHoaDon);
                    dgvDanhSachHD.DataSource = dvHoaDon;
                    dgvDanhSachHD.AutoGenerateColumns = false;
                    return;
                }
            }

            if (rdbMaHD.Checked)
            {
                dtHoaDon = clsHoaDon_BUS.LayHoaDonTheoMaHD(txtMaHD.Text);
                dvHoaDon = new DataView(dtHoaDon);
                dgvDanhSachHD.DataSource = dvHoaDon;
                dgvDanhSachHD.AutoGenerateColumns = false;
                return;
            }


            MessageBox.Show("Không có kết quả.");

        }

        private void dgvDanhSachHD_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachHD.Columns[e.ColumnIndex].Name == "GiamTru")
            {
                e.Value = double.Parse(e.Value.ToString()) == 0.0 ? "0" : e.Value;
            }

                
        }

        private void dgvDanhSachHD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string maHD = dgvDanhSachHD.CurrentRow.Cells[1].Value.ToString();
            string maNV = dgvDanhSachHD.CurrentRow.Cells["MaNV"].Value.ToString();
            dtSanPham = clsChiTietHD_BUS.LayChiTiet(maHD);
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.DataSource = dvSanPham;

            clsNhanVien_DTO nv = clsNhanVien_BUS.LayNhanVien(maNV);

            pictureHinhAnh.ImageLocation = nv.HinhAnh.Url;
            lblTenNV.Text = nv.HoTen;
            lblSDTNV.Text = nv.SoDienThoai;
            lblMaNV.Text = nv.MaNV;
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                e.Value = new Bitmap(e.Value.ToString());
            }
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "SPGiamTru")
            {
                e.Value = double.Parse(e.Value.ToString()) == 0.0 ? "0" : e.Value;
            }
        }

        private void rdbSDT_CheckedChanged(object sender, EventArgs e)
        {
            txtSDT.Enabled = rdbSDT.Checked;
        }

        private void rdbMaHD_CheckedChanged(object sender, EventArgs e)
        {
            txtMaHD.Enabled = rdbMaHD.Checked;
        }

        private void dgvDanhSachHD_DataSourceChanged(object sender, EventArgs e)
        {
            lblHoaDon.Text = string.Format("Có {0} hóa đơn.", dtHoaDon.Rows.Count);

            if (dtHoaDon.Rows.Count >= 1)
            {
                lblTenKH.Text = dtHoaDon.Rows[0]["TenKH"].ToString();
                lblSDT.Text = dtHoaDon.Rows[0]["SDT"].ToString();
                lblMaKH.Text = dtHoaDon.Rows[0]["MaKhachHang"].ToString();
            }
            
        }
    }
}
