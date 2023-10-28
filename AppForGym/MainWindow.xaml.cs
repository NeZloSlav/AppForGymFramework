using AppForGym.ClassHelper;
using AppForGym.Models;
using AppForGym.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.VisualBasic;

namespace AppForGym
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CheckConnString();

            NavigateClass.frmNavigate = FrmContent;

            ListPage listPage = new ListPage();

            FrmContent.Navigate(listPage);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CheckConnString()
        {
            //string line = string.Empty;

            //try
            //{
            //    string pathToIcoFile = AppDomain.CurrentDomain.BaseDirectory + "AppForGym\\ClassHelper\\ConnStr.txt";

            //    StreamReader reader = new StreamReader(pathToIcoFile);

            //    line = reader.ReadLine();

            //    Database.DBClass.ConnectionString = line;

            //    reader.Close();
            //}
            //catch (Exception e)
            //{
            //    StreamWriter sw = new StreamWriter()
            //}
        }
    }
}
