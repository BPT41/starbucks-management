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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
        dbccontrol sql = new dbccontrol();
        void register()
        {
            sql.Param("@usr", txtUsername.Text);
            sql.Param("@pwd", txtPassword.Text);
            sql.Param("@fn", txtFirst.Text);
            sql.Param("@tel",txtTel.Text);
            sql.querry("insert into tbluser(usr,pwd,fn,tel) values(@usr,@pwd,@fn,@tel)");
            if (sql.Check4error(true))
            {
                return;
            }
            MessageBox.Show("Resgitered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if(frm is Form1)
                {
                    frm.Show();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            register();
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
