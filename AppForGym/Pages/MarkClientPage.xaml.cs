using AppForGym.Classes;
using AppForGym.ClassHelper;
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

namespace AppForGym.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarkClientPage.xaml
    /// </summary>
    public partial class MarkClientPage : Page
    {
        private User currentUser;

        public MarkClientPage()
        {
            InitializeComponent();
        }

        public MarkClientPage(User user)
        {
            currentUser = user;

            InitializeComponent();

            foreach (DateTime date in currentUser.MarkDates)
            {
                CldrMark.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (DateTime date in CldrMark.SelectedDates)
            {
                currentUser.MarkDates.Add(date);
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
                if (currentUser.MarkDates.Contains(date))
                {
                    currentUser.MarkDates.Remove(date);
                }
            }

            NavigateClass.frmNavigate.GoBack();
        }
    }
}
