using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace QuanLyBanHang
{
    public partial class frmTimKiemHoaDonTheoNhanVien : Form
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

        //Đối tượng đưa dữ liệu vào DataTable dtNhanVien = null;
        SqlDataAdapter daNhanVien = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtNhanVien = null;

        public frmTimKiemHoaDonTheoNhanVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void LoadData()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);




                //Vận chuyển dữ liệu lên DataTable dtHoaDon
                daNhanVien = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                //Đưa dữ liệu lên ComboBox
                this.cbNhanVien.DataSource = dtNhanVien;
                this.cbNhanVien.DisplayMember = "HoTen";
                this.cbNhanVien.ValueMember = "MaNV";

                //Vận chuyển dữ liệu lên DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                //Đưa dữ liệu lên DataGridView
                this.dgvNhanVien.DataSource = dtHoaDon;
                //Thay đổi độ rộng cột
                dgvNhanVien.AutoResizeColumns();

                //Đếm số dòng trong datatable dtKhachHang
                //int soKH dtKhachHang.Rows.Count();
                int soHD = Convert.ToInt32(dtHoaDon.Compute("COUNT(MAHD)", string.Empty));
                //MessageBox.Show(soKH.ToString(), "Số dòng");
                this.txtTongHD.Text = soHD.ToString();


            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!");
            }
        }


        private void LoadDataByNV()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                //Vận chuyển dữ liệu lên DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon WHERE MaNV = '" + this.cbNhanVien.SelectedValue.ToString() + "'", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                //Đưa dữ liệu lên DataGridView
                this.dgvNhanVien.DataSource = dtHoaDon;
                //Thay đổi độ rộng cột
                dgvNhanVien.AutoResizeColumns();

                //Đếm số dòng trong datatable dtKhachHang
                //int soKH dtKhachHang.Rows.Count();
                int soHD = Convert.ToInt32(dtHoaDon.Compute("COUNT(MAHD)", string.Empty));
                //MessageBox.Show(soKH.ToString(), "Số dòng");
                this.txtTongHD.Text = soHD.ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!");
            }
        }


        private void frmTimKiemHoaDonTheoNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Giải phóng tài nguyên
            dtHoaDon.Dispose();
            dtHoaDon = null;
            //hủy kết nối
            conn = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadDataByNV();
        }

        private void frmTimKiemHoaDonTheoNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
