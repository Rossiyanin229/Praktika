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

                     
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
           
            if (ContactsGrid.SelectedItem is Contact selectedContact)
            {
                
                var result = MessageBox.Show($"Вы уверены, что хотите удалить {selectedContact.Name}?",
                                             "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new AppDbContext())
                    {
                     
                        var contactToDelete = db.Contacts.Find(selectedContact.Id);
                        if (contactToDelete != null)
                        {
                            db.Contacts.Remove(contactToDelete);
                            db.SaveChanges();
                        }
                    }
                    
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите контакт для удаления.", "Внимание");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsGrid.SelectedItem is Contact selectedContact)
            {

                var editWindow = new ContactEditWindow();
                editWindow.Owner = this;

                editWindow.LoadContact(selectedContact);


                if (editWindow.ShowDialog() == true)
                {

                    using (var db = new AppDbContext())
                    {

                        var updatedContact = editWindow.CurrentContact;


                        db.Contacts.Update(updatedContact);
                        db.SaveChanges();
                    }

                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите контакт для редактирования.", "Внимание");
            }
        }

            private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            using (var db = new AppDbContext())
            {
                if (string.IsNullOrWhiteSpace(SearchBox.Text))
                {
                    ContactsGrid.ItemsSource = db.Contacts.ToList();
                }
                else
                {
                    
                    string searchText = SearchBox.Text.ToLower();
                    var filtered = db.Contacts.Where(c =>
                        c.Name.ToLower().Contains(searchText) ||
                        c.Phone.ToLower().Contains(searchText)).ToList();

                    ContactsGrid.ItemsSource = filtered;
                }
            }
        }
    }



    }
        
    
