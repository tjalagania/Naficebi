using Naficebi.Services;
using NaficebiLib.Managers;
using NaficebiLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Naficebi.Pages
{
    /// <summary>
    /// Interaction logic for CaseListPage.xaml
    /// </summary>
    public partial class CaseListPage : Page
    {
        private List<CourtCase> Cases = new List<CourtCase>();
        private readonly CaseManager manager;
        public CaseListPage()
        {
            InitializeComponent();
            manager = new CaseManager();
            GetCases().Wait(); ;
            casesGrid.ItemsSource = Cases;
        }

        private async Task GetCases()
        {
            Cases.AddRange(await manager.GetCaseByClerk(App.Clerk));
            
        }

        private void newCaseBnt_Click(object sender, RoutedEventArgs e)
        {
            NavigationServices.RedirectTo(PageEnum.NewCasePage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
            App.CourtCase = (CourtCase)btn.Tag;
            NavigationWindow wnd = App.Current.MainWindow as NavigationWindow;
            NavigationServices.RedirectTo(PageEnum.ProcessPage);
        }

        private void workTemplateBtn_Click(object sender, RoutedEventArgs e)
        {
            WorkTemplate wrk = new();
            wrk.Show();
        }
    }
}
