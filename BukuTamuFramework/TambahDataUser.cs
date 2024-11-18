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
    public partial class TambahDataUser : Form
    {
        public TambahDataUser()
        {
            InitializeComponent();
        }

        private void BtnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
