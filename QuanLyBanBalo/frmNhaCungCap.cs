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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        private static frmNhaCungCap _Instance = null;
        private static string MaNhaCungCap;
        DataView dvNCC;
        DataTable dtNCC;



        public static frmNhaCungCap Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmNhaCungCap();
                return _Instance;
            }
        }
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            CaiDat();
            LoadNCC();
        }

        private void CaiDat()
        {
            lbTenNCC.Visible = false;
            lbSDT.Visible = false;
            lbPic.Visible = false;
            lbDiaChi.Visible = false;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtTenNCC.Text = "";
            picHinhAnh.Image = null;
        }
        private void LoadNCC()
        {
            dtNCC = clsNhaCungCap_BUS.LayNCC();
            dvNCC = new DataView(dtNCC);
            dgvDanhSachNCC.AutoGenerateColumns = false;
            dgvDanhSachNCC.DataSource = dvNCC;
        }
        private void frmNhaCungCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void dgvDanhSachNCC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvDanhSachNCC.Columns[e.ColumnIndex].Name == "colHinhAnh")
                {
                    e.Value = Bitmap.FromFile(e.Value.ToString());
                }
            }
            catch(Exception)
            {
               
            }
        }

        private void dgvDanhSachNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            MaNhaCungCap = dgvDanhSachNCC.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvDanhSachNCC.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvDanhSachNCC.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSDT.Text = dgvDanhSachNCC.Rows[e.RowIndex].Cells[4].Value.ToString();
            picHinhAnh.ImageLocation = dgvDanhSachNCC.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            CaiDat();
        }
        private void HienLabel(bool i)
        {
            lbDiaChi.Visible = i;
            lbPic.Visible = i;
            lbSDT.Visible = i;
            lbTenNCC.Visible = i;
        }
        private bool KiemTraTextBox()
        {
            bool hople = true;
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                hople = false;
                lbTenNCC.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                hople = false;
                lbSDT.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                hople = false;
                lbDiaChi.Visible = true;
            }
            if(picHinhAnh.Image == null)
            {
                hople = false;
                lbPic.Visible = true;
            }
            return hople;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            HienLabel(false);

            if (KiemTraTextBox())
            {
                try
                {
                    if (clsNhaCungCap_BUS.KiemTraTonTaiTenNCC(txtTenNCC.Text))
                    {
                        MessageBox.Show("Tên nhà cung cấp đã tồn tại \nVui lòng chọn tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtTenNCC.Text = "";
                    }
                    else
                    {
                        // Lưu ảnh vào database 
                        clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(picHinhAnh.ImageLocation, clsHinhAnh_DTO.LoaiHinhAnh.Avatar);
                        object MaHinhAnh = clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);
                        if (MaHinhAnh is int)
                        {

                            clsNhaCungCap_DTO dtoNcc = new clsNhaCungCap_DTO();
                            dtoNcc.MaNhaCungCap = Helper.GetTimestamp(DateTime.Now);
                            dtoNcc.TenNhaCungCap = txtTenNCC.Text;
                            dtoNcc.DiaChi = txtDiaChi.Text;
                            dtoNcc.SoDienThoai = int.Parse(txtSDT.Text);
                            dtoNcc.TrangThai = 1;
                            dtoNcc.MaHinhAnh = int.Parse(MaHinhAnh.ToString());
                            object KqThem = clsNhaCungCap_BUS.ThemNhaCungCap(dtoNcc);
                            if (KqThem is bool)
                            {
                                // Copy image file vào folder data/avatar
                                string fileName = Path.GetFileName(picHinhAnh.ImageLocation);
                                string destPath = Directory.GetCurrentDirectory() + "\\data\\avatar\\" + fileName;
                                File.Copy(picHinhAnh.ImageLocation, destPath, true);
                                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadNCC();
                                CaiDat();
                            }
                            else
                            {
                                MessageBox.Show("Thêm thất bại! \nVui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hình ảnh không hợp lệ vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi \n Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = Helper.layHinhAnh();
            if (filePath != null)
            {
                picHinhAnh.ImageLocation = filePath;
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }
    }
}
