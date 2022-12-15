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

    public partial class AddEmp : Form
    {
        public Employee EmpInfo { get; set; }
        SqlCommand cmd;
        SqlDataAdapter da;
        public AddEmp()
        {
            InitializeComponent();
        }
        public AddEmp(Employee employee) : this()
        {
            EmpInfo = employee;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                if (txtid.Text != "" || txtname.Text != "" || txtrole.Text != "" || txtpass.Text != "")
                {
                    StringBuilder sb = new StringBuilder();
                    if (  EmpInfo==null || EmpInfo.ID == "" || EmpInfo.ID == "0")
                    {
                        sb.Append("INSERT INTO [login_details] \n");
                        sb.Append("           ([user_name] \n");
                        sb.Append("           ,[date_of_join]      ,[role] \n");
                        sb.Append("           ,[pass]) \n");
                        sb.Append("     VALUES \n");
                        sb.Append("           (@user_name \n");
                        sb.Append("           ,@date_of_join   ,@role \n");
                        sb.Append("           ,@pass) \n");
                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.AddWithValue("@user_name", txtname.Text);
                        cmd.Parameters.AddWithValue("@date_of_join", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@role", txtrole.Text);
                        cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                       
                    }
                    else
                    {
                       sb.Append("UPDATE [login_details] \n");
                       sb.Append("   SET [user_name] = @user_name \n");
                       sb.Append("      ,[date_of_join] = @date_of_join \n");
                       sb.Append("      ,[role] = @role \n");
                       sb.Append("      ,[pass] = @pass \n");
                       sb.Append(" WHERE [user_id]=@user_id");
                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.AddWithValue("@user_id", txtid.Text);
                        cmd.Parameters.AddWithValue("@user_name", txtname.Text);
                        cmd.Parameters.AddWithValue("@date_of_join", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@role", txtrole.Text);
                        cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                       
                    }
                   

                    int i = DataAccess.ExecuteNonQuery(cmd);
                    if (i > 0)
                    {
                        MessageBox.Show(i + " Row(s) Updated ");
                        txtid.Clear();
                        txtname.Clear();
                        txtrole.Clear();
                        txtpass.Clear();
                        this.DialogResult = DialogResult.OK;
                        
                    }


                    else
                    {
                        MessageBox.Show("Invalid input");
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void AddEmp_Load(object sender, EventArgs e)
        {
            try
            {
                if (EmpInfo != null)
                {
                    txtid.Text = EmpInfo.ID;
                    txtname.Text = EmpInfo.Name;
                    dateTimePicker1.Value = EmpInfo.Date;
                    txtrole.Text = EmpInfo.Role;
                    txtpass.Text = EmpInfo.Password;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
