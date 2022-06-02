using RentCourseProject.Model;
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

namespace RentCourseProject.Views.Accountant
{
    /// <summary>
    /// Логика взаимодействия для AccountantReceiptPage.xaml
    /// </summary>
    public partial class AccountantReceiptPage : Page
    {
        Core db = new Core();
        List<Invoicing> arrayInvoicing;
        public AccountantReceiptPage()
        {
            InitializeComponent();
            arrayInvoicing = db.context.Invoicing.ToList();
            ResidentReceiptListView.ItemsSource = arrayInvoicing;
        }

        ////Cчитывает элемент и удаляет его
        private void DelReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;

            Invoicing item = activeButton.DataContext as Invoicing;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                db.context.Invoicing.Remove(item);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }

            //обновление ListView
            ResidentReceiptListView.ItemsSource = db.context.Invoicing.ToList();
        }

        //Считывает элемент и переход на страцину с редактированием квитанции
        private void EditReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            Invoicing item = activeButton.DataContext as Invoicing;
            NavigationService.Navigate(new AccountantEditReceiptPage(db.context, item));
        }
    }
}
