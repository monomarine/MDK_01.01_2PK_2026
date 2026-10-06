using MultipleWindows.Models;
using MultipleWindows.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MultipleWindows.Views
{
    /// <summary>
    /// диалоговое окно добавления нового пользователя
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private readonly UserRepository _repository;
        public AddUserWindow(UserRepository repo)
        {
            InitializeComponent();
            _repository = repo;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие текущего объекта окна без изменений
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(LoginTextBox.Text)) //проверка корректности логина
            {
                MessageBox.Show("некорректный логин");
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text)) //проверка корректности пароля
            {
                MessageBox.Show("некорректный пароль");
                return;
            }

            var user = new User(LoginTextBox.Text, PasswordTextBox.Text); //создание новогопользователя из введенных данных

            _repository.Add(user); //добавление через прослойку репозитория
            this.DialogResult = true;
        }
    }
}
