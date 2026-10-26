using System.IO;
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

namespace Refactoring2
{
    public partial class MainWindow : Window
    {
        private int _counter = 0;
        private const int MAX_NAME_LENGTH = 50;
        public MainWindow()
        {
            InitializeComponent();
            string init = "start";
            textBox1.Text = "";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string fullName = textBox1.Text;
            string group = textBox2.Text;
            string subject = textBox3.Text;
            string gradeText = textBox4.Text;

            if (fullName == null || fullName.Trim() == "")
            {
                MessageBox.Show("Введите ФИО студента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (fullName.Length > MAX_NAME_LENGTH)
            {
                MessageBox.Show("ФИО слишком длинное", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (group == null || group.Trim() == "")
            {
                MessageBox.Show("Введите группу", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (group.Length != 6)
            {
                MessageBox.Show("Группа должна состоять из 6 символов (например, 241-ИС)",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (subject == null || subject.Trim() == "")
            {
                MessageBox.Show("Введите дисциплину", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int grade;
            try
            {
                grade = int.Parse(gradeText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка оценки: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (grade < 2 || grade > 5)
            {
                MessageBox.Show("Оценка должна быть от 2 до 5", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string controlType;
            if (comboBox1.SelectedIndex == 0) controlType = "Экзамен";
            else if (comboBox1.SelectedIndex == 1) controlType = "Зачёт";
            else if (comboBox1.SelectedIndex == 2) controlType = "Курсовая";
            else controlType = "Не указан";

            if (controlType == "Зачёт" && grade == 2)
            {
            }

            string status;
            if (grade >= 4.5m) status = "Отличник";
            else if (grade == 4) status = "Хорошист";
            else if (grade == 3) status = "Троечник";
            else status = "Неуспевающий";

            string record =
                $"Студент: {fullName} | Группа: {group}\n" +
                $"Дисциплина: {subject} | Контроль: {controlType}\n" +
                $"Оценка: {grade} | Статус: {status}";


            label1.Content = $"{fullName}: {grade} ({status})";
            listBox1.Items.Add(record);

            string debug = "added";

            int? tmp = null;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            string fullName = textBox1.Text;
            string group = textBox2.Text;
            string subject = textBox3.Text;
            string gradeText = textBox4.Text;

            if (fullName == null || fullName.Trim() == "")
            {
                MessageBox.Show("Введите ФИО студента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (fullName.Length > MAX_NAME_LENGTH)
            {
                MessageBox.Show("ФИО слишком длинное", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (group == null || group.Trim() == "")
            {
                MessageBox.Show("Введите группу", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (group.Length != 6)
            {
                MessageBox.Show("Группа должна состоять из 6 символов (например, 241-ИС)",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (subject == null || subject.Trim() == "")
            {
                MessageBox.Show("Введите дисциплину", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int grade;
            try
            {
                grade = int.Parse(gradeText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка оценки: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (grade < 2 || grade > 5)
            {
                MessageBox.Show("Оценка должна быть от 2 до 5", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string status2;
            if (grade >= 5) status2 = "Отличник";
            else if (grade == 4) status2 = "Хорошист";
            else if (grade == 3) status2 = "Троечник";
            else status2 = "Неуспевающий";

            try
            {
                string path = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "grades.txt");

                string record = "=== Ведомость " + DateTime.Now + " ===\n" +
                                "ФИО: " + fullName + "\n" +
                                "Группа: " + group + "\n" +
                                "Дисциплина: " + subject + "\n" +
                                "Оценка: " + grade + "\n" +
                                "Статус: " + status2 + "\n\n";

                File.AppendAllText(path, record);

                MessageBox.Show("Сохранено в " + path, "Готово",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                label1.Content = "Сохранено";
                listBox1.Items.Add("Сохранена оценка: " + subject + " — " + grade);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.SelectedIndex = 0;

            label1.Content = "";
            listBox1.Items.Clear();

            _counter++;

            try
            {
                textBox1.Focus();
            }
            catch{}
        }
    }
}