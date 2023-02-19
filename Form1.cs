using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void frmLogin()
        {
            Form frm = new Form2();
            frm.ShowDialog();
        }

        private void XemDanhMuc(int intDanhMuc) {
            Form frm = new frmChiTietHoaDon1();
            frm.Text = intDanhMuc.ToString();
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmLogin();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Chắc không?","Trả lời", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK) Application.Exit();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmKhachHang();
            frm.ShowDialog();
        }

        private void thôngTinHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTimKiemHoaDonTheoNhanVien();
            frm.ShowDialog();
        }


        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmSanPham();
            frm.ShowDialog();
        }

        private void thànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmThanhPho();
            frm.ShowDialog();
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmHoaDon();
            frm.ShowDialog();
        }

        private void phiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPhienBan();
            frm.ShowDialog();
        }

        private void thôngTinKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmThongTinKhachHang();
            frm.ShowDialog();
        }

        private void tìmKiếmHóaĐơnTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTimKiemHoaDonTheoKhachHang();
            frm.ShowDialog();
        }

        private void tìmKiếmHóaĐơnTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTimKiemHoaDonTheoNhanVien();
            frm.ShowDialog();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChiTietHoaDon();
            frm.ShowDialog();
        }

    }
}
