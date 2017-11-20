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
using System.Data.SqlClient;

namespace QuanLyBanBalo
{
    public partial class frmNhapHang : Form
    {
        DataTable dtNhaCungCap, dtDanhMuc, dtSanPham;
        DataView dvSanPham;
        bool _KiemTraThayDoiTextBox = true;
        
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
            loadNhaCungCap();
            loadDanhMuc();
            loadSanPham();
            refreshDefault();
        }
        //setup


        //enable 
        private void showHoaDon(bool b)
        {
            cboNCC.Enabled = b;
            txtGhiChu.Enabled = b;
            btnLuuHoaDon.Enabled = b;
        }
        private void showSanPham(bool b)
        {
            txtTenSP.Enabled = b;
            txtKichCo.Enabled = b;
            txtThuongHieu.Enabled = b;
            txtNamBH.Enabled = b;
            cboMauMa.Enabled = b;
            txtChatLieu.Enabled = b;
            txtGiaBanLe.Enabled = b;
            txtGiaVon.Enabled = b;
            btnLuu.Enabled = b;
        }
        private void showChiTiet(bool b)
        {
            txtCTMauSac.Enabled = b;
            txtCTSoLuong.Enabled = b;
            btnLuuCT.Enabled = b;
        }
        private void showCtHoaDon(bool b)
        {
            btnHoanThanh.Enabled = b;
        }

        //refresh
        private void refreshDefault()
        {
            showHoaDon(true);
            showSanPham(false);
            showChiTiet(false);
            showCtHoaDon(false);
            refreshChiTiet();
            refreshHoaDon();
            refreshSanPham();
            //
            lbTongSoLuong.Text = 0.ToString();
            lbMaHoaDon.Text = null;
            btnThemMoiSP.Enabled = false;
        }
        private void refreshThongTin()
        {
            lbTongSoLuong.Text = 0.ToString();
            lbMaHoaDon.Text = null;
        }
        private void refreshHoaDon()
        {
            txtGhiChu.Text = "";
        }
        private void refreshSanPham()
        {
            txtTenSP.Text = null;
            txtKichCo.Text = null;
            txtThuongHieu.Text = null;
            txtNamBH.Text = null;
            txtChatLieu.Text = null;
            txtGiaBanLe.Text = null;
            txtGiaVon.Text = null;
        }
        private void refreshChiTiet()
        {
            txtCTMaSP.Text = null;
            txtCTTenSP.Text = null;
            txtCTMauSac.Text = null;
            txtCTSoLuong.Text = null;
            picHinhAnh.Image = null;
            picHinhAnh.ImageLocation = null;
        }


        private void loadNhaCungCap()
        {
            dtNhaCungCap = clsNhaCungCap_BUS.LayNCC();
            cboNCC.DataSource = dtNhaCungCap;
            cboNCC.ValueMember = "MaNhaCungCap";
            cboNCC.DisplayMember = "TenNhaCungCap";
        }
        private void loadDanhMuc()
        {
            dtDanhMuc = clsDanhMuc_BUS.LayTatCaDanhMuc();
            cboMauMa.DataSource = dtDanhMuc;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
        }
        private void loadSanPham()
        {
            dtSanPham = clsSanPham_BUS.LayBangSanPham();
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = dvSanPham;
        }

        private bool KiemTraTextBox()
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
        private void ShowLabel(bool b)
        {
            lblGiaVon.Visible = b;
            lblChatLieu.Visible = b;
            lblGiaBanLe.Visible = b;
            lblKichCo.Visible = b;
            lblTenSP.Visible = b;
            lblThuongHieu.Visible = b;
            lblNamBH.Visible = b;
        }
        private void ShowLabelCT(bool b)
        {
            lblCTMauSac.Visible = b;
            lblCTSoLuong.Visible = b;
        }

        private void ShowAfterCreateBill()
        {
            showHoaDon(false);
            showSanPham(true);
        }
        private void ShowAfterCreateProduct()
        {
            showChiTiet(true);
            showSanPham(false);
        }
        private void ShowAfterCreateDetail(bool b)
        {
            btnThemMoiSP.Enabled = b;
            btnHoanThanh.Enabled = b;
            btnLamMoi.Enabled = b;
            txtCTMauSac.Text = "";
            txtCTSoLuong.Text = "";
            picHinhAnh.Image = null;
            picHinhAnh.ImageLocation = null;
        }
        private void ShowAfterClickAddNew()
        {
            showSanPham(true);
            showChiTiet(false);
            refreshSanPham();
            refreshChiTiet();
        }

