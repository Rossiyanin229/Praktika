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

using System;
using System.Linq;


namespace PhoneBook
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Проверка подключения к базе данных
            using (var db = new AppDbContext())
            {
                try
                {
                    // Пытаемся посчитать количество записей
                    var count = db.Contacts.Count();
                    MessageBox.Show($"Успех! Подключение работает. В базе {count} контактов.", "Проверка БД");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}
