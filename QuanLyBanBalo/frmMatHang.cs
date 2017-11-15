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
namespace QuanLyBanBalo
{
    public partial class frmMatHang : Form
    {
        DataView dvSanPham;
        DataView dvDanhMuc;
        DataTable dtSanPham;
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
            dtDanhMuc = clsSanPham_BUS.LayTatCaMauMa();
            DataRow dr;
            dr = dtDanhMuc.NewRow();
            dr["TenDanhMuc"] = "Tất cả";
            dr["MaDanhMuc"] = 0;
            dtDanhMuc.Rows.InsertAt(dr,0);
            dvDanhMuc = new DataView(dtDanhMuc);
            cboMauMa.DataSource = dvDanhMuc;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
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





    }
}
