using AppForGym.Classes;
using AppForGym.ClassHelper;
using AppForGym.Database;
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
    /// Логика взаимодействия для EditOrDeleteClientPage.xaml
    /// </summary>
    public partial class EditOrDeleteClientPage : Page
    {
        private User currentUser;
        private bool IsEdit;

        public EditOrDeleteClientPage()
        {
            InitializeComponent();
        }

        public EditOrDeleteClientPage(User user)
        {
            InitializeComponent();

            CmbTariff.ItemsSource = User.Tariffs;

            currentUser = user;

            TbxSurname.Text = currentUser.Surname;
            TbxName.Text = currentUser.Name;
            TbxPatronymic.Text = currentUser.Patronymic;
            DtPickerLastPay.Text = currentUser.LastPayment.ToString();
            CmbTariff.SelectedIndex = currentUser.TariffIndex;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            IsEdit = true;

            BtnEdit.IsEnabled = false;
            TbxSurname.IsEnabled = true;
            TbxName.IsEnabled = true;
            TbxPatronymic.IsEnabled = true;
            BtnSave.IsEnabled = true;
            DtPickerLastPay.IsEnabled = true;
            CmbTariff.IsEnabled = true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DisenableForms();
            UserDB.Update(currentUser.Id, TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, DateTime.Parse(DtPickerLastPay.Text), CmbTariff.SelectedIndex);
            NavigateClass.frmNavigate.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
            {
                DisenableForms();
            }
            else
            {
                NavigateClass.frmNavigate.GoBack();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var answer = MessageBox.Show("Вы уверены, что хотите удалить клиента из базы?", "Подтверждение", MessageBoxButton.YesNo);

            if (answer == MessageBoxResult.Yes)
            {
                UserDB.Delete(currentUser.Id);
                NavigateClass.frmNavigate.GoBack();
            }

        }

        private void DisenableForms()
        {
            IsEdit = false;

            TbxSurname.IsEnabled = false;
            TbxName.IsEnabled = false;
            TbxPatronymic.IsEnabled = false;
            BtnSave.IsEnabled = false;
            BtnEdit.IsEnabled = true;
            DtPickerLastPay.IsEnabled = false;
            CmbTariff.IsEnabled = false;
        }
    }
}
