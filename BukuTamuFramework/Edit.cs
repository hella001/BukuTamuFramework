using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class Edit : Form
    {
        public string Id { get; set; }
        public string Tanggal { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Alamat { get; set; }
        public string NomorHP { get; set; }
        public string Pekerjaan { get; set; }

        public Edit()
        {
            InitializeComponent();
            this.Load += Edit_Load;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            // Set data from properties to TextBoxes
            IntId.Text = Id;
            IntTanggal.Text = Tanggal;
            IntNama.Text = Nama;
            IntEmail.Text = Email;
            IntAlamat.Text = Alamat;
            IntHp.Text = NomorHP;
            IntPekerjaan.Text = Pekerjaan;
        }

        private void BtnBersih_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            // Ambil data yang telah diubah dari TextBox
            var updatedPengunjung = new EditData.Pengunjung
            {
                Id = IntId.Text,
                Tanggal = DateTime.Parse(IntTanggal.Text),
                Nama = IntNama.Text,
                Email = IntEmail.Text,
                Alamat = IntAlamat.Text,
                NomorHP = IntHp.Text,
                Pekerjaan = IntPekerjaan.Text
            };

            // Panggil method UpdatePengunjung di EditData untuk menyimpan perubahan
            var mainForm = Application.OpenForms.OfType<EditData>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.UpdatePengunjung(updatedPengunjung);
            }

            this.Close();
        }
    }
}
