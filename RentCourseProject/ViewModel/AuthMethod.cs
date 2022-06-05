using RentCourseProject.Model;
using RentCourseProject.Views.Accountant;
using RentCourseProject.Views.Admin;
using RentCourseProject.Views.Resident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace RentCourseProject.ViewModel
{
    public class AuthMethod
    {
        Core db = new Core();

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="login">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <returns></returns>
        public bool Autorization(string login, string password)
        {
            List<Users> arrUser = db.context.Users.Where(x => x.Login == login && x.Password == password).ToList();
            int countUsers = arrUser.Count();

            if (countUsers != 0)
            {
                Users user = db.context.Users.Where(x => x.Login == login).First();
                if (user.Login == login && user.Password == password)
                {
                    App.currentUser = db.context.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                    return true;
                }
                else
                {
                    MessageBox.Show("Неверный пароль", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Такой пользователь отсутствует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }
        /// <summary>
        /// Определение роли пользователя
        /// </summary>
        /// <param name="login">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <returns></returns>
        public int GetRole(string login, string password)
        {
            return (int)db.context.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault().IdRole;
        }
    }
}
