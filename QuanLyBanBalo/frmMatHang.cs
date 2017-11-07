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
namespace QuanLyBanBalo
{
    public partial class frmMatHang : Form
    {
        private static frmMatHang _Instance = null;
        public frmMatHang()
        {
            InitializeComponent();
        }
        private void frmMatHang_Load(object sender, EventArgs e)
        {
            loadSanPham();
        }
        private void loadSanPham()
        {
            DataTable dt = new DataTable();
            clsSanPham_BUS bus = new clsSanPham_BUS();
            dt = bus.LayTatCaSanPham();
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = dt;
        }


        public static frmMatHang Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new frmMatHang();
                return _Instance;
            }
        }

        private void frmMatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Tắt tab khi tắt form
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void frmMatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instance = null;
        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvSanPham.Columns[e.ColumnIndex].Name == "colHinhAnh")
                {
                    e.Value = new Bitmap(e.Value.ToString());
                }
                if (dgvSanPham.Columns[e.ColumnIndex].Name =="colChongNuoc")
                {
                    if (e.Value != null)
                    {
                        if(bool.Parse(e.Value.ToString()) == true)
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
            catch(Exception)
            {

            }
            
        }
    }
}
