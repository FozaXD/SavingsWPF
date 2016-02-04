using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;
using Savings;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace SavingsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        #region Variables
        DataTable yearlyTable = CreateDataTable();
        public static string addType;
        public static string editType;
        decimal sumYearly = 0.00m;
        decimal sumMonthly = 0.00m;
        decimal sumWanted = 0.00m;
        decimal twelveMonthMonthly = 0.00m;

        #endregion

        ObservableCollection<Yearly> oc = new ObservableCollection<Yearly>();

        public class Yearly
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Category { get; set; }
            public decimal Amount { get; set; }
        }

        //       #region Functions
        public MainWindow()
        {
            InitializeComponent();

            // Startup1();

            Draw();
            GetYearlyTotal();
            // DrawUserInfo();
        }

        public void Draw()
        {
            DrawYearlyDataGridView();
            DrawMonthlyDataGridView();
            DrawWantedDataGridView();
            //        GetTotals();
            //        GetCategoryCounts();
        }

        public void GetYearlyTotal()
        {
            double sum = 0;
            foreach (var row in yearlyDataGridView.Items)
            {
                sum += double.Parse(row[3].ToString());
            }
            yearlyTotal.Content = sum.ToString()
        }

        public void DrawYearlyDataGridView()
        {
            yearlyDataGridView.Items.Clear();
            try
            {
                SQLiteConnection con = new SQLiteConnection(Variables.connectionString + @"C:\Savings\Databases\Alex.db");
                con.Open();
                SQLiteCommand comm = new SQLiteCommand("Select * From Yearly", con);
                comm.ExecuteNonQuery();

                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(comm);
                DataTable dt = new DataTable("Yearly");
                dataAdp.Fill(dt);
                yearlyDataGridView.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DrawMonthlyDataGridView()
        {
            monthlyDataGridView.Items.Clear();
            try
            {
                SQLiteConnection con = new SQLiteConnection(Variables.connectionString + @"C:\Savings\Databases\Alex.db");
                con.Open();
                SQLiteCommand comm = new SQLiteCommand("Select * From Monthly", con);
                comm.ExecuteNonQuery();

                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(comm);
                DataTable dt = new DataTable("Monthly");
                dataAdp.Fill(dt);
                monthlyDataGridView.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DrawWantedDataGridView()
        {
            wantedDataGridView.Items.Clear();
            try
            {
                SQLiteConnection con = new SQLiteConnection(Variables.connectionString + @"C:\Savings\Databases\Alex.db");
                con.Open();
                SQLiteCommand comm = new SQLiteCommand("Select * From Wanted", con);
                comm.ExecuteNonQuery();

                SQLiteDataAdapter dataAdp = new SQLiteDataAdapter(comm);
                DataTable dt = new DataTable("Wanted");
                dataAdp.Fill(dt);
                wantedDataGridView.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void yearlyDataGridView_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Set properties on the columns during auto-generation 
            switch (e.Column.Header.ToString())
            {
                case "Active":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }

            if (e.Column.Header.ToString() == "Amount")
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "C2";
                (e.Column as DataGridTextColumn).Width = 100;
            }
        }
        private void yearlyDataGridView_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#bfbfbf"));
            e.Row.Height = 22;
        }
    }
}
