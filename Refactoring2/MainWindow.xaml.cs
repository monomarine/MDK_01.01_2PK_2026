using System.IO;
using System.Windows;

namespace Refactoring2
{
    public partial class MainWindow : Window
    {
        private const int MAX_NAME_LENGTH = 50;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void addButton(object sender, RoutedEventArgs e)
        {
            string fullName = fullNameBox.Text;
            string group = groupBox.Text;
            string subject = subjectBox.Text;
            string gradeText = gradeBox.Text;
            bool is_name_correct = NameValidate(fullName);
            bool IsGroupCorrect = GroupValidate(group);
            if (!IsGroupCorrect || is_name_correct)
            {
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


            ListBox1.Content = $"{fullName}: {grade} ({status})";
            listBox1.Items.Add(record);

            string debug = "added";

            int? tmp = null;
        }

        private static bool GroupValidate(string group)
        {
            if (group == null || group.Trim() == "")
            {
                MessageBox.Show("Введите группу", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (group.Length != 6)
            {
                MessageBox.Show("Группа должна состоять из 6 символов (например, 241-ИС)",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private static bool NameValidate(string fullName)
        {
            if (fullName == null || fullName.Trim() == "")
            {
                MessageBox.Show("Введите ФИО студента", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (fullName.Length > MAX_NAME_LENGTH)
            {
                MessageBox.Show("ФИО слишком длинное", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            string fullName = fullNameBox.Text;
            string group = groupBox.Text;
            string subject = subjectBox.Text;
            string gradeText = gradeBox.Text;

            bool corectName = NameValidate(fullName);
            bool corectGroup = GroupValidate(group);
            if (!corectName || !corectGroup)
            {
                return;
            }
            if (subject == null || subject.Trim() == "")
            {
                MessageBox.Show("Введите дисциплину", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int grade;
            bool gradeCheck = GradeCheck(gradeText,out grade);
            if (!gradeCheck)
            {
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

                ListBox1.Content = "Сохранено";
                listBox1.Items.Add("Сохранена оценка: " + subject + " — " + grade);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static bool GradeCheck(string gradeText, out int grade)
        {
            try
            {
                grade = int.Parse(gradeText);
            }
            catch (Exception ex)
            {
                grade = 0;
                MessageBox.Show("Ошибка оценки: " + ex.Message, "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            ClearChto();

            ListBox1.Content = "";
            listBox1.Items.Clear();


            try
            {
                fullNameBox.Focus();
            }
            catch { }
        }

        private void ClearChto()
        {
            fullNameBox.Text = "";
            groupBox.Text = "";
            subjectBox.Text = "";
            gradeBox.Text = "";
            comboBox1.SelectedIndex = 0;
        }
    }
}