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
    public partial class frmDanhMuc : Form
    {
        private static frmDanhMuc _Instance =null;
        private DataTable dtDanhMuc;
        private DataView dvDanhMuc;
        private int MaDanhMuc;
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        public static frmDanhMuc Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmDanhMuc();
                return _Instance;
            }
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }

        private void LoadDanhMuc()
        {
            txtTenDanhMuc.Text = "";
            btnThem.Enabled = true;
            dtDanhMuc = clsDanhMuc_BUS.LayTatCaDanhMuc();
            dvDanhMuc = new DataView(dtDanhMuc);
            dgvDanhMuc.AutoGenerateColumns = false;
            dgvDanhMuc.DataSource = dvDanhMuc;
            lbDemDanhMuc.Text = string.Format("* Có {0} danh mục", dgvDanhMuc.Rows.Count);
        }

        private void frmDanhMuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmDanhMuc_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
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

        //Thêm danh mục
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
                    if(resultDanhMuc is bool || (bool)resultDanhMuc)
                    {
                        MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        LoadDanhMuc();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            if(e.RowIndex != -1)
            {
                txtTenDanhMuc.Text = dgvDanhMuc.Rows[e.RowIndex].Cells[1].Value.ToString();
                MaDanhMuc = int.Parse(dgvDanhMuc.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        //Sửa danh mục
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
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        
        }

        private void dgvDanhMuc_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode  == Keys.Delete)
            {
                if(DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
                {
                    clsDanhMuc_DTO dtoDanhMuc = new clsDanhMuc_DTO();
                    dtoDanhMuc.MaDanhMuc = MaDanhMuc;
                    object resultDanhMuc = clsDanhMuc_BUS.XoaDanhMuc(dtoDanhMuc);
                    if (resultDanhMuc is bool || (bool)resultDanhMuc)
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhMuc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void txtTKTenDanhMuc_TextChanged(object sender, EventArgs e)
        {
            dvDanhMuc.RowFilter = string.Format("TenDanhMuc like '%{0}%'", txtTKTenDanhMuc.Text);
            lbDemDanhMuc.Text = string.Format("* Có {0} danh mục", dgvDanhMuc.Rows.Count);
        }

        private void txtTKMaDanhMuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled =  !Validation.IsNumberic(e);
        }
    }
}
