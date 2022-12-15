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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        // Manage EMPLOYEE ::
        private void button1_Click(object sender, EventArgs e)
        {

            ManageEmp me = new ManageEmp();
            SetContent(me);

        }
        public void SetContent(UserControl control)
        {
            panel2.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel2.Controls.Add(control);
            control.Show();
            panel2.Show();
            control.Refresh();
            panel2.Refresh();
            Refresh();
        }

        //LOGOUT ::
        private void button4_Click(object sender, EventArgs e)
        {
            
            Form1 logout = new Form1();
            logout.Show();
            this.Close();
        }
        // Manage ISSUES ::
        private void button2_Click(object sender, EventArgs e)
        {
            ManageIssue mi = new ManageIssue();
            SetContent(mi);
        }
        // Manage NOTICES ::
        private void button3_Click(object sender, EventArgs e)
        {
            ManageNotice mn = new ManageNotice();
            SetContent(mn);
        }
    }
}
