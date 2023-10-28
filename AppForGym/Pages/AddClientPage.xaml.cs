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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        public AddClientPage()
        {
            InitializeComponent();

            CmbTariff.ItemsSource = DBClass.tariffList;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.frmNavigate.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TbxSurname.Text == string.Empty || TbxName.Text == string.Empty)
            {
                MessageBox.Show("Фамилия или имя клиента обязательно должны быть введены!", "Предупреждение");
            }
            else
            {
                DBClass.SP_AddClient(TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, DateTime.Parse(DtPickerLastPay.Text), CmbTariff.SelectedIndex + 1);
                //UserDB.Add(TbxSurname.Text, TbxName.Text, TbxPatronymic.Text, DateTime.Parse(DtPickerLastPay.Text), CmbTariff.SelectedIndex);
                MessageBox.Show("Данные о клиенте занесены в базу", "Успешно!");
                ClearForms();
            }
        }

        private void ClearForms()
        {
            TbxSurname.Text = string.Empty;
            TbxName.Text = string.Empty;
            TbxPatronymic.Text = string.Empty;
            DtPickerLastPay.Text = string.Empty;
        }
    }
}
