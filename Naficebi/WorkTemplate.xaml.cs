using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Packaging;
using Naficebi.Services;
using Naficebi.Template;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Naficebi
{
    /// <summary>
    /// Interaction logic for WorkTemplate.xaml
    /// </summary>
    public partial class WorkTemplate : Window
    {
        private TemplateEditClass _editor;
        public WorkTemplate()
        {
            InitializeComponent();
            CommandBinding binding = new CommandBinding(ApplicationCommands.Save);
            binding.Executed += Save_comand;
            CommandBindings.Add(binding);
            LoadDocument();
            _editor = new TemplateEditClass(mainText);
        }
        private void LoadDocument()
        {

            TextRange txt = new TextRange(mainText.Document.ContentStart, mainText.Document.ContentEnd);
            
            
            using (FileStream fs = new(System.IO.Path.Combine(Environment.CurrentDirectory, "template.rtf"), FileMode.OpenOrCreate))
            {
                try
                {
                    txt.Load(fs, System.Windows.DataFormats.Rtf);
                }
                catch (Exception ex)
                {

                }
               
            }
            

            fonts.ItemsSource =  Fonts.SystemFontFamilies;
        }



        //TextRange tmp = new TextRange(mainText.Document.ContentStart, mainText.Document.ContentEnd);
        //using (FileStream str = new(System.IO.Path.Combine(Environment.CurrentDirectory, "template.rtf"), FileMode.OpenOrCreate))
        //{



        //    tmp.Save(str, DataFormats.Rtf);
        //    tmp.Load(str, DataFormats.Rtf);


        private void Save_comand(object sender, ExecutedRoutedEventArgs e)
        {

            TextRange doc = new TextRange(mainText.Document.ContentStart, mainText.Document.ContentEnd);
            using (FileStream fs = new(System.IO.Path.Combine(Environment.CurrentDirectory, "template.rtf"), FileMode.OpenOrCreate))
            {
                doc.Save(fs, System.Windows.DataFormats.Rtf);
            }

        }

        private void RibbonGallery_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            RibbonGallery g = (RibbonGallery)sender;
            if (g != null)
            {
                _editor.ChangeFontSelectio(g.SelectedValue.ToString());
            }
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            RibbonButton btn = (RibbonButton)sender;
            _editor.AddTemplete($"[{btn.Name}]");
        }
    }
}
