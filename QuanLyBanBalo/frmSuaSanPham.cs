using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class frmSuaSanPham : Form
    {
        DataTable dtDanhMuc;
        private static string idSP;
        private static string idChiTiet;
        private static bool kiemTraThayDoiPic = false;

        public frmSuaSanPham()
        {
            InitializeComponent();
        }
        public frmSuaSanPham(string idSanPham,string _idChiTiet):this()
        {
            idSP = idSanPham;
            idChiTiet = _idChiTiet;

        }
        private void frmSuaSanPham_Load(object sender, EventArgs e)
        {
            loadMauMa();
            loadSanPham();
            loadKhuyenMai();
        }


      
        private void loadMauMa()
        {
            dtDanhMuc = clsSanPham_BUS.LayTatCaMauMa();
            cboMauMa.DataSource = dtDanhMuc;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
        }

        private void loadKhuyenMai()
        {
            DataTable km = clsKhuyenMai_BUS.LayBangKhuyenMai(false);
            cbKhuyenMai.DataSource = km;
            cbKhuyenMai.ValueMember = "MaKhuyenMai";
            cbKhuyenMai.DisplayMember = "TenKhuyenMai";
        }
        public void loadSanPham()
        {
            SqlDataReader dr = clsSanPham_BUS.LayThongTinMotSanPham(idSP,idChiTiet);
            if (dr != null)
            {
                while (dr.Read())
                {
                    txtMaSP.Text = dr["MaSP"].ToString();
                    txtTenSP.Text = dr["TenSP"].ToString();
                    txtThuongHieu.Text = dr["ThuongHieu"].ToString();
                    txtNamBH.Text = dr["SoNamBH"].ToString();
                    txtChatLieu.Text = dr["ChatLieu"].ToString();
                    txtGiaVon.Text = string.Format("{0:N0}", dr["GiaVon"]);
                    txtGiaBanLe.Text = string.Format("{0:N0}", dr["GiaBanLe"]);
                    txtTrongLuong.Text = dr["TrongLuong"].ToString();
                    txtMauSac.Text = dr["MauSac"].ToString();
                    txtCTSoLuong.Text = dr["SoLuong"].ToString();
                    txtMaCTSP.Text = idChiTiet.ToString();
                    cboMauMa.SelectedValue = dr["MaDanhMuc"].ToString();
                    cbKhuyenMai.SelectedValue = dr["MaKhuyenMai"];
                    if (bool.Parse(dr["ChongNuoc"].ToString()) == true)
                    {
                        rdCo.Checked = true;
                    }
                    else
                    {
                        rdKhong.Checked = true;
                    }
                    picHinhAnh.ImageLocation = dr["Url"].ToString();
                    picHinhAnh.Name = dr["MaHinhAnh"].ToString();
                    picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
   

        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            showLable(false);
            if (KiemTraTextBox())
            {
                try
                {
                    // Sản Phẩm
                    clsSanPham_DTO dtoSanPham = new clsSanPham_DTO();
                
                        dtoSanPham.MaSP = idSP;
                        dtoSanPham.TenSP = txtTenSP.Text;
                        dtoSanPham.ThuongHieu = txtThuongHieu.Text;
                        dtoSanPham.ChatLieu = txtChatLieu.Text;
                        dtoSanPham.GiaVon = decimal.Parse(txtGiaVon.Text);
                        dtoSanPham.GiaBanLe = decimal.Parse(txtGiaBanLe.Text);
                        if(rdCo.Checked == true)
                        {
                                dtoSanPham.ChongNuoc = true;
                        }
                        else
                        {
                                dtoSanPham.ChongNuoc = false;
                        }
                        dtoSanPham.TrongLuong = float.Parse(txtTrongLuong.Text);
                        dtoSanPham.MaDanhMuc = cboMauMa.SelectedValue.ToString();
                        dtoSanPham.SoNamBH = int.Parse(txtNamBH.Text);
                        dtoSanPham.MaKhuyenMai = (int)cbKhuyenMai.SelectedValue;

                    // Thông tin ảnh hiện tại
                    clsHinhAnh_DTO hinhAnh = new clsHinhAnh_DTO(picHinhAnh.ImageLocation, clsHinhAnh_DTO.LoaiHinhAnh.Product, int.Parse(picHinhAnh.Name));
                    /*kiểm tra xem có thay đổi hình ảnh không
                     * Nếu có resultHinhAnh = Mã Hình
                     */
                    if (kiemTraThayDoiPic)
                    {
                        // Lưu ảnh vào database 
                        // HinhAnh được thay đổi mã ảnh mới
                        clsHinhAnh_BUS.ThemHinhAnh(hinhAnh);
                        // Copy image file vào folder data/product
                        string fileName = Path.GetFileName(picHinhAnh.ImageLocation);
                        string destPath = Directory.GetCurrentDirectory() + "\\data\\product\\" + fileName;
                        File.Copy(picHinhAnh.ImageLocation, destPath, true);
                        kiemTraThayDoiPic = false;
                    }
                    // Chi Tiết Sản Phẩm
                    clsChiTietSP_DTO dtoChiTietSP = new clsChiTietSP_DTO();
                        dtoChiTietSP.MaCTSP = txtMaCTSP.Text;
                        dtoChiTietSP.MauSac = txtMauSac.Text;
                        dtoChiTietSP.SoLuong = int.Parse(txtCTSoLuong.Text);
                    dtoChiTietSP.MaHinhAnh = hinhAnh.MaHinhAnh;
               
                    // Sửa sản phẩm
                    object resultSanPham = clsSanPham_BUS.SuaSanPham(dtoSanPham, dtoChiTietSP);
                    if(resultSanPham is bool || (bool)resultSanPham)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                catch (IOException msg)
                {
                    MessageBox.Show(msg.Message);
                }
                catch (Exception)
                {
                     MessageBox.Show("Dữ liệu nhập không chính xác! \nVui Lòng Kiểm Tra Lại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }

        }
        #region: Validate TextBox
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
            if (string.IsNullOrWhiteSpace(txtTrongLuong.Text))
            {
                hople = false;
                lblTrongLuong.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtCTSoLuong.Text))
            {
                hople = false;
                lblSoLuong.Visible = true;
            }
            if (string.IsNullOrWhiteSpace(txtMauSac.Text))
            {
                hople = false;
                lblMauSac.Visible = true;
            }
            return hople;
        }
       private void showLable(bool bl)
       {
            lblTenSP.Visible = bl;
            lblThuongHieu.Visible = bl;
            lblNamBH.Visible = bl;
            lblChatLieu.Visible = bl;
            lblGiaBanLe.Visible = bl;
            lblGiaVon.Visible = bl;
            lblTrongLuong.Visible = bl;
            lblMauSac.Visible = bl;
            lblSoLuong.Visible = bl;
        }
        #endregion

    

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGiaVon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        private void txtGiaBanLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        private void txtNamBH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        private void txtTrongLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtCTSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        
        private void txtGiaBanLe_TextChanged(object sender, EventArgs e)
        {
            Helper.MoneyFormat(txtGiaBanLe);
        }

        private void txtGiaVon_TextChanged(object sender, EventArgs e)
        {
            Helper.MoneyFormat(txtGiaVon);
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            string filePath = Helper.layHinhAnh();
            if (filePath != null)
            {
                kiemTraThayDoiPic = true;
                picHinhAnh.ImageLocation = filePath;
            }
        }
    }
}

