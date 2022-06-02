     
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
    /// Логика взаимодействия для AccountantAddReceiptPage.xaml
    /// </summary>
    public partial class AccountantAddReceiptPage : Page
    {
        Core db = new Core();
        List<Flat> arrayFlat;
        List<Services> arrayService;
        List<Status> arrayStatus;
        List<Year> arrayYear;
        List<Month> arrayMonth;
        public AccountantAddReceiptPage()
        {
            InitializeComponent();


            arrayFlat = db.context.Flat.ToList();
            FlatComboBox.ItemsSource = arrayFlat;
            FlatComboBox.DisplayMemberPath = "NumberFlat";
            FlatComboBox.SelectedValuePath = "IdFlat";
            FlatComboBox.SelectedIndex = 0;

            arrayService = db.context.Services.ToList();
            ServicesComboBox.ItemsSource = arrayService;
            ServicesComboBox.DisplayMemberPath = "Service";
            ServicesComboBox.SelectedValuePath = "IdServices";
            ServicesComboBox.SelectedIndex = 0;

            arrayStatus = db.context.Status.ToList();
            StatusComboBox.ItemsSource = arrayStatus;
            StatusComboBox.DisplayMemberPath = "StatusName";
            StatusComboBox.SelectedValuePath = "IdStatus";
            StatusComboBox.SelectedIndex = 0;

            arrayYear = db.context.Year.ToList();
            YearComboBox.ItemsSource = arrayYear;
            YearComboBox.DisplayMemberPath = "NumberYear";
            YearComboBox.SelectedValuePath = "IdYear";
            YearComboBox.SelectedIndex = 0;

            arrayMonth = db.context.Month.ToList();
            MonthComboBox.ItemsSource = arrayMonth;
            MonthComboBox.DisplayMemberPath = "MonthName";
            MonthComboBox.SelectedValuePath = "IdMonth";
            MonthComboBox.SelectedIndex = 0;
        }

        //Добавление новой квитанции
        private void AddReceiptButtonClick(object sender, RoutedEventArgs e)
        {
            Invoicing newReceipt = new Invoicing()
            {
                IdFlat = Convert.ToInt32(FlatComboBox.SelectedValue),
                IdServicesRegion = Convert.ToInt32(ServicesComboBox.SelectedValue),
                IdStatus = Convert.ToInt32(StatusComboBox.SelectedValue),
                IdMonth = Convert.ToInt32(MonthComboBox.SelectedValue),
                IdYear = Convert.ToInt32(YearComboBox.SelectedValue)
            };

            MessageBoxResult result= MessageBox.Show("Вы точно хотите создать квитанцию?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.No)
            {
                MessageBox.Show("Добавление отменено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                db.context.Invoicing.Add(newReceipt);
                db.context.SaveChanges();
                MessageBox.Show("Добавление выполнено успешно !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
