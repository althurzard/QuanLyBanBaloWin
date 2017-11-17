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
    public partial class frmMatHang : Form
    {
        private int MaDanhMuc;
        DataView dvDanhMuc;
        DataView dvSanPham;
        DataView dvMauMa;
        DataTable dtSanPham;
        DataTable dtMauMa;
        DataTable dtDanhMuc;
        DataRowView drvDanhMuc;
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

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            setUp();
            loadSanPham();
            loadMauMa();
            LoadDanhMuc();
        }

        private void setUp()
        {
            //Ẩn cột Mã Sản Phẩm
            dgvSanPham.Columns["colMaSP"].Visible = false;
            //Ẩn cột Mã Sản Phẩm
            dgvSanPham.Columns["colMaCTSP"].Visible = false;
        }
        private void loadSanPham()
        {
            dtSanPham = clsSanPham_BUS.LayTatCaSanPham();
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = dvSanPham;
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }
        private void loadMauMa()
        {
            dtMauMa = clsSanPham_BUS.LayTatCaMauMa();
            DataRow dr;
            dr = dtMauMa.NewRow();
            dr["TenDanhMuc"] = "Tất cả";
            dr["MaDanhMuc"] = 0;
            dtMauMa.Rows.InsertAt(dr,0);
            dvMauMa = new DataView(dtMauMa);
            cboMauMa.DataSource = dvMauMa;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
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

        private void dgvSanPham_DoubleClick(object sender, EventArgs e)
        {
            string idSanPham = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string idChiTiet = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex].Cells[1].Value.ToString();
            frmSuaSanPham frm = new frmSuaSanPham(idSanPham,idChiTiet);
            frm.Show();
        }
        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            txtTenSP.Text = "";
            txtThuongHieu.Text = "";
            txtChatLieu.Text = "";
            cboMauMa.SelectedIndex = 0;
            rdGia1.Checked = false;
            rdGia2.Checked = false;
            rdGia3.Checked = false;
            rdGia4.Checked = false;
            loadSanPham();
        }
        private void dgvSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
                {
                    // lấy ra id chi tiet trong dgv
                    string idSanPham = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex].Cells[1].Value.ToString();
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
                if (dgvSanPham.Columns[e.ColumnIndex].Name =="colChongNuoc")
                {           if (e.Value != null)
                    {
                        if(bool.Parse(e.Value.ToString()) == true)
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
            catch(Exception)
            {

            }
            
        }
        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("TenSP like '%{0}%'", txtTenSP.Text);
            lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }
        private void txtThuongHieu_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("ThuongHieu like '%{0}%'", txtThuongHieu.Text);
            lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }
        private void txtChatLieu_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("ChatLieu like '%{0}%'", txtChatLieu.Text);
            lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }
        private void cboMauMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectString;
            // Lấy danh mục qua rowview
            drvDanhMuc = (DataRowView)(cboMauMa.SelectedItem);
            selectString = drvDanhMuc["TenDanhMuc"].ToString();
            if(selectString =="Tất cả")
            {
                dvSanPham.RowFilter = "";
                lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
            }
            else
            {
                dvSanPham.RowFilter = string.Format("TenDanhMuc like '%{0}%'", selectString);
                lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
            }
        }
        private void rdGia1_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}'",0,500000);
            lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }
        private void rdGia2_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}'", 500000, 1000000);
            lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }
        private void rdGia3_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}'", 1000000, 2000000);
            lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }
        private void rdGia4_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= {0} ",2000000);
            lbDemSp.Text = string.Format(" Có {0} sản phẩm", dgvSanPham.Rows.Count);
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
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
                {
                    clsDanhMuc_DTO dtoDanhMuc = new clsDanhMuc_DTO();
                    dtoDanhMuc.MaDanhMuc = MaDanhMuc;
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
    }
}
