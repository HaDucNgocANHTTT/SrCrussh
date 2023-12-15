using HoSoNhanSu.Security;
using QuanLyRaVao.ChiHuyTieuDoan;
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

namespace QuanLyRaVao.ChiHuyDonVi
{
    public partial class QuanLyHeThong : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;

        int qso_thieu;
        int index = -1; // chi so chay tu 0

        private void ReloadFormCha()
        {
            // Xử lý tải lại form cha ở đây
            // Ví dụ: Tải lại dữ liệu hoặc làm bất kỳ việc cần thiết khác
            // Sau khi xử lý xong, form cha sẽ load lại
            this.Controls.Clear(); // Xóa tất cả các controls trên form cha
            InitializeComponent(); // Khởi tạo lại controls và form cha
            LoadDanhSachHocVien();
            LoadDanhSachCanBo();
            LoadKhoVe();
            LoadHinhThucRaNgoai();
            LoadHinhThucRaNgoai1();
            int qs = 0;
            for (int i = 0; i < dgv_DanhSachHocVien.RowCount; i++)
            {
                qs++;
            }
            int qso_hientai = qs - qso_thieu;
            quanso.Text = qso_hientai.ToString() + " / " + qs.ToString();
            LoadDaRa();
        }
        public QuanLyHeThong()
        {
            
            InitializeComponent();
            LoadDanhSachHocVien();
            LoadDanhSachCanBo();
            
            LoadDaRa();
        }

