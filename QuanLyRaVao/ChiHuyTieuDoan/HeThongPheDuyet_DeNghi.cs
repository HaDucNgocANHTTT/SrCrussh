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
    public partial class HeThongPheDuyet_DeNghi : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;

        string ma;

        int index = -1; // chi so chay tu 0
        public HeThongPheDuyet_DeNghi()
        {
            InitializeComponent();
            LoadDanhSachCanBo();
            txtSoGiayTranhThu.Text = "";
        }

        private void ReloadFormCha()
        {
            // Xử lý tải lại form cha ở đây
            // Ví dụ: Tải lại dữ liệu hoặc làm bất kỳ việc cần thiết khác
            // Sau khi xử lý xong, form cha sẽ load lại
            this.Controls.Clear(); // Xóa tất cả các controls trên form cha
            InitializeComponent(); // Khởi tạo lại controls và form cha
            LoadDanhSachCanBo();
            txtSoGiayTranhThu.Text = "";
        }

        public void LoadDanhSachDangKyTTCT(string ma)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachHocVien_DangKy_TranhThu_CongTac";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", ma);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachCho.DataSource = dt;
            connect.Close();
            dgv_DanhSachCho.Columns["ID"].Frozen = dgv_DanhSachCho.Columns["MaHV"].Frozen = dgv_DanhSachCho.Columns["TenHV"].Frozen = true;
        }
        public void LoadDanhSachCanBo()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachCanBo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_TieuDoan.DataSource = dt;
            dgv_TieuDoan.Columns[4].Visible = false;
            connect.Close();
        }

        public void LoadKhoVe(string madv)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Kho_Ve";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", madv);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_Ve.DataSource = dt;
            connect.Close();
        }
        private void label16_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void HeThongPheDuyet_DeNghi_Load(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;
            c55.Text = c56.Text = c57.Text = c58.Text = c55_1.Text = c56_1.Text = c57_1.Text = c58_1.Text = tentieudoan.Text = tk.Tendangnhap[1].ToString();
            

        }

        private void btn56_Click(object sender, EventArgs e)
        {
            string madv = c56.Text + "56";
            ve_c.Text = madv;
            string ma = 'c' + madv;
            LoadKhoVe(ma);
            LoadDanhSachDangKyTTCT(ma);
            int qs_cho = 0;
            for (int i = 0; i < dgv_DanhSachCho.RowCount; i++)
            {
                qs_cho++;
            }
            quanso.Text = qs_cho.ToString();
            txtID.Clear();
            txtTenHV.Clear();
            txtHT.Clear();
            txtKV.Clear();
            txtCBduyet.Clear();
            txtSoGiayTranhThu.Clear();
            cbKhoVe.Clear();
        }

        private void btn55_Click(object sender, EventArgs e)
        {
            string madv = c55.Text + "55";
            ve_c.Text = madv;
            ma = 'c' + madv;
            LoadKhoVe(ma);
            LoadDanhSachDangKyTTCT(ma);
            int qs_cho = 0;
            for (int i = 0; i < dgv_DanhSachCho.RowCount; i++)
            {
                qs_cho++;
            }
            quanso.Text = qs_cho.ToString();
            txtID.Clear();
            txtTenHV.Clear();
            txtHT.Clear();
            txtKV.Clear();
            txtCBduyet.Clear();
            txtSoGiayTranhThu.Clear();
            cbKhoVe.Clear();
        }

        private void btn57_Click(object sender, EventArgs e)
        {
            string madv = c57.Text + "57";
            ve_c.Text = madv;
            ma = 'c' + madv;
            LoadKhoVe(ma);
            LoadDanhSachDangKyTTCT(ma);
            int qs_cho = 0;
            for (int i = 0; i < dgv_DanhSachCho.RowCount; i++)
            {
                qs_cho++;
            }
            quanso.Text = qs_cho.ToString();
            txtID.Clear();
            txtTenHV.Clear();
            txtHT.Clear();
            txtKV.Clear();
            txtCBduyet.Clear();
            txtSoGiayTranhThu.Clear();
            cbKhoVe.Clear();
        }

        private void btn58_Click(object sender, EventArgs e)
        {
            string madv = c58.Text + "58";
            ve_c.Text = madv;
            ma = 'c' + madv;
            LoadKhoVe(ma);
            LoadDanhSachDangKyTTCT(ma);
            int qs_cho = 0;
            for (int i = 0; i < dgv_DanhSachCho.RowCount; i++)
            {
                qs_cho++;
            }
            quanso.Text = qs_cho.ToString();
            txtID.Clear();
            txtTenHV.Clear();
            txtHT.Clear();
            txtKV.Clear();
            txtCBduyet.Clear();
            txtSoGiayTranhThu.Clear();
            cbKhoVe.Clear();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv_TieuDoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            txtCBduyet.Text = dgv_TieuDoan.Rows[index].Cells[0].Value.ToString();
        }

        private void dgv_DanhSachCho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            txtID.Text = dgv_DanhSachCho.Rows[index].Cells[0].Value.ToString();
            txtTenHV.Text = dgv_DanhSachCho.Rows[index].Cells[2].Value.ToString();
            txtHT.Text = dgv_DanhSachCho.Rows[index].Cells[6].Value.ToString();
            txtKV.Text = dgv_DanhSachCho.Rows[index].Cells[7].Value.ToString();
            if (dgv_DanhSachCho.Rows[index].Cells["TenHT"].Value.ToString() == "Công Tác" || dgv_DanhSachCho.Rows[index].Cells["TenKV"].Value.ToString() == "Miền Nam")
            {
                btnDuyet.Visible = false;
            }
            else
            {
                btnDuyet.Visible = true;
            }
            if (dgv_DanhSachCho.Rows[index].Cells["TenHT"].Value.ToString() == "Tranh Thủ")
            {
                Random rd = new Random();
                string Numrd;
                Numrd = rd.Next(100, 100000).ToString();
                string SoGiayTT = Numrd + "/GNP-HV";
                txtSoGiayTranhThu.Text = SoGiayTT;
            }
            else
            {
                txtSoGiayTranhThu.Text = "";
            }
        }

        private void dgv_Ve_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            if (dgv_Ve.Rows[index].Cells["Tình Trạng"].Value.ToString() == "Đã sử dụng")
            {
                cbKhoVe.Text = null;
            }
            else
            {
                cbKhoVe.Text = dgv_Ve.Rows[index].Cells[0].Value.ToString();
            }

        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            string Numrd;
            Numrd = rd.Next(100, 100000).ToString();
            string SoGiayTT = Numrd + "/GNP-HV";
            txtSoGiayTranhThu.Text = SoGiayTT;
        }

        private void guna2GradientCircleButton3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Xoa_DangKy";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", txtID.Text);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Xóa thành công !!", "Thông báo");
            }
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            if (txtID.Text != "" && txtCBduyet.Text != "" && cbKhoVe.Text != "")
            {
                cmd.CommandText = "Duyet_TT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@macb", txtCBduyet.Text);
                cmd.Parameters.AddWithValue("@mave", cbKhoVe.Text);
                cmd.Parameters.AddWithValue("@ngayduyet", Convert.ToDateTime(NgayDuyet.Text));
                cmd.Parameters.AddWithValue("@sogiaytt", txtSoGiayTranhThu.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ĐÃ ĐƯỢC DUYỆT THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect.Close();

            }
            else
            {
                MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connect.Close();
            }
                
            
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            if(pn_tieudoan.Visible == true)
            {
                pn_tieudoan.Visible = false;
                int qs_cho = 0;
                for (int i = 0; i < dgv_DanhSachCho.RowCount; i++)
                {
                    qs_cho++;
                }
                quanso.Text = qs_cho.ToString();
                
            }
            else if(pn_tieudoan.Visible == false)
            {
                pn_tieudoan.Visible = true;
            
            } 
        }

        public void LoadDanhSachPheDuyet(string ma)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachHocVien_DangKy_DaDuyet";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", ma);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DSdaduyet.DataSource = dt;
            connect.Close();
            dgv_DSdaduyet.Columns["ID"].Frozen = dgv_DSdaduyet.Columns["MaHV"].Frozen = dgv_DSdaduyet.Columns["TenHV"].Frozen = true;
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string madv = c55_1.Text + "55";
            ma = 'c' + madv;
            LoadDanhSachPheDuyet(ma);
            int qs = 0;
            for (int i = 0; i < dgv_DSdaduyet.RowCount; i++)
            {
                qs++;
            }
            quanso.Text = qs.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string madv = c56_1.Text + "56";
            ma = 'c' + madv;
            LoadDanhSachPheDuyet(ma);
            int qs = 0;
            for (int i = 0; i < dgv_DSdaduyet.RowCount; i++)
            {
                qs++;
            }
            quanso.Text = qs.ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string madv = c57_1.Text + "57";
            ma = 'c' + madv;
            LoadDanhSachPheDuyet(ma);
            int qs = 0;
            for (int i = 0; i < dgv_DSdaduyet.RowCount; i++)
            {
                qs++;
            }
            quanso.Text = qs.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string madv = c58_1.Text + "58";
            ma = 'c' + madv;
            LoadDanhSachPheDuyet(ma);
            int qs = 0;
            for (int i = 0; i < dgv_DSdaduyet.RowCount; i++)
            {
                qs++;
            }
            quanso.Text = qs.ToString();
            
        }

        private void dgv_DanhSachCho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check nếu hàng được chọn có index hợp lệ
            {
                DataGridViewRow selectedRow = dgv_DanhSachCho.Rows[e.RowIndex];

                // Lấy thông tin từ các cột của hàng được chọn
                
                string mahv = dgv_DanhSachCho.Rows[index].Cells[1].Value.ToString();
                string ten = dgv_DanhSachCho.Rows[index].Cells[2].Value.ToString();
                // Tạo và hiển thị form mới
                TanSuat newForm = new TanSuat(mahv,ten);
                newForm.Show();
            }
        }

        private void dgv_Ve_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
