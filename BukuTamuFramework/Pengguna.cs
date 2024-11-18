using Newtonsoft.Json.Linq;
using System;
using System.IO;
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
    public partial class Pengguna : Form
    {
        private Admin mainForm; // Referensi ke form Admin
        private Form currentForm = null;

        public Pengguna(Admin formAdmin) // Terima referensi Admin
        {
            InitializeComponent();
            mainForm = formAdmin; // Simpan referensi Admin
            TampilkanDataPengguna();
        }

        private void TampilkanDataPengguna()
        {
            // Baca file JSON
            string jsonFilePath = "users.json"; // Sesuaikan path ke file users.json Anda
            string jsonData = File.ReadAllText(jsonFilePath);

            // Parse JSON menggunakan Newtonsoft.Json
            JObject data = JObject.Parse(jsonData);
            var users = data["users"].ToObject<List<User>>();

            // Filter berdasarkan role
            var admins = users.Where(u => u.Role == "admin").ToList();
            var regularUsers = users.Where(u => u.Role == "user").ToList();

            // Bind data ke GridAdmin
            GridAdmin.DataSource = admins;
            JmlAdmin.Text = admins.Count.ToString();

            // Bind data ke GridUser
            GridUser.DataSource = regularUsers;
            JmlUser.Text = regularUsers.Count.ToString();
        }

        public class User
        {
            //public int Id { get; set; }
            public string Username { get; set; }
            //public string Password { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        private void DetailAdmin_Click(object sender, EventArgs e)
        {
            mainForm.TampilkanFormDataAdmin(); // Panggil metode di Admin untuk membuka DataAdmin
        }

        private void DetailUser_Click(object sender, EventArgs e)
        {
            mainForm.TampilkanFormDataUser();
        }
    }
}
