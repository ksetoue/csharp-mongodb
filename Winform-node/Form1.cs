using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
//Additionally, you will frequently add one or more of these using statements:
//using MongoDB.Driver.Builders;
//using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace Winform_node
{
    public partial class Form1 : Form
    {
        Process node = new Process();
        Process mongo = new Process();
        string nodeArg = "C:\\node\\mongobase\\index.js";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnnode_Click(object sender, EventArgs e)
        {
            node.StartInfo.UseShellExecute = false;
            node.StartInfo.RedirectStandardOutput = true;
            node.StartInfo.RedirectStandardError = true;
            node.StartInfo.RedirectStandardInput = true;
            node.StartInfo.FileName = @"node"; //path to node            
            node.StartInfo.Arguments = @nodeArg;

            mongo.StartInfo.UseShellExecute = true;
            mongo.StartInfo.RedirectStandardOutput = true;
            mongo.StartInfo.RedirectStandardError = true;
            mongo.StartInfo.RedirectStandardInput = true;
            mongo.StartInfo.FileName = @"mongod"; //path to node            

            node.Start();
            mongo.Start();

        }
    }
}