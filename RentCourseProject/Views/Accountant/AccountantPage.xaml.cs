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
    /// Логика взаимодействия для AccountantPage.xaml
    /// </summary>
    public partial class AccountantPage : Page
    {
        public AccountantPage()
        {
            InitializeComponent();
        }

        //Переход на страницу с квитанциями
        private void ViewReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccountantReceiptPage());
        }

        //Переход на страницу с добавлением новой квитанции
        private void AddReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccountantAddReceiptPage());
        }
    }
}
