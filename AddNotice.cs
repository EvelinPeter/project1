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
    public partial class AddNotice : Form
    {
        public Notice NoticeInfo { get; set; }
        SqlCommand cmd;
     

        public AddNotice()
        {
            InitializeComponent();
        }

        public AddNotice(Notice notice) : this()
        {
            NoticeInfo = notice;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (txttitle.Text != null && txtdesc.Text != null)
                {
                    StringBuilder sb = new StringBuilder();
                    if (NoticeInfo == null || NoticeInfo.ID == "" || NoticeInfo.ID == "0")
                    {
                        sb.Append("INSERT INTO [manage_notice] \n");
                        sb.Append("     ([title] \n");
                        sb.Append("     ,[desc] \n");
                        sb.Append("     ,[start_date] \n");
                        sb.Append("     ,[exp_date],[post_by])\n");
                        sb.Append(" VALUES \n");
                        sb.Append("      (@title \n");
                        sb.Append("      ,@desc \n");
                        sb.Append("      ,@start_date \n");
                        sb.Append("      ,@exp_date,@post_by) \n");
                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.AddWithValue("@title", txttitle.Text);
                        cmd.Parameters.AddWithValue("@desc", txtdesc.Text);
                        cmd.Parameters.AddWithValue("@start_date", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@exp_date", dateTimePicker2.Value.Date);
                        cmd.Parameters.AddWithValue("@post_by", GlobalVariables.UserId);

                    }

                    else
                    {
                        sb.Append("UPDATE [manage_notice] \n");
                        sb.Append("   SET [title] = @title \n");
                        sb.Append("      ,[desc] = @desc \n");
                        sb.Append("      ,[start_date] = @start_date \n");
                        sb.Append("      ,[exp_date] = @exp_date \n");
                        sb.Append(" WHERE [notice_id]=@notice_id");
                        cmd = new SqlCommand(sb.ToString());
                        cmd.Parameters.AddWithValue("@title", txttitle.Text);
                        cmd.Parameters.AddWithValue("@desc", txtdesc.Text);
                        cmd.Parameters.AddWithValue("@start_date", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@exp_date", dateTimePicker2.Value.Date);
                        cmd.Parameters.AddWithValue("@notice_id", NoticeInfo.ID);

                    }
                }


                int i = DataAccess.ExecuteNonQuery(cmd);
                if (i > 0)
                {
                    MessageBox.Show(i + " Row(s) Updated ");
                    txttitle.Clear();
                    txtdesc.Clear();
                    this.DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void AddNotice_Load(object sender, EventArgs e)
        {
            try
            {
                if (NoticeInfo != null)
                {
                    txttitle.Text = NoticeInfo.Title;
                    txtdesc.Text = NoticeInfo.Description;
                    dateTimePicker1.Value = NoticeInfo.StartDate;
                    dateTimePicker2.Value = NoticeInfo.EndDate;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageNotice mn = new ManageNotice();
            mn.Show();
            this.Hide();
        }
    }
}
