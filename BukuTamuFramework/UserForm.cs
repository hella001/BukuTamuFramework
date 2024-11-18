using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class UserForm : Form
    {
        private Form currentForm = null;
        public UserForm()
        {
            InitializeComponent();
        }

        private void TampilkanFormRekap()
        {
            if (currentForm is Rekap)
                return;

            CloseCurrentForm();

            Rekap formRekap = new Rekap();
            formRekap.TopLevel = false;
            formRekap.Dock = DockStyle.Fill;
            Panel.AutoScroll = true;
            Panel.Controls.Add(formRekap);
            formRekap.Show();

            currentForm = formRekap;
        }

        private void CloseCurrentForm()
        {
            if (currentForm != null)
            {
                currentForm.Close();
                Panel.Controls.Remove(currentForm);
                currentForm = null;
            }
        }

        private void BtnRekap_Click(object sender, EventArgs e)
        {
            TampilkanFormRekap();

            kata.Text = "";
            kata1.Text = "";
            kata2.Text = "";
            nama.Text = "";
        }

        private void BtnKeluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            InputTamu f2 = new InputTamu();
            f2.ShowDialog();
            this.Close();
        }
    }
}
