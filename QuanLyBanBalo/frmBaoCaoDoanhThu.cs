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
using System.Data;
using BUS;

namespace QuanLyBanBalo
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        private DataTable dtSanPham;
        private DataView dvSanPham;
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
            CaiDat();
            loadMauMa();
        }

        private static frmBaoCaoDoanhThu _Instance = null;

        public static frmBaoCaoDoanhThu Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmBaoCaoDoanhThu();
                return _Instance;
            }
        }

        private void frmBaoCaoDoanhThu_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Instance = null;
        }

        private void frmBaoCaoDoanhThu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void CaiDat()
        {
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";

        }

        private void loadMauMa()
        {
            DataTable dtMauMa = clsSanPham_BUS.LayTatCaMauMa();
            DataRow dr;
            dr = dtMauMa.NewRow();
            dr["TenDanhMuc"] = "Tất cả";
            dr["MaDanhMuc"] = 0;
            dtMauMa.Rows.InsertAt(dr, 0);
            cboMauMa.DataSource = dtMauMa;
            cboMauMa.ValueMember = "MaDanhMuc";
            cboMauMa.DisplayMember = "TenDanhMuc";
        }

        private void CapNhatThongTinThongKe()
        {
            int soLuong = 0;
            double tongTien = 0;
            double loiNhuan = 0;
            foreach (DataRow row in dtSanPham.Rows)
            {
                soLuong += int.Parse(row["SoLuong"].ToString());
                tongTien += double.Parse(row["TongTien"].ToString());

                loiNhuan += double.Parse(row["GiaBanLe"].ToString()) - double.Parse(row["GiaVon"].ToString());

            }

            lblSoLuongSP.Text = soLuong.ToString();
            lblTongTien.Text = tongTien.ToString("0,00#");
            lblLoiNhuan.Text = loiNhuan.ToString("0,00#");
            
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dtSanPham != null)
                dtSanPham.Clear();
            dtSanPham = clsHoaDon_BUS.LayBangSanPhamTuHDBan(dtpTuNgay.Value.ToString("yyyy-MM-dd"), dtpDenNgay.Value.ToString("yyyy-MM-dd"));
            
           
            dvSanPham = new DataView(dtSanPham);
            dgvSanPham.DataSource = dvSanPham;
            dgvSanPham.AutoGenerateColumns = false;
            for (int i = dtSanPham.Rows.Count - 1; i >= 0; i--)
            {
                bool result = (int)dtSanPham.Rows[i]["MaDanhMuc"] != (int)cboMauMa.SelectedValue && (int)cboMauMa.SelectedValue != 0;
                if (result)
                    dtSanPham.Rows.RemoveAt(i);
            }
            if (dtSanPham.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy kết quả, vui lòng điều chỉnh lại ngày khác.");
            CapNhatThongTinThongKe();
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            int result = DateTime.Compare(dtpTuNgay.Value, dtpDenNgay.Value);
            if (result > 0)
            {
                dtpTuNgay.Value = dtpDenNgay.Value;
            }
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            int result = DateTime.Compare(dtpDenNgay.Value, dtpTuNgay.Value);
            if (result < 0)
            {
                dtpDenNgay.Value = dtpTuNgay.Value;
            }
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "HinhAnh")
            {
                e.Value = new Bitmap(e.Value.ToString());
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInBaoCaoDoanhThu frm = new frmInBaoCaoDoanhThu(dtSanPham, dtpTuNgay.Value.ToString("dd/MM/yyyy"), dtpDenNgay.Value.ToString("dd/MM/yyyy"), lblTongTien.Text, lblLoiNhuan.Text);
            frm.ShowDialog();
        }
    }
}
