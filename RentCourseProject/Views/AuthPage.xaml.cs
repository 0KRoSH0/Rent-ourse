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
using RentCourseProject.Views.Resident;
using RentCourseProject.Views.Accountant;
using RentCourseProject.Views.Admin;
using RentCourseProject.ViewModel;
using System.Threading;

namespace RentCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        Core db = new Core();
        public AuthPage()
        {
            InitializeComponent();
        }

        //Переходит на страницу регистрации
        private void RegTextBlockMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        //Переход на страницу пользователей
        private void AuthButtonClick(object sender, RoutedEventArgs e)
        {
            AuthMethod obj = new AuthMethod();

            if (obj.Autorization(LoginTextBox.Text, PasswordTextBox.Text) == true)
            {
                obj.GetRole(LoginTextBox.Text, PasswordTextBox.Text);
                if (obj.GetRole(LoginTextBox.Text, PasswordTextBox.Text) == 1)
                {
                    NavigationService.Navigate(new AdminPage());
                }
                if (obj.GetRole(LoginTextBox.Text, PasswordTextBox.Text) == 2)
                {
                    NavigationService.Navigate(new AccountantPage());
                }
                if (obj.GetRole(LoginTextBox.Text, PasswordTextBox.Text) == 3)
                {
                    NavigationService.Navigate(new ResidentPage());
                }
            }
        }
    }
}
