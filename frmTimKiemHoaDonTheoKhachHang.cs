﻿using System;
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
    public partial class frmTimKiemHoaDonTheoKhachHang : Form
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

        public frmTimKiemHoaDonTheoKhachHang()
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

                //Vận chuyển dữ liệu lên DataTable dtKhachHang
                daKhachHang = new SqlDataAdapter("SELECT * FROM KhachHang", conn);
                dtKhachHang = new DataTable();
                dtKhachHang.Clear();
                daKhachHang.Fill(dtKhachHang);

                //Xóa các đối tượng trong Panel
                //Đưa dữ liệu lên ComboBox
                this.cbMaKH.DataSource = dtKhachHang;
                this.cbMaKH.DisplayMember = "TenCty";
                this.cbMaKH.ValueMember = "MaKH";

 
                //Vận chuyển dữ liệu lên DataTable dtHoaDon
                daNhanVien = new SqlDataAdapter("SELECT * FROM NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
    

                //Vận chuyển dữ liệu lên DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT * From HoaDon", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);
                

                //Đưa dữ liệu lên DataGridView
                this.dgvHoaDon.DataSource = dtHoaDon;
                //Thay đổi độ rộng cột
                dgvHoaDon.AutoResizeColumns();

                //Đếm số dòng trong datatable dtKhachHang
                //int soKH dtKhachHang.Rows.Count();
                int soHD = Convert.ToInt32(dtHoaDon.Compute("COUNT(MAHD)", string.Empty));
                //MessageBox.Show(soKH.ToString(), "Số dòng");
                this.txtTongSoHD.Text = soHD.ToString();
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!");
            }
        }


        private void LoadDataByCustomer()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);

                //Vận chuyển dữ liệu lên DataTable dtKhachHang
                daHoaDon = new SqlDataAdapter("SELECT * FROM HoaDon WHERE MaKH = '" + this.cbMaKH.SelectedValue.ToString() + "'", conn);
                dtHoaDon = new DataTable();
                dtHoaDon.Clear();
                daHoaDon.Fill(dtHoaDon);

                //Đưa dữ liệu lên DataGridView
                this.dgvHoaDon.DataSource = dtHoaDon;
                //Thay đổi độ rộng cột
                dgvHoaDon.AutoResizeColumns();

                //Đếm số dòng trong datatable dtKhachHang
                //int soKH dtKhachHang.Rows.Count();
                int soHD = Convert.ToInt32(dtHoaDon.Compute("COUNT(MAHD)", string.Empty));
                //MessageBox.Show(soKH.ToString(), "Số dòng");
                this.txtTongSoHD.Text = soHD.ToString();

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung. Lỗi rồi!!!");
            }
        }

        private void frmHoaDonTheoKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmHoaDonTheoKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Giải phóng tài nguyên
            dtHoaDon.Dispose();
            dtHoaDon = null;

            dtKhachHang.Dispose();
            dtKhachHang = null;

            dtNhanVien.Dispose();
            dtNhanVien = null;

            //hủy kết nối
            conn = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadDataByCustomer();
        }


    }
}
