using MultipleWindows.Repositories;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MultipleWindows
{
   
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly UserRepository repo = new();

        /// <summary>
        /// конструктор всего приложения App создан вручную тк требуется
        /// модифицировать запуск главное окна передав ему ссылку на репозиторий
        /// </summary>
        public App()
        {
            MainWindow mainWindow = new MainWindow(repo); //создается объект окна
            mainWindow.Show(); //окно отображается
        }
        
        
    }

}
