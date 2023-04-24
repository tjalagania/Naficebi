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
    /// Interaction logic for SelectNumbers.xaml
    /// </summary>
    public partial class SelectNumbers : UserControl
    {


        public string Number1
        {
            get { return (string)GetValue(Number1Property); }
            set { SetValue(Number1Property, value); }
        }

        // Using a DependencyProperty as the backing store for Number1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Number1Property =
            DependencyProperty.Register("Number1", typeof(string), typeof(SelectNumbers), new PropertyMetadata(string.Empty));



        public string Number2
        {
            get { return (string)GetValue(Number2Property); }
            set { SetValue(Number2Property, value); }
        }

        // Using a DependencyProperty as the backing store for Number2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Number2Property =
            DependencyProperty.Register("Number2", typeof(string), typeof(SelectNumbers), new PropertyMetadata(string.Empty));


        public SelectNumbers()
        {
            InitializeComponent();
        }
    }
}
