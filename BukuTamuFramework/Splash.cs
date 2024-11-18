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
    public partial class Splash : Form
    {
        private Timer timer;
        private int progressValue = 0;

        public Splash()
        {
            InitializeComponent();

            // Inisialisasi Timer
            timer = new Timer();
            timer.Interval = 50; // Interval 50 ms untuk mencapai 5 detik
            timer.Tick += Timer_Tick;
            timer.Start();

            // Inisialisasi nilai awal ProgressBar
            ProgresBar.Maximum = 100; // Asumsi maksimum nilai progress adalah 100
            ProgresBar.Value = 0;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressValue += 1; // Menambah progress sebesar 1% setiap interval
            ProgresBar.Value = progressValue;

            if (progressValue >= 100)
            {
                timer.Stop(); // Menghentikan timer ketika progress selesai
                OpenInputTamuForm(); // Buka form InputTamu
            }
        }

        private void OpenInputTamuForm()
        {
            this.Hide();
            InputTamu inputTamuForm = new InputTamu();
            inputTamuForm.Show();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Event handler kosong
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
