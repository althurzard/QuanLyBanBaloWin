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
            CaiDat();
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

        private void CaiDat()
        {
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";

            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            //Autocomplete cho Chất liệu
          
            List<string> listTenSP = clsSanPham_BUS.LayTenSP();
            List<string> listMauSac = clsChiTietSanPham_BUS.LayMauSac();
            Helper.SetAutocomplete(txtTenSP, listTenSP.ToArray());
            Helper.SetAutocomplete(txtMauSac, listMauSac.ToArray());

        }

        private void Search()
        {
            if (dvSanPham == null) return;
            string searchText = "";
            if (!string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                searchText = string.Format("TenSP like '%{0}%' AND ", txtTenSP.Text);
            }
            else
            {
                searchText = "TRUE AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtMauSac.Text))
            {
                searchText += string.Format("MauSac like '%{0}%' AND ", txtMauSac.Text);
            }
            else
            {
                searchText += "TRUE AND ";
            }

            searchText += "TRUE";
            dvSanPham.RowFilter = searchText;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDanhSachHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpNayLapHD_ValueChanged(object sender, EventArgs e)
        {
            int result = DateTime.Compare(dtpTuNgay.Value, dtpDenNgay.Value);
            if (result > 0)
            {
                dtpTuNgay.Value = dtpDenNgay.Value;
            }

            dvHoaDon.RowFilter = string.Format("NgayKhoiTao >= #{0:MM/dd/yyyy} 12:00:00 AM# AND NgayKhoiTao <= #{1:MM/dd/yyyy} 11:59:00 PM#", dtpTuNgay.Value,dtpDenNgay.Value);
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            int result = DateTime.Compare(dtpDenNgay.Value, dtpTuNgay.Value);
            if (result < 0)
            {
                dtpDenNgay.Value = dtpTuNgay.Value;
            }

            dvHoaDon.RowFilter = string.Format("NgayKhoiTao >= #{0:MM/dd/yyyy} 12:00:00 AM# AND NgayKhoiTao <= #{1:MM/dd/yyyy} 11:59:00 PM#", dtpTuNgay.Value, dtpDenNgay.Value);
        }

        private void txtMauSac_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
