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
        string mongoArg = "C:\\Program Files\\MongoDB\\Server\\3.2\\bin";

        //objeto que contem as informacoes que serao inseridas no db
        BsonDocument person = new BsonDocument {
                { "first_name", "Tony"},
                { "last_name", "Stark"},
                { "accounts", new BsonArray {
                    new BsonDocument {
                        { "account_balance", 20000},
                        { "account_type", "Investment"},
                        { "currency", "USD"}
                    }
                }}
            };

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnMongo_Click(object sender, EventArgs e)
        {

            //mongo.StartInfo.UseShellExecute = true;
            //mongo.StartInfo.RedirectStandardOutput = true;
            //mongo.StartInfo.RedirectStandardError = true;
            //mongo.StartInfo.RedirectStandardInput = true;
            //mongo.StartInfo. = "mongod "; //path to mongo    

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "mongod.exe";
            //startInfo.Arguments = mongoArg;
            //mongo.StartInfo = startInfo;
            //mongo.Start();

            //label2.Show();

            //string connection = "mongodb://localhost:27017";
            //var _client = new MongoClient(connection);
            //_server = _client.GetServer();
            //_database = _server.GetDatabase("vinifig");
            // { "The Process object must have the UseShellExecute property set to false in order to redirect IO streams."}

            //conexao como o MongoDB
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017/test"); // connect to localhost
            MongoServer server = client.GetServer(); 
            MongoDatabase database = server.GetDatabase("test"); // "test" is the name of the database

            //collection que contem o documento
            MongoCollection<BsonDocument> bankData = database.GetCollection<BsonDocument>("bank_data");
           
            //insercao
            bankData.Insert(person);
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

        private void button1_Click(object sender, EventArgs e)
        {

            //conexao como o MongoDB
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017/test"); // connect to localhost
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("test"); // "test" is the name of the database

            //collection que contem o documento
            MongoCollection<BsonDocument> bankData = database.GetCollection<BsonDocument>("bank_data");
            //retrieve the inserted collection from mongodb
            //should be the exact same object we just updated
            BsonDocument newPerson = bankData.FindOneById(person["_id"]);
            //check if the account balance was updated.
            textBox1.Text = newPerson["first_name"].ToString() + " id = "+person["_id"].ToString();
            //System.Console.WriteLine(newPerson["accounts"][0]["account_balance"].AsInt32);
        }
    }
}