        public void LoadDaRa()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "QuanSo_RaNgoai_DaiDoi";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            qso_thieu = code;
            DaRa.Text = code.ToString();
            connect.Close();
        }
        public void LoadDanhSachHocVien()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            tendaidoi.Text = tk.Tendangnhap.Substring(1,3);
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachHocVien";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachHocVien.DataSource = dt;
            connect.Close();
        }

        public void LoadLichSu()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "LichSuCaNhan";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mahv", txtMaHV.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgvLS.DataSource = dt;
            connect.Close();
            LSten.Text = txtHoTenDK.Text;
            solan.Text = dgvLS.RowCount.ToString();
            dgvLS.Columns["ID_PheDuyet"].Visible = false;
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
            dgv_DanhSachCanBo.DataSource = dt;
            dgv_DanhSachCanBo.Columns[4].Visible = false;
            connect.Close();
        }

        public void LoadKhoVe()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Kho_Ve";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_KhoVe.DataSource = dt;
            connect.Close();
        }

        public void LoadHinhThucRaNgoai()
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "HinhThuc_RaNgoai";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);
                cbHT.DataSource = dt;
                cbHT.DisplayMember = "TenHT";
                cbHT.ValueMember = "";


                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadHinhThucRaNgoai1()
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "HinhThuc_RaNgoai";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rd = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);
                

                LSht.DataSource = dt;
                LSht.DisplayMember = "TenHT";
                LSht.ValueMember = "";

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tendaidoi_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "TimKiem_HocVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ten", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
                SqlDataReader rd = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);
                dgv_DanhSachHocVien.DataSource = dt;
                connect.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_DanhSachHocVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pnLichSu.Visible=pn_DangKy.Visible = true;
            index = e.RowIndex;
            if (index < 0)
                return;
            txtMaHV.Text = dgv_DanhSachHocVien.Rows[index].Cells[0].Value.ToString();
            txtHoTenDK.Text = dgv_DanhSachHocVien.Rows[index].Cells[1].Value.ToString();
            txtCB.Text = dgv_DanhSachHocVien.Rows[index].Cells[2].Value.ToString();
            txtCV.Text = dgv_DanhSachHocVien.Rows[index].Cells[3].Value.ToString();
            txtDV.Text = dgv_DanhSachHocVien.Rows[index].Cells[4].Value.ToString();
            LoadLichSu();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            pnLichSu.Visible=pn_DangKy.Visible = false;
        }

        private void QuanLyHeThong_Load(object sender, EventArgs e)
        {
            LoadKhoVe();
            LoadHinhThucRaNgoai();
            LoadHinhThucRaNgoai1();
            int qs = 0;
            for (int i = 0; i < dgv_DanhSachHocVien.RowCount; i++)
            {
                qs++;
            }
            int qso_hientai = qs - qso_thieu;
            quanso.Text = qso_hientai.ToString() +" / "+ qs.ToString();
        }
        
        public void LoadHeThong()
        {
            LoadKhoVe();
            LoadHinhThucRaNgoai();
            LoadHinhThucRaNgoai1();
            LoadDaRa();
            int qs = 0;
            for (int i = 0; i < dgv_DanhSachHocVien.RowCount; i++)
            {
                qs++;
            }
            int qso_hientai = qs - qso_thieu;
            quanso.Text = qso_hientai.ToString() + " / " + qs.ToString();
        }
        private void cbHT_TextChanged(object sender, EventArgs e)
        {
            if (cbHT.Text == "Tranh Thủ")
            {
                KhuVuc.Visible = cbKV.Visible = true;
            }
            else
            {
                KhuVuc.Visible = cbKV.Visible = false;
                cbKV.Text = null;
            }
            
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                if(ThoiGianDi.Text!=""&& ThoiGianVe.Text!=""&& txtLyDo.Text!="")
                {
                    DialogResult result = MessageBox.Show("Chắc chắn đăng ký?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    // Kiểm tra xem người dùng đã nhấn OK hay không
                    if (result == DialogResult.OK)
                    {
                        cmd.CommandText = "DangKy";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mahv", txtMaHV.Text);
                        cmd.Parameters.AddWithValue("@tenht", cbHT.Text);
                        cmd.Parameters.AddWithValue("@tgdi", ThoiGianDi.Text);
                        cmd.Parameters.AddWithValue("@ngaydi", Convert.ToDateTime(NgayDi.Text));
                        cmd.Parameters.AddWithValue("@tgve", ThoiGianVe.Text);
                        cmd.Parameters.AddWithValue("@ngayve", Convert.ToDateTime(NgayVe.Text));
                        cmd.Parameters.AddWithValue("@lydo", txtLyDo.Text);
                        cmd.Parameters.AddWithValue("@diadiem", txtDiaDiem.Text);
                        cmd.Parameters.AddWithValue("@tenmien", cbKV.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        connect.Close();
                        LoadKhoVe();
                        pnLichSu.Visible = pn_DangKy.Visible = false;
                    }
                   
                }
                else
                {
                    MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connect.Close();
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DanhSachDangKy ql;
        private void button1_Click(object sender, EventArgs e)
        {
            ql = new DanhSachDangKy();
            ql.TopLevel = false;
            ql.FormBorderStyle = FormBorderStyle.None;
            ql.WindowState = FormWindowState.Maximized;
            pn_Cha.Controls.Add(ql);
            ql.Dock = DockStyle.Fill;
            pn_Cha.Tag = ql;
            ql.BringToFront();
            ql.FormClosed += DanhSachDangKy_FormClosed;
            ql.Show();
            button2.Enabled = button3.Enabled = false;  
        }

        private void DanhSachDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            ql.Dispose();
            ReloadFormCha();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            LoadKhoVe();
        }

        private LichSu ql3;
        private void button3_Click(object sender, EventArgs e)
        {
            ql3 = new LichSu();
            ql3.TopLevel = false;
            ql3.FormBorderStyle = FormBorderStyle.None;
            ql3.WindowState = FormWindowState.Maximized;
            pn_Cha.Controls.Add(ql3);
            ql3.Dock = DockStyle.Fill;
            pn_Cha.Tag = ql3;
            ql3.BringToFront();
            ql3.FormClosed += LichSu_FormClosed;
            ql3.Show();
            button1.Enabled = button2.Enabled = false;

        }

        private void LichSu_FormClosed(object sender, FormClosedEventArgs e)
        {
            ql3.Dispose();
            ReloadFormCha();
        }

        private DanhSachPheDuyet ql2;
        private void button2_Click(object sender, EventArgs e)
        {
            ql2 = new DanhSachPheDuyet();
            ql2.TopLevel = false;
            ql2.FormBorderStyle = FormBorderStyle.None;
            ql2.WindowState = FormWindowState.Maximized;
            pn_Cha.Controls.Add(ql2);
            ql2.Dock = DockStyle.Fill;
            pn_Cha.Tag = ql2;
            ql2.BringToFront();
            ql2.FormClosed += DanhSachPheDuyet_FormClosed;
            ql2.Show();
            button1.Enabled = button3.Enabled = false;
        }

        private void DanhSachPheDuyet_FormClosed(object sender, FormClosedEventArgs e)
        {
            ql2.Dispose();
            ReloadFormCha();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            LoadHeThong();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Loc_LichSuCaNhan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mahv", txtMaHV.Text);
                cmd.Parameters.AddWithValue("@tenht", LSht.Text);
                cmd.Parameters.AddWithValue("@thang", LSthang.Text);
                SqlDataReader rd = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);
                dgvLS.DataSource = dt;
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            solan.Text = dgvLS.RowCount.ToString();
        }

        private void DaRa_Click(object sender, EventArgs e)
        {

        }
    }
}
