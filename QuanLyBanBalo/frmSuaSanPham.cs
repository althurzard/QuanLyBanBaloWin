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
namespace QuanLyBanBalo
{
    public partial class frmSuaSanPham : Form
    {
        DataTable dtDanhMuc;
        private static string idSP;
        private static string msg;

        public frmSuaSanPham()
        {
            InitializeComponent();
        }
        public frmSuaSanPham(string idSanPham):this()
        {
            idSP = idSanPham;
        }
        private void frmSuaSanPham_Load(object sender, EventArgs e)
        {
            loadMauMa();
            loadSanPham();
            
        }


        #region : Load dữ liệu
        private void loadMauMa()
        {
            dtDanhMuc = clsSanPham_BUS.LayTatCaMauMa();
            cboMauMa.DataSource = dtDanhMuc;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
        }
        public void loadSanPham()
        {
            SqlDataReader dr = clsSanPham_BUS.LayThongTinMotSanPham(idSP);
            if (dr != null)
            {
                while (dr.Read())
                {
                    txtMaSP.Text = dr["MaSP"].ToString();
                    txtTenSP.Text = dr["TenSP"].ToString();
                    txtThuongHieu.Text = dr["ThuongHieu"].ToString();
                    txtNamBH.Text = dr["SoNamBH"].ToString();
                    txtChatLieu.Text = dr["ChatLieu"].ToString();
                    txtGiaVon.Text = dr["GiaVon"].ToString();
                    txtGiaBanLe.Text = dr["GiaBanLe"].ToString();
                    txtTrongLuong.Text = dr["TrongLuong"].ToString();
                    txtMauSac.Text = dr["MauSac"].ToString();
                    txtCTSoLuong.Text = dr["SoLuong"].ToString();
                    txtMaCTSP.Text = dr["MaCTSP"].ToString();
                    cboMauMa.SelectedValue = dr["MaDanhMuc"].ToString();
                    if (bool.Parse(dr["ChongNuoc"].ToString()) == true)
                    {
                        rdCo.Checked = true;
                    }
                    else
                    {
                        rdKhong.Checked = true;
                    }
                    picHinhAnh.ImageLocation = dr["Url"].ToString();
                    picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        #endregion

        #region : Sự kiện bấm nút
        private void btnLuu_Click(object sender, EventArgs e)
        {

            


            try
            {
                    // Sản Phẩm
                    clsSanPham_DTO dtoSanPham = new clsSanPham_DTO();
                    dtoSanPham.MaSP = txtMaSP.Text;
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
                    dtoSanPham.MaDanhMuc = int.Parse(cboMauMa.SelectedValue.ToString());
                    dtoSanPham.SoNamBH = int.Parse(txtNamBH.Text);   
                
                // Chi Tiết Sản Phẩm
                    clsChiTietSP_DTO dtoChiTietSP = new clsChiTietSP_DTO();
                    dtoChiTietSP.MaCTSP = txtMaCTSP.Text;
                    dtoChiTietSP.MauSac = txtMauSac.Text;
                    dtoChiTietSP.SoLuong = int.Parse(txtCTSoLuong.Text);

                    clsSanPham_BUS.SuaSanPham(dtoSanPham, dtoChiTietSP);

                    MessageBox.Show("Cập nhật thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }catch
            {
                 MessageBox.Show("Dữ liệu nhập không chính xác! \nVui Lòng Kiểm Tra Lại","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region: Validate TextBox

        private void txtTenSP_Validated(object sender, EventArgs e)
        {
            //xóa erP
            errorProvider1.SetError(txtTenSP, "");
        }
        private void txtTenSP_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.NotEmptyTextBox(txtTenSP.Text,out msg))
            {
                e.Cancel = true;
                //Chọn vị trí textbox 
                txtTenSP.Select(0, txtTenSP.Text.Length);
                //gọi erP xuất thông báo
                this.errorProvider1.SetError(txtTenSP, msg);
            }
        }

        private void txtThuongHieu_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtThuongHieu, "");
        }
        private void txtThuongHieu_Validating(object sender, CancelEventArgs e)
        {
            
            if (!Validation.NotEmptyTextBox(txtThuongHieu.Text, out msg))
            {
                e.Cancel = true;
                //Chọn vị trí textbox 
                txtTenSP.Select(0, txtThuongHieu.Text.Length);
                //gọi erP xuất thông báo
                this.errorProvider1.SetError(txtThuongHieu, msg);
            }
        }
        
        private void txtNamBH_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNamBH, "");
        }
        private void txtNamBH_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.IsNumberic(txtNamBH.Text, out msg))
            {
                e.Cancel = true;
                txtNamBH.Select(0, txtNamBH.Text.Length);
                this.errorProvider1.SetError(txtNamBH, msg);
            }
        }

        private void txtChatLieu_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtChatLieu, "");
        }
        private void txtChatLieu_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.NotEmptyTextBox(txtChatLieu.Text, out msg))
            {
                e.Cancel = true;
                //Chọn vị trí textbox 
                txtChatLieu.Select(0, txtChatLieu.Text.Length);
                //gọi erP xuất thông báo
                this.errorProvider1.SetError(txtChatLieu, msg);
            }
        }

        private void txtGiaBanLe_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtGiaBanLe, "");
        }
        private void txtGiaBanLe_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.IsNumberic(txtGiaBanLe.Text, out msg))
            {
                e.Cancel = true;
                txtGiaBanLe.Select(0, txtGiaBanLe.Text.Length);
                this.errorProvider1.SetError(txtGiaBanLe, msg);
            }
        }

        private void txtGiaVon_Validated(object sender, EventArgs e)
        {

                errorProvider1.SetError(txtGiaVon, "");
        }
        private void txtGiaVon_Validating(object sender, CancelEventArgs e)
        { 
                if (!Validation.IsNumberic(txtGiaVon.Text, out msg))
                {
                    e.Cancel = true;
                txtGiaVon.Select(0, txtGiaVon.Text.Length);
                    this.errorProvider1.SetError(txtGiaVon, msg);
                }  
        }

        private void txtTrongLuong_Validated(object sender, EventArgs e)
        {
                errorProvider1.SetError(txtTrongLuong, "");
        }
        private void txtTrongLuong_Validating(object sender, CancelEventArgs e)
        {
                if (!Validation.IsNumberic(txtTrongLuong.Text, out msg))
                {
                    e.Cancel = true;
                    txtTrongLuong.Select(0, txtTrongLuong.Text.Length);
                    this.errorProvider1.SetError(txtTrongLuong, msg);
                }
        }

        private void txtMauSac_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMauSac, "");
        }
        private void txtMauSac_Validating(object sender, CancelEventArgs e)
        {
                if (!Validation.NotEmptyTextBox(txtMauSac.Text, out msg))
                {
                    e.Cancel = true;
                    //Chọn vị trí textbox 
                    txtMauSac.Select(0, txtMauSac.Text.Length);
                    //gọi erP xuất thông báo
                    this.errorProvider1.SetError(txtMauSac, msg);
                }
        }

        private void txtCTSoLuong_Validated(object sender, EventArgs e)
        {

                errorProvider1.SetError(txtCTSoLuong, "");
        }
        private void txtCTSoLuong_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.IsNumberic(txtCTSoLuong.Text, out msg))
            {
                e.Cancel = true;
                txtCTSoLuong.Select(0, txtCTSoLuong.Text.Length);
                this.errorProvider1.SetError(txtCTSoLuong, msg);
            }
        }

#endregion

    }
}

