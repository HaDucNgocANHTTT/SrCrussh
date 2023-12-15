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

namespace QuanLyRaVao.Admin
{
    public partial class QuanLyTaiKhoan : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;


        int index = -1; // chi so chay tu 0
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            LoadTK();
        }

        public void LoadTK()
        {

            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Lay_TaiKhoan";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgvAcc.DataSource = dt;
            dgvAcc.Columns["Mật Khẩu"].Visible = false;
            dgvAcc.Columns[3].Visible = false;
            connect.Close();

        }

        private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            txtUser.Text = dgvAcc.Rows[index].Cells[0].Value.ToString();
            txtPass.Text = dgvAcc.Rows[index].Cells[1].Value.ToString();
            cbType.Text = dgvAcc.Rows[index].Cells[2].Value.ToString();
            if (cbType.Text == "ADMIN")
            {
                cbType.Enabled = false;
            }
            else
            {
                cbType.Enabled = true;
            }

        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (label3.Visible == txtDoi.Visible == btnDoi.Visible == label4.Visible == txtXN.Visible == true)
            {
                label3.Visible = txtDoi.Visible = btnDoi.Visible = label4.Visible = txtXN.Visible = false;
            }
            else if (label3.Visible == txtDoi.Visible == btnDoi.Visible == label4.Visible == txtXN.Visible == false)
            {
                label3.Visible = txtDoi.Visible = btnDoi.Visible = label4.Visible = txtXN.Visible = true;
            }
        }

        private void cbHienThi_CheckedChanged(object sender, EventArgs e)
        { 
            if (cbHienThi.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text = dgvAcc.Rows[index].Cells[3].Value.ToString();
            }
            if (!cbHienThi.Checked)
            {
                txtPass.UseSystemPasswordChar = true;
                txtPass.Text = dgvAcc.Rows[index].Cells[1].Value.ToString();
            }
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            if(txtDoi.Text!=""&&txtXN.Text!=null)
            {
                if(txtXN.Text == txtDoi.Text)
                {
                    TaiKhoanSQL tk = Globals.hientai;
                    connect = new SqlConnection(tk.connectStr(tk));
                    connect.Open();
                    //string sqlStr = "alter login " + txtUser.Text + " with password ='" + txtDoi.Text + "'";
                    //cmd = new SqlCommand(sqlStr, connect);
                    //cmd.ExecuteNonQuery();
                    cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "Doi_MatKhau";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaiKhoan", txtUser.Text);
                    cmd.Parameters.AddWithValue("@MatKhauMoi", txtDoi.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    label3.Visible = txtDoi.Visible = btnDoi.Visible = label4.Visible = txtXN.Visible = false;
                    LoadTK();
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu chưa đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connect.Close();
                }
               
            }
            else
            {
                MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (pnThem.Visible == false)
            {
                pnThem.Visible = true;
            }
            else if (pnThem.Visible == true)
            {
                pnThem.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnThem.Visible = false;
        }

        private void btnSua_MouseHover(object sender, EventArgs e)
        {
            btnSua.BackColor = Color.Blue;
        }

        private void btnSua_MouseLeave(object sender, EventArgs e)
        {
            btnSua.BackColor = Color.MediumSpringGreen;
        }

        private void btnThem_MouseHover(object sender, EventArgs e)
        {
            btnThem.BackColor = Color.Blue;
        }

        private void btnThem_MouseLeave(object sender, EventArgs e)
        {
            btnThem.BackColor = Color.MediumSpringGreen;
        }

        private void btnQL_MouseHover(object sender, EventArgs e)
        {
            btnQL.BackColor = Color.Red;
        }

        private void btnQL_MouseLeave(object sender, EventArgs e)
        {
            btnQL.BackColor = Color.MediumSpringGreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                if (txtUser1.Text != "" && txtPass1.Text != ""&& cbTK.Text != "")
                {
                    TaiKhoanSQL tk = Globals.hientai;
                    connect = new SqlConnection(tk.connectStr(tk));
                    connect.Open();
                    //string sqlStr = "create login " + txtUser1.Text + " with password ='" + txtPass1.Text + "';" +
                    //                "create user " + txtUser1.Text + " for login " + txtUser1.Text + ";";
                    //cmd = new SqlCommand(sqlStr, connect);
                    //cmd.ExecuteNonQuery();
                    cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "Them_TaiKhoan";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TenDN", txtUser1.Text);
                    cmd.Parameters.AddWithValue("@MK", txtPass1.Text);
                    switch (cbTK.Text)
                    {
                        case "CHỈ HUY ĐƠN VỊ":
                            cmd.Parameters.AddWithValue("@Q", "1");
                            break;
                        case "VỆ BINH":
                            cmd.Parameters.AddWithValue("@Q", "2");
                            break;
                        case "CHỈ HUY TIỂU ĐOÀN":
                            cmd.Parameters.AddWithValue("@Q", "3");
                            break;
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connect.Close();
                    LoadTK();
                    pnThem.Visible = false;
                }
                else
                {
                    MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connect.Close();
                }
            
        }

        private void cbHienThi1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThi1.Checked)
            {
                txtPass1.UseSystemPasswordChar = false;
            }
            if (!cbHienThi1.Checked)
            {
                txtPass1.UseSystemPasswordChar = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Xoa_TaiKhoan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenTK", txtUser.Text);
                cmd.ExecuteNonQuery();
                connect.Close();
                LoadTK();
            }
        }

        private void vp_Click(object sender, EventArgs e)
        {
            
            VanPhong vp = new VanPhong();
            vp.ShowDialog();
        }

        private void cbTK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
