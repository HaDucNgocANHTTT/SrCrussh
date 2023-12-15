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
    public partial class LichSu : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;

        public LichSu()
        {
            InitializeComponent();
            LoadLichSu();
            TaiKhoanSQL tk = Globals.hientai;
            string ten = "ĐẠI ĐỘI " + tk.Tendangnhap.Substring(1, 3);
            c_bb.Text = c_bb_1.Text = ten;
            LoadViPham();
        }
        public void LoadLichSu()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "LichSu_RaNgoai";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_LichSu.DataSource = dt;
            connect.Close();
            dgv_LichSu.Columns["ID_PheDuyet"].Visible = false;
        }

        public void LoadViPham()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachViPham_DaiDoi";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_ViPham.DataSource = dt;
            connect.Close();
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            pn_vipham.Visible = true;
        }



        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtTen_LS_TextChanged(object sender, EventArgs e)
        {
            txtThang_LS.Text = null;
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_LichSu_RaNgoai_TheoTen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            cmd.Parameters.AddWithValue("@ten", txtTen_LS.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_LichSu.DataSource = dt;
            connect.Close();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            pn_vipham.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadLichSu();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            txtTen_LS.Clear();
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_LichSu_RaNgoai_TheoThang";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            cmd.Parameters.AddWithValue("@month", txtThang_LS.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_LichSu.DataSource = dt;
            connect.Close();
        }

        private void txtTen_VP_TextChanged(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_DanhSachViPham_DaiDoi_TheoTen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            cmd.Parameters.AddWithValue("@ten", txtTen_VP.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_ViPham.DataSource = dt;
            connect.Close();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_DanhSachViPham_DaiDoi_TheoThang";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            cmd.Parameters.AddWithValue("@month", txtThang.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_ViPham.DataSource = dt;
            connect.Close();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadViPham();
        }
    }
}
