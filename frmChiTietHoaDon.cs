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

namespace QuanLyBanHang
{
    public partial class frmChiTietHoaDon : Form
    {
        //Chuỗi kết nối
        //string strConnectionString = @"Server=.\SQLEXPRESS;Database=QuanLyBanHang;Integrated Security=True";
        //or
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=SSPI";

        //Đối tượng kết nối
        SqlConnection conn = null;
        //Đối tượng đưa dữ liệu vào DataTable dtHoaDon = null;
        SqlDataAdapter daHoaDon = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtHoaDon = null;

        //Đối tượng đưa dữ liệu vào DataTable dtKhachHang = null;
        SqlDataAdapter daKhachHang = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtKhachHang = null;

        SqlDataAdapter daNhanVien = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                //Vận chuyển dữ liệu lên DataTable dtHoaDon
                daHoaDon = new SqlDataAdapter("SELECT HoaDon.MaHD,HoaDon.MaKH,KhachHang.TenCty,HoaDon.MaNV,NhanVien.HoTen," +
                    "HoaDon.NgayLapHD,HoaDon.NgayNhanHang From HoaDon,KhachHang,NhanVien" +
                    " where HoaDon.MaKH=KhachHang.MaKH and HoaDon.MaNV=NhanVien.MaNV", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
 


                //Vận chuyển dữ liệu lên DataTable dtKhachHang dùng cho combobox
                daKhachHang = new SqlDataAdapter("SELECT TenCty FROM KhachHang", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);


                //Vận chuyển dữ liệu lên DataTable dtNhanVien dùng cho combobox
                daNhanVien = new SqlDataAdapter("SELECT HoTen FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);

                this.dgvChiTietHoaDon.DataSource = dtHoaDon;
                dgvChiTietHoaDon.AutoResizeColumns();
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi rồi!!!");
            }
        }
        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Giải phóng tài nguyên
            dtHoaDon.Dispose();
            dtHoaDon = null;
            //hủy kết nối
            conn = null;
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
