
namespace WinFormProject
{
    partial class ViewIssue
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.txtpriority = new System.Windows.Forms.TextBox();
            this.txtposton = new System.Windows.Forms.TextBox();
            this.txtpostby = new System.Windows.Forms.TextBox();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.txtdesc = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Issue ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Priority";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(81, 372);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Post_On";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(78, 427);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Post_By";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(78, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(229, 53);
            this.txtid.Multiline = true;
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(208, 29);
            this.txtid.TabIndex = 7;
            // 
            // txttitle
            // 
            this.txttitle.Location = new System.Drawing.Point(229, 116);
            this.txttitle.Multiline = true;
            this.txttitle.Name = "txttitle";
            this.txttitle.ReadOnly = true;
            this.txttitle.Size = new System.Drawing.Size(208, 29);
            this.txttitle.TabIndex = 8;
            // 
            // txtpriority
            // 
            this.txtpriority.Location = new System.Drawing.Point(229, 317);
            this.txtpriority.Multiline = true;
            this.txtpriority.Name = "txtpriority";
            this.txtpriority.ReadOnly = true;
            this.txtpriority.Size = new System.Drawing.Size(208, 29);
            this.txtpriority.TabIndex = 10;
            // 
            // txtposton
            // 
            this.txtposton.Location = new System.Drawing.Point(229, 372);
            this.txtposton.Multiline = true;
            this.txtposton.Name = "txtposton";
            this.txtposton.ReadOnly = true;
            this.txtposton.Size = new System.Drawing.Size(208, 27);
            this.txtposton.TabIndex = 11;
            // 
            // txtpostby
            // 
            this.txtpostby.Location = new System.Drawing.Point(229, 427);
            this.txtpostby.Multiline = true;
            this.txtpostby.Name = "txtpostby";
            this.txtpostby.ReadOnly = true;
            this.txtpostby.Size = new System.Drawing.Size(208, 29);
            this.txtpostby.TabIndex = 12;
            // 
            // txtstatus
            // 
            this.txtstatus.Location = new System.Drawing.Point(229, 487);
            this.txtstatus.Multiline = true;
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.ReadOnly = true;
            this.txtstatus.Size = new System.Drawing.Size(208, 28);
            this.txtstatus.TabIndex = 13;
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(229, 193);
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.ReadOnly = true;
            this.txtdesc.Size = new System.Drawing.Size(219, 96);
            this.txtdesc.TabIndex = 14;
            this.txtdesc.Text = "";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(542, 499);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 15;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.txtstatus);
            this.Controls.Add(this.txtpostby);
            this.Controls.Add(this.txtposton);
            this.Controls.Add(this.txtpriority);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ViewIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ViewIssue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.TextBox txtpriority;
        private System.Windows.Forms.TextBox txtposton;
        private System.Windows.Forms.TextBox txtpostby;
        private System.Windows.Forms.TextBox txtstatus;
        private System.Windows.Forms.RichTextBox txtdesc;
        private System.Windows.Forms.Button button1;
    }
}
