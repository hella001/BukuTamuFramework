using System;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class InputTamu : Form
    {
        private Form currentForm = null;
        private Tamu formTamu;

        public InputTamu()
        {
            InitializeComponent();
            TampilkanFormTamu();
        }

        public void TampilkanFormTamu()
        {
            if (currentForm is Tamu)
                return;

            CloseCurrentForm();
            formTamu = new Tamu(this); // Inisialisasi formTamu
            formTamu.TopLevel = false;
            formTamu.Dock = DockStyle.Top;
            PanelInputTamu.AutoScroll = true;
            PanelInputTamu.Controls.Clear();
            PanelInputTamu.Controls.Add(formTamu);
            formTamu.Show();
            currentForm = formTamu;
        }

        public void TampilkanFormFoto()
        {
            if (currentForm is Foto)
                return;

            CloseCurrentForm();
            Foto formFoto = new Foto(this); // Kirimkan instance InputTamu ini ke form Foto
            formFoto.TopLevel = false;
            formFoto.Dock = DockStyle.Fill;
            PanelInputTamu.AutoScroll = true;
            PanelInputTamu.Controls.Add(formFoto);
            formFoto.Show();
            currentForm = formFoto;
        }

        // Pastikan hanya ada satu SetFotoPath
        public void SetFotoPath(string fotoPath)
        {
            if (formTamu != null)
            {
                formTamu.SetFotoPath(fotoPath); // Mengirim path ke TextBox di formTamu
            }
        }

        private void CloseCurrentForm()
        {
            if (currentForm != null)
            {
                currentForm.Close();
                PanelInputTamu.Controls.Remove(currentForm);
                currentForm = null;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login f2 = new Login();
            f2.ShowDialog();
            this.Close();
        }
    }
}
