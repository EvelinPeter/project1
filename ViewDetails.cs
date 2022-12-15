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
    public partial class ViewDetails : Form
    {
        public Notice ViewInfo { get; set; }
        public ViewDetails()
        {
            InitializeComponent();
        }
        public ViewDetails(Notice notice) : this()
        {
            ViewInfo = notice;
        }

        private void ViewDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (ViewInfo != null)
                {
                    txtid.Text = ViewInfo.ID;
                    txttitle.Text = ViewInfo.Title;
                    txtdesc.Text = ViewInfo.Description;
                    txtstart.Text = ViewInfo.StartDate.ToString();
                    txtend.Text = ViewInfo.EndDate.ToString();
                    txtpost.Text = ViewInfo.Post;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
