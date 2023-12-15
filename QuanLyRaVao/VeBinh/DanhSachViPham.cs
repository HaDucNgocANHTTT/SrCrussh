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
    public partial class DanhSachViPham : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;

        public DanhSachViPham()
        {
            InitializeComponent();
            LoadViPham();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadViPham()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachViPham";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_ViPham.DataSource = dt;
            connect.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
                
            
            
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            LoadViPham();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            txtTen.Text = txtDV.Text = null;
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_ViPham_TheoThang";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@month", txtThang.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_ViPham.DataSource = dt;
            connect.Close();
        }

        private void txtDV_TextChanged(object sender, EventArgs e)
        {
            txtTen.Text = txtThang.Text = null;
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_ViPham_TheoDonVi";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tendv", txtDV.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_ViPham.DataSource = dt;
            connect.Close();
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            txtDV.Text = txtThang.Text = null;
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_ViPham_TheoTen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ten", txtTen.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_ViPham.DataSource = dt;
            connect.Close();
        }
    }
}
