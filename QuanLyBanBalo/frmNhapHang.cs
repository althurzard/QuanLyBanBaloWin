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
        DataTable dtNhaCungCap, dtDanhMuc, dtSanPham, dtSanPhamMoi;
        DataView dvSanPham, dvSanPhamMoi;
        bool _KiemTraThayDoiTextBox = true;
        bool _KiemTraThemChiTiet = false;
        private static frmNhapHang _Instance = null;

        public frmNhapHang()
        {
            InitializeComponent();
        }

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
            TaoCotDataTable();

            btnThemMoi.Enabled = false;
            EnableSanPham(true);
            EnableThongTinHD(false);
            EnableChiTiet(false);

            List<string> listTH = clsSanPham_BUS.LayThuongHieu();
            Helper.SetAutocomplete(txtThuongHieu, listTH.ToArray());

            List<string> listCL = clsSanPham_BUS.LayChatLieu();
            Helper.SetAutocomplete(txtChatLieu, listCL.ToArray());

            List<string> listMauSac = clsChiTietSanPham_BUS.LayMauSac();
            Helper.SetAutocomplete(txtCTMauSac, listMauSac.ToArray());

            List<string> listTenSP = clsSanPham_BUS.LayTenSP();
            Helper.SetAutocomplete(txtTenSP, listTenSP.ToArray());
        }

        //Load dữ liệu 
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
        //Validate
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

        //refresh
        private void RefreshChiTietSanPham()
        {
            txtCTMauSac.Text = null;
            txtCTSoLuong.Text = null;
            picHinhAnh.Image = null;
            picHinhAnh.ImageLocation = null;
        }
        private void RefreshHoaDon()
        {
            txtGhiChu.Text = null;
        }
        private void RefreshSanPham()
        {
            txtTenSP.Text = null;
            txtKichCo.Text = null;
            txtThuongHieu.Text = null;
            txtNamBH.Text = null;
            txtChatLieu.Text = null;
            txtGiaVon.Text = null;
            txtGiaBanLe.Text = null;
        }
        //enable and disable
        private void EnableSanPham(bool b)
        {
            txtTenSP.Enabled = b;
            txtKichCo.Enabled = b;
            txtThuongHieu.Enabled = b;
            txtNamBH.Enabled = b;
            cboMauMa.Enabled = b;
            txtChatLieu.Enabled = b;
            txtGiaVon.Enabled = b;
            txtGiaBanLe.Enabled = b;
            btnLuuSanPham.Enabled = b;
        }
        private void EnableChiTiet(bool b)
        {
            txtCTMauSac.Enabled = b;
            txtCTSoLuong.Enabled = b;
            picHinhAnh.Enabled = b;
            btnLuuCT.Enabled = b;
            picHinhAnh.Enabled = b;
        }
        private void EnableThongTinHD(bool b)
        {
            btnLuuCTHD.Enabled = b;
        }

        private void TaoCotDataTable()
        {
            dtSanPhamMoi = new DataTable();
            dtSanPhamMoi.Columns.Add("MaSp");
            dtSanPhamMoi.Columns.Add("TenSp");
            dtSanPhamMoi.Columns.Add("ThuongHieu");
            dtSanPhamMoi.Columns.Add("ChatLieu");
            dtSanPhamMoi.Columns.Add("GiaVon");
            dtSanPhamMoi.Columns.Add("GiaBanLe");
            dtSanPhamMoi.Columns.Add("ChongNuoc");
            dtSanPhamMoi.Columns.Add("TrongLuong");
            dtSanPhamMoi.Columns.Add("MaDanhMuc");
            dtSanPhamMoi.Columns.Add("NamBH");
            dvSanPhamMoi = new DataView(dtSanPhamMoi);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
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

                        string _maSanPhamMoi = Helper.GetTimestamp(DateTime.Now);
                        txtCTMaSP.Text = _maSanPhamMoi;
                        txtCTTenSP.Text = txtTenSP.Text;
                        bool chongNuoc = (rdCo.Checked) ? true : false;
                        int maDanhMuc = int.Parse(cboMauMa.SelectedValue.ToString());
                        DataRow dr = dtSanPhamMoi.NewRow();
                        dr["MaSp"] = _maSanPhamMoi;
                        dr["TenSp"] = txtTenSP.Text;
                        dr["ThuongHieu"] = txtThuongHieu.Text;
                        dr["ChatLieu"] = txtChatLieu.Text;
                        dr["GiaVon"] = txtGiaVon.Text.Replace(",", "");
                        dr["GiaBanLe"] = txtGiaBanLe.Text.Replace(",", "");
                        dr["ChongNuoc"] = chongNuoc;
                        dr["TrongLuong"] = txtKichCo.Text;
                        dr["MaDanhMuc"] = maDanhMuc;
                        dr["NamBH"] = txtNamBH.Text;
                        dtSanPhamMoi.Rows.Add(dr);

                        EnableSanPham(false);
                        EnableChiTiet(true);

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

        private void btnLuuCT_Click(object sender, EventArgs e)
        {

            ShowLabelCT(false);
            if (KiemTraTextBoxCT())
            {
                try
                {
                    //Kiểm tra tồn tại màu trong chitiet ==> nếu tồn tại ==> không cần thêm hình, 
                    if (clsChiTietSanPham_BUS.KiemTraTonTaiMau(txtCTMaSP.Text, txtCTMauSac.Text.Trim()))
                    {
                        //Lấy số lượng sản phẩm
                        int SoLuongSanPhamCu = 0;
                        string maChiTietSanPham = null;
                        string hinhAnh = null;

                        SqlDataReader dr = clsChiTietSanPham_BUS.LayChiTiet(txtCTMaSP.Text, txtCTMauSac.Text.Trim());
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                SoLuongSanPhamCu = int.Parse(dr["SoLuong"].ToString());
                                maChiTietSanPham = dr["MaCTSP"].ToString();
                                hinhAnh = dr["MaHinhAnh"].ToString();
                            }
                        }

                        //Kiễm tra đã tồn tại dòng trong dgv chưa ==> cập nhật số lượng
                        if (dgvHDSanPham.Rows.Count > 0)
                        {
                            bool found = false;
                            for (int i = 0; i < dgvHDSanPham.Rows.Count; i++)
                            {
                                //kiểm tra  sp và màu
                                if (dgvHDSanPham.Rows[i].Cells["colTenCTSP"].Value.ToString() == txtCTTenSP.Text && dgvHDSanPham.Rows[i].Cells["colMauSac"].Value.ToString() == txtCTMauSac.Text.ToString().Trim())
                                {
                                    found = true;
                                    dgvHDSanPham.Rows[i].Cells["colSoLuong"].Value = int.Parse(txtCTSoLuong.Text) + int.Parse(dgvHDSanPham.Rows[i].Cells["colSoLuong"].Value.ToString());
                                    RefreshChiTietSanPham();
                                    EnableThongTinHD(true);
                                    btnThemMoi.Enabled = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                //Lưu số lương mới vào dgv
                                dgvHDSanPham.Rows.Add(maChiTietSanPham, txtCTMaSP.Text, txtCTTenSP.Text, SoLuongSanPhamCu, txtCTSoLuong.Text, txtCTMauSac.Text, hinhAnh, txtGiaVon.Text);
                                RefreshChiTietSanPham();
                                EnableThongTinHD(true);
                                btnThemMoi.Enabled = true;
                            }
                        }
                        else
                        {
                            //Lưu số lương mới vào dgv
                            dgvHDSanPham.Rows.Add(maChiTietSanPham, txtCTMaSP.Text, txtCTTenSP.Text, SoLuongSanPhamCu, txtCTSoLuong.Text, txtCTMauSac.Text, hinhAnh,txtGiaVon.Text);
                            RefreshChiTietSanPham();
                            EnableThongTinHD(true);
                            btnThemMoi.Enabled = true;
                        }
                        //lbTongSoLuong.Text = (int.Parse(txtCTSoLuong.Text) + int.Parse(lbTongSoLuong.Text)).ToString();
                    }
                    // Nếu không tồn tại ==> phải chọn hình
                    else if (string.IsNullOrEmpty(picHinhAnh.ImageLocation))
                    {
                        MessageBox.Show("Chưa thêm hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //tao moi chi tiet
                        string maChiTietSanPhamMoi = Helper.GetTimestamp(DateTime.Now);

                        //Kiễm tra đã tồn tại dòng trong dgv chưa ==> cập nhật số lượng
                        if (dgvHDSanPham.Rows.Count > 0)
                        {
                            bool found = false;
                            for (int i = 0; i < dgvHDSanPham.Rows.Count; i++)
                            {
                                //kiểm tra  sp và màu
                                if (dgvHDSanPham.Rows[i].Cells["colTenCTSP"].Value.ToString() == txtCTTenSP.Text && dgvHDSanPham.Rows[i].Cells["colMauSac"].Value.ToString() == txtCTMauSac.Text.ToString().Trim())
                                {
                                    found = true;
                                    dgvHDSanPham.Rows[i].Cells["colSoLuong"].Value = int.Parse(txtCTSoLuong.Text) + int.Parse(dgvHDSanPham.Rows[i].Cells["colSoLuong"].Value.ToString());
                                    RefreshChiTietSanPham();
                                    EnableThongTinHD(true);
                                    btnThemMoi.Enabled = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                //Lưu số lương mới vào dgv
                                dgvHDSanPham.Rows.Add(maChiTietSanPhamMoi, txtCTMaSP.Text, txtCTTenSP.Text, 0, txtCTSoLuong.Text, txtCTMauSac.Text, picHinhAnh.ImageLocation, txtGiaVon.Text);
                                RefreshChiTietSanPham();
                                EnableThongTinHD(true);
                                btnThemMoi.Enabled = true;
                            }
                        }
                        else
                        {
                            //Lưu số lương mới vào dgv
                            dgvHDSanPham.Rows.Add(maChiTietSanPhamMoi, txtCTMaSP.Text, txtCTTenSP.Text, 0, txtCTSoLuong.Text, txtCTMauSac.Text, picHinhAnh.ImageLocation,txtGiaVon.Text);
                            RefreshChiTietSanPham();
                            EnableThongTinHD(true);
                            btnThemMoi.Enabled = true;
                        }
                        //lbTongSoLuong.Text = (int.Parse(txtCTSoLuong.Text) + int.Parse(lbTongSoLuong.Text)).ToString();
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
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

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            string _maChiTietSanPham;
            string _mauSac;
            string _soLuong;
            string _hinhAnh;
            string _maSanPham;
            int _layDongTrongDataTable = 0;
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lập hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                try
                {
                    //Lưu vào PhieuNhapKho
                    string _maPhieuNhapKho = Helper.GetTimestamp(DateTime.Now);
                    clsPhieuNhapKho_DTO phieuNhapKho = new clsPhieuNhapKho_DTO(_maPhieuNhapKho, Validation.LayMaNhanVien(), txtGhiChu.Text, DateTime.Now, 1, cboNCC.SelectedValue.ToString());
                    object resultPhieuNhapKho = clsPhieuNhapKho_BUS.ThemPhieuNhapKho(phieuNhapKho);
                    if (resultPhieuNhapKho is bool)
                    {
                        if ((bool)(resultPhieuNhapKho))
                        {
                            //Thành công
                            for (int i = 0; i < dgvHDSanPham.Rows.Count; i++)
                            {
                                _maChiTietSanPham = dgvHDSanPham.Rows[i].Cells["colMaChiTiet"].Value.ToString();
                                _mauSac = dgvHDSanPham.Rows[i].Cells["colMauSac"].Value.ToString();
                                _soLuong = dgvHDSanPham.Rows[i].Cells["colSoLuong"].Value.ToString();
                                _hinhAnh = dgvHDSanPham.Rows[i].Cells["colHinhAnh"].Value.ToString();
                                _maSanPham = dgvHDSanPham.Rows[i].Cells["colMaSanPham"].Value.ToString();
                                //kiem tra ton tai san pham ==> chua ton tai ==> thêm mới sản phẩm ==> thêm từng chi tiết ==> lưu hóa đơn nhập
                                if (clsSanPham_BUS.KiemTonTaiSanPham(_maSanPham))
                                {
                                    //kiem tra ton tai chi tiet trong db ==> update
                                    if (clsChiTietSanPham_BUS.KiemTraTonTaiMaCT(_maChiTietSanPham))
                                    {
                                        //Tồn tại
                                        //Lấy số lượng cũ để cập nhật
                                        int SoLuongSanPhamCu = 0;
                                        SqlDataReader dr = clsChiTietSanPham_BUS.LayChiTiet(_maSanPham, _mauSac.Trim());
                                        if (dr != null)
                                        {
                                            while (dr.Read())
                                            {
                                                SoLuongSanPhamCu = int.Parse(dr["SoLuong"].ToString());
                                            }
                                        }
                                        SoLuongSanPhamCu += int.Parse(_soLuong);
                                        //Lưu chi tiết sản phẩm
                                        clsChiTietSP_DTO chiTietSanPham = new clsChiTietSP_DTO(_maChiTietSanPham, _mauSac, SoLuongSanPhamCu);
                                        object resultChiTietSP = clsChiTietSanPham_BUS.CapNhatSoLuong(chiTietSanPham);
                                        if (resultChiTietSP is bool)
                                        {
                                            if ((bool)resultChiTietSP)
                                            {
                                                //MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Thêm chi tiết thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show((string)resultChiTietSP);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        //Không tồn tại chi tiết ==> tạo mới chi tiết
                                        //Lưu ảnh vào database
                                        clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(_hinhAnh, clsHinhAnh_DTO.LoaiHinhAnh.Product);
                                        object resultHinhAnh = clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);
                                        if (resultHinhAnh is bool)
                                        {
                                            //Lưu chi tiết sản phẩm mới
                                            clsChiTietSP_DTO chiTietSanPham = new clsChiTietSP_DTO(_maSanPham, _maChiTietSanPham, _mauSac, int.Parse(_soLuong), hinhAnh.MaHinhAnh, 1);
                                            object resultChiTietSP = clsChiTietSanPham_BUS.ThemChiTietSanPham(chiTietSanPham);
                                            if (resultChiTietSP is bool)
                                            {
                                                if ((bool)resultChiTietSP)
                                                {
                                                    // Copy image file vào folder data/product
                                                    string fileName = Path.GetFileName(_hinhAnh);
                                                    string destPath = Directory.GetCurrentDirectory() + "\\data\\product\\" + fileName;
                                                    File.Copy(_hinhAnh, destPath, true);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Thêm chi tiết mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }

                                            }
                                            else
                                            {
                                                MessageBox.Show((string)resultChiTietSP);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show((string)resultHinhAnh);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    //Không tồn tại sản phẩm ==> thêm mới sản phẩm
                                    //Lấy dữ liệu trong DataTable
                                    DataRow row = dtSanPhamMoi.Rows[_layDongTrongDataTable];
                                    string _maSP = row["MaSp"].ToString();
                                    string _tenSP = row["TenSp"].ToString();
                                    string _thuongHieu = row["ThuongHieu"].ToString();
                                    string _chatLieu = row["ChatLieu"].ToString();
                                    int _giaVon = int.Parse(row["GiaVon"].ToString());
                                    int _giaBanLe = int.Parse(row["GiaBanLe"].ToString());
                                    bool _chongNuoc = bool.Parse(row["ChongNuoc"].ToString());
                                    float _trongLuong = float.Parse(row["TrongLuong"].ToString());
                                    string _maDanhMuc = row["MaDanhMuc"].ToString();
                                    int _namBH = int.Parse(row["NamBH"].ToString());

                                    //Thêm sản phẩm
                                    clsSanPham_DTO sanPham = new clsSanPham_DTO(_maSP, _tenSP, _thuongHieu, _chatLieu, _giaVon, _giaBanLe, _chongNuoc, _trongLuong, _maDanhMuc, _namBH);
                                    object resultSanPham = clsSanPham_BUS.ThemSanPham(sanPham);
                                    if (resultSanPham is bool)
                                    {
                                        if ((bool)resultSanPham)
                                        {
                                            //MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            //_layDongTrongDataTable lấy dòng tiếp theo trong datatable nếu có sản phẩm mới
                                            _layDongTrongDataTable++;
                                            //thêm chi tiết sản phẩm vừa thêm
                                            clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(_hinhAnh, clsHinhAnh_DTO.LoaiHinhAnh.Product);
                                            object resultHinhAnh = clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);
                                            if (resultHinhAnh is bool)
                                            {
                                                if ((bool)(resultHinhAnh))
                                                {
                                                    //Lưu chi tiết sản phẩm mới
                                                    clsChiTietSP_DTO chiTietSanPham = new clsChiTietSP_DTO(_maSanPham, _maChiTietSanPham, _mauSac, int.Parse(_soLuong), hinhAnh.MaHinhAnh, 1);
                                                    object resultChiTietSP = clsChiTietSanPham_BUS.ThemChiTietSanPham(chiTietSanPham);
                                                    if (resultChiTietSP is bool)
                                                    {
                                                        if ((bool)resultChiTietSP)
                                                        {
                                                            // Copy image file vào folder data/product
                                                            string fileName = Path.GetFileName(_hinhAnh);
                                                            string destPath = Directory.GetCurrentDirectory() + "\\data\\product\\" + fileName;
                                                            File.Copy(_hinhAnh, destPath, true);
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Thêm chi tiết mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show((string)resultChiTietSP);
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Thêm hình ảnh mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show((string)resultHinhAnh);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show((string)resultSanPham);
                                        return;
                                    }
                                }

                                //Lưu ChiTietNhapKho
                                clsChiTietPhieuNhapKho_DTO chiTiet = new clsChiTietPhieuNhapKho_DTO(Helper.GetTimestamp(DateTime.Now), _maChiTietSanPham, int.Parse(_soLuong), _maPhieuNhapKho);
                                object resultChiTiet = clsChiTietPhieuNhapKho_BUS.ThemChiTietPhieuNhapKho(chiTiet);
                                if (resultChiTiet is bool)
                                {
                                    if ((bool)(resultChiTiet))
                                    {
                                        //MessageBox.Show("Đã lưu vào chi tiết hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        _KiemTraThemChiTiet = true;
                                    }
                                    else
                                    {
                                        _KiemTraThemChiTiet = false;
                                        MessageBox.Show("Thêm chi tiết thất bại, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show((string)resultChiTiet);
                                    return;
                                }
                            }//end for
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show((string)resultPhieuNhapKho);
                        return; 
                    }
                    
                    //lưu thành công
                    if (_KiemTraThemChiTiet)
                    {
                        _layDongTrongDataTable = 0;
                        dtSanPhamMoi.Rows.Clear();
                        loadSanPham();
                        lblSoLuongSP.Text = "0";
                        lblTongTien.Text = "0";
                        txtCTMaSP.Text = null;
                        txtCTTenSP.Text = null;
                        btnThemMoi.Enabled = false;
                        EnableChiTiet(false);
                        EnableSanPham(true);
                        EnableThongTinHD(false);
                        RefreshChiTietSanPham();
                        RefreshHoaDon();
                        RefreshSanPham();
                        dgvHDSanPham.Rows.Clear();
                        MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (IOException msg)
                {
                    MessageBox.Show(msg.Message);
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }

        private void dgvSanPham_DoubleClick_1(object sender, EventArgs e)
        {
            //
            txtCTMaSP.Text = dgvSanPham.CurrentRow.Cells["colMaSp"].Value.ToString();
            txtCTTenSP.Text = dgvSanPham.CurrentRow.Cells["colTenSanPham"].Value.ToString();
            //
            txtTenSP.Text = dgvSanPham.CurrentRow.Cells["colTenSanPham"].Value.ToString();
            txtGiaVon.Text = dgvSanPham.CurrentRow.Cells["colGiaVon"].Value.ToString();
            txtGiaBanLe.Text = dgvSanPham.CurrentRow.Cells["colGiaBan"].Value.ToString();
            txtKichCo.Text = dgvSanPham.CurrentRow.Cells["colTrongLuong"].Value.ToString();
            txtNamBH.Text = dgvSanPham.CurrentRow.Cells["colNamBH"].Value.ToString();
            txtChatLieu.Text = dgvSanPham.CurrentRow.Cells["colChatLieu"].Value.ToString();
            txtThuongHieu.Text =dgvSanPham.CurrentRow.Cells["colThuongHieu"].Value.ToString();
            cboMauMa.SelectedValue = dgvSanPham.CurrentRow.Cells["colMauMa"].Value.ToString();
            //
            EnableChiTiet(true);
            EnableSanPham(false);
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            dvSanPham.RowFilter = string.Format("TenSp like '%{0}%'", txtTenSP.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            loadSanPham();
            RefreshHoaDon();
            RefreshChiTietSanPham();
            RefreshSanPham();
            EnableChiTiet(false);
            EnableSanPham(true);
            EnableThongTinHD(false);
            dgvHDSanPham.Rows.Clear();
            txtCTMaSP.Text = null;
            txtCTTenSP.Text = null;
            lblTongTien.Text = "0";
            lblSoLuongSP.Text = "0";
            ShowLabel(false);
        }

      

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            EnableSanPham(true);
            RefreshSanPham();
        }

        private void btnLuuHoaDon_Click_1(object sender, EventArgs e)
        {

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

        int soLuong = 0;
        double tongTien = 0;
        private void dgvHDSanPham_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            soLuong += int.Parse(dgvHDSanPham.Rows[dgvHDSanPham.RowCount - 1].Cells["colSoLuong"].Value.ToString().Replace(",", ""));
            tongTien += int.Parse(dgvHDSanPham.Rows[dgvHDSanPham.RowCount - 1].Cells["colGiaVonNhap"].Value.ToString().Replace(",", ""))* int.Parse(dgvHDSanPham.Rows[dgvHDSanPham.RowCount - 1].Cells["colSoLuong"].Value.ToString().Replace(",", ""));
            lblSoLuongSP.Text = soLuong.ToString();
            lblTongTien.Text = tongTien.ToString("0,00#");
        }
    }
}

