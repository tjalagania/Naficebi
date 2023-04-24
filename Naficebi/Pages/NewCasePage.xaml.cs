using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using NaficebiLib.Managers;
using Naficebi.Services;

using System.IO;
using NaficebiLib.Models;

namespace Naficebi.Pages
{
    /// <summary>
    /// Interaction logic for NewCasePage.xaml
    /// </summary>
    public partial class NewCasePage : Page
    {


       /* public string CaseNumber
        {
            get { return (string)GetValue(CaseNumberProperty); }
            set { SetValue(CaseNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CaseNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaseNumberProperty =
            DependencyProperty.Register("CaseNumber", typeof(string), typeof(NewCasePage), new PropertyMetadata(string.Empty));



        public string Accused
        {
            get { return (string)GetValue(AccusedProperty); }
            set { SetValue(AccusedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Accused.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccusedProperty =
            DependencyProperty.Register("Accused", typeof(string), typeof(NewCasePage), new PropertyMetadata(string.Empty));

        */

        public string CasePath
        {
            get { return (string)GetValue(CasePathProperty); }
            set { SetValue(CasePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CasePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CasePathProperty =
            DependencyProperty.Register("CasePath", typeof(string), typeof(NewCasePage), new PropertyMetadata("აირჩიეთ საქაღალდე"));



        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.Register("ErrorMessage", typeof(string), typeof(NewCasePage), new PropertyMetadata(string.Empty));





        public CourtCase NewCase
        {
            get { return (CourtCase)GetValue(NewCaseProperty); }
            set { SetValue(NewCaseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewCase.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewCaseProperty =
            DependencyProperty.Register("NewCase", typeof(CourtCase), typeof(NewCasePage), new PropertyMetadata(null));





        public NewCasePage()
        {
            InitializeComponent();
            NewCase = new CourtCase();
            NewCase.ClercId = App.Clerk.Id;
        }

        private void OpenFolderButton_Click(object sender, RoutedEventArgs e)
        {

            using (FolderBrowserDialog dl = new FolderBrowserDialog())
            {
                DialogResult result = dl.ShowDialog();
                if (result == DialogResult.OK)
                {
                    NewCase.Path = CasePath = dl.SelectedPath;
                }
            }

        }

        private async void addCaseButton_Click(object sender, RoutedEventArgs e)
        {

            if (!VerificationOfEnteredInformation())
                return;
            CombineFullPath();
            CaseManager csmanager = new CaseManager();

            int i = await csmanager.AddCase(NewCase);
            
            if (i > 0)
            {
                
                FileSystemManager.FolderCreate(NewCase.Path);
                NavigationServices.RedirectTo(PageEnum.CaseList);
            }
        }
        private void CombineFullPath()
        {
            string fullPath = System.IO.Path.Combine(CasePath, NewCase.CaseNumber);
            NewCase.Path = fullPath;
        }
        private bool VerificationOfEnteredInformation()
        {
            if (NewCase.CaseNumber == string.Empty || NewCase.Path == string.Empty
                    || NewCase.NameOftheAccused == string.Empty
                    )
            {
                ErrorMessage = "Error: გთხოვთ შეავსეთ ყველა ველი !!!";
                return false;
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationServices.RedirectTo(PageEnum.CaseList);
        }
    }
}
