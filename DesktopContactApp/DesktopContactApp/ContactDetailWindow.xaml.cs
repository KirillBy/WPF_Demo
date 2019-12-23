using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesktopContactApp.Classes;
namespace DesktopContactApp
{
    /// <summary>
    /// Interaction logic for ContactDetailWindow.xaml
    /// </summary>
    public partial class ContactDetailWindow : Window
    {
        Contacts contacts;
        public ContactDetailWindow(Contacts contacts)
        {
            
            InitializeComponent();
            this.contacts = contacts;
            nameTextBox.Text = this.contacts.Name;
            emailTextBox.Text = this.contacts.Email;
            phoneNumberTextBox.Text = this.contacts.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                contacts.Name = nameTextBox.Text;
                contacts.Email = emailTextBox.Text;
                contacts.Phone = phoneNumberTextBox.Text;
                connection.CreateTable<Contacts>();
                connection.Update(contacts);
                this.Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                
                connection.CreateTable<Contacts>();
                connection.Delete(contacts);
                this.Close();
            }
        }
    }
}
