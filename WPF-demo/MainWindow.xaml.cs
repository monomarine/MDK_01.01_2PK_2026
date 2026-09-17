using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, string> _users = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SayHelloButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Password;

            if (string.IsNullOrEmpty(login))
                MessageBox.Show("Логин не может быть пустым");
            else if (string.IsNullOrEmpty(password))
                MessageBox.Show("Пароль не может быть пустым");
            else
            {
                if (!_users.ContainsKey(login) && (isAgreeCheckBox.IsChecked == true))
                {
                    _users[login] = password;
                    MessageBox.Show("регистрация прошла успешно");
                }
                    
                else
                {
                    MessageBox.Show("Регистрация не возможна. Логин занят");
                }
            }
        }
    }
}