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
    public partial class ThuHoiVe : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;

        public ThuHoiVe(string ID, string MaHV,string TenHV, string MaVe)
        {
            TaiKhoanSQL tk = Globals.hientai;
            InitializeComponent();
            txtID.Text = ID;
            txtMaHV.Text = MaHV;
            txtTenHV.Text = TenHV;
            txtMaVe.Text = MaVe;
            txtDV.Text = tk.Tendangnhap;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Chắc chắn thu hồi?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Kiểm tra xem người dùng đã nhấn OK hay không
            if (result == DialogResult.OK)
            {
                try
                {
                    TaiKhoanSQL tk = Globals.hientai;
                    connect = new SqlConnection(tk.connectStr(tk));
                    connect.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "ThuHoi_Ve";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txtID.Text);
                    cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("VÉ " + txtMaVe.Text + " " + "ĐÃ THU HỒI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
                
        }
    }
}
