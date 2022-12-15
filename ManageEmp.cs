using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProject
{

    public partial class ManageEmp : UserControl
    {
        private List<Employee> Employees;
        public ManageEmp()
        {
            InitializeComponent();
        }


        // ADD Employee Button::
        private void button1_Click(object sender, EventArgs e)
        {
            AddEmp ae = new AddEmp();
            if (ae.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        // Edit Employee Row from DataGrid::
        private void button2_Click(object sender, EventArgs e)
        {
            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;      
            if (row != null)
            {
                var employee = new Employee();
                employee.ID = row["user_id"].ToString();
                employee.Name = row["user_name"].ToString();
                employee.Date = Convert.ToDateTime(row["date_of_join"]);
                employee.Role = row["role"].ToString();
                employee.Password = row["pass"].ToString();
                AddEmp ae = new AddEmp(employee);
                if (ae.ShowDialog() == DialogResult.OK)
                {

                    RefreshGrid();

                }

            }
        }

        private void ManageEmp_Load(object sender, EventArgs e)
        {

            try
            {
                RefreshGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshGrid()
        {
            Employees = new List<Employee>();
            SqlCommand cmd = new SqlCommand("SELECT  [user_id],[user_name],[date_of_join],[role] ,[pass]  FROM [login_details]");
            var dt = DataAccess.GetData(cmd);
           
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }


        // DELETE Employee Row from DataGrid::
        private void button3_Click(object sender, EventArgs e)
        {
            try
            
            {
                DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
                if (row != null)
                {

                    SqlCommand cmd = new SqlCommand("DELETE FROM [login_details] WHERE [user_id]=@user_id");
                    cmd.Parameters.AddWithValue("@user_id", row["user_id"].ToString());
                    int i = DataAccess.ExecuteNonQuery(cmd);
                    if (i > 0)
                    {
                        MessageBox.Show(i + " deleted sucessfully");

                      
                    }
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

    }
}