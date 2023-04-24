using MahApps.Metro.IconPacks;
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
    /// Interaction logic for ProcessLeftButton.xaml
    /// </summary>
    public partial class ProcessLeftButton : UserControl
    {


        public PackIconMaterialKind Kind
        {
            get { return (PackIconMaterialKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KindProperty =
            DependencyProperty.Register("Kind", typeof(PackIconMaterialKind), typeof(ProcessLeftButton));





        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(ProcessLeftButton), new PropertyMetadata(string.Empty));





        public string CaseNumber
        {
            get { return (string)GetValue(CaseNumberProperty); }
            set { SetValue(CaseNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CaseNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaseNumberProperty =
            DependencyProperty.Register("CaseNumber", typeof(string), typeof(ProcessLeftButton), new PropertyMetadata(string.Empty));




        public bool Disable
        {
            get { return (bool)GetValue(DisableProperty); }
            set { SetValue(DisableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Disable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisableProperty =
            DependencyProperty.Register("Disable", typeof(bool), typeof(ProcessLeftButton), new PropertyMetadata(false));


        public string CreateDate
        {
            get { return (string)GetValue(CreateDateProperty); }
            set { SetValue(CreateDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateDateProperty =
            DependencyProperty.Register("CreateDate", typeof(string), typeof(ProcessLeftButton), new PropertyMetadata("31.01"));



        public bool SecondTextVisibility
        {
            get { return (bool)GetValue(SecondTextVisibilityProperty); }
            set { SetValue(SecondTextVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SecondTextVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondTextVisibilityProperty =
            DependencyProperty.Register("SecondTextVisibility", typeof(bool), typeof(ProcessLeftButton), new PropertyMetadata(false));


        public ProcessLeftButton()
        {
            InitializeComponent();
        }

        //public static implicit operator ProcessLeftButton(ProcessLeftButton v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
