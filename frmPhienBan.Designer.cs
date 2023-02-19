namespace QuanLyBanHang
{
    partial class frmPhienBan
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
            this.dgvPhienBan = new System.Windows.Forms.RichTextBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dgvPhienBan
            // 
            this.dgvPhienBan.Location = new System.Drawing.Point(32, 28);
            this.dgvPhienBan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPhienBan.Name = "dgvPhienBan";
            this.dgvPhienBan.Size = new System.Drawing.Size(411, 144);
            this.dgvPhienBan.TabIndex = 0;
            this.dgvPhienBan.Text = "Phiên Bản 1.0\nĐược thực hiện bởi nhóm 8\n\t\t\t";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.Location = new System.Drawing.Point(344, 181);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 35);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Trở về";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmPhienBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(476, 223);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvPhienBan);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPhienBan";
            this.Text = "Thông Tin Phiên Bản";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox dgvPhienBan;
        private System.Windows.Forms.Button btnThoat;

    }
}