using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleWindows.Models
{
    /// <summary>
    /// класс-модель - описывает сущность предметной области - пользователя
    /// </summary>
    public class User
    {
        public string Login {  get; set; } //логин
        public string Password { get; set; } //пароль - пока в открытом виде
        public DateTime CreationTime { get; set; } //дата создания 

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            CreationTime = DateTime.Now; 
        }

        public override string ToString()
        {
            return Login;
        }
    }
}
