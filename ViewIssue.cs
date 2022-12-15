using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormProject
{
    public partial class ViewIssue : Form
    {
        public Issue ViewInfo { get; set; }
        public ViewIssue()
        {
            InitializeComponent();
        }
        public ViewIssue(Issue issue) : this()
        {
            ViewInfo = issue;
        }

       
        private void ViewIssue_Load(object sender, EventArgs e)
        {
            try
            {
                if (ViewInfo != null)
                {
                  

                    txtid.Text = ViewInfo.IssueID.ToString();      
                    txttitle.Text = ViewInfo.Title;
                    txtdesc.Text = ViewInfo.Description;
                    txtpriority.Text = ViewInfo.Priority.ToString();
                    txtposton.Text = ViewInfo.PostOn.ToString("dd MMMMs yyyy");
                    txtpostby.Text = ViewInfo.PostBy;
                    txtstatus.Text = ViewInfo.Status.ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
