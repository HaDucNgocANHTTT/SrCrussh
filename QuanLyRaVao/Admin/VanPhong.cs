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

namespace QuanLyRaVao.Admin
{
    public partial class VanPhong : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;

        string tieude = "";
        int index = -1; // chi so chay tu 0
        public VanPhong()
        {
            InitializeComponent();
            LoadDanhSachCanBo();
            LoadDanhSachDangKy();
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
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
            cmd.Parameters.AddWithValue("@madv", "vp");
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachCanBo.DataSource = dt;
            dgv_DanhSachCanBo.Columns[4].Visible = false;
            connect.Close();
        }

        public void LoadDanhSachDangKy()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSach_DeNghi_VanPhong";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachCho.DataSource = dt;
            connect.Close();
           dgv_DanhSachCho.Columns["ID"].Frozen = dgv_DanhSachCho.Columns["MaHV"].Frozen = dgv_DanhSachCho.Columns["TenHV"].Frozen = true;
        }
        private void VanPhong_Load(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;

            
        }

        private void dgv_DanhSachCanBo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            txtMaCB.Text = dgv_DanhSachCanBo.Rows[index].Cells[0].Value.ToString();
        }

        private void dgv_DanhSachCho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            txtID.Text = dgv_DanhSachCho.Rows[index].Cells[0].Value.ToString();
            txtMaHV.Text = dgv_DanhSachCho.Rows[index].Cells[1].Value.ToString();
            txtDV.Text = dgv_DanhSachCho.Rows[index].Cells[5].Value.ToString();
            txtHT.Text = dgv_DanhSachCho.Rows[index].Cells[6].Value.ToString();
            txtKV.Text = dgv_DanhSachCho.Rows[index].Cells[7].Value.ToString();
            LoadVe(dgv_DanhSachCho.Rows[index].Cells[5].Value.ToString());
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            string Numrd;
            Numrd = rd.Next(10000, 1000000).ToString();
            string SoGiayTT =  Numrd+"/GNP-HV";
            txtGiayTranhThu.Text = SoGiayTT;
        }

        public void LoadVe(string a)
        {
           
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Ve_ChuaPhat_VP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dv", a);
                SqlDataReader rd = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);
                cbKhoVe.DataSource = dt;
                cbKhoVe.DisplayMember = "SoGiayRaVao";
                cbKhoVe.ValueMember = "";
                connect.Close();
            
        }

        private void cbKhoVe_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtHT_TextChanged(object sender, EventArgs e)
        {
            if (txtHT.Text == "Công Tác" || txtHT.Text == "")
            {
                txtGiayTranhThu.Text = "";
            }
            else if (txtHT.Text == "Tranh Thủ")
            {
                Random rd = new Random();
                string Numrd;
                Numrd = rd.Next(10000, 1000000).ToString();
                string SoGiayTT = Numrd + "/GNP-HV";
                txtGiayTranhThu.Text = SoGiayTT;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "" && txtMaCB.Text != "")
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Duyet_TT_CT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@macb", txtMaCB.Text);
                cmd.Parameters.AddWithValue("@dv", txtDV.Text);
                cmd.Parameters.AddWithValue("@sove", cbKhoVe.Text);
                cmd.Parameters.AddWithValue("@ngayduyet", Convert.ToDateTime(NgayDuyet.Text));
                cmd.Parameters.AddWithValue("@tenht", txtHT.Text);
                cmd.Parameters.AddWithValue("@sogiaytt", txtGiayTranhThu.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ĐÃ ĐƯỢC DUYỆT THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect.Close();
                LoadDanhSachDangKy();
            }
            else
            {
                MessageBox.Show("Thiếu thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label35_Click(object sender, EventArgs e)
        {
            DanhSachViPham vp = new DanhSachViPham();
            vp.Show();
        }

        public void ImportExcel(DataTable dataTable, string sheetname, string title)
        {
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oExcel.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;

            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "N1");
            head.MergeCells = true;
            head.Value2 = title;
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "25";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range c1 = oSheet.get_Range("A3", "A3");
            c1.Value2 = "ID";
            c1.ColumnWidth = 10;

            Microsoft.Office.Interop.Excel.Range c2 = oSheet.get_Range("B3", "B3");
            c2.Value2 = "Mã học viên";
            c2.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range c3 = oSheet.get_Range("C3", "C3");
            c3.Value2 = "Tên học viên";
            c3.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range("D3", "D3");
            c4.Value2 = "Cấp bậc";
            c4.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range c5 = oSheet.get_Range("E3", "E3");
            c5.Value2 = "Chức vụ";
            c5.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range c6 = oSheet.get_Range("F3", "F3");
            c6.Value2 = "Đơn vị";
            c6.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range c7 = oSheet.get_Range("G3", "G3");
            c7.Value2 = "Hình thức";
            c7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range c8 = oSheet.get_Range("H3", "H3");
            c8.Value2 = "Khu vực";
            c8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range c9 = oSheet.get_Range("I3", "I3");
            c9.Value2 = "Thời gian đi";
            c9.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range c10 = oSheet.get_Range("J3", "J3");
            c10.Value2 = "Ngày đi";
            c10.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range c11 = oSheet.get_Range("K3", "K3");
            c11.Value2 = "Thời gian về";
            c11.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range c12 = oSheet.get_Range("L3", "L3");
            c12.Value2 = "Ngày về";
            c12.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range c13 = oSheet.get_Range("M3", "M3");
            c13.Value2 = "Địa điểm";
            c13.ColumnWidth = 25;

            Microsoft.Office.Interop.Excel.Range c14 = oSheet.get_Range("N3", "N3");
            c14.Value2 = "Lý do";
            c14.ColumnWidth = 35;

            Microsoft.Office.Interop.Excel.Range rowhead = oSheet.get_Range("A3", "N3");
            rowhead.Font.Bold = true;

            rowhead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            rowhead.Interior.ColorIndex = 6;
            rowhead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            int rowStart = 4;
            int colStart = 1;
            int rowEnd = rowStart + dataTable.Rows.Count - 1;
            int colEnd = dataTable.Columns.Count;

            Microsoft.Office.Interop.Excel.Range cl1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, colStart];

            Microsoft.Office.Interop.Excel.Range cl2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, colEnd];

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(cl1, cl2);

            range.Value2 = arr;

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            oSheet.get_Range(cl1, cl2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("ID");
            DataColumn col2 = new DataColumn("MaHV");
            DataColumn col3 = new DataColumn("TenHV");
            DataColumn col4 = new DataColumn("TenCB");
            DataColumn col5 = new DataColumn("TenCV");
            DataColumn col6 = new DataColumn("TenDV");
            DataColumn col7 = new DataColumn("TenHT");
            DataColumn col8 = new DataColumn("TenKV");
            DataColumn col9 = new DataColumn("ThoiGianDi");
            DataColumn col10 = new DataColumn("NgayDi");
            DataColumn col11 = new DataColumn("ThoiGianVe");
            DataColumn col12 = new DataColumn("NgayVe");
            DataColumn col13 = new DataColumn("DiaDiem");
            DataColumn col14 = new DataColumn("LyDo");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);
            dataTable.Columns.Add(col9);
            dataTable.Columns.Add(col10);
            dataTable.Columns.Add(col11);
            dataTable.Columns.Add(col12);
            dataTable.Columns.Add(col13);
            dataTable.Columns.Add(col14);

            foreach (DataGridViewRow dgvRow in dgv_DanhSachCho.Rows)
            {
                DataRow dtRow = dataTable.NewRow();
                dtRow[0] = dgvRow.Cells[0].Value;
                dtRow[1] = dgvRow.Cells[1].Value;
                dtRow[2] = dgvRow.Cells[2].Value;
                dtRow[3] = dgvRow.Cells[3].Value;
                dtRow[4] = dgvRow.Cells[4].Value;
                dtRow[5] = dgvRow.Cells[5].Value;
                dtRow[6] = dgvRow.Cells[6].Value;
                dtRow[7] = dgvRow.Cells[7].Value;
                dtRow[8] = dgvRow.Cells[8].Value;
                dtRow[9] = dgvRow.Cells[9].Value;
                dtRow[10] = dgvRow.Cells[10].Value;
                dtRow[11] = dgvRow.Cells[11].Value;
                dtRow[12] = dgvRow.Cells[12].Value;
                dtRow[13] = dgvRow.Cells[13].Value;

                dataTable.Rows.Add(dtRow);
            }

            ImportExcel(dataTable, "Danh sach", "DANH SÁCH HỌC VIÊN ĐĂNG KÝ "+tieude);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tieude = "TRANH THỦ KHU VỰC MIỀN NAM";
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSach_DeNghi_VanPhong_TTMN";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachCho.DataSource = dt;
            connect.Close();
            dgv_DanhSachCho.Columns["ID"].Frozen = dgv_DanhSachCho.Columns["MaHV"].Frozen = dgv_DanhSachCho.Columns["TenHV"].Frozen = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tieude = "CÔNG TÁC";
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSach_DeNghi_VanPhong_CT";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachCho.DataSource = dt;
            connect.Close();
            dgv_DanhSachCho.Columns["ID"].Frozen = dgv_DanhSachCho.Columns["MaHV"].Frozen = dgv_DanhSachCho.Columns["TenHV"].Frozen = true;
        }
    }
}
