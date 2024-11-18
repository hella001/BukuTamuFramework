namespace BukuTamuFramework
{
    partial class UserForm
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
            this.Panel = new Guna.UI2.WinForms.Guna2Panel();
            this.nama = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.kata2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.kata1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.kata = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.PanelData = new Guna.UI2.WinForms.Guna2Panel();
            this.BtnKeluar = new Guna.UI2.WinForms.Guna2Button();
            this.BtnEksport = new Guna.UI2.WinForms.Guna2Button();
            this.BtnRekap = new Guna.UI2.WinForms.Guna2Button();
            this.Panel.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel.Controls.Add(this.nama);
            this.Panel.Controls.Add(this.kata2);
            this.Panel.Controls.Add(this.kata1);
            this.Panel.Controls.Add(this.kata);
            this.Panel.Location = new System.Drawing.Point(206, 12);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(582, 423);
            this.Panel.TabIndex = 5;
            // 
            // nama
            // 
            this.nama.BackColor = System.Drawing.Color.Transparent;
            this.nama.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nama.Location = new System.Drawing.Point(348, 142);
            this.nama.Name = "nama";
            this.nama.Size = new System.Drawing.Size(92, 33);
            this.nama.TabIndex = 3;
            this.nama.Text = "User :)";
            // 
            // kata2
            // 
            this.kata2.BackColor = System.Drawing.Color.Transparent;
            this.kata2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kata2.Location = new System.Drawing.Point(173, 209);
            this.kata2.Name = "kata2";
            this.kata2.Size = new System.Drawing.Size(254, 22);
            this.kata2.TabIndex = 2;
            this.kata2.Text = " \"Rekap Pengunjung\" di samping kiri";
            // 
            // kata1
            // 
            this.kata1.BackColor = System.Drawing.Color.Transparent;
            this.kata1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kata1.Location = new System.Drawing.Point(67, 181);
            this.kata1.Name = "kata1";
            this.kata1.Size = new System.Drawing.Size(456, 22);
            this.kata1.TabIndex = 1;
            this.kata1.Text = "Untuk mengecek data yang tersimpan silahkan menekan tombol ";
            // 
            // kata
            // 
            this.kata.BackColor = System.Drawing.Color.Transparent;
            this.kata.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kata.Location = new System.Drawing.Point(136, 142);
            this.kata.Name = "kata";
            this.kata.Size = new System.Drawing.Size(211, 33);
            this.kata.TabIndex = 0;
            this.kata.Text = "Selamat Datang";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2ShadowPanel1.Controls.Add(this.PanelData);
            this.guna2ShadowPanel1.Controls.Add(this.BtnKeluar);
            this.guna2ShadowPanel1.Controls.Add(this.BtnEksport);
            this.guna2ShadowPanel1.Controls.Add(this.BtnRekap);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.SlateGray;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(200, 449);
            this.guna2ShadowPanel1.TabIndex = 4;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::BukuTamuFramework.Properties.Resources.BUKU_TAMU;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(16, 22);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(168, 60);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 20;
            this.guna2PictureBox1.TabStop = false;
            // 
            // PanelData
            // 
            this.PanelData.Location = new System.Drawing.Point(203, 3);
            this.PanelData.Name = "PanelData";
            this.PanelData.Size = new System.Drawing.Size(585, 435);
            this.PanelData.TabIndex = 1;
            // 
            // BtnKeluar
            // 
            this.BtnKeluar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnKeluar.Animated = true;
            this.BtnKeluar.BackColor = System.Drawing.Color.Transparent;
            this.BtnKeluar.BorderRadius = 12;
            this.BtnKeluar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnKeluar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnKeluar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnKeluar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnKeluar.FillColor = System.Drawing.Color.Crimson;
            this.BtnKeluar.FocusedColor = System.Drawing.Color.Yellow;
            this.BtnKeluar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnKeluar.ForeColor = System.Drawing.Color.White;
            this.BtnKeluar.Location = new System.Drawing.Point(3, 401);
            this.BtnKeluar.Name = "BtnKeluar";
            this.BtnKeluar.Size = new System.Drawing.Size(193, 37);
            this.BtnKeluar.TabIndex = 19;
            this.BtnKeluar.Text = "Keluar";
            this.BtnKeluar.Click += new System.EventHandler(this.BtnKeluar_Click);
            // 
            // BtnEksport
            // 
            this.BtnEksport.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnEksport.Animated = true;
            this.BtnEksport.BackColor = System.Drawing.Color.Transparent;
            this.BtnEksport.BorderRadius = 12;
            this.BtnEksport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnEksport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnEksport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnEksport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnEksport.FillColor = System.Drawing.Color.MidnightBlue;
            this.BtnEksport.FocusedColor = System.Drawing.Color.Yellow;
            this.BtnEksport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnEksport.ForeColor = System.Drawing.Color.White;
            this.BtnEksport.Location = new System.Drawing.Point(4, 154);
            this.BtnEksport.Name = "BtnEksport";
            this.BtnEksport.Size = new System.Drawing.Size(193, 37);
            this.BtnEksport.TabIndex = 17;
            this.BtnEksport.Text = "Eksport Data";
            // 
            // BtnRekap
            // 
            this.BtnRekap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnRekap.Animated = true;
            this.BtnRekap.BackColor = System.Drawing.Color.Transparent;
            this.BtnRekap.BorderRadius = 12;
            this.BtnRekap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnRekap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnRekap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnRekap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnRekap.FillColor = System.Drawing.Color.MidnightBlue;
            this.BtnRekap.FocusedColor = System.Drawing.Color.Yellow;
            this.BtnRekap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnRekap.ForeColor = System.Drawing.Color.White;
            this.BtnRekap.Location = new System.Drawing.Point(4, 95);
            this.BtnRekap.Name = "BtnRekap";
            this.BtnRekap.Size = new System.Drawing.Size(193, 37);
            this.BtnRekap.TabIndex = 15;
            this.BtnRekap.Text = "Rekap Pengunjung";
            this.BtnRekap.Click += new System.EventHandler(this.BtnRekap_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel Panel;
        private Guna.UI2.WinForms.Guna2HtmlLabel nama;
        private Guna.UI2.WinForms.Guna2HtmlLabel kata2;
        private Guna.UI2.WinForms.Guna2HtmlLabel kata1;
        private Guna.UI2.WinForms.Guna2HtmlLabel kata;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel PanelData;
        private Guna.UI2.WinForms.Guna2Button BtnKeluar;
        private Guna.UI2.WinForms.Guna2Button BtnEksport;
        private Guna.UI2.WinForms.Guna2Button BtnRekap;
    }
}