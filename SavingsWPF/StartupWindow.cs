using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savings
{
    public partial class StartupWindow : Form
    {
        public string path;

        public StartupWindow()
        {
            InitializeComponent();
        }

        public void GetDatabasePath()
        {
            DialogResult dr = new DialogResult();

            DatabasePath dataBasePath = new DatabasePath();
            dr = dataBasePath.ShowDialog();
            if (dr == DialogResult.OK)
            {
                path = dataBasePath.DataFilePath;
                Variables.accountName = Path.GetFileNameWithoutExtension(path);
                SetDatabasePath();
                this.Close();
            }
        }

        public void SetDatabasePath()
        {
            Variables.dataPath = Variables.connectionString + path;
        }

        private void existingAccountButton_Click(object sender, EventArgs e)
        {
            GetDatabasePath();      
        }

        private void newAccountButton_Click(object sender, EventArgs e)
        {

            Directory.CreateDirectory(Variables.databaseFolder);

            string newAccountName = "";
            DialogResult dr = new DialogResult();

            NameAccount nameAccount = new NameAccount();
            dr = nameAccount.ShowDialog();

            if (Variables.accountName != "")
            {
                newAccountName = Variables.accountName + ".db";

                // This is the query which will create a new table in our database file with three columns. An auto increment column called "ID", and two NVARCHAR type columns with the names "Key" and "Value"
                string createMonthlyTableQuery = @"CREATE TABLE IF NOT EXISTS [Monthly] (
                          [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                          [Active] INTEGER NOT NULL,
                          [Description] TEXT NOT NULL,
                          [Category] INTEGER NULL,
                          [Amount] NUMERIC NOT NULL
                          )";

                string createYearlyTableQuery = @"CREATE TABLE IF NOT EXISTS [Yearly] (
                          [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                          [Active] INTEGER NOT NULL,
                          [Description] TEXT NOT NULL,
                          [Category] INTEGER NULL,
                          [Amount] NUMERIC NOT NULL
                          )";

                string createWantedTableQuery = @"CREATE TABLE IF NOT EXISTS [Wanted] (
                          [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                          [Active] INTEGER NOT NULL,
                          [Description] TEXT NOT NULL,
                          [Category] INTEGER NULL,
                          [Amount] NUMERIC NOT NULL
                          )";

                System.Data.SQLite.SQLiteConnection.CreateFile(Path.Combine(Variables.databaseFolder,newAccountName));        // Create the file which will be hosting our database
                using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + Path.Combine(Variables.databaseFolder, newAccountName)))
                {
                    using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                    {
                        con.Open();                             // Open the connection to the database

                        com.CommandText = createMonthlyTableQuery;     // Set CommandText to our query that will create the table
                        com.ExecuteNonQuery();                  // Execute the query
                        com.CommandText = createYearlyTableQuery;     // Set CommandText to our query that will create the table
                        com.ExecuteNonQuery();                  // Execute the query                   
                        com.CommandText = createWantedTableQuery;     // Set CommandText to our query that will create the table
                        com.ExecuteNonQuery();                  // Execute the query


                        con.Close();        // Close the connection to the database
                    }
                }
                Variables.dataPath = Variables.connectionString + Variables.databaseFolder + @"\" + Variables.accountName + ".db";

                string fullDbPath = Variables.databaseFolder + @"\" + Variables.accountName + ".db";

                if (File.Exists(fullDbPath))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("I cannot find the database captain. I must abort!", "Database Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                
            }
        }

        private void StartupWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Variables.dataPath == "")
            {
                Application.Exit();
            }
        }
    }
}
