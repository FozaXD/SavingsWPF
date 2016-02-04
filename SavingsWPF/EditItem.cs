using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Savings
{
    public partial class EditItem : Form
    {

        #region Parameters?

        int cat;
        private Main mainForm;

        #endregion

        #region Constructors

        public EditItem(Main form)
        {
            InitializeComponent();
            SetErrorProviders();
            SetFields();

            mainForm = form;
        }

        #endregion

        #region Functions

        private void SetErrorProviders()
        {
            errorProvider1.Clear();
            editButton.Enabled = false;
            if (descriptionTextBox.Text == "")
            {
                errorProvider1.SetIconAlignment(descriptionTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(descriptionTextBox, "Please enter a description.");
            }
            else if (categoryComboBox.SelectedIndex == -1)
            {
                errorProvider1.SetIconAlignment(categoryComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(categoryComboBox, "Please select a category.");
            }
            else if (amountTextBox.Text == "")
            {
                errorProvider1.SetIconAlignment(amountTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
                errorProvider1.SetError(amountTextBox, "Please enter an amount.");
            }
            else
            {
                errorProvider1.Clear();
                editButton.Enabled = true;
            }
        }

        public void SetFields()
        {
            descriptionTextBox.Text = Variables.Description;
            categoryComboBox.SelectedIndex = Variables.CategoryIndex;
            amountTextBox.Text = Variables.Amount;
        }

        public void editRecord()
        {
            switch (Main.editType)
            {
                case "Monthly":
                    try
                    {
                        using (SQLiteConnection con = new SQLiteConnection(Variables.dataPath))
                        {
                            SQLiteCommand cmd = new SQLiteCommand();
                            cmd.CommandText = @"Update Monthly SET Active = @active, Description = @description, Category = @category, Amount = @amount where Id =" + Variables.Id;
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SQLiteParameter("@active", 1));
                            cmd.Parameters.Add(new SQLiteParameter("@description", descriptionTextBox.Text));
                            cmd.Parameters.Add(new SQLiteParameter("@category", cat));
                            cmd.Parameters.Add(new SQLiteParameter("@amount", amountTextBox.Text));

                            con.Open();

                            int i = cmd.ExecuteNonQuery();

                            if (i != 1)
                            {
                                MessageBox.Show("The database isn't being friendly at the moment. He doesn't want to talk to me.");
                            }
                            mainForm.Draw();
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "Yearly":
                    try
                    {
                        using (SQLiteConnection con = new SQLiteConnection(Variables.dataPath))
                        {
                            SQLiteCommand cmd = new SQLiteCommand();
                            cmd.CommandText = @"Update Yearly SET Active = @active, Description = @description, Category = @category, Amount = @amount where Id =" + Variables.Id;
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SQLiteParameter("@active", 1));
                            cmd.Parameters.Add(new SQLiteParameter("@description", descriptionTextBox.Text));
                            cmd.Parameters.Add(new SQLiteParameter("@category", cat));
                            cmd.Parameters.Add(new SQLiteParameter("@amount", amountTextBox.Text));

                            con.Open();

                            int i = cmd.ExecuteNonQuery();

                            if (i != 1)
                            {
                                MessageBox.Show("The database isn't being friendly at the moment. He doesn't want to talk to me.");
                            }
                            mainForm.Draw();
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                case "Wanted":
                    try
                    {
                        using (SQLiteConnection con = new SQLiteConnection(Variables.dataPath))
                        {
                            SQLiteCommand cmd = new SQLiteCommand();
                            cmd.CommandText = @"Update Wanted SET Active = @active, Description = @description, Category = @category, Amount = @amount where Id =" + Variables.Id;
                            cmd.Connection = con;
                            cmd.Parameters.Add(new SQLiteParameter("@active", 1));
                            cmd.Parameters.Add(new SQLiteParameter("@description", descriptionTextBox.Text));
                            cmd.Parameters.Add(new SQLiteParameter("@category", cat));
                            cmd.Parameters.Add(new SQLiteParameter("@amount", amountTextBox.Text));

                            con.Open();

                            int i = cmd.ExecuteNonQuery();

                            if (i != 1)
                            {
                                MessageBox.Show("The database isn't being friendly at the moment. He doesn't want to talk to me.");
                            }
                            mainForm.Draw();
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

                default:
                    MessageBox.Show("Stop trying to confuse me! You have to tell me where you want me to add to.");
                    break;
            }
        }



        #endregion

        #region Events

        private void editButton_Click(object sender, EventArgs e)
        {
            editRecord();
        }

        private void amountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (Char)Keys.Back)
            {
                if (e.KeyChar != '.')
                {
                    e.Handled = !char.IsNumber(e.KeyChar);
                }
            }
            if (Regex.IsMatch(amountTextBox.Text, @"\.\d\d") && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetErrorProviders();
            switch (categoryComboBox.SelectedIndex)
            {
                case 0:
                    cat = 1;
                    break;

                case 1:
                    cat = 2;
                    break;

                case 2:
                    cat = 3;
                    break;

                case 3:
                    cat = 4;
                    break;

                default:
                    cat = 1;
                    break;
            }
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            SetErrorProviders();
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            SetErrorProviders();
        }

        #endregion
    }
}

