﻿using System;
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
    public partial class frmMatHang : Form
    {
        private int MaDanhMuc;
        DataView dvDanhMuc;
        DataView dvSanPham;
        DataView dvMauMa;
        DataTable dtSanPham;
        DataTable dtMauMa;
        DataTable dtDanhMuc;
        DataRowView drvDanhMuc,drvTonKho;
        clsKhuyenMai_DTO khuyenMai;
        private static frmMatHang _Instance = null;
        public static frmMatHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmMatHang();
                return _Instance;
            }
        }
        public frmMatHang()
        {
            InitializeComponent();
        }

        public frmMatHang(clsKhuyenMai_DTO km)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Text = "CẬP NHẬT KHUYẾN MẠI";
            this.FormClosed -= frmMatHang_FormClosed;
            this.FormClosing -= frmMatHang_FormClosing;
            dgvSanPham.AllowUserToDeleteRows = false;
            dgvSanPham.DoubleClick -= dgvSanPham_DoubleClick;
            dgvSanPham.Columns["ApDungKM"].Visible = true;
            dgvSanPham.Columns["colTenKhuyenMai"].Visible = true;
            dgvSanPham.Columns["colMauSac"].Visible = false;
            dgvSanPham.Columns["colSoLuong"].Visible = false;
            dgvSanPham.Columns["colHinhAnh"].Visible = false;

            khuyenMai = km;
            grbDanhMuc.Visible = false;
            lblHDXoa.Visible = false;
            lblHDSua.Visible = false;
            cboApDung.Visible = true;
            grpThongTinKM.Visible = true;
            btnXacNhan.Visible = true;
            txtMauSac.Visible = false;
            lblMauSac.Visible = false;
            if (khuyenMai.NgayBatDau != null && khuyenMai.NgayKetThuc != null)
            {
                DateTime timeNow = DateTime.Now;
                DateTime ngayBatDau = km.NgayBatDau ?? timeNow;
                int result = DateTime.Compare(timeNow, ngayBatDau);
                if (result >= 0)
                {
                    DateTime ngayKetThuc = km.NgayKetThuc ?? DateTime.Now;
                    result = DateTime.Compare(timeNow, ngayKetThuc);
                    if (result <= 0)
                    {
                        khuyenMai = km;
                        lblTenCTKM.Text = string.Format("- {0}", km.TenKhuyenMai);
                        lblNgayKM.Text = string.Format("- Diễn ra từ ngày {0} đến hết ngày {1}", ngayBatDau.ToString("dd/MM/yyyy"), ngayKetThuc.ToString("dd/MM/yyyy"));

                        return;
                    }
                }
            }
            else
            {
                lblTenCTKM.Text = string.Format("- {0}", km.TenKhuyenMai);
                lblNgayKM.Text = "Không có thời hạn";
            }

        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            setUp();
            loadSanPham();
            loadMauMa();
            LoadDanhMuc();
            loadTonKho();
        }

        private void setUp()
        {
            //Ẩn cột Mã Sản Phẩm
            dgvSanPham.Columns["colMaSP"].Visible = false;
            //Ẩn cột Mã Sản Phẩm
            dgvSanPham.Columns["colMaCTSP"].Visible = false;

            //Autocomplete cho Chất liệu
            List<string> listThuongHieu = clsSanPham_BUS.LayThuongHieu();
            List<string> listChatLieu = clsSanPham_BUS.LayChatLieu();
            List<string> listTenSP = clsSanPham_BUS.LayTenSP();
            List<string> listMauSac = clsChiTietSanPham_BUS.LayMauSac();
            Helper.SetAutocomplete(txtThuongHieu, listThuongHieu.ToArray());
            Helper.SetAutocomplete(txtChatLieu, listChatLieu.ToArray());
            Helper.SetAutocomplete(txtTenSP, listTenSP.ToArray());
            Helper.SetAutocomplete(txtMauSac, listMauSac.ToArray());

        }
        private void loadSanPham(int i = 0)
        {
            dtSanPham = clsSanPham_BUS.LaySPTheoDK(i);
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = dvSanPham;
            lbDemSp.Text = string.Format("* Có {0} loại sản phẩm", dgvSanPham.Rows.Count);
        }
        private void loadMauMa()
        {
            dtMauMa = clsSanPham_BUS.LayTatCaMauMa();
            DataRow dr;
            dr = dtMauMa.NewRow();
            dr["TenDanhMuc"] = "Tất cả";
            dr["MaDanhMuc"] = 0;
            dtMauMa.Rows.InsertAt(dr, 0);
            dvMauMa = new DataView(dtMauMa);
            cboMauMa.DataSource = dvMauMa;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
        }

        private void loadTonKho()
        {
            DataRow dr;
            DataTable dtTonKho = new DataTable();
            dtTonKho.Clear();
            dtTonKho.Columns.Add("TenTonKho");
            dtTonKho.Columns.Add("MaTonKho");

            dr = dtTonKho.NewRow();
            dr["TenTonKho"] = "Tất cả";
            dr["MaTonKho"] = 0;
            dtTonKho.Rows.InsertAt(dr, 0);

            dr = dtTonKho.NewRow();
            dr["TenTonKho"] = "Sản phẩm còn hàng";
            dr["MaTonKho"] = 1;
            dtTonKho.Rows.InsertAt(dr, 1);

            dr = dtTonKho.NewRow();
            dr["TenTonKho"] = "Sản phẩm hết hàng";
            dr["MaTonKho"] = 2;
            dtTonKho.Rows.InsertAt(dr, 2);

            dr = dtTonKho.NewRow();
            dr["TenTonKho"] = "Sản phẩm đã xóa";
            dr["MaTonKho"] = -1;
            dtTonKho.Rows.InsertAt(dr, 3);

            DataView dvTonKho = new DataView(dtTonKho);
            cboTonKho.DataSource = dvTonKho;
            cboTonKho.ValueMember = "MaTonKho";
            cboTonKho.DisplayMember = "TenTonKho";
        }

        private void LoadDanhMuc()
        {
            txtTenDanhMuc.Text = "";
            btnThem.Enabled = true;
            dtDanhMuc = clsDanhMuc_BUS.LayTatCaDanhMuc();
            dvDanhMuc = new DataView(dtDanhMuc);
            dgvDanhMuc.AutoGenerateColumns = false;
            dgvDanhMuc.DataSource = dvDanhMuc;
            lbDemDanhMuc.Text = string.Format("Có {0} mẫu mã.", dgvDanhMuc.Rows.Count);
        }

        private bool KiemTraTextBox()
        {
            bool kiemtra = true;
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                kiemtra = false;
                lbTenDanhMuc.Visible = true;

            }
            return kiemtra;
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

            if (!string.IsNullOrWhiteSpace(txtThuongHieu.Text))
            {
                searchText += string.Format("ThuongHieu like '%{0}%' AND ", txtThuongHieu.Text);
            }
            else
            {
                searchText += "TRUE AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtChatLieu.Text))
            {
                searchText += string.Format("ChatLieu like '%{0}%' AND ", txtChatLieu.Text);
            }
            else
            {
                searchText += "TRUE AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtMauSac.Text))
            {
                searchText += string.Format("MauSac like '%{0}%' AND ", txtMauSac.Text);
            }
            else
            {
                searchText += "TRUE AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtGiaTu.Text))
            {
                double giaTu = double.Parse(txtGiaTu.Text.Trim(','));
                if (!string.IsNullOrWhiteSpace(txtGiaDen.Text))
                {


                    double giaDen = double.Parse(txtGiaDen.Text.Trim(','));
                    if (giaDen < giaTu)
                        searchText += string.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}' AND ", giaTu, 10000000000);
                    else
                        searchText += string.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}' AND ", giaTu, giaDen);
                }
                else
                {
                    searchText += string.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}' AND ", giaTu, 10000000000);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtGiaDen.Text))
                {
                    double giaDen = double.Parse(txtGiaDen.Text.Trim(','));
                    searchText += string.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}' AND ", 0, giaDen);
                }
                else
                {
                    searchText += "TRUE AND ";
                }

            }


            // Lấy danh mục qua rowview
            drvDanhMuc = (DataRowView)(cboMauMa.SelectedItem);
            string selectString = drvDanhMuc["TenDanhMuc"].ToString().Trim();
            if (selectString != "Tất cả")
            {
                searchText += string.Format("TenDanhMuc like '%{0}%'", selectString);

            }
            else
            {
                searchText += "TRUE";
            }

            dvSanPham.RowFilter = searchText;
            lbDemSp.Text = string.Format(" Có {0} loại sản phẩm", dgvSanPham.Rows.Count);
            cboApDung.Checked = false;

        }

        private void kiemTraGia()
        {
            if (string.IsNullOrWhiteSpace(txtGiaTu.Text)) return;
            if (string.IsNullOrWhiteSpace(txtGiaDen.Text))
            {
                txtGiaDen.Text = txtGiaTu.Text;
                return;
            }

            double giaTu = double.Parse(txtGiaTu.Text.Trim(','));
            double giaDen = double.Parse(txtGiaDen.Text.Trim(','));
            if (giaDen < giaTu)
            {
                txtGiaDen.Text = txtGiaTu.Text;
            }
        }

        private void dgvSanPham_DoubleClick(object sender, EventArgs e)
        {
            string idSanPham = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex].Cells["colMaSP"].Value.ToString();
            string idChiTiet = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex].Cells["colMaCTSP"].Value.ToString();
            frmSuaSanPham frm = new frmSuaSanPham(idSanPham, idChiTiet);
            frm.Show();
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            txtTenSP.Text = "";
            txtThuongHieu.Text = "";
            txtChatLieu.Text = "";
            txtMauSac.Text = "";
            cboMauMa.SelectedIndex = 0;
            txtGiaTu.Text = "";
            txtGiaDen.Text = "";
            loadSanPham();
        }
        private void dgvSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show(string.Format("Bạn có muốn xóa '{0}' không?",dgvSanPham.CurrentRow.Cells["colTenSP"].Value), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
                {
                    // lấy ra id chi tiet trong dgv
                    string idSanPham = dgvSanPham.CurrentRow.Cells["colMaCTSP"].Value.ToString();
                    if (clsSanPham_BUS.XoaSanPham(idSanPham) == 1)
                    {
                        MessageBox.Show("Xóa Thành Công");
                        loadSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại");
                    }
                }
            }
        }
        private void frmMatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }
        private void frmMatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }
        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvSanPham.Columns[e.ColumnIndex].Name == "colHinhAnh")
                {
                    e.Value = new Bitmap(e.Value.ToString());
                }
                if (dgvSanPham.Columns[e.ColumnIndex].Name == "colChongNuoc")
                {
                    if (e.Value != null)
                    {
                        if (bool.Parse(e.Value.ToString()) == true)
                        {
                            e.Value = "Có";
                        }
                        else
                        {
                            e.Value = "Không";
                        }
                    }
                }
               

            }
            catch (Exception)
            {

            }

        }
        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void txtThuongHieu_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void txtChatLieu_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        private void cboMauMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lbTenDanhMuc.Visible = false;
            if (KiemTraTextBox())
            {
                //kiểm tra tồn tại
                if (clsDanhMuc_BUS.KiemTraTonTaiTenDanhMuc(txtTenDanhMuc.Text))
                {
                    MessageBox.Show("Tên danh mục đã tồn tại, vui lòng chọn tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    clsDanhMuc_DTO dtoDanhMuc = new clsDanhMuc_DTO();
                    dtoDanhMuc.TenDanhMuc = txtTenDanhMuc.Text;
                    dtoDanhMuc.TrangThai = 1;
                    object resultDanhMuc = clsDanhMuc_BUS.ThemDanhMuc(dtoDanhMuc);
                    if (resultDanhMuc is bool || (bool)resultDanhMuc)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhMuc();
                        loadSanPham();
                        loadMauMa();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lbTenDanhMuc.Visible = false;
            if (KiemTraTextBox())
            {
                clsDanhMuc_DTO dtoDanhMuc = new clsDanhMuc_DTO();
                dtoDanhMuc.MaDanhMuc = MaDanhMuc;
                dtoDanhMuc.TenDanhMuc = txtTenDanhMuc.Text;
                object resultDanhMuc = clsDanhMuc_BUS.SuaDanhMuc(dtoDanhMuc);

                if (resultDanhMuc is bool || (bool)resultDanhMuc)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhMuc();
                    loadSanPham();
                    loadMauMa();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["colTenMauMa"].Value.ToString();
                MaDanhMuc = int.Parse(dgvDanhMuc.CurrentRow.Cells["colMaDanhMuc"].Value.ToString());
            }
        }

        private void dgvDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult rsl = MessageBox.Show(string.Format("Bạn có muốn xóa '{0}' không ?",dgvDanhMuc.CurrentRow.Cells["colTenMauMa"].Value), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (rsl == DialogResult.Yes)
                {
                    clsDanhMuc_DTO dtoDanhMuc = new clsDanhMuc_DTO();
                    dtoDanhMuc.MaDanhMuc = (int)dgvDanhMuc.CurrentRow.Cells["colMaDanhMuc"].Value;
                    object resultDanhMuc = clsDanhMuc_BUS.XoaDanhMuc(dtoDanhMuc);
                    if (resultDanhMuc is bool || (bool)resultDanhMuc)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhMuc();
                        loadSanPham();
                        loadMauMa();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtTenDanhMuc_TextChanged(object sender, EventArgs e)
        {
            dvDanhMuc.RowFilter = string.Format("TenDanhMuc like '%{0}%'", txtTenDanhMuc.Text);
            lbDemDanhMuc.Text = string.Format("Có {0} danh mục", dgvDanhMuc.Rows.Count);
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                btnSua.Enabled = false;
                btnThem.Enabled = true;
            }
        }

        private void txtMauSac_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtGiaTu_TextChanged(object sender, EventArgs e)
        {
            Helper.MoneyFormat(txtGiaTu);
            //kiemTraGia();
            Search();
        }

        private void txtGiaDen_TextChanged(object sender, EventArgs e)
        {
            Helper.MoneyFormat(txtGiaDen);
            Search();
        }

        private void txtGiaDen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        private void txtGiaTu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        private void txtGiaDen_Leave(object sender, EventArgs e)
        {
            //kiemTraGia();
        }

        private void cboApDung_CheckedChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                row.Cells["ApDungKM"].Value = cboApDung.Checked;
              
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dgvSanPham.Rows)
            {
                bool apDung = row.Cells["ApDungKM"].Value == null ? false : (bool)row.Cells["ApDungKM"].Value;
                string maSp = row.Cells["colMaSP"].Value.ToString();
                if (apDung)
                {
                    clsSanPham_BUS.CapNhatKhuyenMai(maSp, khuyenMai.MaKhuyenMai);
                }
            }

            Close();
        }

        private void cboTonKho_SelectionChangeCommitted(object sender, EventArgs e)
        {
            drvTonKho = (DataRowView)(cboTonKho.SelectedItem);
            int maTonKho = int.Parse(drvTonKho["MaTonKho"].ToString());
            loadSanPham(maTonKho);
        }

        private void dgvDanhMuc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            if (e.RowIndex >= 0)
            {
                txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["colTenMauMa"].Value.ToString();
                MaDanhMuc = int.Parse(dgvDanhMuc.CurrentRow.Cells["colMaDanhMuc"].Value.ToString());
            }
        }

        
    }
}
