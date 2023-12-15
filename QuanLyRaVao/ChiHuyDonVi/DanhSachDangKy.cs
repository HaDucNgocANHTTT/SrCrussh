using QuanLyRaVao.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyRaVao.ChiHuyTieuDoan
{
    public partial class DanhSachDangKy : Form
    {
        private SqlConnection connect;
        private SqlCommand cmd;
        private DataTable dt;


        int index = -1; // chi so chay tu 0
        int index1 = -1;
        public DanhSachDangKy()
        {
            InitializeComponent();
            LoadDanhSachDangKy();
            LoadDanhSachCanBo();
            LoadQuanSo();
        }

        private void DanhSachDangKy_Load(object sender, EventArgs e)
        {
            LoadVe();
        }

        public void LoadQuanSo()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "QuanSo_DangKy";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            object kq = cmd.ExecuteScalar();
            int code = Convert.ToInt32(kq);
            qs.Text = code.ToString();
            connect.Close();
        }

        public void LoadDanhSachDangKy()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "DanhSachHocVien_DangKy";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachDangKy.DataSource = dt;
            connect.Close();
            dgv_DanhSachDangKy.Columns["ID"].Frozen = dgv_DanhSachDangKy.Columns["MaHV"].Frozen = dgv_DanhSachDangKy.Columns["TenHV"].Frozen = true;
            dgv_DanhSachDangKy.Columns["ID"].Visible = false;
        }
        public void LoadDanhSachCanBo()
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            daidoi.Text = tk.Tendangnhap;
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

        public void LoadVe()
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Ve_ChuaPhat";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
                SqlDataReader rd = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(rd);
                cbKhoVe.DataSource = dt;
                cbKhoVe.DisplayMember = "SoGiayRaVao";
                cbKhoVe.ValueMember = "";
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                LoadDanhSachDangKy();
                MessageBox.Show("Xóa thành công !!", "Thông báo");
            }
        }

        private void dgv_DanhSachDangKy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            if (index < 0)
                return;
            txtID.Text = dgv_DanhSachDangKy.Rows[index].Cells[0].Value.ToString();
            txtTenHV.Text = dgv_DanhSachDangKy.Rows[index].Cells[2].Value.ToString();
            txtHT.Text = dgv_DanhSachDangKy.Rows[index].Cells[6].Value.ToString();
            txtKV.Text = dgv_DanhSachDangKy.Rows[index].Cells[7].Value.ToString();

            if (dgv_DanhSachDangKy.Rows[index].Cells["TenHT"].Value.ToString() == "Tranh Thủ" || dgv_DanhSachDangKy.Rows[index].Cells["TenHT"].Value.ToString() == "Công Tác")
            {
                guna2GradientCircleButton2.Visible = false;
            }
            else
            {
                guna2GradientCircleButton2.Visible = true;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanSQL tk = Globals.hientai;
                connect = new SqlConnection(tk.connectStr(tk));
                connect.Open();
                cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandText = "Duyet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@macb", txtCBduyet.Text);
                cmd.Parameters.AddWithValue("@sove", cbKhoVe.Text);
                cmd.Parameters.AddWithValue("@ngayduyet", Convert.ToDateTime(NgayDuyet.Text));
                cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ĐÃ ĐƯỢC DUYỆT THÀNH CÔNG", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thiếu thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgv_DanhSachCanBo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dgv_DanhSachCanBo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index1 = e.RowIndex;
            if (index1 < 0)
                return;
            txtCBduyet.Text = dgv_DanhSachCanBo.Rows[index1].Cells[0].Value.ToString();
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "Loc_DanhSachDangKy_TheoTen";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            cmd.Parameters.AddWithValue("@ten", txtTen.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachDangKy.DataSource = dt;
            connect.Close();
            dgv_DanhSachDangKy.Columns["ID"].Frozen = dgv_DanhSachDangKy.Columns["MaHV"].Frozen = dgv_DanhSachDangKy.Columns["TenHV"].Frozen = true;

        }

        private void txtTK_HT_TextChanged(object sender, EventArgs e)
        {
            TaiKhoanSQL tk = Globals.hientai;
            connect = new SqlConnection(tk.connectStr(tk));
            connect.Open();
            cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "LocDanhSachCho_theoHinhThuc";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@madv", tk.Tendangnhap);
            cmd.Parameters.AddWithValue("@ht", txtTK_HT.Text);
            SqlDataReader rd = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(rd);
            dgv_DanhSachDangKy.DataSource = dt;
            connect.Close();
            dgv_DanhSachDangKy.Columns["ID"].Frozen = dgv_DanhSachDangKy.Columns["MaHV"].Frozen = dgv_DanhSachDangKy.Columns["TenHV"].Frozen = true;
            qs.Text = dgv_DanhSachDangKy.RowCount.ToString();
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
            c7.ColumnWidth = 30;

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

            foreach (DataGridViewRow dgvRow in dgv_DanhSachDangKy.Rows)
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

            ImportExcel(dataTable, "Danh sach", "DANH SÁCH HỌC VIÊN ĐĂNG KÝ ");
        }

        private void DanhSachDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true; // Chuyển sang in ngang
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // Hiển thị trước khi in
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            // Các chuỗi cần in
            TaiKhoanSQL tk = Globals.hientai;
            string tieuDoan = "TIỂU ĐOÀN 1";
            string daidoi = "ĐẠI ĐỘI " + tk.Tendangnhap.Substring(1, 3);
            string conghoa = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
            string doclap = "Độc lập - Tự do - Hạnh phúc";
            string tieuDe = "DANH SÁCH ĐĂNG KÝ";
            string chihuy = "CHỈ HUY ĐƠN VỊ";
            string chihuy1 = "CHỈ HUY TIỂU ĐOÀN";
            // Thiết lập font cho các phần in
            Font tieuDoanFont = new Font("Arial", 14, FontStyle.Bold);
            Font conghoaFont = new Font("Arial", 14, FontStyle.Bold);
            Font daidoiFont = new Font("Arial", 13, FontStyle.Bold);
            Font doclapFont = new Font("Arial", 13, FontStyle.Bold);
            Font tieuDeFont = new Font("Arial", 16, FontStyle.Bold);
            Font chukyFont = new Font("Arial", 7);

            // Vẽ các chuỗi trên trang in
            e.Graphics.DrawString(tieuDoan, tieuDoanFont, Brushes.Black, 60, 50);
            e.Graphics.DrawString(daidoi, daidoiFont, Brushes.Black, 72, 80);
            e.Graphics.DrawString(conghoa, conghoaFont, Brushes.Black, e.PageBounds.Width - 450, 50);
            e.Graphics.DrawString(doclap, doclapFont, Brushes.Black, e.PageBounds.Width - 380, 80);
            e.Graphics.DrawString(tieuDe, tieuDeFont, Brushes.Black, (e.PageBounds.Width - e.Graphics.MeasureString(tieuDe, tieuDeFont).Width) / 2, 140);
            
            // Vẽ DataGridView (tương tự như trước)
            // ...
            int[] selectedColumns = { 1, 2,5,6,7,8,9,10,11,12,13 }; // Chọn các cột cần in theo index (đây là ví dụ)

            int rowCount = dgv_DanhSachDangKy.RowCount;
            float rowHeight = 25; // Chiều cao của mỗi dòng
             // Điều chỉnh giá trị của trục X để thay đổi vị trí bắt đầu của bảng
            float startY = 180; // Điều chỉnh giá trị của trục Y để thay đổi vị trí bắt đầu của bảng

            // Vẽ dữ liệu từ DataGridView ra trang in cho các cột đã chọn
            for (int i = 0; i < rowCount; i++)
            {
                float currentY = startY + (i * rowHeight); // Tính vị trí dòng
                float startX = 60;
                for (int j = 0; j < selectedColumns.Length; j++)
                {
                    int columnIndex = selectedColumns[j];
                    string cellValue = "";

                    // Kiểm tra xem ô dữ liệu có phải là kiểu DateTime không
                    if (dgv_DanhSachDangKy.Rows[i].Cells[columnIndex].Value is DateTime)
                    {
                        // Định dạng lại dữ liệu ngày giờ theo định dạng mong muốn
                        DateTime dateTimeValue = (DateTime)dgv_DanhSachDangKy.Rows[i].Cells[columnIndex].Value;
                        cellValue = dateTimeValue.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        // Lấy dữ liệu không phải là kiểu DateTime
                        cellValue = dgv_DanhSachDangKy.Rows[i].Cells[columnIndex].Value.ToString();
                    }

                    // Đo chiều rộng thực của dữ liệu cần vẽ
                    SizeF cellSize = e.Graphics.MeasureString(cellValue, chukyFont);

                    // Vẽ dữ liệu ô sao cho độ dài của ô tương đương với độ dài của dữ liệu
                    e.Graphics.DrawString(cellValue, chukyFont, Brushes.Black, startX, currentY + ((rowHeight - cellSize.Height)/2));

                    startX += dgv_DanhSachDangKy.Columns[columnIndex].Width; // Di chuyển sang cột tiếp theo
                }

                startX = 100; // Đặt lại vị trí bắt đầu cho hàng mới

            }
            e.Graphics.DrawString(chihuy, tieuDoanFont, Brushes.Black, e.PageBounds.Width - 350, startY + rowCount * rowHeight + 30);
            e.Graphics.DrawString(chihuy1, tieuDoanFont, Brushes.Black, 100, startY + rowCount * rowHeight + 30);
        }

        private void dgv_DanhSachDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
