using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32;
using Naficebi.Services;
using Naficebi.UserControll;
using NaficebiLib.DataBaseAccessLayer;
using NaficebiLib.ExcelLeyer;
using NaficebiLib.Managers;
using NaficebiLib.Models;
using Spire.Doc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ProcessPage.xaml
    /// </summary>
    public partial class ProcessPage : Page
    {

        private CandidateManager _candManager;
        private INumberManager<Numbers> _numManager;
        private List<PrincipalModel> _principalModels;
        private MsAccessDb _accessDb;
        BackgroundWorker _worek = new BackgroundWorker();
        public bool Disable
        {
            get { return (bool)GetValue(DisableProperty); }
            set { SetValue(DisableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Disable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisableProperty =
            DependencyProperty.Register("Disable", typeof(bool), typeof(ProcessPage), new PropertyMetadata(false));



        public string Number1
        {
            get { return (string)GetValue(Number1Property); }
            set { SetValue(Number1Property, value); }
        }

        // Using a DependencyProperty as the backing store for Number1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Number1Property =
            DependencyProperty.Register("Number1", typeof(string), typeof(ProcessPage), new PropertyMetadata(string.Empty));




        public string Number2
        {
            get { return (string)GetValue(Number2Property); }
            set { SetValue(Number2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Number2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Number2Property =
            DependencyProperty.Register("Number2", typeof(string), typeof(ProcessPage), new PropertyMetadata(string.Empty));


        public ProcessPage()
        {
            InitializeComponent();
            InitializeBane();
            _candManager = new CandidateManager();
            if (App.CourtCase.State == CaseState.second)
                openDbAccess.IsEnabled = false;
            _worek.RunWorkerCompleted += runComplerte;
        }

        private void runComplerte(object? sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void InitializeBane()
        {
            Banner.CaseNumber = App.CourtCase.CaseNumber;
            Banner.AccusedName = App.CourtCase.NameOftheAccused;
            _numManager = new NumberManager();
            var numbers = await _numManager.GetNumbersWithCase(App.CourtCase.Id);
            if (numbers != null)
            {
                foreach (var nm in numbers)
                {

                    numbersViewer.Children.Add(CreateNumberButton(nm));
                }
            }
            GC.Collect();
        }
        private ProcessLeftButton CreateNumberButton(Numbers nm)
        {
            var pr = new ProcessLeftButton()
            {
                CaseNumber = nm.SelectedNumber,
                CreateDate = nm.CreatedDate,
                Kind = MahApps.Metro.IconPacks.PackIconMaterialKind.Hammer,
                SecondTextVisibility = true,
                FilePath = nm.Path
            };
            pr.PreviewMouseLeftButtonUp += SelectPrincipalsWithNumber;
            return pr;
        }

        private async void SelectPrincipalsWithNumber(object sender, MouseButtonEventArgs e)
        {
            App.IsRunning = true;
            loader.Visibility = Visibility.Visible;
            principalGridPanel.ItemsSource = null;
            ProcessLeftButton pr = (ProcessLeftButton)sender;

            _principalModels = await _candManager.DeserializeFromJson(pr.FilePath, false);
            principalGridPanel.ItemsSource = _principalModels;
            loader.Visibility = Visibility.Hidden;
            App.IsRunning = false;
            GC.Collect();
        }

        /*
           მეთოდი MSAccess მონაცემთა ბაზის არჩევა
         */
        private async void openDbAccess_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            App.IsRunning = true;
            UserControl cont = (UserControl)sender;
            cont.IsEnabled = false;
            



                var fname = await OpenFiles.GetFileName();
                loader.Visibility = Visibility.Visible;
                _accessDb = new MsAccessDb(fname);
                var candidate = await _accessDb.GetAccessTablesAsync();
                _candManager.Principal = (List<PrincipalModel>)candidate;








            await _candManager.SaveListToJson(System.IO.Path.Combine(App.CourtCase.Path, $"{App.CourtCase.CaseNumber}.json"));
            var csmanager = new CaseManager();
            csmanager.UpdateState(App.CourtCase, CaseState.second).Wait();
            App.CourtCase.State = CaseState.second;
            loader.Visibility = Visibility.Hidden;
            App.IsRunning = false;
            GC.Collect();
        }

        private async void selectMainCandidateBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Number1 = string.Empty;
            Number2 = string.Empty;
            selectNumberPanel.Visibility = Visibility.Visible;
            principalList.Visibility = Visibility.Collapsed;

        }
        //private async Task OpenFile()
        //{


        //    await Task.Run(() =>
        //     {
        //         using (System.Windows.Forms.OpenFileDialog openF = new())
        //         {

        //             try
        //             {
        //                 if (openF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //                 {

        //                     _accessDb = new MsAccessDb(openF.FileName);
        //                 }

        //             }
        //             catch (Exception e)
        //             {
        //                 throw new Exception(e.Message);
        //             }
        //         }
        //     });

        //}

        private async void selectPrincipalButton_Click(object sender, RoutedEventArgs e)
        {
            if (Number1 != string.Empty && Number2 != string.Empty)
            {
                App.IsRunning = true;
                principalGridPanel.ItemsSource = null;
                string path = System.IO.Path.Combine(App.CourtCase.Path, $"{App.CourtCase.CaseNumber}.json");
                double nmb1 = Double.Parse(Number1.Trim());
                double nmb2 = Double.Parse(Number2.Trim());


                selectNumberPanel.Visibility = Visibility.Collapsed;
                principalList.Visibility = Visibility.Visible;
                loader.Visibility = Visibility.Visible;
                _principalModels = await _candManager.DeserializeFromJson(path, nmb1, nmb2);

                string numberPath = System.IO.Path.Combine(App.CourtCase.Path, $"{nmb1}{nmb2}.json");
                await _candManager.SaveListToJson(numberPath, _principalModels);
                var numb = new Numbers()
                {
                    SelectedNumber = $"{nmb1}{nmb2}",
                    CreatedDate = DateTime.Now.ToString("g", CultureInfo.GetCultureInfo("de-DE")),
                    Path = numberPath,
                    CourtCaseId = App.CourtCase.Id
                };
                await _numManager.AddNumber(numb);
                await _candManager.SaveListToJson(path);



                numbersViewer.Children.Add(CreateNumberButton(numb));
                principalGridPanel.ItemsSource = _principalModels;

                loader.Visibility = Visibility.Hidden;
                App.IsRunning = false;
                GC.Collect();
            }
        }

        private void saveToExcel_Click(object sender, RoutedEventArgs e)
        {
            if (_principalModels != null)
            {
                SaveFileDialog svdl = new SaveFileDialog();
                svdl.Filter = "xlsx files (*.xlsx)|*.xlsx";
                if (svdl.ShowDialog() == true)
                {
                    ExcelManager exmanager = new ExcelManager();
                    exmanager.saveToExcel(_principalModels, svdl.FileName);
                }


            }
        }

        private async void archiveBtn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var caseManager = new CaseManager();
            await caseManager.AddArchive(App.CourtCase);
            NavigationServices.RedirectTo(PageEnum.CaseList);
        }





        private void listBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationServices.RedirectTo(PageEnum.CaseList);
        }

        private void PrintTemplate_btn_Click(object sender, RoutedEventArgs e)
        {
            if(_principalModels.Count > 0)
            {
                foreach(var principalModel in _principalModels)
                {
                using(Document doc = new Document())
                    {
                        doc.LoadFromFile("template.rtf");
                        doc.Replace(@"[fullname]", principalModel.FullName, true, false);
                        doc.Replace(@"[pwnumber]", principalModel.PV_NUNMBER,true,false);
                        doc.Replace(@"[address]", principalModel.BP_FULL_ADDRESS,true,false);
                        doc.Replace(@"[bithday]", principalModel.BIRTH_DATE.Substring(0,10),true,false);

                        System.Windows.Forms.PrintDialog pr = new System.Windows.Forms.PrintDialog();
                        pr.Document = doc.PrintDocument;
                        pr.Document.Print();
                    }
                }
               
            }
            ;
            

            
            
        }
    }

    public class OpenFiles
    {
        public static async Task<string> GetFileName()
        {
            using (System.Windows.Forms.OpenFileDialog openF = new())
            {

                try
                {
                    if (openF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        return openF.FileName;
                    }
                    else
                        return null;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
