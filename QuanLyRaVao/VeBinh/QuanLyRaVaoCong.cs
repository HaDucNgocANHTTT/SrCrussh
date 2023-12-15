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

namespace QuanLyRaVao.VeBinh
{
    public partial class QuanLyRaVaoCong : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;


        int index = -1; // chi so chay tu 0
        public QuanLyRaVaoCong()
        {
            InitializeComponent();
            LoadDanhSachDaRa();
            LoadDanhSachDaVao();
        }

        private void QuanLyRaVaoCong_Load(object sender, EventArgs e)
        {
            LoadDanhSachPheDuyet();
        }
        public void LoadDanhSachDaVao()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSach_HocVien_DangKy_DaDuyet_DaVao_VeBinh";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachDaVao.DataSource = dt;
            connect.Close();
            dgv_DanhSachDaVao.Columns["ID_PheDuyet"].Frozen = dgv_DanhSachDaVao.Columns["MaHV"].Frozen = dgv_DanhSachDaVao.Columns["TenHV"].Frozen = true;
        }
        public void LoadDanhSachPheDuyet()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachHocVien_DangKy_DaDuyet_ChuaRa_VEBINH";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachPheDuyet.DataSource = dt;
            connect.Close();
            dgv_DanhSachPheDuyet.Columns["ID_PheDuyet"].Frozen = dgv_DanhSachPheDuyet.Columns["MaHV"].Frozen = dgv_DanhSachPheDuyet.Columns["TenHV"].Frozen = true;
        }
        public void LoadDanhSachDaRa()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachHocVien_DangKy_DaDuyet_DaRa_VEBINH";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachDaRa.DataSource = dt;
            connect.Close();
            dgv_DanhSachDaRa.Columns["ID_PheDuyet"].Frozen = dgv_DanhSachDaRa.Columns["MaHV"].Frozen = dgv_DanhSachDaRa.Columns["TenHV"].Frozen = true;
        }

        private void dgv_DanhSachPheDuyet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pn_Ra.Visible = true;
            index = e.RowIndex;
            if (index < 0)
                return;
            txtIDpheduyet.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[0].Value.ToString();
            txtMaHV.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[1].Value.ToString();
            txtHoTen.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[2].Value.ToString();
            txtCB.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[3].Value.ToString();
            txtCV.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[4].Value.ToString();
            txtDV.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[5].Value.ToString();
            txtHT.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[6].Value.ToString();
            txtTichKe.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[14].Value.ToString();
            txtGiayTranhThu.Text = dgv_DanhSachPheDuyet.Rows[index].Cells[15].Value.ToString();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            pn_Ra.Visible = false;
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Xác nhận ra ngoài?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                // Kiểm tra xem người dùng đã nhấn OK hay không
                if (result == DialogResult.OK)
                {
                    TaiKhoanSQL tk = Globals.hientai;
                    connect = new SqlConnection(tk.connectStr(tk));
                    connect.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "Ra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idpheduyet", txtIDpheduyet.Text);
                    cmd.Parameters.AddWithValue("@tgra", ThoiGianRa.Text);
                    cmd.Parameters.AddWithValue("@ngayra", Convert.ToDateTime(NgayRa.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(txtHoTen.Text + " " + txtDV.Text + " " + "ĐÃ RA NGOÀI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    pn_Ra.Visible = false;
                    LoadDanhSachDaRa();
                    LoadDanhSachPheDuyet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            pn_Ra.Visible = false;
        }

        private void dgv_DanhSachDaRa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pn_Vao.Visible = true;
            index = e.RowIndex;
            if (index < 0)
                return;
            txtIDtheodoi.Text = dgv_DanhSachDaRa.Rows[index].Cells[19].Value.ToString();
            txtID.Text = txtID_1.Text = dgv_DanhSachDaRa.Rows[index].Cells[0].Value.ToString();
            txtMaHVvao.Text = txtMaHV_1.Text = dgv_DanhSachDaRa.Rows[index].Cells[1].Value.ToString();
            txtHT_vao.Text=txtHT_1.Text = dgv_DanhSachDaRa.Rows[index].Cells[6].Value.ToString();
            txtTichKe_vao.Text = dgv_DanhSachDaRa.Rows[index].Cells[10].Value.ToString();
            txtGiayTranhThu_vao.Text = dgv_DanhSachDaRa.Rows[index].Cells[11].Value.ToString();
            txtTenHV.Text = dgv_DanhSachDaRa.Rows[index].Cells[2].Value.ToString();
            txtDV_1.Text = dgv_DanhSachDaRa.Rows[index].Cells[5].Value.ToString();

        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            pn_Vao.Visible = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {
            pn_DaVao.Visible = true;
        }

        private void guna2GradientCircleButton3_Click(object sender, EventArgs e)
        {
            pn_DaVao.Visible=false;
        }

        private void guna2GradientCircleButton4_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                DialogResult result = MessageBox.Show("Xác nhận đã vào?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                // Kiểm tra xem người dùng đã nhấn OK hay không
                if (result == DialogResult.OK)
                {
                    cmd.CommandText = "Vao";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@tgvao", ThoiGianVao.Text);
                    cmd.Parameters.AddWithValue("@ngayvao", Convert.ToDateTime(NgayVao.Text));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(txtMaHVvao.Text + " " + "XÁC NHẬN ĐÃ VÀO", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    pn_Vao.Visible = false;
                    pn_DaVao.Visible = true;
                    LoadDanhSachDaRa();
                    LoadDanhSachDaVao();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void guna2GradientCircleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                if(txtND.Text != "")
                {
                    cmd.CommandText = "Them_ViPham";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idtheodoi", txtIDtheodoi.Text);
                    cmd.Parameters.AddWithValue("@idpheduyet", txtID_1.Text);
                    cmd.Parameters.AddWithValue("@thoigianvipham", ThoiGianViPham.Text);
                    cmd.Parameters.AddWithValue("@ngayvipham", Convert.ToDateTime(NgayViPham.Text));
                    cmd.Parameters.AddWithValue("@noidung", txtND.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(txtTenHV.Text + " " + "VI PHẠM", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                }
                else
                {
                    MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có trong danh sách vi phạm");
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {
          
            DanhSachViPham vp = new DanhSachViPham();
            vp.Show();
        }

    }
}
