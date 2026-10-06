using MultipleWindows.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace MultipleWindows.Repositories
{
    /// <summary>
    /// класс-репозиторий модели User
    /// отвечает за добавление нового пользователя в хранилище (пока не в бд а в списке в памяти)
    /// </summary>
    public class UserRepository
    {
        private readonly ObservableCollection<User> _users = new(); //коллекция - хранилище всех объектов пользователей
        public ObservableCollection<User> Users => _users; //открытое свойство только для чтения чтобы моги связать в качестве источника данных

        public void Add(User user)
        {
            var tempUser = GetUserByLogin(user.Login); //попытка найти пользователя в системе с таким же логином
            if(tempUser != null)
            {
                MessageBox.Show("Логин занят попробуйте другой");
                return;
            }

            _users.Add(user);
        }
       
        public void Remove(string login)
        {
            var user = _users.FirstOrDefault(x => x.Login == login);
            if(user != null)
                _users.Remove(user);
        }

        /// <summary>
        /// вспомогательный метод для поиска в хранилище пользователя с таким логином
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private User? GetUserByLogin(string login) => _users.FirstOrDefault(x => x.Login == login);
    }
}
