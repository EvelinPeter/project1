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
    public partial class ManageIssue : UserControl
    {
        private List<Issue> Issues;
        public ManageIssue()
        {
            InitializeComponent();
        }

        private void ManageIssue_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);


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
            Issues = new List<Issue>();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  [issue_id] \n");
            sb.Append("      ,[title] \n");
            sb.Append("      ,[post_on] \n");
            sb.Append("      ,[post_by], \n");
            sb.Append("	  ld.User_Name,mi.status,mi.priority,mi.[desc] FROM manage_issue mi  INNER JOIN Login_Details ld \n");
            sb.Append("	  on mi.[post_by]=ld.user_id");



            SqlCommand cmd = new SqlCommand(sb.ToString());
            var dt = DataAccess.GetData(cmd);
            foreach (DataRow row in dt.Rows)
            {
                var issue = new Issue();
                issue.IssueID = Convert.ToInt32(row["issue_id"].ToString());
                issue.Title = row["title"].ToString();
                issue.Description = row["desc"].ToString();
                issue.Priority = (Priority)Convert.ToInt32(row["priority"]);
                issue.PostOn = Convert.ToDateTime(row["post_on"]);
                issue.PostBy = row["User_Name"].ToString();
                issue.Status = (Status)Convert.ToInt32(row["status"]);
               
                Issues.Add(issue);
            }
          
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = Issues;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            AddIssue ai = new AddIssue();
            ai.ShowDialog();
        }

      

        // EDIT Issue ::
        private void button2_Click(object sender, EventArgs e)
        {
            Issue row = dataGridView1.CurrentRow.DataBoundItem as Issue;
            if (row != null)
            {
             
                AddIssue ae = new AddIssue(row);
                if (ae.ShowDialog() == DialogResult.OK)
                {

                    RefreshGrid();

                }

            }
        }

        // DELETE ISSUE DETAILS ::
        private void button3_Click(object sender, EventArgs e)
        {
            try

            {
                Issue row = dataGridView1.CurrentRow.DataBoundItem as Issue;
                if (row != null)
                {

                    SqlCommand cmd = new SqlCommand("DELETE FROM [manage_issue] WHERE [issue_id]=@issue_id");
                   
                    cmd.Parameters.AddWithValue("@issue_id", row.IssueID);
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

        //VIEW ISSUE DETAILS::
        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                Issue row = dataGridView1.CurrentRow.DataBoundItem as Issue;
                if (row != null)
                {                    

                    ViewIssue vi = new ViewIssue(row);
                    if (vi.ShowDialog() == DialogResult.OK)
                    {

                        RefreshGrid();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
