using QuanLyRaVao.ChiHuyDonVi;
using QuanLyRaVao.Data;
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

namespace QuanLyRaVao.ChiHuyTieuDoan
{
    public partial class DanhSachPheDuyet : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;


        int index = -1; // chi so chay tu 0
        int index1 = -1;
        public DanhSachPheDuyet()
        {
            InitializeComponent();
            LoadDanhSachPheDuyet();
            LoadDanhSachDaVao();
        }
        public void LoadDanhSachPheDuyet()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachHocVien_DangKy_DaDuyet";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachPheDuyet.DataSource = dt;
            connect.Close();
            dgv_DanhSachPheDuyet.Columns["ID"].Frozen = dgv_DanhSachPheDuyet.Columns["MaHV"].Frozen = dgv_DanhSachPheDuyet.Columns["TenHV"].Frozen = true;
            dgv_DanhSachPheDuyet.Columns["ID"].Visible = false;
        }

        public void LoadDanhSachDaVao()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSach_DangKy_DaDuyet_DaVao";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_TheoDoi.DataSource = dt;
            connect.Close();
            dgv_TheoDoi.Columns["ID_PheDuyet"].Frozen = dgv_TheoDoi.Columns["MaHV"].Frozen = dgv_TheoDoi.Columns["TenHV"].Frozen = true;
            dgv_TheoDoi.Columns["ID_PheDuyet"].Visible = false;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            pn_TheoDoi.Visible = true;
        }

        private void guna2GradientCircleButton1_Click_1(object sender, EventArgs e)
        {
            pn_TheoDoi.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lb1.Visible= true;
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "btn_ChuaRa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachPheDuyet.DataSource = dt;
            connect.Close();
            dgv_DanhSachPheDuyet.Columns["ID"].Frozen = dgv_DanhSachPheDuyet.Columns["MaHV"].Frozen = dgv_DanhSachPheDuyet.Columns["TenHV"].Frozen = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            lb1.Visible = false;
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "btn_DaRa";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachPheDuyet.DataSource = dt;
            connect.Close();
            dgv_DanhSachPheDuyet.Columns["ID"].Frozen = dgv_DanhSachPheDuyet.Columns["MaHV"].Frozen = dgv_DanhSachPheDuyet.Columns["TenHV"].Frozen = true;

        }

        private void dgv_DanhSachPheDuyet_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check nếu hàng được chọn có index hợp lệ
            {
                DataGridViewRow selectedRow = dgv_DanhSachPheDuyet.Rows[e.RowIndex];

                // Lấy thông tin từ các cột của hàng được chọn
                string ID = selectedRow.Cells["ID"].Value.ToString(); //
                string MaHV = selectedRow.Cells["MaHV"].Value.ToString();
                string TenHV = selectedRow.Cells["TenHV"].Value.ToString(); //
                string MaVe = selectedRow.Cells["SoGiayRaVao"].Value.ToString(); //
                // Tạo và hiển thị form mới
                ThuHoiVe newForm = new ThuHoiVe(ID,MaHV,TenHV,MaVe);
                newForm.Show();
            }

        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientCircleButton2_Click_1(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            if (txtHoTen.Text != "" && txtTichKe.Text != "")
                {
                    cmd.CommandText = "Tra_Ve";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idpheduyet", txtID.Text);
                    cmd.Parameters.AddWithValue("@tgtra", ThoiGianTra.Text);
                    cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(txtHoTen.Text + " " + "ĐÃ TRẢ VÉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    pn_TheoDoi.Visible = false;
                    LoadDanhSachPheDuyet();
                }
                else
                {
                    MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

        }

        private void dgv_TheoDoi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            txtID.Text = dgv_TheoDoi.Rows[index].Cells[0].Value.ToString();
            txtMaHV.Text = dgv_TheoDoi.Rows[index].Cells[1].Value.ToString();
            txtHoTen.Text = dgv_TheoDoi.Rows[index].Cells[2].Value.ToString();
            txtHT.Text = dgv_TheoDoi.Rows[index].Cells[6].Value.ToString();
            txtTichKe.Text = dgv_TheoDoi.Rows[index].Cells[10].Value.ToString();
            txtGiayTranhThu.Text = dgv_TheoDoi.Rows[index].Cells[11].Value.ToString();
        }

        private void dgv_TheoDoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
