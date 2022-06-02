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

namespace RentCourseProject.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminPaymentHistoryPage.xaml
    /// </summary>
    public partial class AdminPaymentHistoryPage : Page
    {
        Core db = new Core();
        List<Invoicing> arrayInvoicing;
        public AdminPaymentHistoryPage()
        {
            InitializeComponent();
            arrayInvoicing = db.context.Invoicing.Where(x => x.IdStatus == 2).ToList();
            AdminPaymentHistoryListView.ItemsSource = arrayInvoicing;
        }

        //Cчитывает элемент и переходит на страницу редактирования
        private void EditReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;
            PaymentHistory item = activeButton.DataContext as PaymentHistory;
            NavigationService.Navigate(new AdminEditPaymentHistoryPage(db.context, item));
        }

        //Cчитывает элемент и удаляет его
        private void DelReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            Button activeButton = sender as Button;

            PaymentHistory item = activeButton.DataContext as PaymentHistory;

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                db.context.PaymentHistory.Remove(item);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }

            //обновление ListView
            AdminPaymentHistoryListView.ItemsSource = db.context.Invoicing.ToList();
        }
    }
}
