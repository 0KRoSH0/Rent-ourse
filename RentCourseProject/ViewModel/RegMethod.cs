using RentCourseProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RentCourseProject.ViewModel
{
    public class RegMethod
    {
        Core db = new Core();
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="login">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <param name="email">
        /// Почта пользователя
        /// </param>
        /// <param name="phone">
        /// Телефон пользователя
        /// </param>
        /// <param name="idFlat">
        /// Квартира пользователя
        /// </param>
        /// <returns></returns>
        public bool Registration(string login, string password, string email, string phone, int idFlat)
        {
            Users newUser = new Users()
            {
                Login = login,
                Password = password,
                Email = email,
                Phone = phone,
                IdFlat = idFlat,
                IdRole = 3
            };
            if (login == String.Empty || password == String.Empty || email == String.Empty || phone == String.Empty)
            {
                MessageBox.Show("Заполните все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                db.context.Users.Add(newUser);
                db.context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
        }
    }
}
