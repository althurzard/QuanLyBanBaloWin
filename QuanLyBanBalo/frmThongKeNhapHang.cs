using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DTO;
using BUS;
namespace QuanLyBanBalo
{
    public partial class frmThongKeNhapHang : Form
    {

        private DataTable dtPhieuNhapKho;
        private DataView dvPhieuNhapKho;
        private DataTable dtSanPham;
        private DataView dvSanPham;
        public frmThongKeNhapHang()
        {
            InitializeComponent();
            CaiDat();
            CaiDatDatatable();
        }

        private void CaiDat()
        {
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";

            cbLoc.SelectedIndex = 0;

            List<string> lstMauSac = clsChiTietSanPham_BUS.LayMauSac();
            Helper.SetAutocomplete(txtMauSac, lstMauSac.ToArray());
            List<string> lstTenSP = clsSanPham_BUS.LayTenSP();
            Helper.SetAutocomplete(txtTenSP, lstTenSP.ToArray());

        }

        private void CaiDatDatatable()
        {
            dtSanPham = new DataTable();
            dtSanPham.Clear();
            dtSanPham.Columns.Add("Url");
            dtSanPham.Columns.Add("TenSP");
            dtSanPham.Columns.Add("MauSac");
            dtSanPham.Columns.Add("ThuongHieu");
            dtSanPham.Columns.Add("ChongNuoc");
            dtSanPham.Columns.Add("TrongLuong");
            dtSanPham.Columns.Add("ChatLieu");
            dtSanPham.Columns.Add("GiaVon");
            dtSanPham.Columns.Add("SoLuong");
            dtSanPham.Columns.Add("TongTien");
            dtSanPham.Columns.Add("MaPhieuNhapKho");
            dtSanPham.Columns.Add("TenNCC");
            dtSanPham.Columns.Add("MaSP");
            dtSanPham.Columns.Add("DVT");
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.DataSource = dvSanPham;
            dgvSanPham.AutoGenerateColumns = false;

        }

        private void EnableTextBox(bool flag)
        {
            txtMauSac.Enabled = flag;
            txtTenSP.Enabled = flag;
            cbLoc.Enabled = flag;
            
        }


        private static frmThongKeNhapHang _Instance = null;

        public static frmThongKeNhapHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmThongKeNhapHang();
                return _Instance;
            }
        }

        private void frmDanhSachHDX_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmDanhSachHDX_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }


        private void DoDuLieuVaoBangSanPham(DataRow row)
        {
            string maPNK = row["MaPhieuNhapKho"].ToString();
            clsChiTietPhieuNhapKho_DTO pnk = clsChiTietPhieuNhapKho_BUS.LayChiTiet(maPNK);
            if (pnk != null)
            {
                clsChiTietSP_DTO ctsp = clsChiTietSanPham_BUS.LayChiTiet(pnk.MaCTSanPham);
                clsHinhAnh_DTO hinhAnh = clsHinhAnh_BUS.LayHinhAnh(ctsp.MaHinhAnh);
                clsSanPham_DTO sanPham = clsSanPham_BUS.LayThongTinMotSanPham(ctsp.MaSP);

                DataRow newSP = dtSanPham.NewRow();
                newSP["Url"] = hinhAnh.Url;
                newSP["TenSP"] = sanPham.TenSP;
                newSP["MauSac"] = ctsp.MauSac;
                newSP["ThuongHieu"] = sanPham.ThuongHieu;
                newSP["ChongNuoc"] = sanPham.ChongNuoc ? "Có" : "Không";
                newSP["TrongLuong"] = sanPham.TrongLuong;
                newSP["ChatLieu"] = sanPham.ChatLieu;
                newSP["GiaVon"] = sanPham.GiaVon.ToString("0,00#");
                newSP["SoLuong"] = pnk.SoLuong;
                newSP["TongTien"] = (sanPham.GiaVon * pnk.SoLuong).ToString("0,00#");
                newSP["MaPhieuNhapKho"] = pnk.MaPhieuNhapKho;
                newSP["TenNCC"] = row["TenNhaCungCap"];
                newSP["MaSP"] = ctsp.MaSP;
                newSP["DVT"] = "Cái";
                dtSanPham.Rows.Add(newSP);
            }
            
        }


        private void CapNhatThongTinThongKe()
        {
            int soLuong = 0;
            double tongTien = 0;
            foreach (DataRow row in dtSanPham.Rows)
            {
                soLuong += int.Parse(row["SoLuong"].ToString());
                tongTien += double.Parse(row["TongTien"].ToString());
            }

            lblSoLuongSP.Text = soLuong.ToString();
            lblTongTien.Text = tongTien.ToString("0,00#");
        }

        private void Search()
        {
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

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            int result = DateTime.Compare(dtpTuNgay.Value, dtpDenNgay.Value);
            if (result > 0)
            {
                dtpTuNgay.Value = dtpDenNgay.Value;
            }



        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            int result = DateTime.Compare(dtpDenNgay.Value, dtpTuNgay.Value);
            if (result < 0)
            {
                dtpDenNgay.Value = dtpTuNgay.Value;
            }

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dtSanPham != null)
                dtSanPham.Clear();
            dtPhieuNhapKho = clsPhieuNhapKho_BUS.LayBang(dtpTuNgay.Value.ToString("yyyy-MM-dd"),dtpDenNgay.Value.ToString("yyyy-MM-dd"));
            dvPhieuNhapKho = new DataView(dtPhieuNhapKho);
            dgvPhieuNhapKho.DataSource = dvPhieuNhapKho;
            lblHoaDon.Text = string.Format("Có {0} phiếu nhập hàng.", dtPhieuNhapKho.Rows.Count);
            if (dtPhieuNhapKho.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy kết quả, vui lòng điều chỉnh lại ngày khác.");
            
            if (cbLoc.SelectedIndex == 0)
            {
                foreach (DataRow row in dtPhieuNhapKho.Rows)
                {
                    DoDuLieuVaoBangSanPham(row);
                }
                
            }
        }

        private void dgvPhieuNhapKho_DataSourceChanged(object sender, EventArgs e)
        {

          EnableTextBox(dgvPhieuNhapKho.Rows.Count > 0);
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                e.Value = new Bitmap(e.Value.ToString());
            }
        }

        private void dgvSanPham_DataSourceChanged(object sender, EventArgs e)
        {
            
            
            
        }

        private void dgvSanPham_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CapNhatThongTinThongKe();
        }

        private void dgvSanPham_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CapNhatThongTinThongKe();
        }

        private void cbLoc_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtSanPham.Clear();
            if (cbLoc.SelectedIndex == 0)
            {
                foreach (DataRow row in dtPhieuNhapKho.Rows)
                {
                    DoDuLieuVaoBangSanPham(row);
                }
            }
        }

        private void dgvPhieuNhapKho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cbLoc.SelectedIndex == 0) return;
            dtSanPham.Clear();
            DoDuLieuVaoBangSanPham(dtPhieuNhapKho.Rows[e.RowIndex]);
            
        }



        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtMauSac_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInThongKeChiTietPNK frm = new frmInThongKeChiTietPNK(dtSanPham, dtpTuNgay.Value.ToString("dd/MM/yyyy"), dtpDenNgay.Value.ToString("dd/MM/yyyy"), lblTongTien.Text);
            frm.ShowDialog();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtSanPham.Clear();
            dtPhieuNhapKho.Clear();
            txtMauSac.Text = "";
            txtTenSP.Text = "";
            cbLoc.SelectedIndex = 0;
            EnableTextBox(false);
        }
    }
}
