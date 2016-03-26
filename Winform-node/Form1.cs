using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Winform_node
{
    public partial class Form1 : Form
    {
        Process node = new Process();
        Process mongo = new Process();
        string nodeArg = "C:\\node\\mongobase\\index.js";
        MongoDatabase database;
        MongoClient client;
        MongoServer server;
        BsonDocument person2;
        MongoCollection<BsonDocument> bankData;
        public void StartMongo()
        {
      
            ProcessStartInfo procStartInfo = new ProcessStartInfo();               
            procStartInfo.CreateNoWindow = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.FileName = @"C:\Program Files\MongoDB\Server\3.2\bin\mongod.exe";         
            mongo = Process.Start(procStartInfo);
         
        }

        public void StopMongo()
        {
            try
            {
                mongo.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error stopping Mongod.exe");
            }
        }

        public Form1()
        {
            InitializeComponent();
            //Inicia o MongoDB
            StartMongo();
            //Conexão com o MongoDB
            ConnectToMongo();
            //Lista todas as entradas do banco (só para verificar se está inserindo)
            SeeAll();

           
        }

        private void  SeeAll()
        {
            var data = "";
            var cursor = bankData.FindAll().ToList();          
            foreach (var document in cursor)
            {
                data += document["first_name"].ToString() +" "+ document["last_name"].ToString() + " " + document["accounts"][0]["account_balance"].ToString() + "\n";
               
            }
            label1.Text = data.ToString();
            label1.Show();
        }
        private void ConnectToMongo()
        {
            
            client = new MongoClient("mongodb://127.0.0.1:27017/test"); // connect to localhost
            server = client.GetServer();
            database = server.GetDatabase("test"); // "test" is the name of the database
            bankData = database.GetCollection<BsonDocument>("bank_data"); //collection que contem o documento
        }
        //insert a person to the db
        private void btnMongo_Click(object sender, EventArgs e)
        {
            // Process teste = Process.Start("Mongod.exe");

            //mongo.StartInfo.UseShellExecute = true;
            //mongo.StartInfo.RedirectStandardOutput = true;
            //mongo.StartInfo.RedirectStandardError = true;
            //mongo.StartInfo.RedirectStandardInput = true;
            //mongo.StartInfo. = "mongod "; //path to mongo    

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.UseShellExecute = false;
            ////startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "mongod";
            //startInfo.Arguments = mongoArg + " mongod";
            //mongo.StartInfo = startInfo;
            //mongo.Start();

            //label2.Show();

            //string connection = "mongodb://localhost:27017";
            //var _client = new MongoClient(connection);
            //_server = _client.GetServer();
            //_database = _server.GetDatabase("vinifig");
            // { "The Process object must have the UseShellExecute property set to false in order to redirect IO streams."}

            //Object that has the information to be inserted on the db
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
            //insert 
            bankData.Insert(person);
            person2 = person;


            //should be the exact same object we just updated
            BsonDocument newP = bankData.FindOneById(person["_id"]);
            //check if the account balance was updated.
            textBox1.Text = newP["first_name"].ToString() + " id = " + person["_id"].ToString();

            label2.Show();
            newP["accounts"][0]["account_balance"] = newP["accounts"][0]["account_balance"].AsInt32;
            label2.Text = "bal = " + newP["accounts"][0]["account_balance"].ToString();
            SeeAll();
            
        }
        //start conection with node
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
        //increases the last person balance by 100000
        private void button1_Click(object sender, EventArgs e)
        {

            //MongoDB conection
            ConnectToMongo();
            var sortBy = SortBy.Descending("date");
            var query = new QueryDocument();
            //gets the last record 
            var cursor = bankData.Find(query).SetSortOrder(SortBy.Descending("_id")).SetLimit(1);
            person2 = cursor.ElementAt(0);            
            if (person2 != null)
            {
                //increment the last record's balance by 100000                    
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
                /*      var query = Query.EQ("_id", newPerson["_id"]);
                      WriteConcernResult result = bankData.Remove(query);
                      label1.Text = "number of documents removed: " + result.DocumentsAffected.ToString();
                      label1.Show();*/
                SeeAll();
            }
            else {
                label1.Text = "Precisa inserir uma pessoa antes";
                label1.Show();
                  
            }
            
          
        }
        //removes all the records
        private void button2_Click(object sender, EventArgs e)
        {
            /*  ProcessStartInfo si = new ProcessStartInfo();
              si.UseShellExecute = false;
              si.CreateNoWindow = true;
              si.FileName = "Mongod.exe";
              Process p = Process.Start(si);*/
            //MongoDB conection
            ConnectToMongo();

            WriteConcernResult result = bankData.Remove(null);
            label1.Text = "number of documents removed: " + result.DocumentsAffected.ToString();
            label1.Show();
        }
    }
}