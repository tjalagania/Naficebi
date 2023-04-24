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

namespace Naficebi.UserControll
{
    /// <summary>
    /// Interaction logic for WIndowsButtonsUc.xaml
    /// </summary>
    public partial class WIndowsButtonsUc : UserControl
    {
        public WIndowsButtonsUc()
        {
            InitializeComponent();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (App.IsRunning)
            {
                MessageBox.Show("დაელოდეთ პროცესის დასრულებას", "გაფრთხილება", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Application.Current.Shutdown();
        }

        private void ResizeBtn_Click(object sender, RoutedEventArgs e)
        {
            var wnd = Application.Current.MainWindow;
            if (wnd.WindowState == WindowState.Normal)
            {
                wnd.WindowState = WindowState.Maximized;
                return;
            }
            if (wnd.WindowState == WindowState.Maximized)
            {
                wnd.WindowState = WindowState.Normal;
            }
        }

       
    }
}
