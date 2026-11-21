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
                ContactsGrid.ItemsSource = db.Contacts.ToList();
            }
        }

       
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
   
            var editWindow = new ContactEditWindow();
        
            editWindow.Owner = this;

         
            if (editWindow.ShowDialog() == true)
            {
            
                var newContact = editWindow.CurrentContact;

            
                using (var db = new AppDbContext())
                {
                    db.Contacts.Add(newContact);
                    db.SaveChanges();
                }

                LoadData();
            }
        }
    }
}
