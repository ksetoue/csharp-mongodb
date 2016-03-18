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
        string mongoArg = "C:\\Program Files\\MongoDB\\Server\\3.2\\bin\\mongod.exe";


        BsonDocument person2;
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

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "mongod";
            startInfo.Arguments = mongoArg + " mongod";
            mongo.StartInfo = startInfo;
            mongo.Start();

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
            //objeto que contem as informacoes que serao inseridas no db
            BsonDocument person = new BsonDocument {
                { "first_name", "bla"},
                { "last_name", "bla"},
                { "accounts", new BsonArray {
                    new BsonDocument {
                        { "account_balance", 1000},
                        { "account_type", "Investment"},
                        { "currency", "USD"}
                    }
                }}
            };
            //insercao
            bankData.Insert(person);
            person2 = person;

            //should be the exact same object we just updated
            BsonDocument newP = bankData.FindOneById(person["_id"]);
            //check if the account balance was updated.
            textBox1.Text = newP["first_name"].ToString() + " id = " + person["_id"].ToString();

            label2.Show();
            newP["accounts"][0]["account_balance"] = newP["accounts"][0]["account_balance"].AsInt32;
            label2.Text = "bal = " + newP["accounts"][0]["account_balance"].ToString();
            
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

            //increment this persons balance by 100000
            person2["accounts"][0]["account_balance"] = person2["accounts"][0]["account_balance"].AsInt32 + 200000;
            bankData.Save(person2);
            label2.Text = "Successfully updated 1 document.";
            label2.Show();

            //should be the exact same object we just updated
            BsonDocument newPerson = bankData.FindOneById(person2["_id"]);
            //check if the account balance was updated.
            textBox1.Text = newPerson["first_name"].ToString() + " id = " + person2["_id"].ToString();
            newPerson["accounts"][0]["account_balance"] = newPerson["accounts"][0]["account_balance"].AsInt32;
            label2.Text = "bal = " + newPerson["accounts"][0]["account_balance"].ToString();
            //System.Console.WriteLine(newPerson["accounts"][0]["account_balance"].AsInt32);

            //now delete the document we just inserted
            var query = Query.EQ("_id", newPerson["_id"]);
            WriteConcernResult result = bankData.Remove(query);
            label1.Text = "number of documents removed: " + result.DocumentsAffected.ToString();
            label1.Show();
            //System.Console.WriteLine("number of documents removed: " + result.DocumentsAffected);
        }
    }
}