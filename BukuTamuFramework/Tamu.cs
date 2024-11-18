using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class Tamu : Form
    {
        private static readonly string EncryptionKey = "kartika";
        private InputTamu mainForm;

        public Tamu(InputTamu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        public class Pengunjung
        {
            public int Id { get; set; }  // Tambahkan properti Id untuk pengunjung
            public string Tanggal { get; set; }
            public string Nama { get; set; }
            public string Email { get; set; }
            public string Alamat { get; set; }
            public string Kelamin { get; set; }
            public string Hp { get; set; }
            public string Pekerjaan { get; set; }
            public string Keperluan { get; set; }
            public string Keterangan { get; set; }
            public string FotoPath { get; set; }
        }

        public class RootObject
        {
            public List<Pengunjung> pengunjung { get; set; }
            public List<User> users { get; set; }
        }

        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        private void ClearForm()
        {
            IntTanggal.Value = DateTime.Now;
            IntNama.Clear();
            IntEmail.Clear();
            IntAlamat.Clear();
            IntKelamin.SelectedIndex = -1;
            IntHp.Clear();
            IntPekerjaan.Clear();
            IntKeperluan.Clear();
            IntKeterangan.Clear();
            IntFoto.Clear();
        }

        private string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    return Encoding.Unicode.GetString(ms.ToArray());
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.StartsWith("08") && phoneNumber.Length >= 10;
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(IntTanggal.Text) ||
                string.IsNullOrWhiteSpace(IntNama.Text) ||
                string.IsNullOrWhiteSpace(IntAlamat.Text) ||
                string.IsNullOrWhiteSpace(IntKelamin.Text) ||
                string.IsNullOrWhiteSpace(IntPekerjaan.Text) ||
                string.IsNullOrWhiteSpace(IntKeperluan.Text) ||
                string.IsNullOrWhiteSpace(IntKeterangan.Text))
            {
                MessageBox.Show("Semua data wajib diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(IntEmail.Text))
            {
                MessageBox.Show("Format email tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPhoneNumber(IntHp.Text))
            {
                MessageBox.Show("Nomor HP harus diawali dengan '08' dan minimal 10 digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Enkripsi data sensitif
            string encryptedEmail = Encrypt(IntEmail.Text);
            string encryptedAlamat = Encrypt(IntAlamat.Text);
            string encryptedHp = Encrypt(IntHp.Text);
            string encryptedKeperluan = Encrypt(IntKeperluan.Text);
            string encryptedKeterangan = Encrypt(IntKeterangan.Text);

            // Pindahkan foto ke direktori tujuan
            string sourceDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "Sementara");
            string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "Picture");
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string photoFileName = Path.GetFileName(IntFoto.Text);
            string targetPhotoPath = Path.Combine(targetDirectory, photoFileName);

            try
            {
                File.Move(IntFoto.Text, targetPhotoPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memindahkan foto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Baca dan simpan data ke dalam file JSON
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            RootObject rootData;

            if (File.Exists(jsonFilePath))
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                rootData = JsonConvert.DeserializeObject<RootObject>(jsonData) ?? new RootObject { pengunjung = new List<Pengunjung>(), users = new List<User>() };
            }
            else
            {
                rootData = new RootObject { pengunjung = new List<Pengunjung>(), users = new List<User>() };
            }

            // Menentukan ID untuk pengunjung baru
            int newId = rootData.pengunjung.Any() ? rootData.pengunjung.Max(p => p.Id) + 1 : 1;

            // Buat objek data user
            var userData = new Pengunjung
            {
                Id = newId, // Tambahkan ID baru
                Tanggal = IntTanggal.Value.ToString("yyyy-MM-dd"),
                Nama = IntNama.Text,
                Email = encryptedEmail,
                Alamat = encryptedAlamat,
                Kelamin = IntKelamin.Text,
                Hp = encryptedHp,
                Pekerjaan = IntPekerjaan.Text,
                Keperluan = encryptedKeperluan,
                Keterangan = encryptedKeterangan,
                FotoPath = targetPhotoPath
            };

            // Tambahkan data pengunjung baru
            rootData.pengunjung.Add(userData);

            // Tulis kembali ke file JSON, mempertahankan data `users` yang ada
            File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(rootData, Formatting.Indented));

            MessageBox.Show("Data pengunjung berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearForm();
        }

        private void BtnBersih_Click(object sender, EventArgs e)
        {
            // Hapus foto dari folder Sementara jika ada
            if (!string.IsNullOrWhiteSpace(IntFoto.Text) && File.Exists(IntFoto.Text))
            {
                try
                {
                    File.Delete(IntFoto.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus foto sementara: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Bersihkan semua input
            IntTanggal.Value = DateTime.Now;
            IntNama.Clear();
            IntEmail.Clear();
            IntAlamat.Clear();
            IntKelamin.SelectedIndex = -1;
            IntHp.Clear();
            IntPekerjaan.Clear();
            IntKeperluan.Clear();
            IntKeterangan.Clear();
            IntFoto.Clear();
        }

        private void BtnPilih_Click(object sender, EventArgs e)
        {
            Foto formFoto = new Foto(mainForm); // Kirimkan instance InputTamu ke form Foto
            formFoto.ShowDialog();
        }

        public void SetFotoPath(string fotoPath)
        {
            IntFoto.Text = fotoPath;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {
        }

        private void guna2HtmlLabel16_Click(object sender, EventArgs e)
        {
        }
    }
}
