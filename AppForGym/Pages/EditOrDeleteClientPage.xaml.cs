using AppForGym.Classes;
using AppForGym.ClassHelper;
using AppForGym.Database;
using AppForGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
        private Client currentClient;
        private bool IsEdit;

        public EditOrDeleteClientPage()
        {
            InitializeComponent();
        }

        public EditOrDeleteClientPage(Client client)
        {
            InitializeComponent();

            CmbTariff.ItemsSource = DBClass.tariffList;

            currentClient = client;

            TbxSurname.Text = currentClient.Surname;
            TbxName.Text = currentClient.Name;
            TbxPatronymic.Text = currentClient.Patronymic;
            DtPickerLastPay.Text = currentClient.LastPaymentDate.ToString();
            CmbTariff.SelectedIndex = currentClient.IDTariff;
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
            DBClass.SP_UpdateClient(currentClient.IDClient, TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, DateTime.Parse(DtPickerLastPay.Text), CmbTariff.SelectedIndex + 1);
            //UserDB.Update(currentClient.IDClient, TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, DateTime.Parse(DtPickerLastPay.Text), CmbTariff.SelectedIndex);
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
                DBClass.SP_DeleteClient(currentClient.IDClient);
                //UserDB.Delete(currentClient.IDClient);
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
