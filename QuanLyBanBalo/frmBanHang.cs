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
namespace QuanLyBanBalo
{
    public partial class frmBanHang : Form
    {
        private DataTable dtSanPham;
        private DataView dvSanPham;
        public frmBanHang()
        {
            InitializeComponent();
            CaiDat();
            CaiDatDatatable();
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


        private void CapNhatThongTinThanhToan()
        {
            double _thanhTien = 0;
            foreach (DataRow row in dtSanPham.Rows)
            {
                double tongTien = double.Parse(row["TongTien"].ToString());
                _thanhTien += tongTien;
            }

            _thanhTien -= double.Parse(lblGiamTru.Text);

            lblThanhTien.Text = _thanhTien.ToString("0,00#");
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
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.DataSource = dvSanPham;
            dgvSanPham.AutoGenerateColumns = false;

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

            if (KiemTraSPTonTai(CTSP))
            {
                CapNhatThongTinThanhToan();
                return;
            }

            clsSanPham_DTO sanPham = clsSanPham_BUS.LayThongTinMotSanPham(CTSP.MaSP);
            clsHinhAnh_DTO hinhAnhSP = clsHinhAnh_BUS.LayHinhAnh(CTSP.MaHinhAnh);
            clsKhuyenMai_DTO khuyenMai = clsKhuyenMai_BUS.LayKhuyenMai(sanPham.MaKhuyenMai);

            double giaGiamTru = ((double.Parse(khuyenMai.MoTa) / 100) * (double)sanPham.GiaBanLe);
            khuyenMai.MoTa = giaGiamTru.ToString();

            
            string soLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text) ? "1" : txtSoLuong.Text;
            double tongTienSP = (((double)sanPham.GiaBanLe - double.Parse(khuyenMai.MoTa)) * double.Parse(soLuong));

            DataRow newRow = dtSanPham.NewRow();
            newRow["HinhAnh"] = hinhAnhSP.Url;
            newRow["TenSP"] = sanPham.TenSP;
            newRow["MauSac"] = CTSP.MauSac;
            newRow["GiaBanLe"] = sanPham.GiaBanLe.ToString("0,00#");
            newRow["TenKhuyenMai"] = khuyenMai.TenKhuyenMai;
            newRow["GiamTru"] = double.Parse(khuyenMai.MoTa).ToString("0,00#");
            newRow["SoNamBH"] = sanPham.SoNamBH;
            newRow["SoLuong"] = soLuong;
            newRow["MaCTSP"] = CTSP.MaCTSP;
            newRow["TongTien"] = tongTienSP.ToString("0,00#"); 
            dtSanPham.Rows.Add(newRow);

            CapNhatThongTinThanhToan();
            
            

        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                e.Value = new Bitmap(e.Value.ToString());
            }

        }
    }
}
