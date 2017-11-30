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
    public partial class frmKhuyenMai : Form
    {
        private DataView dvKhuyenMai;
        private int _maKhuyenMai;
        public frmKhuyenMai()
        {
            InitializeComponent();
            CaiDat();
            LoadKhuyenMai();
        }

        private static frmKhuyenMai _Instance = null;

        public static frmKhuyenMai Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmKhuyenMai();
                return _Instance;
            }
        }

        private void CaiDat()
        {
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            lblMoTa.Visible = false;
            lblTenCTKM.Visible = false;
        }


        private void LoadKhuyenMai()
        {
            DataTable dt = clsKhuyenMai_BUS.LayBangKhuyenMai();
            dvKhuyenMai = new DataView(dt);
            dgvKhuyenMai.DataSource = dvKhuyenMai;
            dgvKhuyenMai.AutoGenerateColumns = false;
        }

        private bool KiemTraTextbox()
        {
            bool hopLe = true;
            if (string.IsNullOrWhiteSpace(txtTenCTKM.Text))
            {
                lblTenCTKM.Visible = true;
                hopLe = false;
            }

            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                lblMoTa.Visible = true;
                hopLe = false;


            }

            return hopLe;
        }

        private void LamMoi()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            txtMoTa.Text = "";
            txtTenCTKM.Text = "";
            ckbGioiHanTG.Checked = false;
            rdbThuCong.Checked = true;
            lblMoTa.Text = "";
            lblTenCTKM.Text = "";
        }

        private void CapNhatKM(int maKM)
        {
            if (rdbApDungSP.Checked)
            {
               clsSanPham_BUS.CapNhatKhuyenMai(maKM);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ckbGioiHanTG_CheckedChanged(object sender, EventArgs e)
        {
            grpThoiGian.Enabled = ckbGioiHanTG.Checked;
        }

        private void rdbApDungSP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvKhuyenMai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "ApDungHD")
            {
                e.Value = ((bool)e.Value) ? "Có" : "Không";
            }

            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "NgayBatDau")
            {
                e.Value = string.IsNullOrWhiteSpace(e.Value.ToString()) ? "Vô hạn" : e.Value;
            }

            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "NgayKetThuc")
            {
                e.Value = string.IsNullOrWhiteSpace(e.Value.ToString()) ? "Vô hạn" : e.Value;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraTextbox()) return;
            clsKhuyenMai_DTO khuyenMai;
            if(ckbGioiHanTG.Checked)
            {
                 khuyenMai = new clsKhuyenMai_DTO(txtTenCTKM.Text, txtMoTa.Text, rdbApDungHD.Checked, dtpTuNgay.Value, dtpDenNgay.Value);
            } else
            {
                khuyenMai = new clsKhuyenMai_DTO(txtTenCTKM.Text, txtMoTa.Text, rdbApDungHD.Checked);
            }

            bool result = clsKhuyenMai_BUS.Them(khuyenMai);
            if (result)
            {
                MessageBox.Show("Thêm thành công.");
                LoadKhuyenMai();
                CapNhatKM(khuyenMai.MaKhuyenMai);
                LamMoi();
            } else
            {
                MessageBox.Show("Thêm thất bại.");
            }
        }

        private void dgvKhuyenMai_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KiemTraTextbox()) return;
            clsKhuyenMai_DTO khuyenMai;
            if (ckbGioiHanTG.Checked)
            {
                khuyenMai = new clsKhuyenMai_DTO(txtTenCTKM.Text, txtMoTa.Text, rdbApDungHD.Checked, dtpTuNgay.Value, dtpDenNgay.Value,1,_maKhuyenMai);
            }
            else
            {
                khuyenMai = new clsKhuyenMai_DTO(txtTenCTKM.Text, txtMoTa.Text, rdbApDungHD.Checked,null,null,1,_maKhuyenMai);
            }

            

            bool result = clsKhuyenMai_BUS.Sua(khuyenMai);

            if (result)
            {
                MessageBox.Show("Sửa thành công.");
                LoadKhuyenMai();
                CapNhatKM(khuyenMai.MaKhuyenMai);
                LamMoi();

            }
            else
                MessageBox.Show("Sửa thất bại.");

        }

        private void dgvKhuyenMai_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void dgvKhuyenMai_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
                {
                    // lấy ra id chi tiet trong dgv
                    int maKhuyenMai = (int)dgvKhuyenMai.CurrentRow.Cells["MaKhuyenMai"].Value;
                    if(maKhuyenMai == 4)
                    {
                        // Khong the xoa Mac dinh
                        MessageBox.Show("Không thể xóa Loại khuyến mại mặc định.","Thông báo");
                        return;
                    }
                    clsSanPham_BUS.CapNhatKhuyenMai(maKhuyenMai, 4); // Cập nhật lại mã km mặc định cho các sản phẩm có mã KM cần xóa
                    if (clsKhuyenMai_BUS.Xoa(maKhuyenMai))
                    {
                        MessageBox.Show("Xóa Thành Công");
                        LamMoi();
                        LoadKhuyenMai();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại");
                    }
                }
            }
        }

        private void dgvKhuyenMai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            _maKhuyenMai = int.Parse(dgvKhuyenMai.CurrentRow.Cells["MaKhuyenMai"].Value.ToString());
            txtTenCTKM.Text = dgvKhuyenMai.CurrentRow.Cells["TenKhuyenMai"].Value.ToString();
            txtMoTa.Text = dgvKhuyenMai.CurrentRow.Cells["MoTa"].Value.ToString();
            rdbApDungHD.Checked = (bool)dgvKhuyenMai.CurrentRow.Cells["ApDungHD"].Value;
            rdbThuCong.Checked = !(bool)dgvKhuyenMai.CurrentRow.Cells["ApDungHD"].Value;

            ckbGioiHanTG.Checked = !string.IsNullOrWhiteSpace(dgvKhuyenMai.CurrentRow.Cells["NgayBatDau"].Value.ToString());
            if (ckbGioiHanTG.Checked)
            {
                dtpTuNgay.Value = DateTime.Parse(dgvKhuyenMai.CurrentRow.Cells["NgayBatDau"].Value.ToString());
                dtpDenNgay.Value = DateTime.Parse(dgvKhuyenMai.CurrentRow.Cells["NgayKetThuc"].Value.ToString());
            }

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void txtMoTa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }
    }
}
