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
    public partial class Admin : Form
    {
        private Form currentForm = null;

        public Admin()
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

        private void TampilkanFormEditData()
        {
            if (currentForm is EditData)
                return;

            CloseCurrentForm();

            EditData formEdit = new EditData();
            formEdit.TopLevel = false;
            formEdit.Dock = DockStyle.Fill;
            Panel.AutoScroll = true;
            Panel.Controls.Add(formEdit);
            formEdit.Show();

            currentForm = formEdit;
        }

        public void TampilkanFormPengguna()
        {
            if (currentForm is Pengguna)
                return;

            CloseCurrentForm();

            Pengguna formPengguna = new Pengguna(this); // Kirim referensi Admin
            formPengguna.TopLevel = false;
            formPengguna.Dock = DockStyle.Top; // Agar konten form berada di bagian atas panel
            Panel.AutoScroll = true; // Aktifkan AutoScroll pada panel
            Panel.Controls.Add(formPengguna);
            formPengguna.Show();

            currentForm = formPengguna;
        }

        public void TampilkanFormDataAdmin()
        {
            if (currentForm is DataAdmin)
                return;

            CloseCurrentForm();

            DataAdmin formDataAdmin = new DataAdmin(this); // Kirim referensi Admin ke DataAdmin
            formDataAdmin.TopLevel = false;
            formDataAdmin.Dock = DockStyle.Fill;
            Panel.AutoScroll = true;
            Panel.Controls.Add(formDataAdmin);
            formDataAdmin.Show();

            currentForm = formDataAdmin;
        }

        public void TampilkanFormDataUser()
        {
            if (currentForm is DataUser)
                return;

            CloseCurrentForm();

            DataUser formDataUser = new DataUser(this); // Kirim referensi Admin ke DataAdmin
            formDataUser.TopLevel = false;
            formDataUser.Dock = DockStyle.Fill;
            Panel.AutoScroll = true;
            Panel.Controls.Add(formDataUser);
            formDataUser.Show();

            currentForm = formDataUser;
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

        private void BtnMasuk_Click(object sender, EventArgs e)
        {
            TampilkanFormRekap();

            kata.Text = "";
            kata1.Text = "";
            kata2.Text = "";
            nama.Text = "";
        }

        private void BtnEditData_Click(object sender, EventArgs e)
        {
            TampilkanFormEditData();

            kata.Text = "";
            kata1.Text = "";
            kata2.Text = "";
            nama.Text = "";
        }

        private void BtnEksport_Click(object sender, EventArgs e)
        {
            kata.Text = "";
            kata1.Text = "";
            kata2.Text = "";
            nama.Text = "";
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            TampilkanFormPengguna();

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
