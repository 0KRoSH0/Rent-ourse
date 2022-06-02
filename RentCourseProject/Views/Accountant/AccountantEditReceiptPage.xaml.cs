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
    /// Логика взаимодействия для AccountantEditReceiptPage.xaml
    /// </summary>
    public partial class AccountantEditReceiptPage : Page
    {
        Core db = new Core();
        Invoicing currentItem;
        List<Flat> arrayFlat;
        List<Services> arrayServices;
        List<Status> arrayStatus;
        List<Year> arrayYear;
        List<Month> arrayMonth;
        public AccountantEditReceiptPage(RentFlatEntities context, Invoicing activeItem)
        {
            InitializeComponent();
            arrayFlat = db.context.Flat.ToList();
            FlatComboBox.ItemsSource = arrayFlat;
            FlatComboBox.DisplayMemberPath = "NumberFlat";
            FlatComboBox.SelectedValuePath = "IdFlat";

            arrayServices = db.context.Services.ToList();
            ServicesComboBox.ItemsSource = arrayServices;
            ServicesComboBox.DisplayMemberPath = "Service";
            ServicesComboBox.SelectedValuePath = "IdServices";

            arrayStatus = db.context.Status.ToList();
            StatusComboBox.ItemsSource = arrayStatus;
            StatusComboBox.DisplayMemberPath = "StatusName";
            StatusComboBox.SelectedValuePath = "IdStatus";

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

        //Сохранение измененной информации
        private void EditReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            db.context.SaveChanges();
            NavigationService.Navigate(new AccountantReceiptPage());
        }
    }
}
