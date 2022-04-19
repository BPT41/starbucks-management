using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbccontrol sql = new dbccontrol();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DashBoard ds = new DashBoard("Guest");
            ds.Show();
            this.Hide();
        }
        bool Login()
        {
            sql.Param("@usr", txtUsername.Text);
            sql.Param("@pwd", txtPassword.Text);
            sql.querry("select count(*) from tbluser where usr=@usr and pwd=@pwd");
            if ((int)sql.dt.Rows[0][0]==1)
            {
                return true;
            }
            MessageBox.Show("Invalid Username or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login() == true)
            {
                DashBoard ds = new DashBoard("Admin");
                ds.Show();
                this.Hide();
            }                
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            Hide();
            rf.ShowDialog();
        }
    }
}
