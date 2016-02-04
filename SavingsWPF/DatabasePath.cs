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
    public partial class DatabasePath : Form
    {
        public string DataFilePath { get; set; }



        public DatabasePath()
        {
            InitializeComponent();
            Reset();
            CheckExisting();
        }

        public void CheckExisting()
        {
            var directory = new DirectoryInfo(Variables.databaseFolder);

            var existingFile = (from f in directory.GetFiles("*.db")
                                orderby f.LastWriteTime descending
                                select f).FirstOrDefault();
            if (existingFile != null)
            {
                if (existingFile.ToString() != "")
                {
                    databaseFilePathTextBox.Text = Variables.databaseFolder + @"\" + existingFile.ToString();
                    DataFilePath = databaseFilePathTextBox.Text;
                }
            }
        }

        private void Reset()
        {
            errorProviderDataPath.SetIconAlignment(databaseFilePathTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            tick.Visible = false;
            setDataPathButton.Enabled = false;
            if (databaseFilePathTextBox.Text == "")
            {
                errorProviderDataPath.SetError(databaseFilePathTextBox, "Invalid Path.");
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Sqlite (.db)|*.db|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;


            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                DataFilePath = openFileDialog1.FileName;
            }
            databaseFilePathTextBox.Text = DataFilePath;

        }

        private void databaseFilePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(databaseFilePathTextBox.Text))
            {
                tick.Visible = true;
                errorProviderDataPath.Clear();
                setDataPathButton.Enabled = true;
            }
            else
            {
                errorProviderDataPath.SetIconAlignment(databaseFilePathTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
                errorProviderDataPath.SetError(databaseFilePathTextBox, "Invalid Path.");
                tick.Visible = false;
                setDataPathButton.Enabled = false;
            }
        }

        private void setDataPathButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
