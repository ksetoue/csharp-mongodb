namespace Winform_node
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnnode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMongo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnnode
            // 
            this.btnnode.Location = new System.Drawing.Point(59, 229);
            this.btnnode.Name = "btnnode";
            this.btnnode.Size = new System.Drawing.Size(242, 53);
            this.btnnode.TabIndex = 0;
            this.btnnode.Text = "Node";
            this.btnnode.UseVisualStyleBackColor = true;
            this.btnnode.Click += new System.EventHandler(this.btnnode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Yay! ";
            this.label1.Visible = false;
            // 
            // btnMongo
            // 
            this.btnMongo.Location = new System.Drawing.Point(59, 158);
            this.btnMongo.Name = "btnMongo";
            this.btnMongo.Size = new System.Drawing.Size(242, 55);
            this.btnMongo.TabIndex = 2;
            this.btnMongo.Text = "Insert info";
            this.btnMongo.UseVisualStyleBackColor = true;
            this.btnMongo.Click += new System.EventHandler(this.btnMongo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "uhuul";
            this.label2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(380, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 20);
            this.textBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 54);
            this.button1.TabIndex = 5;
            this.button1.Text = "Update Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(326, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(242, 53);
            this.button2.TabIndex = 6;
            this.button2.Text = "Remove All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 327);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMongo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnnode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnnode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMongo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

