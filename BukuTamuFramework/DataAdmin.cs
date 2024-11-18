using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class DataAdmin : Form
    {
        private Admin mainForm;
        private static readonly string EncryptionKey = "kartika";
        private List<User> adminList;

        public DataAdmin(Admin mainForm)
        {
            InitializeComponent();
            LoadAdminData();
            this.mainForm = mainForm;
        }

        public class User
        {
            public string Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        public class RootObject
        {
            public List<User> pengunjung { get; set; } // tambahkan properti 'pengunjung' jika ada data pengunjung
            public List<User> users { get; set; } // untuk data 'users'
        }

        private void SaveAdminToJson(List<User> updatedList)
        {
            string filePath = "users.json";
            string jsonContent = File.ReadAllText(filePath);
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonContent);

            // Ambil data asli dari JSON, termasuk pengguna dengan role "user"
            List<User> allUsers = LoadUsersFromJson();

            // Perbarui data admin pada daftar pengguna tanpa mengubah data user
            foreach (var admin in updatedList)
            {
                var userToUpdate = allUsers.FirstOrDefault(u => u.Id == admin.Id && u.Role == "admin");
                if (userToUpdate != null)
                {
                    userToUpdate.Name = admin.Name;
                    userToUpdate.Email = admin.Email;
                    userToUpdate.Username = admin.Username;
                    userToUpdate.Password = admin.Password;
                }
            }

            jsonObject.users = JToken.FromObject(allUsers);
            string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            File.WriteAllText(filePath, updatedJsonContent);
        }

        private string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public void UpdateUser(User updatedAdmin)
        {
            var admin = adminList.FirstOrDefault(a => a.Id == updatedAdmin.Id);
            if (admin != null)
            {
                admin.Name = updatedAdmin.Name;
                admin.Email = updatedAdmin.Email;
                admin.Username = updatedAdmin.Username;
                admin.Password = updatedAdmin.Password;

                SaveAdminToJson(adminList);
                LoadAdminData();
            }
        }

        private void LoadAdminData()
        {
            adminList = LoadUsersFromJson().Where(u => u.Role == "admin").ToList();
            DisplayAdminData(adminList);
        }

        private List<User> LoadUsersFromJson()
        {
            string filePath = "users.json";
            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<RootObject>(json) ?? new RootObject();
            return data.users ?? new List<User>();
        }

        private void DisplayAdminData(List<User> data)
        {
            GridAdmin.DataSource = new BindingSource() { DataSource = data };
            GridAdmin.Columns["Id"].Visible = false;
            GridAdmin.Columns["Password"].Visible = false;
            GridAdmin.Columns["Role"].Visible = false;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (GridAdmin.SelectedRows.Count > 0)
            {
                var selectedAdmin = (User)GridAdmin.SelectedRows[0].DataBoundItem;

                EditAdmin editForm = new EditAdmin
                {
                    Id = selectedAdmin.Id,
                    Name = selectedAdmin.Name,
                    Email = selectedAdmin.Email,
                    Username = selectedAdmin.Username,
                    Password = selectedAdmin.Password
                };

                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pilih data terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadAdminData();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            mainForm.TampilkanFormPengguna();
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
            TambahAdmin Add = new TambahAdmin();
            Add.ShowDialog();
            this.Activate();
        }
    }
}
