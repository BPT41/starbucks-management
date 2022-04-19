using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGVPrinterHelper;

namespace CafeManagement.UserContorls
{
    public partial class UC_PlaceOrder : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                guna2DataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                guna2DataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            String category = comboCategory.Text;
            query = "select name from items where category = '" + category + "'";
            showItemlist(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String category = comboCategory.Text;
            query = "select name from items where category = '" + category + "'and name like '"+txtSearch.Text+"%'";
            showItemlist(query);
        }
        private void showItemlist(string query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                txtQuanityUpDown1.ResetText();
                txtTotal.Clear();

                String text = listBox1.GetItemText(listBox1.SelectedItem);
                txtItenName.Text = text;
                query = "select price from items where name = '" + text + "'";
                DataSet ds = fn.getData(query);

                txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
                try
                {
                    txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                catch { }
            }
        }

        private void txtQuanityUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtQuanityUpDown1.Value.ToString());
            Int64 price = Int64.Parse(txtPrice.Text);
            txtTotal.Text = (quan * price).ToString();
        }
        int amount;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { }
        }
        protected int n, total = 0;

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            labelTotalAmount.Text = "฿. " + total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill Form StarBucks";
            printer.SubTitle = string.Format("Date :{0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount : " + labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);

            total = 0;
            guna2DataGridView1.Rows.Clear();
            labelTotalAmount.Text = "฿. " + total;

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTotalAmount_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddTobag_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = txtItenName.Text;
                guna2DataGridView1.Rows[n].Cells[1].Value = txtPrice.Text;
                guna2DataGridView1.Rows[n].Cells[2].Value = txtQuanityUpDown1.Value;
                guna2DataGridView1.Rows[n].Cells[3].Value = txtTotal.Text;


                total += int.Parse(txtTotal.Text);
                labelTotalAmount.Text = "฿. " + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
