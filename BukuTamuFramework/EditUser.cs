using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json; 

namespace BukuTamuFramework
{
    public partial class EditUser : Form
    {
        private dynamic selectedUser;

        public EditUser(dynamic selectedUser)
        {
            InitializeComponent();
            this.selectedUser = selectedUser;
            LoadUserData();
        }

        private void LoadUserData()
        {
            IntNama.Text = selectedUser["Name"].ToString();
            IntEmail.Text = selectedUser["Email"].ToString();
            IntUsername.Text = selectedUser["Username"].ToString();
            IntPassword.Text = selectedUser["Password"].ToString();
        }

        private void BtnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            selectedUser["Name"] = IntNama.Text;
            selectedUser["Email"] = IntEmail.Text;
            selectedUser["Username"] = IntUsername.Text;
            selectedUser["Password"] = IntPassword.Text;

            SaveUserData();
            this.Close();
        }

        private void SaveUserData()
        {
            string jsonData = File.ReadAllText("users.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, List<dynamic>>>(jsonData);

            var userIndex = data["users"].FindIndex(user => user["Id"] == selectedUser["Id"]);
            if (userIndex != -1)
            {
                data["users"][userIndex] = selectedUser;
                string updatedJsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText("users.json", updatedJsonData);
            }
        }
    }
}
