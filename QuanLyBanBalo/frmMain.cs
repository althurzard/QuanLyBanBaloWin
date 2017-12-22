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

namespace QuanLyBanBalo
{
    public partial class frmMain : Form
    {
        private List<Form> forms = new List<Form>();
        public frmMain()
        {
            CapNhatKhuyenMai();
            InitializeComponent();
            nhapHangToolStripMenuItem.Visible = Validation.CheckPermission();
            nhanVienToolStripMenuItem.Visible = Validation.CheckPermission();
            matHangToolStripMenuItem.Visible = Validation.CheckPermission();
            nhaCungCapToolStripMenuItem.Visible = Validation.CheckPermission();
            khuyenMaiToolStripMenuItem.Visible = Validation.CheckPermission();
            baoCaoToolStripDropDownButton.Visible = Validation.CheckPermission();
            toolStripDropDownButton2.Visible = Validation.CheckPermission();
            //TODO: Hướng phát triển tiếp theo
            baoHanhToolStripMenuItem.Visible = false;
            //TODO: Làm trợ giúp ở main
            troGiupToolStripDropDownButton.Visible = false;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                item.ForeColor = Color.Green;

                if (item is ToolStripDropDownButton)
                {
                    var dropdown = ((ToolStripDropDownButton)item);
                    foreach (ToolStripItem dropdownItem in dropdown.DropDownItems)
                    {
                        dropdownItem.ForeColor = Color.Green;
                    }
                }
                
            }
        }

        private void CapNhatKhuyenMai()
        {
            clsSanPham_BUS.CapNhatKhuyenMai();
        }


        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private int KiemTraTonTaiForm(TabControl tab, Form frm)
        {
            // duyệt qua tất cả tab
            for (int i = 0; i < tab.TabCount; i++)
            {
                //Nếu tên tab trùng vs tên form ==> trả về vị trí của tab
                if (tab.TabPages[i].Text.Trim() == frm.Text.Trim())
                {
                    return i;
                }

            }
            return -1;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmNhanVien frmNv = frmNhanVien.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmNv);
            if (index>=0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmNv.MdiParent = this;
                forms.Add(frmNv);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmNv.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmNv.Parent = tp;
                frmNv.Show();
                tbcMain.SelectTab(tp);
            }
           
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatHang frmMH = frmMatHang.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmMH);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmMH.MdiParent = this;
                forms.Add(frmMH);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmMH.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmMH.Parent = tp;
                frmMH.Show();
                tbcMain.SelectTab(tp);
            }
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaCungCap frmNCC = frmNhaCungCap.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmNCC);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmNCC.MdiParent = this;
                forms.Add(frmNCC);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmNCC.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmNCC.Parent = tp;
                frmNCC.Show();
                tbcMain.SelectTab(tp);
            }
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoHanh frmBH = frmBaoHanh.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmBH);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmBH.MdiParent = this;
                forms.Add(frmBH);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmBH.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmBH.Parent = tp;
                frmBH.Show();
                tbcMain.SelectTab(tp);
            }
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void danhSáchHĐXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoNhapHang frmDSX = frmBaoCaoNhapHang.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmDSX);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmDSX.MdiParent = this;
                forms.Add(frmDSX);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmDSX.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmDSX.Parent = tp;
                frmDSX.Show();
                tbcMain.SelectTab(tp);
            }
        }

     

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
           DialogResult result =  MessageBox.Show("Bạn có chắc chứ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                //Application.Exit();
                foreach(Form frm in Application.OpenForms)
                {
                    if (frm is frmDangNhap)
                    {
                        frm.Show();
                        break;
                    }
                }
                foreach(Form frm in forms)
                {
                    frm.Close();
                }
                this.Close();
            } 
        }

        private void tbcMain_DoubleClick(object sender, EventArgs e)
        {
            TabPage i = tbcMain.SelectedTab;
            if (i != null)
            {
                tbcMain.TabPages.Remove(i);
            }

        }

        private void khuyếnMạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhuyenMai frmDSN = frmKhuyenMai.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmDSN);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmDSN.MdiParent = this;
                forms.Add(frmDSN);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmDSN.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmDSN.Parent = tp;
                frmDSN.Show();
                tbcMain.SelectTab(tp);
            }
        }

        private void nhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapHang frmNH = frmNhapHang.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmNH);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmNH.MdiParent = this;
                forms.Add(frmNH);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmNH.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmNH.Parent = tp;
                frmNH.Show();
                tbcMain.SelectTab(tp);
            }
        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBanHang frmXH = frmBanHang.Instance;
            
            int index = KiemTraTonTaiForm(tbcMain, frmXH);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmXH.MdiParent = this;
                forms.Add(frmXH);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmXH.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmXH.Parent = tp;
                frmXH.Show();
                tbcMain.SelectTab(tp);
            }
        }

        private void nhapHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBaoCaoNhapHang frmXH = frmBaoCaoNhapHang.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmXH);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmXH.MdiParent = this;
                forms.Add(frmXH);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmXH.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmXH.Parent = tp;
                frmXH.Show();
                tbcMain.SelectTab(tp);
            }
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu frmXH = frmBaoCaoDoanhThu.Instance;

            int index = KiemTraTonTaiForm(tbcMain, frmXH);
            if (index >= 0)
            {
                // Nếu tồn tại tab form ==> nhảy vào tab đó
                tbcMain.SelectedIndex = index;
            }
            else
            {
                frmXH.MdiParent = this;
                forms.Add(frmXH);
                //Tạo ra 1 tab mới
                TabPage tp = new TabPage { Text = frmXH.Text };
                tp.Size = new Size(400, 400);
                //Add tab mới vào TabControl
                tbcMain.TabPages.Add(tp);
                frmXH.Parent = tp;
                frmXH.Show();
                tbcMain.SelectTab(tp);
            }
        }
    }
}
