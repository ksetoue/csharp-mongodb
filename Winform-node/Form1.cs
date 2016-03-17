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
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace Winform_node
{
    public partial class Form1 : Form
    {
        Process node = new Process();
        Process mongo = new Process();
        string nodeArg = "C:\\node\\mongobase\\index.js";
        MongoServer _server;
        MongoDatabase _database;       

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnMongo_Click(object sender, EventArgs e)
        {


            mongo.StartInfo.UseShellExecute = false;
            mongo.StartInfo.RedirectStandardOutput = true;
            mongo.StartInfo.RedirectStandardError = true;
            mongo.StartInfo.RedirectStandardInput = true;
            mongo.StartInfo.FileName = "mongod"; //path to node   
            mongo.StartInfo.Arguments = "";
            var time = mongo.GetLifetimeService();
            mongo.Start();
            label2.Show();
            textBox1.Text = time.ToString();
            //string connection = "mongodb://localhost:27017";
            //var _client = new MongoClient(connection);
            //_server = _client.GetServer();
            //_database = _server.GetDatabase("vinifig");
            // { "The Process object must have the UseShellExecute property set to false in order to redirect IO streams."}
        }

        private void btnnode_Click(object sender, EventArgs e)
        {
            node.StartInfo.UseShellExecute = false;
            node.StartInfo.RedirectStandardOutput = true;
            node.StartInfo.RedirectStandardError = true;
            node.StartInfo.RedirectStandardInput = true;
            node.StartInfo.FileName = "node"; //path to node            
            node.StartInfo.Arguments = @nodeArg;

                     

            node.Start();
            label1.Show();

        }

    }
}