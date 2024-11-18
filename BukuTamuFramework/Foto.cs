using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace BukuTamuFramework
{
    public partial class Foto : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private InputTamu mainForm;
        private string selectedPhotoPath;

        public Foto(InputTamu mainForm) // Ubah ke InputTamu
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void Foto_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                MenuWebcam.Items.Add(device.Name);
            }
            if (videoDevices.Count > 0)
            {
                MenuWebcam.SelectedIndex = 0;
            }
        }

        private void BtnKamera_Click(object sender, EventArgs e)
        {
            if (MenuWebcam.SelectedIndex >= 0)
            {
                videoSource = new VideoCaptureDevice(videoDevices[MenuWebcam.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                videoSource.Start();
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();
            PreviewFoto.Image = frame;
        }

        private void BtnAmbil_Click(object sender, EventArgs e)
        {
            if (PreviewFoto.Image != null)
            {
                string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "Sementara");
                if (!Directory.Exists(projectPath))
                {
                    Directory.CreateDirectory(projectPath);
                }

                string fileName = Path.Combine(projectPath, Path.GetRandomFileName() + ".jpg");
                PreviewFoto.Image.Save(fileName, ImageFormat.Jpeg);

                selectedPhotoPath = fileName;
                MessageBox.Show("Foto berhasil diambil dan disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            StopVideoSource();
        }

        private void BtnCari_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Title = "Pilih Foto",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lepaskan gambar sebelumnya dari PictureBox jika ada
                if (PreviewFoto.Image != null)
                {
                    PreviewFoto.Image.Dispose();
                    PreviewFoto.Image = null;
                }

                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                if (fileInfo.Length > 500 * 1024)
                {
                    MessageBox.Show("Ukuran file maksimal adalah 500 KB.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tentukan path direktori target
                string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source", "Sementara");
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                // Buat nama file random dengan format GUID dan tambahkan ekstensi asli
                string randomFileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                string targetPath = Path.Combine(targetDirectory, randomFileName);

                // Salin file dengan nama random
                File.Copy(openFileDialog.FileName, targetPath, true);

                // Set the selected photo path
                selectedPhotoPath = targetPath;

                // Tampilkan foto di PictureBox PreviewFoto
                PreviewFoto.Image = Image.FromFile(targetPath);

                MessageBox.Show("Foto berhasil dipilih.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StopVideoSource();

            // Lepaskan resource gambar di PreviewFoto jika ada gambar yang ditampilkan
            if (PreviewFoto.Image != null)
            {
                PreviewFoto.Image.Dispose();
                PreviewFoto.Image = null;
            }

            // Mengirimkan path foto yang dipilih atau diambil ke form InputTamu
            if (!string.IsNullOrEmpty(selectedPhotoPath))
            {
                mainForm?.SetFotoPath(selectedPhotoPath); // Kirim path ke TextBox di InputTamu
            }

            this.Close();
        }

        private void StopVideoSource()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource = null;
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Kosongkan jika tidak ada logika yang perlu diimplementasikan
        }
    }
}
