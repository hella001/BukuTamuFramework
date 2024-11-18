using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace BukuTamuFramework
{
    public partial class EditData : Form
    {
        private static readonly string EncryptionKey = "kartika";
        private List<Pengunjung> pengunjungList;

        public EditData()
        {
            InitializeComponent();
            GridData.Font = new Font("Microsoft Sans Serif", 12);
            LoadPengunjungData();
            IntCari.TextChanged += IntCari_TextChanged;
        }

        public class Pengunjung
        {
            public string Id { get; set; }
            public DateTime Tanggal { get; set; }
            public string Nama { get; set; }
            public string Email { get; set; }
            public string Alamat { get; set; }
            public string Kelamin { get; set; }
            public string NomorHP { get; set; }
            public string Pekerjaan { get; set; }
            public string Keperluan { get; set; }
            public string Keterangan { get; set; }
            public string FotoPath { get; set; }
        }

        public class RootObject
        {
            public List<Pengunjung> pengunjung { get; set; }
        }

        private void SavePengunjungToJson(List<Pengunjung> updatedList)
        {
            // Baca file JSON asli
            string filePath = "users.json";
            string jsonContent = File.ReadAllText(filePath);

            // Deserialisasi isi file JSON ke objek dinamis untuk menghindari perubahan pada "user"
            dynamic jsonObject = JsonConvert.DeserializeObject(jsonContent);

            // Enkripsi data di dalam daftar pengunjung yang diperbarui
            foreach (var pengunjung in updatedList)
            {
                pengunjung.Nama = Encrypt(pengunjung.Nama);
                pengunjung.Email = Encrypt(pengunjung.Email);
                pengunjung.Alamat = Encrypt(pengunjung.Alamat);
                pengunjung.NomorHP = Encrypt(pengunjung.NomorHP);
                pengunjung.Keperluan = Encrypt(pengunjung.Keperluan);
                pengunjung.Keterangan = Encrypt(pengunjung.Keterangan);
            }

            // Gantikan data "pengunjung" dengan data yang sudah diperbarui dan terenkripsi
            jsonObject.pengunjung = JToken.FromObject(updatedList);

            // Serialisasi kembali objek JSON dengan bagian "pengunjung" yang sudah diperbarui
            string updatedJsonContent = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);

            // Tulis kembali ke file JSON
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

        public void UpdatePengunjung(Pengunjung updatedPengunjung)
        {
            // Cari pengunjung yang sesuai berdasarkan ID
            var pengunjung = pengunjungList.FirstOrDefault(p => p.Id == updatedPengunjung.Id);
            if (pengunjung != null)
            {
                pengunjung.Tanggal = updatedPengunjung.Tanggal;
                pengunjung.Nama = updatedPengunjung.Nama;
                pengunjung.Email = updatedPengunjung.Email;
                pengunjung.Alamat = updatedPengunjung.Alamat;
                pengunjung.NomorHP = updatedPengunjung.NomorHP;
                pengunjung.Pekerjaan = updatedPengunjung.Pekerjaan;

                // Simpan perubahan ke file JSON
                SavePengunjungToJson(pengunjungList);
                LoadPengunjungData(); // Refresh GridData
            }
        }


        private List<Pengunjung> LoadPengunjungFromJson()
        {
            string filePath = "users.json";

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(new RootObject { pengunjung = new List<Pengunjung>() }));
            }

            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<RootObject>(json) ?? new RootObject();
            if (data.pengunjung == null)
            {
                data.pengunjung = new List<Pengunjung>();
            }

            foreach (var pengunjung in data.pengunjung)
            {
                pengunjung.Nama = TryDecrypt(pengunjung.Nama);
                pengunjung.Email = TryDecrypt(pengunjung.Email);
                pengunjung.Alamat = TryDecrypt(pengunjung.Alamat);
                pengunjung.NomorHP = TryDecrypt(pengunjung.NomorHP);
                pengunjung.Keperluan = TryDecrypt(pengunjung.Keperluan);
                pengunjung.Keterangan = TryDecrypt(pengunjung.Keterangan);
            }

            return data.pengunjung;
        }

        private string TryDecrypt(string cipherText)
        {
            try
            {
                if (IsBase64String(cipherText))
                {
                    return Decrypt(cipherText);
                }
                else
                {
                    return cipherText;
                }
            }
            catch (Exception)
            {
                return cipherText;
            }
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

        private bool IsBase64String(string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String) || base64String.Length % 4 != 0 ||
                base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void LoadPengunjungData()
        {
            pengunjungList = LoadPengunjungFromJson();
            DisplayPengunjungData(pengunjungList);
            UpdateJumlahTamu(pengunjungList.Count);
        }

        private void DisplayPengunjungData(List<Pengunjung> data)
        {
            GridData.Columns.Clear();

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                HeaderText = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80
            };
            GridData.Columns.Add(imgCol);

            GridData.DataSource = new BindingSource() { DataSource = data };

            if (GridData.Columns["FotoPath"] != null)
            {
                GridData.Columns["FotoPath"].Visible = false;
            }

            foreach (DataGridViewRow row in GridData.Rows)
            {
                if (row.Cells["FotoPath"].Value != null)
                {
                    string fotoPath = row.Cells["FotoPath"].Value.ToString();
                    if (File.Exists(fotoPath))
                    {
                        try
                        {
                            Image img = Image.FromFile(fotoPath);
                            row.Cells[0].Value = img;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error loading image: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"File not found: {fotoPath}");
                    }
                }
            }

            foreach (DataGridViewColumn column in GridData.Columns)
            {
                if (column.Name != "Foto")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void UpdateJumlahTamu(int totalTamu)
        {
            JmlTamu.Text = $"{totalTamu} Orang";
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (GridData.SelectedRows.Count > 0)
            {
                // Ambil data dari baris yang dipilih
                DataGridViewRow selectedRow = GridData.SelectedRows[0];
                var pengunjung = (Pengunjung)selectedRow.DataBoundItem;

                // Buka form Edit dan isi data ke dalam TextBox
                Edit editForm = new Edit
                {
                    Id = pengunjung.Id,
                    Tanggal = pengunjung.Tanggal.ToString("yyyy-MM-dd"),
                    Nama = pengunjung.Nama,
                    Email = pengunjung.Email,
                    Alamat = pengunjung.Alamat,
                    NomorHP = pengunjung.NomorHP,
                    Pekerjaan = pengunjung.Pekerjaan
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
            LoadPengunjungData();
        }

        private void IntCari_TextChanged(object sender, EventArgs e)
        {
            string searchText = IntCari.Text.ToLower();

            var filteredData = pengunjungList.Where(p =>
                p.Nama.ToLower().Contains(searchText) ||
                p.Tanggal.ToString("yyyy-MM-dd").Contains(searchText)
            ).ToList();

            DisplayPengunjungData(filteredData);
            UpdateJumlahTamu(filteredData.Count);
        }
    }
}
