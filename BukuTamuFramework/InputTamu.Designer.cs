namespace BukuTamuFramework
{
    partial class InputTamu
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
            this.PanelInputTamu = new Guna.UI2.WinForms.Guna2Panel();
            this.BtnMasuk = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelInputTamu
            // 
            this.PanelInputTamu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelInputTamu.Location = new System.Drawing.Point(0, 81);
            this.PanelInputTamu.Name = "PanelInputTamu";
            this.PanelInputTamu.Size = new System.Drawing.Size(802, 357);
            this.PanelInputTamu.TabIndex = 2;
            // 
            // BtnMasuk
            // 
            this.BtnMasuk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMasuk.Animated = true;
            this.BtnMasuk.BackColor = System.Drawing.Color.Transparent;
            this.BtnMasuk.BorderRadius = 12;
            this.BtnMasuk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnMasuk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnMasuk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnMasuk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnMasuk.FillColor = System.Drawing.Color.MidnightBlue;
            this.BtnMasuk.FocusedColor = System.Drawing.Color.Yellow;
            this.BtnMasuk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BtnMasuk.ForeColor = System.Drawing.Color.White;
            this.BtnMasuk.Location = new System.Drawing.Point(685, 12);
            this.BtnMasuk.Name = "BtnMasuk";
            this.BtnMasuk.Size = new System.Drawing.Size(103, 37);
            this.BtnMasuk.TabIndex = 1;
            this.BtnMasuk.Text = "Masuk";
            this.BtnMasuk.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.Image = global::BukuTamuFramework.Properties.Resources.BUKU_TAMU;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(298, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(191, 63);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // InputTamu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelInputTamu);
            this.Controls.Add(this.BtnMasuk);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InputTamu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buku Tamu";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button BtnMasuk;
        private Guna.UI2.WinForms.Guna2Panel PanelInputTamu;
    }
}