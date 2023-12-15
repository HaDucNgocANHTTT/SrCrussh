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
    
    public partial class TanSuat : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;
        string mahocvien;
        string tenhocvien;
        public TanSuat(string mahv, string ten)
        {
            InitializeComponent();
            LoadLichSu(mahv);
            mahocvien = mahv;
            tenhocvien = ten;
            tenHV.Text = ten;
        }
        public void LoadLichSu(string mahv)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "LichSuCaNhan";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mahv", mahv);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgvLS.DataSource = dt;
            connect.Close();
            dgvLS.Columns["ID_PheDuyet"].Visible = false;
            solan.Text = dgvLS.RowCount.ToString();
        }

        public void LoadLichSu_thang(string mahv, int thang)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "LichSuCaNhan_Thang";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mahv", mahv);
            cmd.Parameters.AddWithValue("@thang", thang);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgvLS.DataSource = dt;
            connect.Close();
            dgvLS.Columns["ID_PheDuyet"].Visible = false;
            solan.Text = dgvLS.RowCount.ToString();
        }

        private void cbThang_TextChanged(object sender, EventArgs e)
        {
            if(cbThang.Text == "ALL")
            {
                LoadLichSu(mahocvien);
            }
            else
            {
                LoadLichSu_thang(mahocvien,Convert.ToInt32(cbThang.Text));
            }
        }
    }
}
