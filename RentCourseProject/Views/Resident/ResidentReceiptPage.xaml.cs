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
    /// Логика взаимодействия для ReceiptPage.xaml
    /// </summary>
    public partial class ResidentReceiptPage : Page
    {
        Core db = new Core();
        List<Invoicing> arrayInvoicing;

        public ResidentReceiptPage()
        {
            InitializeComponent();
            arrayInvoicing = db.context.Invoicing.ToList();
            ResidentReceiptListView.ItemsSource = arrayInvoicing;
        }
    }
}
