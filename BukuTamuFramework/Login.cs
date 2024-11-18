using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Windows.Forms;
using UserModel = BukuTamuFramework.Login.User;
using System.Security.Cryptography;
using System.Text;

namespace BukuTamuFramework
{
    public partial class Login : Form
    {
        private static readonly string EncryptionKey = "kartika";
        public Login()
        {
            InitializeComponent();
        }

        private string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        // Kelas User untuk menyimpan data pengguna
        public class User
        {
            public string Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        // RootObject untuk deserialisasi JSON
        public class RootObject
        {
            public List<object> pengunjung { get; set; }  // Hanya jika pengunjung memang diperlukan
            public List<UserModel> users { get; set; } = new List<UserModel>();  // Inisialisasi list kosong
        }

        // Fungsi untuk membaca data pengguna dari file JSON
        private List<UserModel> LoadUsersFromJson()
        {
            string filePath = "users.json";

            if (!File.Exists(filePath))
            {
                // Membuat file JSON jika tidak ada
                File.WriteAllText(filePath, JsonConvert.SerializeObject(new RootObject { users = new List<UserModel>() }));
            }

            string json = File.ReadAllText(filePath);
            RootObject data = JsonConvert.DeserializeObject<RootObject>(json) ?? new RootObject();

            return data.users ?? new List<UserModel>();  // Pastikan `users` tidak null
        }

        // Fungsi untuk menambahkan pengguna ke file JSON
        private void AddUserToJson(UserModel newUser)
        {
            string filePath = "users.json";
            RootObject data = new RootObject();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                data = JsonConvert.DeserializeObject<RootObject>(json) ?? new RootObject();
            }

            newUser.Id = Guid.NewGuid().ToString();  // Mengisi Id sebagai UUID string
            data.users.Add(newUser);

            File.WriteAllText(filePath, JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        // Event handler untuk tombol login
        private void BtnMasuk_Click(object sender, EventArgs e)
        {
            string username = IntUsername.Text;
            string password = IntPassword.Text;

            // Muat data pengguna
            List<UserModel> users = LoadUsersFromJson();

            // Verifikasi login
            UserModel loginUser = users.FirstOrDefault(u => u.Username == username && Decrypt(u.Password) == password);

            if (loginUser != null)
            {
                MessageBox.Show($"Login berhasil!\nSelamat datang, {loginUser.Name}.\nEmail: {loginUser.Email}");

                // Periksa peran pengguna
                if (loginUser.Role == "admin")
                {
                    this.Hide();
                    Admin f2 = new Admin();
                    f2.ShowDialog();
                    this.Close();
                }
                else if (loginUser.Role == "user")
                {
                    this.Hide();
                    UserForm f3 = new UserForm();
                    f3.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Role tidak dikenali!");
                }
            }
            else
            {
                MessageBox.Show("Username atau password salah!");
            }
        }

        // Event handler untuk tombol keluar
        private void BtnKeluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            InputTamu f2 = new InputTamu();
            f2.ShowDialog();
            this.Close();
        }
    }
}
