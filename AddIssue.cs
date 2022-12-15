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
    public partial class AddIssue : Form
    {
        private Issue IssueInfo { get; set; }
        private SqlCommand cmd;
        private List<KeyValuePair<int, string>> Prioritites = new List<KeyValuePair<int, string>>();
        private List<KeyValuePair<int, string>> Status = new List<KeyValuePair<int, string>>();
        public AddIssue()
        {
            IssueInfo = new Issue();
            InitializeComponent();
        }

        public AddIssue(Issue issue) : this()
        {
            IssueInfo = issue;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (txttitle.Text != "" || richTextBox1.Text != "" || cboPriority.Text != "" )
                {

                    StringBuilder sb = new StringBuilder();
                    if (IssueInfo.IssueID == 0)
                    {
                        sb.Append("INSERT INTO [manage_issue] \n");

                        sb.Append("           ([title] \n");
                        sb.Append("           ,[desc] \n");
                        sb.Append("           ,[priority] \n");
                        sb.Append("           ,[post_on],[post_by] ) \n");
                        sb.Append("     VALUES \n");
                        sb.Append("           (@title \n");
                        sb.Append("           ,@desc \n");
                        sb.Append("           ,@priority \n");
                        sb.Append("           ,@post_on ,@post_by) \n");

                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.AddWithValue("@title", txttitle.Text);
                        cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
                        cmd.Parameters.AddWithValue("@priority", cboPriority.SelectedValue);
                        cmd.Parameters.AddWithValue("@post_on", DateTime.Now);
                        cmd.Parameters.AddWithValue("@post_by", GlobalVariables.UserId);
                      
                    }
                    else
                    {

                        sb.Append("UPDATE [manage_issue] \n");
                        sb.Append("      SET [title] = @title \n");
                        sb.Append("      ,[desc] = @desc \n");
                        sb.Append("      ,[priority] = @priority \n");
                        sb.Append("      ,[post_on] = @post_on \n");
                        sb.Append("      ,[post_by] = @post_by \n");
                        sb.Append("      ,[status] = @status \n");
                        sb.Append(" WHERE [issue_id]=@issue_id");
                        cmd = new SqlCommand(sb.ToString());       
                        cmd.Parameters.AddWithValue("@title", txttitle.Text);
                        cmd.Parameters.AddWithValue("@desc", richTextBox1.Text);
                        cmd.Parameters.AddWithValue("@priority", cboPriority.SelectedValue);
                        cmd.Parameters.AddWithValue("@post_on", DateTime.Now);
                        cmd.Parameters.AddWithValue("@post_by", GlobalVariables.UserId);    
                        if (GlobalVariables.Role == "Admin") { 
                            cmd.Parameters.AddWithValue("@status", cboStatus.SelectedValue);
                        }
                        else { 
                            cmd.Parameters.AddWithValue("@status", IssueInfo.Status);
                        }
                        cmd.Parameters.AddWithValue("@issue_id", IssueInfo.IssueID);
                       
     }


                    int i = DataAccess.ExecuteNonQuery(cmd);
                    if (i > 0)
                    {
                        MessageBox.Show(i + " Row(s) Updated ");
                        txttitle.Clear();
                        richTextBox1.Clear();
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

        private void AddIssue_Load(object sender, EventArgs e)
        {
            try
            {
                cboPriority.DataSource = GetPriorities();
                cboPriority.DisplayMember = "Value";
                cboPriority.ValueMember = "Key";
                cboStatus.DataSource = GetStatus();
                cboStatus.DisplayMember = "Value";
                cboStatus.ValueMember = "Key";
                if (IssueInfo.IssueID == 0)
                {
                    label4.Visible = false;
                    label5.Visible = false;
                    cboStatus.Visible = false;
                 
                }
                else
                {
                    label4.Visible = true;
                    label5.Visible = true;
                    cboStatus.Visible = true;


           
                
                }
                label4.Text = IssueInfo.IssueID.ToString();
                txttitle.Text = IssueInfo.Title;
                richTextBox1.Text = IssueInfo.Description;

                cboPriority.SelectedValue = (int)IssueInfo.Priority;
                cboStatus.SelectedValue = (int)IssueInfo.Status;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private List<KeyValuePair<int, string>> GetPriorities()
        {
            var collections = new List<KeyValuePair<int, string>>();
            foreach (var val in Enum.GetValues(typeof(Priority)))
            {
                var keyValue = new KeyValuePair<int, string>((int)val, val.ToString());
                collections.Add(keyValue);
            }
            return collections;
        }


        private List<KeyValuePair<int, string>> GetStatus()
        {
            var collections = new List<KeyValuePair<int, string>>();
            foreach (var val in Enum.GetValues(typeof(Status)))
            {
                var keyValue = new KeyValuePair<int, string>((int)val, val.ToString());
                collections.Add(keyValue);
            }
            return collections;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
