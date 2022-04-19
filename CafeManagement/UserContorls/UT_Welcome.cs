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
    public partial class UT_Welcome : UserControl
    {
        public UT_Welcome()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void UT_Welcome_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int num= 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(num == 0)
            {
                label1.ForeColor = Color.DarkGreen;
                label2.ForeColor = Color.DarkGreen;
                label3.ForeColor = Color.DarkGreen;
                num++;
            }
            else if(num == 1)
            {
                label1.ForeColor = Color.ForestGreen;
                label2.ForeColor = Color.ForestGreen;
                label3.ForeColor = Color.ForestGreen;
                num++;
            }
            else if(num == 2)
            {
                label1.ForeColor = Color.DarkOliveGreen;
                label2.ForeColor = Color.DarkOliveGreen;
                label3.ForeColor = Color.DarkOliveGreen;
                num++;
            }
        }
    }
}
