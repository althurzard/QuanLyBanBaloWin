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
        clsSanPham_BUS bus = new clsSanPham_BUS();

        DataView dvSanPham;
        DataView dvDanhMuc;
        DataTable dtSanPham;
        DataTable dtDanhMuc;
        DataRowView drvDanhMuc;
        private static frmMatHang _Instance = null;
        public frmMatHang()
        {
            InitializeComponent();
        }
        private void frmMatHang_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadMauMa();
        }
        private void loadSanPham()
        {
            dtSanPham = bus.LayTatCaSanPham();
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = dvSanPham;
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

       private void loadMauMa()
       {
            dtDanhMuc = bus.LayTatCaDanhMuc();
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

        public static frmMatHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmMatHang();
                return _Instance;
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

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("MaSP like '%{0}%'", txtMaSP.Text);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("TenSP like '%{0}%'", txtTenSP.Text);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void txtThuongHieu_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("ThuongHieu like '%{0}%'", txtThuongHieu.Text);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void txtChatLieu_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("ChatLieu like '%{0}%'", txtChatLieu.Text);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void cboMauMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectString;
            drvDanhMuc = (DataRowView)(cboMauMa.SelectedItem);
            selectString = drvDanhMuc["TenDanhMuc"].ToString();
            if(selectString =="Tất cả")
            {
                dvSanPham.RowFilter = "";
            }
            else
            {
                dvSanPham.RowFilter = string.Format("TenDanhMuc like '%{0}%'", selectString);
                lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
            }
        }

        private void rdGia1_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}'",0,500000);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void rdGia2_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}'", 500000, 1000000);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void rdGia3_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= '{0}' and GiaBanLe <= '{1}'", 1000000, 2000000);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void rdGia4_CheckedChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = String.Format("GiaBanLe >= {0} ",2000000);
            lbDemSp.Text = string.Format("* Có {0} sản phẩm", dgvSanPham.Rows.Count);
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
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
    }
}
