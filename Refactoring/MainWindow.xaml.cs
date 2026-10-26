using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Refactoring
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // [ЗАПАХ: неиспользуемое поле — VS 2026 подсветит серым]
        private int _unusedCounter = 0;

        // [ЗАПАХ: магическое число]
        private const int MAX_NAME_LENGTH = 20;
        public MainWindow()
        {
            InitializeComponent();
            // [ЗАПАХ: неиспользуемая локальная переменная — серая подсказка VS]
            string temp = "инициализация";
            // [ПРЕДУПРЕЖДЕНИЕ VS 2026: возможный NullReferenceException,
            //  если textBox1 не инициализирован — но здесь сработает]
            textBox1.Text = "";
        }

        // [ЗАПАХ: «божественный» метод ~100 строк]
        // Смешано: UI + валидация + парсинг + бизнес-логика + вывод
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // [ЗАПАХ: прямое чтение контролов внутри "логики"]
            string name = textBox1.Text;
            string email = textBox2.Text;
            string qtyText = textBox3.Text;
            string priceText = textBox4.Text;

            // [ЗАПАХ: валидация, которая ДУБЛИРУЕТСЯ в SaveButton_Click]
            if (name == null || name.Trim() == "")
            {
                MessageBox.Show("Введите имя клиента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                MessageBox.Show("Имя слишком длинное", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (email == null || email.Trim() == "")
            {
                MessageBox.Show("Введите email", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Некорректный email", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // [ЗАПАХ: int.Parse без TryParse — VS 2026 предупредит
            //  о возможном FormatException]
            int quantity;
            try
            {
                quantity = int.Parse(qtyText);
            }
            catch (Exception ex)
            {
                // [ЗАПАХ: catch Exception — слишком широко]
                MessageBox.Show("Некорректное количество: " + ex.Message,
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // [ЗАПАХ: магическое число 1000 — бизнес-ограничение]
            if (quantity <= 0 || quantity > 1000)
            {
                MessageBox.Show("Количество должно быть от 1 до 1000",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // [ЗАПАХ: магическое число 0.2 — ставка НДС, нигде не названа]
            decimal price;
            try
            {
                price = decimal.Parse(priceText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректная цена: " + ex.Message,
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть положительной", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // [ЗАПАХ: бизнес-логика прямо в обработчике события]
            decimal subtotal = quantity * price;
            decimal vat = subtotal * 0.2m;
            decimal total = subtotal + vat;

            // [ЗАПАХ: форматирование и вывод смешаны с расчётом]
            string summary = $"Клиент: {name}\n" +
                             $"Email: {email}\n" +
                             $"Количество: {quantity}\n" +
                             $"Цена за шт.: {price:F2} руб.\n" +
                             $"Сумма без НДС: {subtotal:F2} руб.\n" +
                             $"НДС (20%): {vat:F2} руб.\n" +
                             $"Итого: {total:F2} руб.";

            // [ЗАПАХ: работа с UI из "логики"]
            labelResult.Content = $"Итого: {total:F2} руб.";
            listBox1.Items.Add(summary);

            // [ЗАПАХ: неиспользуемая локальная переменная — VS подсветит]
            string debugInfo = "расчёт выполнен";
        }

        // [ЗАПАХ: ДУБЛИРОВАНИЕ валидации из CalculateButton_Click]
        // Те же проверки на null/пустоту/длину/email/количество
        // и тот же try/catch — копипаста
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox1.Text;
            string email = textBox2.Text;
            string qtyText = textBox3.Text;
            string priceText = textBox4.Text;

            // [КОПИПАСТА 1: та же проверка имени]
            if (name == null || name.Trim() == "")
            {
                MessageBox.Show("Введите имя клиента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                MessageBox.Show("Имя слишком длинное", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // [КОПИПАСТА 2: та же проверка email]
            if (email == null || email.Trim() == "")
            {
                MessageBox.Show("Введите email", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!email.Contains("@"))
            {
                MessageBox.Show("Некорректный email", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // [КОПИПАСТА 3: тот же int.Parse с тем же try/catch]
            int quantity;
            try
            {
                quantity = int.Parse(qtyText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректное количество: " + ex.Message,
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (quantity <= 0 || quantity > 1000)
            {
                MessageBox.Show("Количество должно быть от 1 до 1000",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            decimal price;
            try
            {
                price = decimal.Parse(priceText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Некорректная цена: " + ex.Message,
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть положительной", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // [ЗАПАХ: запись в файл прямо из обработчика, без отдельного класса]
            try
            {
                decimal total = quantity * price * 1.2m;

                // [ЗАПАХ: магическая строка — путь к файлу "зашит"]
                string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "orders.txt");

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("=== Заказ ===");
                sb.AppendLine("Дата: " + DateTime.Now.ToString());
                sb.AppendLine("Клиент: " + name);
                sb.AppendLine("Email: " + email);
                sb.AppendLine("Количество: " + quantity);
                sb.AppendLine("Цена: " + price);
                sb.AppendLine("Итого: " + total);
                sb.AppendLine();

                File.AppendAllText(path, sb.ToString(),
                    Encoding.UTF8);

                MessageBox.Show("Заказ сохранён в " + path, "Готово",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                labelResult.Content = "Заказ сохранён";
            }
            catch (Exception ex)
            {
                // [ЗАПАХ: catch Exception + вывод ex.Message пользователю]
                MessageBox.Show("Ошибка сохранения: " + ex.Message,
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
