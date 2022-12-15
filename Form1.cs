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
    public partial class Form1 : Form
    {
      
        SqlCommand cmd;
        SqlDataAdapter da;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
             {
                DataTable dt = new DataTable();
                if (texUser.Text == "")
                {
                    MessageBox.Show("Enter Valid UserName !");
                    texUser.Focus();

                }
                else if (texPass.Text == "")
                {
                    MessageBox.Show("Enter Valid Password!");
                    texPass.Focus();
                }
                else
                {
                    cmd = new SqlCommand("Select * from login_details where user_name = @user_name and pass =@pass");
                    cmd.Parameters.AddWithValue("@user_name", texUser.Text);
                    cmd.Parameters.AddWithValue("@pass", texPass.Text);
                    dt = DataAccess.GetData(cmd);
                    if (dt.Rows.Count > 0)

                    {
                        MessageBox.Show("Login Sucessfully");
                    
                        if (dt.Rows.Count == 1)
                        {
                            this.Hide();

                            GlobalVariables.Role = dt.Rows[0]["Role"].ToString();
                            GlobalVariables.UserId = Convert.ToInt64(dt.Rows[0]["user_id"]);
                            GlobalVariables.UserName = dt.Rows[0]["user_name"].ToString();

                            switch (GlobalVariables.Role)
                            {
                                case "ADMIN":
                                    Form2 frm = new Form2();
                                    frm.Show();
                                   
                                    break;
                                case "USER":
                                    //Show a different form
                                    Form3 fur = new Form3();
                                    fur.Show();
                                    this.Hide();
                                    break;
                                default:
                                    this.Show();
                                    break;
                            }
                        }
                    }
                    else
                        MessageBox.Show("Invalid user name and password");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         

        }

        
    }
}
