using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class fLogin : Form
    {
        private Client theClient = new Client();
        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txbUserName.Text.Length != 0 && txbPwd.Text.Length != 0)
            {
                theClient.User.UserName = txbUserName.Text;
                theClient.User.PassWord = txbPwd.Text;
            }
            if (theClient.Login())
            {
                this.Hide();
                fMain f = new fMain(theClient);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password! \nPlease check again!", "Login faile", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
