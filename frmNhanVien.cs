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
    public partial class frmNhanVien : Form
    {
        bool Them;
        //Chuỗi kết nối
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";
        //Đối tượng kết nối
        SqlConnection conn = null;
        //Đối tượng đưa dữ liệu vào Datatable dtNhanVien
        SqlDataAdapter daNhanVien = null;
        //Đối tượng hiển thị dữ liệu lên form
        DataTable dtNhanVien = null;

        //Form Load
        void LoadData()
        {
            try
            {
                //Khởi động connection
                conn = new SqlConnection(strConnectionString);
                //Vận chuyển dữ liệu lên DataTable dtNhanVien
                daNhanVien = new SqlDataAdapter("SELECT * FROM NHANVIEN", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                //Đưa dữ liệu lên DataGridView
                dgvNHANVIEN.DataSource = dtNhanVien;
                //Thay đổi độ rộng cột
                dgvNHANVIEN.AutoResizeColumns();

                //Xóa các đối tượng trong Panel
                this.txtMaNV.ResetText();
                this.txtHoTen.ResetText();
                this.txtNgayNV.ResetText();
                this.txtDiaChi.ResetText();
                this.txtDienThoai.ResetText();
                //Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.pnlThongTinNV.Enabled = false;
                //Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table NHANVIEN. Lỗi rồi!!!");
            }
               
        }


        public frmNhanVien()
        {
            InitializeComponent();
        }


        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Giải phóng tài nguyên
            dtNhanVien.Dispose();
            dtNhanVien = null;
            //Hủy kết nối
            conn = null;
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Mở kết nối
            conn.Open();
            try
            {
                //Thực hiện lệnh
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                //Lấy thứ tự record hiện hành
                int r = dgvNHANVIEN.CurrentCell.RowIndex;
                //Lấy MaKH của record hiện hành
                string strMANV = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
                //Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete from NhanVien where MaNV='" + strMANV + "'");
                //cmd.CommandType = CommandType.Text;
                //Thực hiện câu lệnh SQL
                cmd.ExecuteNonQuery();
                //Cập nhật lại DataGridView
                LoadData();
                //Thông báo
                MessageBox.Show("Đã xóa xong!");

            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!!!");
            }
            //Đóng kết nối
            conn.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến Them
            Them = true;
            this.txtMaNV.Enabled = true;
            //Xóa trống các đối tượng trong Panel
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.txtNgayNV.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();
            //Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlThongTinNV.Enabled = true;
            //Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;

            //Đưa con trỏ đến TextField txtMaHD
            this.txtMaNV.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến Sửa
            Them = false;
            this.txtMaNV.Enabled = false;
            //Cho phép thao tác trên Panel
            this.pnlThongTinNV.Enabled = true;
            //Thứ tự dòng hiện hành
            int r = dgvNHANVIEN.CurrentCell.RowIndex;
            //Chuyển thông tin lên panel
            this.txtMaNV.Text = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
            this.txtHoTen.Text = dgvNHANVIEN.Rows[r].Cells[1].Value.ToString();
            this.txtNgayNV.Text = dgvNHANVIEN.Rows[r].Cells[2].Value.ToString();
            this.txtDiaChi.Text = dgvNHANVIEN.Rows[r].Cells[3].Value.ToString();
            this.txtDienThoai.Text = dgvNHANVIEN.Rows[r].Cells[4].Value.ToString();

            //Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlThongTinNV.Enabled = true;
            //Không cho thao tác trên các nút thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            //Đưa con trỏ đến TextField txtMaKH
            this.txtMaNV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Mở kết nối
            conn.Open();
            if (Them)
            {
                try
                {
                    //Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    //Lệnh Insert InTo
                    cmd.CommandText = System.String.Concat("Insert into NhanVien values(" + "'" +
                        this.txtMaNV.Text.ToString() + "',N'" + this.txtHoTen.Text.ToString() + "','" +
                        this.txtNgayNV.Text.ToString() + "',N'" + this.txtDiaChi.Text.ToString() +
                        "','" + this.txtDienThoai.Text.ToString() + "')");
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    //Load lại dữ liệu trên DataGridView
                    LoadData();
                    //Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được. Lỗi rồi!");
                }
            }

            //for updating data
            if (!Them)
            {
                try
                {
                    //Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    //Thứ tự dòng hiện hành
                    int r = dgvNHANVIEN.CurrentCell.RowIndex;
                    //MaKH hiện hành
                    string strMANV = dgvNHANVIEN.Rows[r].Cells[0].Value.ToString();
                    //Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update NhanVien Set MaNV='" +
                        this.txtMaNV.Text.ToString() + "', HoTen =N'" +
                        this.txtHoTen.Text.ToString() + "', NgayNV ='" + this.txtNgayNV.Text.ToString()
                        + "', DiaChi =N'" + this.txtDiaChi.Text.ToString()
                        + "', DienThoai ='" + this.txtDienThoai.Text.ToString() +
                        "' where MaNV ='" + strMANV + "'");
                    //Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    //Load lại dữ liệu lên trên DataGridView
                    LoadData();
                    //Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            //Đóng kết nối
            conn.Close();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //Xóa trống các đối tượng trong panel
            this.txtMaNV.ResetText();
            this.txtHoTen.ResetText();
            this.txtNgayNV.ResetText();
            this.txtDiaChi.ResetText();
            this.txtDienThoai.ResetText();

            //Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            //Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.pnlThongTinNV.Enabled = false;
        }
    }
}
