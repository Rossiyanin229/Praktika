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

            LoadData();
        }

      
        private void LoadData()
        {
            using (var db = new AppDbContext())
            {
                try
                {
                    
                    ContactsGrid.ItemsSource = db.Contacts.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
                }
            }
        }
    }
}
