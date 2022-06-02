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

namespace RentCourseProject.Views.Resident
{
    /// <summary>
    /// Логика взаимодействия для ResidentPage.xaml
    /// </summary>
    public partial class ResidentPage : Page
    {
        public ResidentPage()
        {
            InitializeComponent();
        }

        //Переход на страницу с квитанциями
        private void ReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResidentReceiptPage());
        }

        //Переход на страницу с платежами
        private void HistoryPaymentButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResidentPaymentHistoryPage());
        }
    }
}
