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
using System.IO;

namespace QuanLyBanBalo
{
    public partial class frmNhapHang : Form
    {
        DataTable dtNhaCungCap;
        DataTable dtDanhMuc;
        bool _KiemTraThayDoiTextBox = true;
        int _TongSanPham = 0;
        public frmNhapHang()
        {
            InitializeComponent();
        }
        private static frmNhapHang _Instance = null;

        public static frmNhapHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmNhapHang();
                return _Instance;
            }
        }
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            RefreshDefault();
            loadNhaCungCap();
            loadDanhMuc();
        }

        //khôi phục về mặc đinh
        public void RefreshDefault()
        {
            txtCTMaSP.Enabled = false;
            txtCTMauSac.Enabled = false;
            txtCTSoLuong.Enabled = false;
            btnLuuCT.Enabled = false;
            rdCo.Checked = true;
            txtTenSP.Text = "";
            txtKichCo.Text = "";
            txtThuongHieu.Text = "";
            txtNamBH.Text = "";
            txtChatLieu.Text = "";
            txtGiaBanLe.Text = "";
            txtGiaVon.Text = "";
            txtCTTenSP.Text = "";
            txtCTMaSP.Text = "";
            txtGhiChu.Text = "";
            RefreshChiTiet();
            SetUpHoaDon(false);
        }

        //Hiện chi tiết sau khi thêm sản phẩm
        public void SetUpChiTiet(string maSanPham)
        {
            txtCTMaSP.Text = maSanPham;
            txtCTTenSP.Text = txtTenSP.Text;
            txtCTMauSac.Enabled = true;
            txtCTSoLuong.Enabled = true;
            btnLuuCT.Enabled = true;
        }

        //Hiện hóa đơn sau khi thêm chi tiết
        public void SetUpHoaDon(bool show)
        {
            txtGhiChu.Enabled = show;
            cboNCC.Enabled = show;
            btnLuuHoaDon.Enabled = show;
        }

        //refresh sau khi them 1 chi tiet
        public void RefreshChiTiet()
        {
            txtCTMauSac.Text = "";
            txtCTSoLuong.Text = "";
            picHinhAnh.Image = null;
        }

        public void loadNhaCungCap()
        {
            dtNhaCungCap = clsNhaCungCap_BUS.LayNCC();
            cboNCC.DataSource = dtNhaCungCap;
            cboNCC.ValueMember = "MaNhaCungCap";
            cboNCC.DisplayMember = "TenNhaCungCap";
        }
        public void loadDanhMuc()
        {
            dtDanhMuc = clsDanhMuc_BUS.LayTatCaDanhMuc();
            cboMauMa.DataSource = dtDanhMuc;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
        }
        public bool KiemTraTextBox()
        {
            bool hople = true;

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                hople = false;
                lblTenSP.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtThuongHieu.Text))
            {
                hople = false;
                lblThuongHieu.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtKichCo.Text))
            {
                hople = false;
                lblKichCo.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtNamBH.Text))
            {
                hople = false;
                lblNamBH.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtChatLieu.Text))
            {
                hople = false;
                lblChatLieu.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtGiaBanLe.Text))
            {
                hople = false;
                lblGiaBanLe.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtGiaVon.Text))
            {
                hople = false;
                lblGiaVon.Visible = true;
            }
            
            return hople;
        }
        public void ShowLabel(bool b)
        {
            lblGiaVon.Visible = b;
            lblChatLieu.Visible = b;
            lblGiaBanLe.Visible = b;
            lblKichCo.Visible = b;
            lblTenSP.Visible = b;
            lblThuongHieu.Visible = b;
            lblNamBH.Visible = b;
           
        }
        public void ShowLabelCT(bool b)
        {
            lblCTMauSac.Visible = b;
            lblCTSoLuong.Visible = b;
            lblImage.Visible = b;
        }
        public bool KiemTraTextBoxCT()
        {
            bool hople = true;
            if (string.IsNullOrWhiteSpace(txtCTMauSac.Text))
            {
                lblCTMauSac.Visible = true;
                hople = false;
            }
            if (string.IsNullOrWhiteSpace(txtCTSoLuong.Text))
            {
                lblCTSoLuong.Visible = true;
                hople = false;
            }
            if (string.IsNullOrWhiteSpace(picHinhAnh.ImageLocation))
            {
                hople = false;
                lblImage.Visible = true;
            }
            return hople;
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            ShowLabel(false);
            if (KiemTraTextBox())
            {
                //kiểm tra trùng tên sp
                if (clsSanPham_BUS.KiemTraTrungSanPham(txtTenSP.Text))
                {
                    MessageBox.Show("Sản phẩm đã tồn tại, vui lòng kiểm tra lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    try
                    {
                        bool chongNuoc = (rdCo.Checked) ? true : false;
                        int maDanhMuc = int.Parse(cboMauMa.SelectedValue.ToString());
                        string maSanPham = Helper.GetTimestamp(DateTime.Now);
                        clsSanPham_DTO sanPham = new clsSanPham_DTO(maSanPham, txtTenSP.Text, txtThuongHieu.Text, txtChatLieu.Text, decimal.Parse(txtGiaVon.Text), decimal.Parse(txtGiaBanLe.Text), chongNuoc, float.Parse(txtKichCo.Text), maDanhMuc, int.Parse(txtNamBH.Text));
                        object resultSanPham = clsSanPham_BUS.ThemSanPham(sanPham);
                        if (resultSanPham is bool || (bool)resultSanPham)
                        {
                            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SetUpChiTiet(maSanPham);
                        }
                        else
                        {
                            MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập không chính xác, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }
        }

        private void txtGiaBanLe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_KiemTraThayDoiTextBox)
                {
                    string strTemp = txtGiaBanLe.Text;
                    //kiểm tra chuỗi có trống không
                    if (String.IsNullOrEmpty(strTemp)) return;

                    //tìm vị trí dấu chấm trong text box
                    int iIndex = strTemp.IndexOf('.');

                    //nếu tìm thấy 
                    if (iIndex != -1)
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {

                        }
                    }

                    double DinhDangTien = double.Parse(txtGiaBanLe.Text.Trim(','));
                    _KiemTraThayDoiTextBox = false;
                    //Định dạng lại textbox
                    txtGiaBanLe.Text = DinhDangTien.ToString("0,00.##");
                }
                else
                {
                    _KiemTraThayDoiTextBox = true;
                    //Đưa vị trí con trỏ ra cuối chuỗi
                    txtGiaBanLe.Select(txtGiaBanLe.TextLength, 0);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi không biết");
            }
        }

     

        private void frmNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmNhapHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            ShowLabelCT(false);
            if (KiemTraTextBoxCT())
            {
                try
                {
                    // Lưu ảnh vào database 
                    clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(picHinhAnh.ImageLocation, clsHinhAnh_DTO.LoaiHinhAnh.Product);
                    object resultHinhAnh = clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);
                    if (resultHinhAnh is bool)
                    {
                        //Lưu chi tiết sản phẩm
                        clsChiTietSP_DTO chiTietSanPham = new clsChiTietSP_DTO(txtCTMaSP.Text, Helper.GetTimestamp(DateTime.Now), txtCTMauSac.Text, int.Parse(txtCTSoLuong.Text), hinhAnh.MaHinhAnh, 1);
                        object resultChiTietSP = clsChiTietSanPham_BUS.ThemChiTietSanPham(chiTietSanPham);
                        if (resultChiTietSP is bool || (bool)resultChiTietSP)
                        {
                            // Copy image file vào folder data/product
                            string fileName = Path.GetFileName(picHinhAnh.ImageLocation);
                            string destPath = Directory.GetCurrentDirectory() + "\\data\\product\\" + fileName;
                            File.Copy(picHinhAnh.ImageLocation, destPath, true);
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _TongSanPham += int.Parse(txtCTSoLuong.Text);
                            RefreshChiTiet();
                            SetUpHoaDon(true);
                            
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

      

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            string filePath = Helper.layHinhAnh();
            if (filePath != null)
            {
                //kiemTraThayDoiPic = true;
                picHinhAnh.ImageLocation = filePath;
            }
        }



        private void txtGiaVon_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (_KiemTraThayDoiTextBox)
                {
                    string strTemp = txtGiaVon.Text;
                    //kiểm tra chuỗi có trống không
                    if (String.IsNullOrEmpty(strTemp)) return;

                    //tìm vị trí dấu chấm trong text box
                    int iIndex = strTemp.IndexOf('.');

                    //nếu tìm thấy 
                    if (iIndex != -1)
                    {
                        string strT = strTemp.Substring(iIndex + 1, 1);
                        if (!String.IsNullOrEmpty(strT))
                        {

                        }
                    }

                    double DinhDangTien = double.Parse(txtGiaVon.Text.Trim(','));
                    _KiemTraThayDoiTextBox = false;
                    //Định dạng lại textbox
                    txtGiaVon.Text = DinhDangTien.ToString("0,00.##");
                }
                else
                {
                    _KiemTraThayDoiTextBox = true;
                    //Đưa vị trí con trỏ ra cuối chuỗi
                    txtGiaVon.Select(txtGiaVon.TextLength, 0);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi không biết");
            }
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {

            if (_TongSanPham != 0)
            {
                //Lưu vào PhieuNhapKho
                string maPhieuNhapKho = Helper.GetTimestamp(DateTime.Now);
                clsPhieuNhapKho_DTO phieuNhapKho = new clsPhieuNhapKho_DTO(maPhieuNhapKho, Validation.LayMaNhanVien(), txtGhiChu.Text, DateTime.Now, 1, cboNCC.SelectedValue.ToString());
                object resultPhieuNhap = clsPhieuNhapKho_BUS.ThemPhieuNhapKho(phieuNhapKho);
                if(resultPhieuNhap is bool || (bool)(resultPhieuNhap))
                {
                    //Lưu ChiTietNhapKho
                    clsChiTietPhieuNhapKho_DTO chiTiet = new clsChiTietPhieuNhapKho_DTO(Helper.GetTimestamp(DateTime.Now), txtCTMaSP.Text, _TongSanPham, maPhieuNhapKho);
                    object resultChiTiet = clsChiTietPhieuNhapKho_BUS.ThemChiTietPhieuNhapKho(chiTiet);
                    if(resultChiTiet is bool || (bool)(resultChiTiet))
                    {
                        MessageBox.Show("Thêm hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _TongSanPham = 0;
                        RefreshDefault();
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập chi tiết");
            }
        }
    }
}
