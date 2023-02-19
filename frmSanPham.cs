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
//using System.Data;

namespace QuanLyBanHang
{
    public partial class frmSanPham : Form
    {

        bool Them;
        //Chuỗi kết nối
        string strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=SSPI";

        //Đối tượng kết nối
        SqlConnection conn = null;
        //Đối tượng đưa dữ liệu vào DataTable dtSanPham = null;
        SqlDataAdapter daSanPham = null;
        //Đối tượng hiển thị dữ liệu lên Form
        DataTable dtSanPham = null;

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_FormClosing(object sender, FormClosingEventArgs e)
        {
            dtSanPham.Dispose();
            dtSanPham = null;
            //hủy kết nối
            conn = null;
        }

        void LoadData()
        {
            try
            {
                //Khởi động kết nối
                conn = new SqlConnection(strConnectionString);
                // mở kết nối
                //Vận chuyển dữ liệu lên DataTable dtSanPham
                daSanPham = new SqlDataAdapter("SELECT * FROM SanPham", conn);
                dtSanPham = new DataTable();
                dtSanPham.Clear();
                daSanPham.Fill(dtSanPham);
                //Đưa dữ liệu lên DataGridView
                dgvSanPham.DataSource = dtSanPham;
                //Thay đổi độ rộng cột
                dgvSanPham.AutoResizeColumns();

                //Xóa các đối tượng trong Panel
                this.txtMaSP.ResetText();
                this.txtTenSP.ResetText();
                this.txtDVT.ResetText();
                this.txtDonGia.ResetText();
                //Không cho thao tác trên các nút Lưu / Hủy
                this.btnLuu.Enabled = false;
                this.btnHuy.Enabled = false;
                this.pnlThongTinSP.Enabled = false;
                //Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
                this.btnThem.Enabled = true;
                this.btnSua.Enabled = true;
                this.btnXoa.Enabled = true;
                this.btnTroVe.Enabled = true;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được nội dung trong table SanPham, Lỗi rồi!!!");
            }
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
                int r = dgvSanPham.CurrentCell.RowIndex;
                //Lấy MaKH của record hiện hành
                string strMASP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                //Viết câu lệnh SQL
                cmd.CommandText = System.String.Concat("Delete from SanPham where MaSP='" + strMASP + "'");
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            //Xóa trống các đối tượng trong panel
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGia.ResetText();

            //Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = true;
            this.btnSua.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnTroVe.Enabled = true;
            //Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = false;
            this.btnHuy.Enabled = false;
            this.pnlThongTinSP.Enabled = false;
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến Them
            Them = true;
            
            this.txtMaSP.Enabled = true;
            //Xóa trống các đối tượng trong Panel
            this.txtMaSP.ResetText();
            this.txtTenSP.ResetText();
            this.txtDVT.ResetText();
            this.txtDonGia.ResetText();

            //Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlThongTinSP.Enabled = true;
            //Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;

            //Đưa con trỏ đến TextField txtMaHD
            this.txtMaSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kích hoạt biến Sửa
            Them = false;
            this.txtMaSP.Enabled = false;

            //Cho phép thao tác trên Panel
            this.pnlThongTinSP.Enabled = true;
            //Thứ tự dòng hiện hành
            int r = dgvSanPham.CurrentCell.RowIndex;
            //Chuyển thông tin lên panel
            this.txtMaSP.Text = dgvSanPham.Rows[r].Cells[0].Value.ToString();
            this.txtTenSP.Text = dgvSanPham.Rows[r].Cells[1].Value.ToString();
            this.txtDVT.Text = dgvSanPham.Rows[r].Cells[2].Value.ToString();
            this.txtDonGia.Text = dgvSanPham.Rows[r].Cells[3].Value.ToString();

            //Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.pnlThongTinSP.Enabled = true;
            //Không cho thao tác trên các nút thêm / Sửa / Xóa / Thoát
            this.btnThem.Enabled = false;
            this.btnSua.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnTroVe.Enabled = false;
            //Đưa con trỏ đến TextField txtMaKH
            this.txtMaSP.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Mở kết nối
            conn.Open();
            if (Them)
            {
                try
                {
                    if (this.txtMaSP.Text.ToString() != string.Empty
                        && this.txtTenSP.Text.ToString() != string.Empty)
                    {
                        //Thực hiện lệnh
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        //Lệnh Insert InTo
                        cmd.CommandText = System.String.Concat("Insert into SanPham values(" + "'" +
                            this.txtMaSP.Text.ToString() + "',N'" + this.txtTenSP.Text.ToString() + "',N'" +
                            this.txtDVT.Text.ToString() + "','" + this.txtDonGia.Text.ToString() + "')");
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        //Load lại dữ liệu trên DataGridView
                        LoadData();
                        //Thông báo
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không thêm được. Lỗi rồi!");
                    }
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
                    if(this.txtMaSP.Text.ToString() != string.Empty 
                        && this.txtTenSP.Text.ToString() != string.Empty)
                    {
                    //Thực hiện lệnh
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    //Thứ tự dòng hiện hành
                    int r = dgvSanPham.CurrentCell.RowIndex;
                    //MaKH hiện hành
                    string strMASP = dgvSanPham.Rows[r].Cells[0].Value.ToString();
                    //Câu lệnh SQL
                    cmd.CommandText = System.String.Concat("Update SanPham Set MaSP='" +
                        this.txtMaSP.Text.ToString() + "', TenSP =N'" +
                        this.txtTenSP.Text.ToString() + "', DonViTinh =N'" + this.txtDVT.Text.ToString()
                        + "', DonGia ='" + this.txtDonGia.Text.ToString() +
                        "' where MaSP ='" + strMASP + "'");
                    //Cập nhật
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    //Load lại dữ liệu lên trên DataGridView
                    LoadData();
                    //Thông báo
                    MessageBox.Show("Đã sửa xong!");
                    }
                    else
                    {
                        MessageBox.Show("Không sửa được. Lỗi rồi!");
                    }

                }
                catch (SqlException)
                {
                    MessageBox.Show("Không sửa được. Lỗi rồi!");
                }
            }
            //Đóng kết nối
            conn.Close();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
