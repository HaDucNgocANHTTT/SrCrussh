using QuanLyRaVao.Admin;
using QuanLyRaVao.ChiHuyDonVi;
using QuanLyRaVao.ChiHuyTieuDoan;
using QuanLyRaVao.Data;
using QuanLyRaVao.VeBinh;
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

namespace QuanLyRaVao
{
    public partial class Form1 : Form
    {
        public static string TaiKhoan = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có chắc chắn muốn thoát? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string connStr = @"Server=DESKTOP-79I4RNR\MSSQLSERVER01;Database=QuanLyRaVao;User Id=ducngoc_vp;Password=1;";
            TaiKhoanSQL taiKhoanSQL = new TaiKhoanSQL();
            taiKhoanSQL.Tendangnhap = txtUserName.Text;
            taiKhoanSQL.Matkhau = txtPassword.Text;
            Globals.hientai = taiKhoanSQL;
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "KiemTra_Tai_Khoan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TaiKhoan", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Mat_Khau", txtPassword.Text);
                TaiKhoan = txtUserName.Text;
                object kq = cmd.ExecuteScalar();      //lay ket qua tra ve cua Quyen (0,1)
                int code = Convert.ToInt32(kq);
                if (code == 0)
                {
                    MessageBox.Show("Bạn đã đăng nhập với tư cách là [ ADMIN ] vào hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    QuanLyTaiKhoan a = new QuanLyTaiKhoan();
                    a.ShowDialog();
                    this.Show();
                }
                else if (code == 1)
                {
                    MessageBox.Show("Bạn đã đăng nhập với tư cách là [ CHỈ HUY ĐƠN VỊ ] vào hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    QuanLyHeThong a = new QuanLyHeThong();
                    a.ShowDialog();
                    this.Show();
                }
                else if (code == 2)
                {
                    MessageBox.Show("Bạn đã đăng nhập với tư cách là [ VỆ BINH ] vào hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    QuanLyRaVaoCong a = new QuanLyRaVaoCong();
                    a.ShowDialog();
                    this.Show();
                }
                else if (code == 3)
                {
                    MessageBox.Show("Bạn đã đăng nhập với tư cách là [ CHỈ HUY TIỂU ĐOÀN ] vào hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    HeThongPheDuyet_DeNghi a = new HeThongPheDuyet_DeNghi();
                    a.ShowDialog();
                    this.Show();
                }
                else if (code == 4)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                    txtUserName.Focus();
                }
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbHienThi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThi.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            if (!cbHienThi.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
