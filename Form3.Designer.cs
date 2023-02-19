namespace QuanLyBanHang
{
    partial class frmChiTietHoaDon1
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
            this.dgvDANHMUC = new System.Windows.Forms.DataGridView();
            this.btnTrove = new System.Windows.Forms.Button();
            this.lblDM = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDANHMUC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDANHMUC
            // 
            this.dgvDANHMUC.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvDANHMUC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDANHMUC.Location = new System.Drawing.Point(39, 105);
            this.dgvDANHMUC.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDANHMUC.Name = "dgvDANHMUC";
            this.dgvDANHMUC.RowHeadersWidth = 51;
            this.dgvDANHMUC.Size = new System.Drawing.Size(457, 133);
            this.dgvDANHMUC.TabIndex = 0;
            // 
            // btnTrove
            // 
            this.btnTrove.Location = new System.Drawing.Point(396, 263);
            this.btnTrove.Margin = new System.Windows.Forms.Padding(4);
            this.btnTrove.Name = "btnTrove";
            this.btnTrove.Size = new System.Drawing.Size(100, 28);
            this.btnTrove.TabIndex = 1;
            this.btnTrove.Text = "Trở về";
            this.btnTrove.UseVisualStyleBackColor = true;
            this.btnTrove.Click += new System.EventHandler(this.btnTrove_Click);
            // 
            // lblDM
            // 
            this.lblDM.AutoSize = true;
            this.lblDM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDM.Location = new System.Drawing.Point(174, 31);
            this.lblDM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDM.Name = "lblDM";
            this.lblDM.Size = new System.Drawing.Size(86, 31);
            this.lblDM.TabIndex = 3;
            this.lblDM.Text = "label1";
            // 
            // frmChiTietHoaDon1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(534, 304);
            this.Controls.Add(this.lblDM);
            this.Controls.Add(this.btnTrove);
            this.Controls.Add(this.dgvDANHMUC);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChiTietHoaDon1";
            this.Text = "Chi Tiết Hóa Đơn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDANHMUC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDANHMUC;
        private System.Windows.Forms.Button btnTrove;
        private System.Windows.Forms.Label lblDM;
    }
}