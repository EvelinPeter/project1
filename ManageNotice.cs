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
    public partial class ManageNotice : UserControl
    {
        private List<Notice> Notices;
    
        public ManageNotice()
        {
            InitializeComponent();
        }

        private void ManageNotice_Load(object sender, EventArgs e)
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
            Notices = new List<Notice>();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  [notice_id] \n");
            sb.Append("      ,[title] \n");
            sb.Append("      ,[desc] \n");
            sb.Append("      ,[start_date] \n");
            sb.Append("      ,[exp_date] \n");
            sb.Append("      ,[post_by], \n");
            sb.Append("	  ld.User_Name FROM [manage_notice] mn  INNER JOIN Login_Details ld \n");
            sb.Append("	  on mn.[post_by]=ld.user_id");
            SqlCommand cmd = new SqlCommand(sb.ToString());
            var dt = DataAccess.GetData(cmd);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        // ADD Notices :::
        private void button1_Click(object sender, EventArgs e)
        {

            AddNotice an = new AddNotice();
            an.ShowDialog();
            if (an.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        // Edit Notices :::
        private void button2_Click(object sender, EventArgs e)
        {
            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row != null)
            {
               var notice = new Notice();
                notice.ID = row["notice_id"].ToString();
                notice.Title = row["title"].ToString();
                notice.Description = row["desc"].ToString();
                notice.StartDate = Convert.ToDateTime(row["start_date"]);
                notice.EndDate = Convert.ToDateTime(row["exp_date"]);
                AddNotice ae = new AddNotice(notice);
                if (ae.ShowDialog() == DialogResult.OK)
                {

                    RefreshGrid();

                }

            }
        }

        // Delete Record ::
        private void button3_Click(object sender, EventArgs e)
        {
            try

            {
                DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
                if (row != null)
                {

                    SqlCommand cmd = new SqlCommand("DELETE FROM [manage_notice] WHERE [notice_id]=@notice_id");
                    cmd.Parameters.AddWithValue("@notice_id", row["notice_id"].ToString());
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


        // view details:
        private void button4_Click(object sender, EventArgs e)

        {
            try
            {
                DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
                if (row != null)
                {
                    var notice = new Notice();
                    notice.ID = row["notice_id"].ToString();
                    notice.Title = row["title"].ToString();
                    notice.Description = row["desc"].ToString();
                    notice.StartDate = Convert.ToDateTime(row["start_date"]);
                    notice.EndDate = Convert.ToDateTime(row["exp_date"]);
                    notice.Post = row["post_by"].ToString();

                    ViewDetails vd = new ViewDetails(notice);
                    if (vd.ShowDialog() == DialogResult.OK)
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
