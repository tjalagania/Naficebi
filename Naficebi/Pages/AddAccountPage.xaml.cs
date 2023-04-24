using Naficebi.Services;

using NaficebiLib.Managers;
using NaficebiLib.Models;
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

namespace Naficebi.Pages
{
    /// <summary>
    /// Interaction logic for AddAccountPage.xaml
    /// </summary>
    public partial class AddAccountPage : Page
    {


        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Login.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(AddAccountPage), new PropertyMetadata(string.Empty));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(AddAccountPage), new PropertyMetadata(string.Empty));




        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }


        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(AddAccountPage), new PropertyMetadata(""));


        // Using a DependencyProperty as the backing store for FullName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FullNameProperty =
            DependencyProperty.Register("FullName", typeof(string), typeof(AddAccountPage), new PropertyMetadata(string.Empty));



        public string ConfirmPassword
        {
            get { return (string)GetValue(ConfirmPasswordProperty); }
            set { SetValue(ConfirmPasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConfirmPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfirmPasswordProperty =
            DependencyProperty.Register("ConfirmPassword", typeof(string), typeof(AddAccountPage), new PropertyMetadata(string.Empty));


        public AddAccountPage()
        {
            InitializeComponent();
        }

        private async void addClerkButton_Click(object sender, RoutedEventArgs e)
        {
           if(Login == string.Empty || Password == string.Empty ||
                ConfirmPassword == string.Empty || FullName == string.Empty
                )
            {
                ErrorMessage = "გთხოვთ შეავსოთ ყველა ველი";
                return;
            }
           if(!Password.Equals(ConfirmPassword))
            {
                ErrorMessage = "პაროლები არ ემთხვევა";
                return;
            }
            
            IClerkManager manager = new ClerkManager();
            int? i = await manager.AddClerk(Login,this.Password,this.FullName);
            if(i is not null)
            {
                NavigationServices.RedirectTo(PageEnum.LoginPage);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationServices.RedirectTo(PageEnum.LoginPage);
        }
    }
}
