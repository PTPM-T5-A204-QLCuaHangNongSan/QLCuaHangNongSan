namespace UserControls
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_dssp = new System.Windows.Forms.DataGridView();
            this.txt_soLuong = new System.Windows.Forms.TextBox();
            this.txt_donGia = new System.Windows.Forms.TextBox();
            this.txt_tenSP = new System.Windows.Forms.TextBox();
            this.txt_maSP = new System.Windows.Forms.TextBox();
            this.cb_NCC = new System.Windows.Forms.ComboBox();
            this.date_ngayNhapHang = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dssp)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_dssp
            // 
            this.dgv_dssp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dssp.Location = new System.Drawing.Point(22, 141);
            this.dgv_dssp.Name = "dgv_dssp";
            this.dgv_dssp.Size = new System.Drawing.Size(660, 314);
            this.dgv_dssp.TabIndex = 38;
            this.dgv_dssp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dssp_CellClick);
            // 
            // txt_soLuong
            // 
            this.txt_soLuong.Location = new System.Drawing.Point(482, 51);
            this.txt_soLuong.Name = "txt_soLuong";
            this.txt_soLuong.Size = new System.Drawing.Size(200, 20);
            this.txt_soLuong.TabIndex = 37;
            // 
            // txt_donGia
            // 
            this.txt_donGia.Location = new System.Drawing.Point(482, 16);
            this.txt_donGia.Name = "txt_donGia";
            this.txt_donGia.Size = new System.Drawing.Size(200, 20);
            this.txt_donGia.TabIndex = 36;
            // 
            // txt_tenSP
            // 
            this.txt_tenSP.Location = new System.Drawing.Point(103, 51);
            this.txt_tenSP.Name = "txt_tenSP";
            this.txt_tenSP.Size = new System.Drawing.Size(245, 20);
            this.txt_tenSP.TabIndex = 35;
            // 
            // txt_maSP
            // 
            this.txt_maSP.Location = new System.Drawing.Point(103, 16);
            this.txt_maSP.Name = "txt_maSP";
            this.txt_maSP.Size = new System.Drawing.Size(245, 20);
            this.txt_maSP.TabIndex = 34;
            // 
            // cb_NCC
            // 
            this.cb_NCC.FormattingEnabled = true;
            this.cb_NCC.Location = new System.Drawing.Point(103, 88);
            this.cb_NCC.Name = "cb_NCC";
            this.cb_NCC.Size = new System.Drawing.Size(245, 21);
            this.cb_NCC.TabIndex = 33;
            // 
            // date_ngayNhapHang
            // 
            this.date_ngayNhapHang.Location = new System.Drawing.Point(482, 88);
            this.date_ngayNhapHang.Name = "date_ngayNhapHang";
            this.date_ngayNhapHang.Size = new System.Drawing.Size(200, 20);
            this.date_ngayNhapHang.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(387, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Ngày nhập hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Đơn giá:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Nhà cung cấp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Mã sản phẩm:";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_dssp);
            this.Controls.Add(this.txt_soLuong);
            this.Controls.Add(this.txt_donGia);
            this.Controls.Add(this.txt_tenSP);
            this.Controls.Add(this.txt_maSP);
            this.Controls.Add(this.cb_NCC);
            this.Controls.Add(this.date_ngayNhapHang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(706, 466);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dssp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_dssp;
        private System.Windows.Forms.TextBox txt_soLuong;
        private System.Windows.Forms.TextBox txt_donGia;
        private System.Windows.Forms.TextBox txt_tenSP;
        private System.Windows.Forms.TextBox txt_maSP;
        private System.Windows.Forms.ComboBox cb_NCC;
        private System.Windows.Forms.DateTimePicker date_ngayNhapHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
