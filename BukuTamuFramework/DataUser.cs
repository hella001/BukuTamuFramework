using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json; 

namespace BukuTamuFramework
{
    public partial class DataUser : Form
    {
        private Admin mainForm;
        private List<dynamic> userList;

        public DataUser(Admin mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadUserData();
        }

        private void LoadUserData()
        {
            string jsonData = File.ReadAllText("users.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, List<dynamic>>>(jsonData);

            userList = data["users"].Where(user => user["Role"].ToString() == "user").ToList();

            GridUser.DataSource = userList.Select(user => new
            {
                Name = user["Name"].ToString(),
                Email = user["Email"].ToString(),
                Username = user["Username"].ToString()
            }).ToList();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            mainForm.TampilkanFormPengguna();
        }

        private void BtnTambah_Click(object sender, EventArgs e)
        {
             TambahDataUser Add = new TambahDataUser(); 
             Add.ShowDialog();
             this.Activate();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (GridUser.SelectedRows.Count > 0)
            {
                var selectedUser = userList[GridUser.SelectedRows[0].Index];
                EditUser editUserForm = new EditUser(selectedUser);
                editUserForm.ShowDialog();
                LoadUserData();
            }
        }
    }
}
