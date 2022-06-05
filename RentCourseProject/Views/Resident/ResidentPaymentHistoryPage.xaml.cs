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

namespace RentCourseProject.Views.Resident
{
    /// <summary>
    /// Логика взаимодействия для ResidentPaymentHistoryPage.xaml
    /// </summary>
    public partial class ResidentPaymentHistoryPage : Page
    {
        Core db = new Core();
        List<PaymentHistory> arrayPaymentHistory;
        public ResidentPaymentHistoryPage()
        {
            InitializeComponent();
            arrayPaymentHistory = db.context.PaymentHistory.Where(x => x.Invoicing.IdStatus == 2).ToList();
            ResidentPaymentHistoryListView.ItemsSource = arrayPaymentHistory;
        }
    }
}
