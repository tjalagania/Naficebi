using Naficebi.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Naficebi.Services
{
    public class NavigationServices
    {
        private static Page pg;

        private static void CreatePage(PageEnum page)
        {
            pg = page switch
            {
                PageEnum.AddAcount => new AddAccountPage(),
                PageEnum.LoginPage => new AuthorizatiionPage(),
                PageEnum.CaseList => new CaseListPage(),
                PageEnum.NewCasePage => new NewCasePage(),
                PageEnum.ProcessPage => new ProcessPage(),
                _ => throw new NotImplementedException()
            };


           
            
        }
        public static void RedirectTo(PageEnum page) 
        {
            CreatePage(page);
            (Application.Current.MainWindow as NavigationWindow).Navigate(pg);
            
        }
    }
}
