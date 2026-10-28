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

namespace Profiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static event Action? GlobalDataUpdate;
        public MainWindow()
        {
            InitializeComponent();
            GlobalDataUpdate += OnGlobalDataUpdate;
        }

        private void BtnMemoryLeak_Click(object sender, RoutedEventArgs e)
        {
            var secondaryWindow = new MainWindow();
            secondaryWindow.ShowDialog(); 
        }

        private void BtnLayoutLoad_Click(object sender, RoutedEventArgs e)
        {
            HeavyListContainer.Children.Clear();
            var items = new List<int>();
            for (int i = 0; i < 20000; i++) items.Add(i);

            foreach (var item in items)
            {
                var btn = new Button { Content = $"Элемент {item}", Margin = new Thickness(2) };
                HeavyListContainer.Children.Add(btn);
            }
        }

        private void BtnCPULoad_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as System.Windows.Controls.Button;
            if (btn != null) btn.IsEnabled = false;

            var sw = System.Diagnostics.Stopwatch.StartNew();

            Task.Run(() =>
            {
                Parallel.For(0, Environment.ProcessorCount, (i) =>
                {
                    while (sw.ElapsedMilliseconds < 5000)
                    {
                        double result = 0;
                        for (int j = 0; j < 100000; j++)
                        {
                            result += Math.Sin(j) * Math.Cos(j) / Math.Sqrt(j + 1);
                        }

                        if (result == double.MaxValue)
                            Console.WriteLine(result);
                    }
                });
                Dispatcher.Invoke(() =>
                {
                    if (btn != null) btn.IsEnabled = true;
                    MessageBox.Show($"Нагрузка 100% завершена. Время: {sw.ElapsedMilliseconds} мс");
                });
            });
        }

        private void OnGlobalDataUpdate()
        {

        }
    }
}