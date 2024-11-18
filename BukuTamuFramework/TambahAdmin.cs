using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class TambahAdmin : Form
    {
        private static readonly string EncryptionKey = "kartika";

        public TambahAdmin()
        {
            InitializeComponent();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            // Ambil data dari TextBox
            string nama = IntNama.Text;
            string email = IntEmail.Text;
            string username = IntUsername.Text;
            string password = IntPassword.Text;

            // Validasi input data
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Semua kolom harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buat ID unik untuk admin baru
            string id = GenerateUniqueId();

            // Enkripsi password
            string encryptedPassword = Encrypt(password);

            // Buat objek User baru
            var newAdmin = new DataAdmin.User
            {
                Id = id,
                Name = nama,
                Email = email,
                Username = username,
                Password = encryptedPassword,
                Role = "admin"
            };

            // Tambahkan data ke JSON
            AddAdminToJson(newAdmin);

            // Beri pesan konfirmasi dan tutup form
            MessageBox.Show("Data admin berhasil ditambahkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private string GenerateUniqueId()
        {
            // Buat ID unik (contoh dengan GUID, Anda bisa modifikasi sesuai kebutuhan)
            return Guid.NewGuid().ToString();
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

        private void AddAdminToJson(DataAdmin.User newAdmin)
        {
            string filePath = "users.json";

            // Baca isi file JSON
            var json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<DataAdmin.RootObject>(json) ?? new DataAdmin.RootObject();

            // Pastikan daftar users tidak null
            if (data.users == null)
                data.users = new List<DataAdmin.User>();

            // Tambahkan admin baru ke daftar users
            data.users.Add(newAdmin);

            // Buat objek baru yang hanya memperbarui bagian "users" dan mempertahankan "pengunjung" tanpa perubahan
            var updatedData = new
            {
                pengunjung = data.pengunjung, // pertahankan data pengunjung yang sudah ada
                users = data.users // tambahkan data user baru
            };

            // Tulis kembali ke file JSON
            string updatedJson = JsonConvert.SerializeObject(updatedData, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        private void TambahAdmin_Load(object sender, EventArgs e)
        {
        }

        private void BtnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
