using System;
using System.Linq;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class EditAdmin : Form
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public EditAdmin()
        {
            InitializeComponent();
            this.Load += EditAdmin_Load;
        }

        private void EditAdmin_Load(object sender, EventArgs e)
        {
            IntId.Text = Id;
            IntNama.Text = Name;
            IntEmail.Text = Email;
            IntUsername.Text = Username;
            IntPassword.Text = Password;
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            var updatedAdmin = new DataAdmin.User
            {
                Id = IntId.Text,
                Name = IntNama.Text,
                Email = IntEmail.Text,
                Username = IntUsername.Text,
                Password = IntPassword.Text,
                Role = "admin" // Pastikan data yang diubah tetap sebagai admin
            };

            var mainForm = Application.OpenForms.OfType<DataAdmin>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.UpdateUser(updatedAdmin);
            }

            this.Close();
        }

        private void BtnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
