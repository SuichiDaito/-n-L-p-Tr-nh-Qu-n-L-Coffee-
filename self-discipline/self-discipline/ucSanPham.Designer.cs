namespace self_discipline
{
    partial class ucSanPham
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSanPham));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnTenMon = new Guna.UI2.WinForms.Guna2Button();
            this.picAnhMonAn = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.guna2Separator2);
            this.guna2ShadowPanel1.Controls.Add(this.guna2Separator1);
            this.guna2ShadowPanel1.Controls.Add(this.btnTenMon);
            this.guna2ShadowPanel1.Controls.Add(this.picAnhMonAn);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(1, -1);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(159, 191);
            this.guna2ShadowPanel1.TabIndex = 4;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(5, 0);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(168, 10);
            this.guna2Separator2.TabIndex = 5;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(5, 125);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(168, 10);
            this.guna2Separator1.TabIndex = 4;
            // 
            // btnTenMon
            // 
            this.btnTenMon.BorderColor = System.Drawing.Color.White;
            this.btnTenMon.BorderThickness = 2;
            this.btnTenMon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTenMon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTenMon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTenMon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTenMon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(199)))), ((int)(((byte)(148)))));
            this.btnTenMon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnTenMon.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnTenMon.Location = new System.Drawing.Point(6, 125);
            this.btnTenMon.Name = "btnTenMon";
            this.btnTenMon.Size = new System.Drawing.Size(146, 60);
            this.btnTenMon.TabIndex = 3;
            this.btnTenMon.Text = "Tên Món";
            // 
            // picAnhMonAn
            // 
            this.picAnhMonAn.Image = ((System.Drawing.Image)(resources.GetObject("picAnhMonAn.Image")));
            this.picAnhMonAn.ImageRotate = 0F;
            this.picAnhMonAn.Location = new System.Drawing.Point(3, 1);
            this.picAnhMonAn.Name = "picAnhMonAn";
            this.picAnhMonAn.Size = new System.Drawing.Size(152, 156);
            this.picAnhMonAn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhMonAn.TabIndex = 2;
            this.picAnhMonAn.TabStop = false;
            this.picAnhMonAn.Click += new System.EventHandler(this.picAnhMonAn_Click);
            // 
            // ucSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "ucSanPham";
            this.Size = new System.Drawing.Size(160, 189);
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhMonAn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Button btnTenMon;
        private Guna.UI2.WinForms.Guna2PictureBox picAnhMonAn;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
    }
}
