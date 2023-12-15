namespace QuanLyRaVao.ChiHuyTieuDoan
{
    partial class TanSuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tenHV = new System.Windows.Forms.Label();
            this.dgvLS = new System.Windows.Forms.DataGridView();
            this.lb = new System.Windows.Forms.Label();
            this.solan = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbThang = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLS)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGreen;
            this.panel1.Controls.Add(this.cbThang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.solan);
            this.panel1.Controls.Add(this.lb);
            this.panel1.Controls.Add(this.tenHV);
            this.panel1.Controls.Add(this.dgvLS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 258);
            this.panel1.TabIndex = 1;
            // 
            // tenHV
            // 
            this.tenHV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tenHV.AutoSize = true;
            this.tenHV.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.tenHV.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.tenHV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tenHV.Location = new System.Drawing.Point(432, 9);
            this.tenHV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tenHV.Name = "tenHV";
            this.tenHV.Size = new System.Drawing.Size(213, 31);
            this.tenHV.TabIndex = 34;
            this.tenHV.Text = "TÊN HỌC VIÊN";
            // 
            // dgvLS
            // 
            this.dgvLS.AllowUserToAddRows = false;
            this.dgvLS.AllowUserToDeleteRows = false;
            this.dgvLS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvLS.BackgroundColor = System.Drawing.Color.White;
            this.dgvLS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLS.Location = new System.Drawing.Point(3, 98);
            this.dgvLS.Name = "dgvLS";
            this.dgvLS.ReadOnly = true;
            this.dgvLS.Size = new System.Drawing.Size(1072, 158);
            this.dgvLS.TabIndex = 0;
            // 
            // lb
            // 
            this.lb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.lb.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lb.Location = new System.Drawing.Point(11, 60);
            this.lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(185, 31);
            this.lb.TabIndex = 35;
            this.lb.Text = "Số lần ra vào: ";
            // 
            // solan
            // 
            this.solan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.solan.AutoSize = true;
            this.solan.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.solan.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.solan.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.solan.Location = new System.Drawing.Point(189, 60);
            this.solan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.solan.Name = "solan";
            this.solan.Size = new System.Drawing.Size(28, 31);
            this.solan.TabIndex = 36;
            this.solan.Text = "?";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 31);
            this.label1.TabIndex = 37;
            this.label1.Text = "THÁNG: ";
            // 
            // cbThang
            // 
            this.cbThang.BackColor = System.Drawing.Color.DarkGreen;
            this.cbThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbThang.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThang.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.cbThang.FormattingEnabled = true;
            this.cbThang.Items.AddRange(new object[] {
            "ALL",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang.Location = new System.Drawing.Point(133, 12);
            this.cbThang.Name = "cbThang";
            this.cbThang.Size = new System.Drawing.Size(94, 39);
            this.cbThang.TabIndex = 38;
            this.cbThang.TextChanged += new System.EventHandler(this.cbThang_TextChanged);
            // 
            // TanSuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 258);
            this.Controls.Add(this.panel1);
            this.Name = "TanSuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TanSuat";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tenHV;
        private System.Windows.Forms.DataGridView dgvLS;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Label solan;
        private System.Windows.Forms.ComboBox cbThang;
        private System.Windows.Forms.Label label1;
    }
}