        private bool KiemTraTextBoxCT()
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
                            txtCTMaSP.Text = maSanPham;
                            txtCTTenSP.Text = txtTenSP.Text;
                            ShowAfterCreateProduct();
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
                        //Kiểm tra tồn tại màu 
                        if (clsChiTietSanPham_BUS.KiemTraTonTaiMau(txtCTMaSP.Text, txtCTMauSac.Text.Trim()))
                        {
                            //Lấy số lượng sản phẩm
                            int SoLuong = 0;
                            int SoLuongSanPhamCu = 0;
                            SqlDataReader dr =  clsChiTietSanPham_BUS.LayChiTiet(txtCTMaSP.Text, txtCTMauSac.Text.Trim());
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    SoLuong = int.Parse(dr["SoLuong"].ToString());
                                    SoLuongSanPhamCu = int.Parse(dr["SoLuong"].ToString());
                                }
                            }

                            SoLuong += int.Parse(txtCTSoLuong.Text);
                            //Màu đã tồn tại ==> cập nhật số lượng
                            clsChiTietSP_DTO chiTietSanPham = new clsChiTietSP_DTO(txtCTMaSP.Text, txtCTMauSac.Text.Trim(), SoLuong);
                            object resultCapNhat = clsChiTietSanPham_BUS.CapNhatSoLuong(chiTietSanPham);
                            if (resultCapNhat is bool || (bool)resultCapNhat)
                            {
                                lbTongSoLuong.Text = (int.Parse(txtCTSoLuong.Text) + int.Parse(lbTongSoLuong.Text)).ToString();
                                MessageBox.Show(string.Format("Thêm sản phẩm thành công \n Số lượng sản phẩm cũ trong kho: {0}  \n Số lượng sản phẩm sau khi thêm: {1} ", SoLuongSanPhamCu,SoLuong), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowAfterCreateDetail(true);
                        }
                        }
                        else
                        {
                            // Lưu ảnh vào database 
                            clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(picHinhAnh.ImageLocation, clsHinhAnh_DTO.LoaiHinhAnh.Product);
                            object resultHinhAnh = clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);
                            if (resultHinhAnh is bool)
                            {
                                //Thêm mới chi tiết
                                clsChiTietSP_DTO chiTietSanPham = new clsChiTietSP_DTO(txtCTMaSP.Text, Helper.GetTimestamp(DateTime.Now), txtCTMauSac.Text, int.Parse(txtCTSoLuong.Text), hinhAnh.MaHinhAnh, 1);
                                object resultChiTietSP = clsChiTietSanPham_BUS.ThemChiTietSanPham(chiTietSanPham);
                                if (resultChiTietSP is bool || (bool)resultChiTietSP)
                                {
                                    // Copy image file vào folder data/product
                                    string fileName = Path.GetFileName(picHinhAnh.ImageLocation);
                                    string destPath = Directory.GetCurrentDirectory() + "\\data\\product\\" + fileName;
                                    File.Copy(picHinhAnh.ImageLocation, destPath, true);
                                    MessageBox.Show("Thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lbTongSoLuong.Text = (int.Parse(txtCTSoLuong.Text) + int.Parse(lbTongSoLuong.Text)).ToString() ;
                                ShowAfterCreateDetail(true);
                                }
                                else
                                {
                                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                        }
                        else
                        {
                            MessageBox.Show("Chưa thêm hình ảnh","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                       
                        }
                }
                catch (IOException msg)
                {
                    MessageBox.Show(msg.ToString());
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //txtCTMaSP.Text = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex].Cells["colMaSp"].Value.ToString();
            //txtCTTenSP.Text = dgvSanPham.Rows[dgvSanPham.CurrentCell.RowIndex].Cells["colTenSanPham"].Value.ToString();
            //setUpCapNhat(true);
            //setUpSanPham(false);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            try
            {
                //Lưu ChiTietNhapKho
                clsChiTietPhieuNhapKho_DTO chiTiet = new clsChiTietPhieuNhapKho_DTO(Helper.GetTimestamp(DateTime.Now), txtCTMaSP.Text, int.Parse(lbTongSoLuong.Text), lbMaHoaDon.Text);
                object resultChiTiet = clsChiTietPhieuNhapKho_BUS.ThemChiTietPhieuNhapKho(chiTiet);
                if (resultChiTiet is bool)
                {
                    if ((bool)(resultChiTiet))
                    {
                        MessageBox.Show("Đã lưu vào chi tiết hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshDefault();
                        
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi!! Vui lòng tạo mới hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnLamMoiSP_Click(object sender, EventArgs e)
        {
            try
            {
                //Lưu ChiTietNhapKho
                clsChiTietPhieuNhapKho_DTO chiTiet = new clsChiTietPhieuNhapKho_DTO(Helper.GetTimestamp(DateTime.Now), txtCTMaSP.Text, int.Parse(lbTongSoLuong.Text), lbMaHoaDon.Text);
                object resultChiTiet = clsChiTietPhieuNhapKho_BUS.ThemChiTietPhieuNhapKho(chiTiet);
                if (resultChiTiet is bool)
                {
                    if ((bool)(resultChiTiet))
                    {
                        MessageBox.Show("Đã lưu vào chi tiết hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbTongSoLuong.Text = 0.ToString();
                        btnThemMoiSP.Enabled = false;
                        ShowAfterClickAddNew();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi!! Vui lòng tạo mới hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnLamMOi_Click_1(object sender, EventArgs e)
        {
            refreshDefault();
        }

       

        private void dgvSanPham_DoubleClick_1(object sender, EventArgs e)
        {
            if (lbMaHoaDon.Text == "")
            {
                MessageBox.Show("Vui lòng tạo mới hóa đơn trước khi cập nhật sản phâm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                txtCTMaSP.Text = dgvSanPham.CurrentRow.Cells["colMaSp"].Value.ToString();
                txtCTTenSP.Text = dgvSanPham.CurrentRow.Cells["colTenSanPham"].Value.ToString();
                showChiTiet(true);
                showSanPham(false);
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
                //Lưu vào PhieuNhapKho
                string maPhieuNhapKho = Helper.GetTimestamp(DateTime.Now);
                clsPhieuNhapKho_DTO phieuNhapKho = new clsPhieuNhapKho_DTO(maPhieuNhapKho, Validation.LayMaNhanVien(), txtGhiChu.Text, DateTime.Now, 1, cboNCC.SelectedValue.ToString());
                object resultPhieuNhap = clsPhieuNhapKho_BUS.ThemPhieuNhapKho(phieuNhapKho);
                if(resultPhieuNhap is bool )
                {
                    if ((bool)(resultPhieuNhap))
                    {
                        //Thành công
                        lbMaHoaDon.Text = maPhieuNhapKho;
                        ShowAfterCreateBill();
                    }
                    else
                    {
                    MessageBox.Show("Thêm thất bại");
                    }
                }
                else
                {
                    MessageBox.Show((string)resultPhieuNhap);
                }
        }
    }
}

