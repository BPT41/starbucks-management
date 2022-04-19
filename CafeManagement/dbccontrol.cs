using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CafeManagement
{
   class dbccontrol
    {
        SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\BOOM\source\repos\CafeManagement\CafeManagement\Database1.mdf;Integrated Security=True");
        SqlCommand cm;
        public SqlDataAdapter da;
        List<SqlParameter> Paramas = new List<SqlParameter>();
        public DataTable dt;
        public int recordcount;
        public string exception;

        public void querry(string name)
        {
            recordcount = 0;
            exception = null;
            try
            {
                cn.Open();
                cm = new SqlCommand(name, cn);
                Paramas.ForEach(p => cm.Parameters.Add(p));
                Paramas.Clear();
                dt = new DataTable();
                da = new SqlDataAdapter(cm);
                recordcount = da.Fill(dt);


            }
            catch (Exception e)
            {
                exception = "Problem:" + e.Message;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

        }
        public void Param(string name,object value)
        {
            SqlParameter newparam = new SqlParameter(name, value);
            Paramas.Add(newparam);
        }
        public bool Check4error(bool err = false)
        {
            if (string.IsNullOrEmpty(exception))
            {
                return false;
            }
            if (err== true)
            {
                MessageBox.Show(exception, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
    }
}
