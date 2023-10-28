using AppForGym.Classes;
using AppForGym.ClassHelper;
using AppForGym.Database;
using AppForGym.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AppForGym.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarkClientPage.xaml
    /// </summary>
    public partial class MarkClientPage : Page
    {
        private readonly Client currentClient;

        public MarkClientPage()
        {
            InitializeComponent();
        }

        public MarkClientPage(Client client)
        {
            currentClient = client;

            InitializeComponent();

            foreach (DateTime date in DBClass.SP_GetAllMarkDates(currentClient.IDClient))
            {
                CldrMark.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (DateTime date in CldrMark.SelectedDates)
            {
                DBClass.SP_AddMarkDate(currentClient.IDClient, date);
                //currentUser.MarkDates.Add(date);
            }

            MessageBox.Show("Выделенные даты занесены в базу.", "Успех!");

            NavigateClass.frmNavigate.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNavigate.GoBack();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var date in CldrMark.SelectedDates)
            {
                if (DBClass.SP_GetAllMarkDates(currentClient.IDClient).Contains(date))
                {
                    DBClass.SP_DeleteMarkDate(currentClient.IDClient, date);
                    //currentUser.MarkDates.Remove(date);
                }
            }

            NavigateClass.frmNavigate.GoBack();
        }
    }
}
