using MultipleWindows.Models;
using MultipleWindows.Repositories;
using MultipleWindows.Views;
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

namespace MultipleWindows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserRepository _repository;
        public MainWindow(UserRepository repo)
        {
            InitializeComponent();
            _repository = repo;
            UsersListView.ItemsSource = _repository.Users;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUserWindow(_repository);
            addUserWindow.Owner = this;
            addUserWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersListView.SelectedItem as User;
            if (selectedUser != null)
                _repository.Remove(selectedUser.Login);
        }
    }
}