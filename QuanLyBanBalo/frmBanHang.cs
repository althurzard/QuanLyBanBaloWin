using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using DTO;
using BUS;
using System.Threading;

namespace QuanLyBanBalo
{
    public partial class frmBanHang : Form
    {
        private DataTable dtSanPham;
        private DataView dvSanPham;
        private clsKhuyenMai_DTO khuyenMai = null;
        private DataView dvTatCaSP;
        private DataTable dtTatCaSP;
        private List<object[]> listTempRemovedRows = new List<object[]>();
        private clsHoaDon_DTO hoaDonHienTai = null;
        private clsKhachHang_DTO khachHang = null;
        public frmBanHang()
        {
            InitializeComponent();
            CaiDat();
            CaiDatDatatable();
            KiemTraKhuyenMai();
            LoadSanPham();
        }

        private static frmBanHang _Instance = null;

        public static frmBanHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmBanHang();
                return _Instance;
            }
        }

        private void CaiDat()
        {
            List<string> listMaCTSP = clsChiTietSanPham_BUS.LayMaCTSP();
            Helper.SetAutocomplete(txtMaCTSP, listMaCTSP.ToArray());

            List<string> lstTenSP = clsSanPham_BUS.LayTenSP();
            Helper.SetAutocomplete(txtTenSP, lstTenSP.ToArray());

            List<string> listMauSac = clsChiTietSanPham_BUS.LayMauSac();
            Helper.SetAutocomplete(txtMauSac, listMauSac.ToArray());
        }

        private bool KiemTraSPTonTai(clsChiTietSP_DTO CTSP)
        {
            foreach(DataRow row in dtSanPham.Rows)
            {
                string _maCTSP = row["MaCTSP"].ToString();
                if (_maCTSP == CTSP.MaCTSP)
                {
                    string soLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text) ? "1" : txtSoLuong.Text;
                    int tongSL = int.Parse(row["SoLuong"].ToString()) + int.Parse(soLuong);
                    double tongTienSP = ((double.Parse(row["GiaBanLe"].ToString()) - double.Parse(row["GiamTru"].ToString())) * tongSL);
                    row["SoLuong"] = tongSL;
                    row["TongTien"] = tongTienSP.ToString("0,00#");
                    return true;
                }
            }
            return false;
        }

        private DataRow KiemTraSPTonTai(string maCTSP)
        {
            foreach (DataRow row in dtTatCaSP.Rows)
            {
                string _maCTSP = row["MaCTSP"].ToString();
                if (maCTSP == _maCTSP)
                    return row;
            }
            return null;
        }



        private void KiemTraKhuyenMai()
        {
            List<clsKhuyenMai_DTO> lstKM = clsKhuyenMai_BUS.LayKhuyenMaiTheoHD();
            DateTime timeNow = DateTime.Now;
            foreach (clsKhuyenMai_DTO km in lstKM)
            {
                if (km.NgayBatDau != null && km.NgayKetThuc != null)
                {
                    DateTime ngayBatDau = km.NgayBatDau ?? DateTime.Now;
                    int result = DateTime.Compare(timeNow, ngayBatDau);
                    if (result >= 0)
                    {
                        DateTime ngayKetThuc = km.NgayKetThuc ?? DateTime.Now;
                        result = DateTime.Compare(timeNow, ngayKetThuc);
                        if(result <= 0)
                        {
                            khuyenMai = km;
                            lblTenCTKM.Text = string.Format("- {0}", km.TenKhuyenMai);
                            lblNgayKM.Text = string.Format("- Diễn ra từ ngày {0} đến hết ngày {1}", ngayBatDau.ToString("dd/MM/yyyy"), ngayKetThuc.ToString("dd/MM/yyyy"));

                            return;
                        }
                    }
                }
                
            }

            lblTenCTKM.Text = "Hiện không có chương trình khuyến mại.";
            lblNgayKM.Text = "";
            khuyenMai = clsKhuyenMai_BUS.LayKhuyenMai(4); // Mặc định

        }


        private void CapNhatThongTinThanhToan()
        {
            double _thanhTien = 0;
            foreach (DataRow row in dtSanPham.Rows)
            {
                double tongTien = double.Parse(row["TongTien"].ToString());
                _thanhTien += tongTien;
            }
            double giamTru = 0;

            if (khuyenMai != null)
            {
                giamTru = (double.Parse(khuyenMai.MoTa) / 100) * _thanhTien;
            }
            _thanhTien -= giamTru;

            lblGiamTru.Text = giamTru.ToString("0,00#");
            lblThanhTien.Text = _thanhTien.ToString("0,00#");
        }


        private void LoadSanPham()
        {
            dtTatCaSP = clsSanPham_BUS.LayTatCaSanPham(false);
            dvTatCaSP = new DataView(dtTatCaSP);
            dgvTatCaSP.AutoGenerateColumns = false;
            dgvTatCaSP.DataSource = dvTatCaSP;
        }

        private void CaiDatDatatable()
        {
            dtSanPham = new DataTable();
            dtSanPham.Clear();
            dtSanPham.Columns.Add("HinhAnh");
            dtSanPham.Columns.Add("TenSP");
            dtSanPham.Columns.Add("MauSac");
            dtSanPham.Columns.Add("GiaBanLe");
            dtSanPham.Columns.Add("TenKhuyenMai");
            dtSanPham.Columns.Add("GiamTru");
            dtSanPham.Columns.Add("SoNamBH");
            dtSanPham.Columns.Add("SoLuong");
            dtSanPham.Columns.Add("TongTien");
            dtSanPham.Columns.Add("MaCTSP");
            dtSanPham.Columns.Add("MaKhuyenMai");
            dtSanPham.Columns.Add("ThuongHieu");
            dtSanPham.Columns.Add("KMGiamTru");
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.DataSource = dvSanPham;
            dgvSanPham.AutoGenerateColumns = false;

        }

        private void CapNhatSoLuongChoBangTatCaSP(int soLuong, string maCTSP)
        {
            foreach(DataRow row in dtTatCaSP.Rows)
            {
                string _maCTSP = row["MaCTSP"].ToString();
                if (maCTSP == _maCTSP)
                {
                    int soLuongCapNhat = int.Parse(row["SoLuong"].ToString()) + soLuong;
                    row["SoLuong"] = soLuongCapNhat;
                    

                    return;

                }
            }

            // Người dùng hủy hóa đơn(xóa sản phẩm trong hóa đơn)
            // Cập nhật lại bảng tất cả sp

         

        }

        

        private void LamMoi()
        {
            XacNhanHoaDon(true);
            txtGhiChu.Text = "";
            txtMaCTSP.Text = "";
            txtSDT.Text = "";
            txtSoLuong.Text = "";
            txtTenKH.Text = "";
            txtTenSP.Text = "";
            txtMauSac.Text = "";
            txtSoTienNhan.Text = "";
            lblThanhTien.Text = "0,000";
            lblTienNhan.Text = "0,000";
            dtSanPham.Clear();
            CapNhatThongTinThanhToan();
            LoadSanPham();
            CaiDat();
        }

        private void XacNhanHoaDon(bool flag)
        {
            txtTenKH.Enabled = flag;
            txtSDT.Enabled = flag;
            txtGhiChu.Enabled = flag;
            txtSoTienNhan.Enabled = flag;
            btnThem.Enabled = flag;
            txtMaCTSP.Enabled = flag;
            txtTenSP.Enabled = flag;
            txtMauSac.Enabled = flag;
            txtSoLuong.Enabled = flag;
            btnXacNhan.Enabled = flag;
        }

        private void In()
        {
            frmInHDBanHang frm = new frmInHDBanHang(dtSanPham, hoaDonHienTai,khuyenMai,lblThanhTien.Text);
            frm.ShowDialog();
        }

        private void DoiTrangThaiButtonThem()
        {
            DataRow row = KiemTraSPTonTai(txtMaCTSP.Text);
            btnThem.Enabled = txtSoLuong.Text != "0" && row != null && row["SoLuong"].ToString() != "0";
        }

        private void frmXuatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;

        }

        private void frmXuatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clsChiTietSP_DTO CTSP = clsChiTietSanPham_BUS.LayChiTiet(txtMaCTSP.Text);
            if(CTSP == null)
            {
                MessageBox.Show("Sản phẩm không tồn tại.");
                return;
            }

            string soLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text) ? "1" : txtSoLuong.Text;

            if (KiemTraSPTonTai(CTSP))
            {
                CapNhatThongTinThanhToan();
                CapNhatSoLuongChoBangTatCaSP(-int.Parse(soLuong), CTSP.MaCTSP);
                CapNhatSoLuongChoTextbox();
                return;
            }

            clsSanPham_DTO sanPham = clsSanPham_BUS.LayThongTinMotSanPham(CTSP.MaSP);
            clsHinhAnh_DTO hinhAnhSP = clsHinhAnh_BUS.LayHinhAnh(CTSP.MaHinhAnh);
            clsKhuyenMai_DTO khuyenMai = clsKhuyenMai_BUS.LayKhuyenMai(sanPham.MaKhuyenMai);

            double giaGiamTru = ((double.Parse(khuyenMai.MoTa) / 100) * (double)sanPham.GiaBanLe);
            double tongTienSP = (((double)sanPham.GiaBanLe - giaGiamTru) * double.Parse(soLuong));

            DataRow newRow = dtSanPham.NewRow();
            newRow["HinhAnh"] = hinhAnhSP.Url;
            newRow["TenSP"] = sanPham.TenSP;
            newRow["MauSac"] = CTSP.MauSac;
            newRow["GiaBanLe"] = sanPham.GiaBanLe.ToString("0,00#");
            newRow["TenKhuyenMai"] = khuyenMai.TenKhuyenMai;
            newRow["GiamTru"] = giaGiamTru.ToString("0,00#");
            newRow["SoNamBH"] = sanPham.SoNamBH;
            newRow["SoLuong"] = soLuong;
            newRow["MaCTSP"] = CTSP.MaCTSP;
            newRow["MaKhuyenMai"] = khuyenMai.MaKhuyenMai;
            newRow["TongTien"] = tongTienSP.ToString("0,00#");
            newRow["ThuongHieu"] = sanPham.ThuongHieu;
            newRow["KMGiamTru"] = khuyenMai.MoTa + "%";
            dtSanPham.Rows.Add(newRow);
            
            CapNhatThongTinThanhToan();
            CapNhatSoLuongChoBangTatCaSP(-int.Parse(soLuong), CTSP.MaCTSP);
            CapNhatSoLuongChoTextbox();
            

        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                e.Value = new Bitmap(e.Value.ToString());
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTienNhan.Text)) return;
            double tienNhan = double.Parse(txtSoTienNhan.Text);
            double tienThua = tienNhan - double.Parse(lblThanhTien.Text);
            Helper.MoneyFormat(txtSoTienNhan);
            lblTienNhan.Text = tienNhan.ToString("0,00#");
            lblTienThua.Text = tienThua.ToString("0,00#");
        }

        private void dgvSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                CapNhatSoLuongChoBangTatCaSP(int.Parse(dtSanPham.Rows[dgvSanPham.CurrentRow.Index]["SoLuong"].ToString()), dtSanPham.Rows[dgvSanPham.CurrentRow.Index]["MaCTSP"].ToString());
                dgvSanPham.Rows.RemoveAt(dgvSanPham.CurrentRow.Index);
                CapNhatThongTinThanhToan();
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            KiemTraKhuyenMai();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (khachHang == null)
            {
                // Khách hàng mới
               khachHang = new clsKhachHang_DTO(txtTenKH.Text, txtSDT.Text, Helper.GetTimestamp(DateTime.Now));
               clsKhachHang_BUS.Them(khachHang);
            }
           
            hoaDonHienTai = new clsHoaDon_DTO(
                Helper.GetTimestamp(DateTime.Now),
                Validation.LayMaNhanVien(),
                string.IsNullOrWhiteSpace(txtGhiChu.Text) ? "Không" : txtGhiChu.Text,
                double.Parse(lblGiamTru.Text),
                double.Parse(lblThanhTien.Text),
                khachHang,
                khuyenMai);

            if (clsHoaDon_BUS.Them(hoaDonHienTai))
            {
                // Chi tiet hoa don
                foreach(DataRow row in dtSanPham.Rows)
                {

                    clsKhuyenMai_DTO km = new clsKhuyenMai_DTO
                        (
                        row["TenKhuyenMai"].ToString(),
                        row["GiamTru"].ToString(),
                        false, null, null, 1, int.Parse(row["MaKhuyenMai"].ToString())
                        );
        
                    clsChiTietHD_DTO cthd = new clsChiTietHD_DTO
                        (
                        Helper.GetTimestamp(DateTime.Now),
                        row["MaCTSP"].ToString(),
                        double.Parse(row["GiamTru"].ToString()),
                        double.Parse(row["TongTien"].ToString()),
                        int.Parse(row["SoLuong"].ToString()),
                        km,
                        hoaDonHienTai
                        );

                   if (!clsChiTietHD_BUS.Them(cthd))
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi tạo chi tiết hóa đơn, vui lòng thử lại hoặc liên hệ Admin để xử lý.");
                        // TODO: Xóa hóa đơn đã tạo ở trên

                        return;
                    } else
                    {
                        // TODO: Giam so luong ton kho trong database
                        if (!clsChiTietSanPham_BUS.CapNhatSoLuong(cthd.MaCTSP, cthd.SoLuong))
                        {
                            MessageBox.Show("Đã xảy ra lỗi khi cập nhật số lượng, vui lòng thử lại hoặc liên hệ Admin để xử lý.");
                            return;
                        }

                    }

                    int milliseconds = 100;
                    Thread.Sleep(milliseconds);

                }

                DialogResult result = MessageBox.Show("Tạo hóa đơn thành công, bạn có muốn In ngay bây giờ?", "Thông báo", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    In();
                }
                btnIn.Enabled = true;
                XacNhanHoaDon(false);

            } else
            {
                MessageBox.Show("Thêm hóa đơn thất bại.");
            }

               
        }

        private void lblTienNhan_TextChanged(object sender, EventArgs e)
        {
            double tienNhan = double.Parse(lblTienNhan.Text);
            double thanhTien = double.Parse(lblThanhTien.Text);
            btnXacNhan.Enabled = tienNhan >= thanhTien && tienNhan > 0 && dtSanPham.Rows.Count >= 1;

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            In();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.IsNumberic(e);
        }

        private void dgvTatCaSP_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTatCaSP.Columns[e.ColumnIndex].Name == "colHinhAnh")
            {
                e.Value = new Bitmap(e.Value.ToString());
            }

            if (dgvTatCaSP.Columns[e.ColumnIndex].Name == "colChongNuoc")
            {
                if (e.Value != null)
                {
                    if (bool.Parse(e.Value.ToString()) == true)
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

        private void Search()
        {
            string searchText = "";
            if (!string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                searchText = string.Format("TenSP like '%{0}%' AND ", txtTenSP.Text);
            }
            else
            {
                searchText = "TRUE AND ";
            }

            if (!string.IsNullOrWhiteSpace(txtMauSac.Text))
            {
                searchText += string.Format("MauSac like '%{0}%' AND ", txtMauSac.Text);
            }
            else
            {
                searchText += "TRUE AND ";
            }

            searchText += "TRUE";

            dvTatCaSP.RowFilter = searchText;


        }

        private void txtMaCTSP_TextChanged(object sender, EventArgs e)
        {
            dvTatCaSP.RowFilter = string.Format("MaCTSP LIKE '%{0}%'", txtMaCTSP.Text);
            DoiTrangThaiButtonThem();
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void txtMaCTSP_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaCTSP.Text)) return;

            foreach (DataRow row in dtTatCaSP.Rows)
            {
                if (row["MaCTSP"].ToString() == txtMaCTSP.Text)
                {
                    txtTenSP.Text = row["TenSP"].ToString();
                    txtMauSac.Text = row["MauSac"].ToString();
                    int soLuong = int.Parse(row["SoLuong"].ToString());

                    // Cập nhật lại sô lượng nếu vượt quá số lượng tồn kho
                    if (!string.IsNullOrWhiteSpace(txtSoLuong.Text) && int.Parse(txtSoLuong.Text) > soLuong)
                        txtSoLuong.Text = soLuong.ToString();

                    break;
                }
            }
            
        }

        private void CapNhatSoLuongChoTextbox()
        {
            if (string.IsNullOrWhiteSpace(txtSoLuong.Text)) return;
            DataRow row = KiemTraSPTonTai(txtMaCTSP.Text);
            if (row != null)
            {
                int soLuong = int.Parse(txtSoLuong.Text);
                int soLuongHienTai = int.Parse(row["SoLuong"].ToString());
                if (soLuong > soLuongHienTai)
                {
                    txtSoLuong.Text = soLuongHienTai.ToString();
                }
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            CapNhatSoLuongChoTextbox();
            DoiTrangThaiButtonThem();

        }

        private void dgvTatCaSP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            // Cập nhật lại sô lượng nếu vượt quá số lượng tồn kho
            if (dgvTatCaSP.SelectedRows.Count > 0)
            {
                string tenSP = dgvTatCaSP.SelectedRows[0].Cells[3].Value.ToString();
                string mauSac = dgvTatCaSP.SelectedRows[0].Cells[7].Value.ToString();
                string maCTSP = dgvTatCaSP.SelectedRows[0].Cells[1].Value.ToString();
                txtTenSP.Text = tenSP;
                txtMauSac.Text = mauSac;
                txtMaCTSP.Text = maCTSP;
            }

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            khachHang = clsKhachHang_BUS.LayThongTin(txtSDT.Text);
            txtTenKH.Text = khachHang != null ? khachHang.TenKH : "";
            txtTenKH.Enabled = khachHang == null;
        }

    }
}
