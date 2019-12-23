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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopContactApp.Classes;
namespace DesktopContactApp.Controls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {


        public Contacts Contacts
        {
            get { return (Contacts)GetValue(ContactsProperty); }
            set { SetValue(ContactsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for contacts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactsProperty =
            DependencyProperty.Register("Contacts", typeof(Contacts), typeof(UserControl1), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 userControl = d as UserControl1;
            if (userControl!= null)
            {
                userControl.nameTextBox.Text = (e.NewValue as Contacts).Name;
                userControl.emailTextBox.Text = (e.NewValue as Contacts).Email;
                userControl.phoneTextBox.Text = (e.NewValue as Contacts).Phone;
            }
                
            
            
        }

        public UserControl1()
        {
            InitializeComponent();
        }

       
    }
}
