using Naficebi.Services;
using NaficebiLib.Managers;
using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for AuthorizatiionPage.xaml
    /// </summary>
    public partial class AuthorizatiionPage : Page
    {


        public string Login
        {
            get { return (string)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Login.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(string), typeof(AuthorizatiionPage));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(AuthorizatiionPage), new PropertyMetadata(string.Empty));


        public AuthorizatiionPage()
        {
            InitializeComponent();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            NavigationServices.RedirectTo(PageEnum.AddAcount);
        }

        private async void authBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Login == string.Empty || Password == string.Empty)
            {
                return;
            }
            var manager = new ClerkManager();
            Clerk cl = await manager.GetClerk(Login, Password);
            if (cl is not null)
            {
                NavigationWindow? wnd = App.Current.MainWindow as NavigationWindow;
                wnd.Width = 1179;
                wnd.Height = 800;
                App.Clerk= cl;
                
                NavigationServices.RedirectTo(PageEnum.CaseList);

            }
            else
            {
                MessageBox.Show("მომხარებელი ვერ მოიძებნა");
            }

        }
    }
}
