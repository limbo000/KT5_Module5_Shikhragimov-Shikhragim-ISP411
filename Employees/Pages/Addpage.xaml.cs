using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees.Pages
{
    /// <summary>
    /// Логика взаимодействия для Addpage.xaml
    /// </summary>
    public partial class Addpage : Page
    {
        public Data.Employees _currentUser = new Data.Employees();
        public Addpage()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            IdLabel.Visibility = Visibility.Hidden;
            IdTextBox.Visibility = Visibility.Hidden;
            RoleComboBox.ItemsSource = Data.EmployeesEntities.GetContext().Role.ToList();
            GenderComboBox.ItemsSource = Data.EmployeesEntities.GetContext().Gender.ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrEmpty(LastnameTextBox.Text))
                {
                    errors.AppendLine("Заполните фамилию");
                }
                if (string.IsNullOrEmpty(FirstnameTextBox.Text))
                {
                    errors.AppendLine("Заполните имя");
                }
                if (string.IsNullOrEmpty(PatronymicnameTextBox.Text))
                {
                    errors.AppendLine("Заполните отчество");
                }
                if (string.IsNullOrEmpty(RoleComboBox.Text))
                {
                    errors.AppendLine("Выберите должность");
                }
                if (string.IsNullOrEmpty(PhoneTextBox.Text))
                {
                    errors.AppendLine("Заполните номер телефона");
                }
                if (string.IsNullOrEmpty(GenderComboBox.Text))
                {
                    errors.AppendLine("Выберите пол");
                }
                if (string.IsNullOrEmpty(EmailTextBox.Text))
                {
                    errors.AppendLine("Заполните email");
                }
                if (string.IsNullOrEmpty(PasswordTextBox.Password))
                {
                    errors.AppendLine("Заполните пароль");
                }
                if (string.IsNullOrEmpty(ConfirmPasswordTextBox.Password))
                {
                    errors.AppendLine("Потвердите пароль");
                }
                if (PasswordTextBox.Password != ConfirmPasswordTextBox.Password)
                {
                    errors.AppendLine("Пароли не совпадают!");
                }

                if (DatebirthPicker.SelectedDate.HasValue)
                {
                    _currentUser.Birthday = DatebirthPicker.SelectedDate.Value;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите дату рождения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception errors)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.ListViewPage());
        }
    }
}
