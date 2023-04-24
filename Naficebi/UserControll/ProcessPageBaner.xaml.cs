using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
    /// Interaction logic for ProcessPageBaner.xaml
    /// </summary>
    public partial class ProcessPageBaner : UserControl
    {


        public string CaseNumber
        {
            get { return (string)GetValue(CaseNumberProperty); }
            set { SetValue(CaseNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CaseNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaseNumberProperty =
            DependencyProperty.Register("CaseNumber", typeof(string), typeof(ProcessPageBaner), new PropertyMetadata(string.Empty));



        public string AccusedName
        {
            get { return (string)GetValue(AccusedNameProperty); }
            set { SetValue(AccusedNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccusedName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccusedNameProperty =
            DependencyProperty.Register("AccusedName", typeof(string), typeof(ProcessPageBaner), new PropertyMetadata(string.Empty));


        public ProcessPageBaner()
        {
            InitializeComponent();
        }
    }
}
