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

        private void button1_Click(object sender, EventArgs e)
        {
            loadSanPham();
        }

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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

