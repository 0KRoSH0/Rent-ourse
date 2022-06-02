using RentCourseProject.Model;
using RentCourseProject.ViewModel;
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

namespace RentCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Core db = new Core();
        List<Flat> arrayFlat;
        List<House> arrayHouse;
        public RegPage()
        {
            InitializeComponent();
            FlatComboBox.Visibility = Visibility.Collapsed;

            arrayHouse = db.context.House.ToList();
            HouseComboBox.ItemsSource = arrayHouse;
            HouseComboBox.DisplayMemberPath = "Address";
            HouseComboBox.SelectedValuePath = "IdHouse";
            HouseComboBox.SelectedIndex = 0; 
        }

        //Добавление нового пользователя
        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            RegMethod obj = new RegMethod();
            obj.Registration(LoginTextBox.Text, PasswordTextBox.Text, EmailTextBox.Text, TelephoneTextBox.Text, Convert.ToInt32(FlatComboBox.SelectedValue));
        }

        //Фильтрация домов и квартир
        private void HouseComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int activeHouse = Convert.ToInt32(HouseComboBox.SelectedValue);
            arrayFlat = db.context.Flat.Where(x => x.IdHouse == activeHouse).ToList();
            FlatComboBox.ItemsSource = arrayFlat;
            FlatComboBox.DisplayMemberPath = "NumberFlat";
            FlatComboBox.SelectedValuePath = "IdFlat";
            FlatComboBox.SelectedIndex = 0;

            FlatComboBox.Visibility = Visibility.Visible;
        }

        private void FlatComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
