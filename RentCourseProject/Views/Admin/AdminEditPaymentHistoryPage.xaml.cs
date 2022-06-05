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
    /// Логика взаимодействия для AdminEditPaymentHistoryPage.xaml
    /// </summary>
    public partial class AdminEditPaymentHistoryPage : Page
    {
        Core db = new Core();
        PaymentHistory currentItem;
        public AdminEditPaymentHistoryPage(RentFlatEntities context, PaymentHistory activeItem)
        {
            InitializeComponent();
            List<Flat> arrayFlat;
            List<Services> arrayServices;
            List<Year> arrayYear;
            List<Month> arrayMonth;


            arrayFlat = db.context.Flat.ToList();
            FlatComboBox.ItemsSource = arrayFlat;
            FlatComboBox.DisplayMemberPath = "NumberFlat";
            FlatComboBox.SelectedValuePath = "IdFlat";

            arrayServices = db.context.Services.ToList();
            ServicesComboBox.ItemsSource = arrayServices;
            ServicesComboBox.DisplayMemberPath = "Service";
            ServicesComboBox.SelectedValuePath = "IdServices";

            arrayYear = db.context.Year.ToList();
            YearComboBox.ItemsSource = arrayYear;
            YearComboBox.DisplayMemberPath = "NumberYear";
            YearComboBox.SelectedValuePath = "IdYear";

            arrayMonth = db.context.Month.ToList();
            MonthComboBox.ItemsSource = arrayMonth;
            MonthComboBox.DisplayMemberPath = "MonthName";
            MonthComboBox.SelectedValuePath = "IdMonth";

            currentItem = activeItem;
            this.db.context = context;
            this.DataContext = currentItem;
        }

        //Сохранение и переход на прошлую страницу
        private void EditPaymentHistoryButtonClick(object sender, RoutedEventArgs e)
        {
            db.context.SaveChanges();
            NavigationService.Navigate(new AdminPaymentHistoryPage());
        }
    }
}
