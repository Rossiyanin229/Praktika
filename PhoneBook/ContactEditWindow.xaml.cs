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
using System.Windows.Shapes;



using System;


namespace PhoneBook
{
    public partial class ContactEditWindow : Window
    {
        
        public Contact CurrentContact { get; set; }

        public ContactEditWindow()
        {
            InitializeComponent();
        }

      
        public void LoadContact(Contact contact)
        {
            CurrentContact = contact;
            if (contact != null)
            {
                TbName.Text = contact.Name;
                TbPhone.Text = contact.Phone;
                TbEmail.Text = contact.Email;
            }
        }

       
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(TbName.Text))
            {
                MessageBox.Show("Имя не может быть пустым!", "Ошибка");
                return;
            }

            
            if (CurrentContact == null)
            {
                CurrentContact = new Contact();
            }

            
            CurrentContact.Name = TbName.Text;
            CurrentContact.Phone = TbPhone.Text;
            CurrentContact.Email = TbEmail.Text;

          
            DialogResult = true;
        }

        
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
           
            DialogResult = false;
        }
    }
}
