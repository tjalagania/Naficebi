using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Documents;

namespace Naficebi.Services
{
    public class TemplateEditClass
    {
        private FlowDocument _flowDocument;
        private readonly RichTextBox richTextBox;
        public TemplateEditClass(RichTextBox RechTextBox)
        {
            richTextBox= RechTextBox;
            _flowDocument = richTextBox.Document;
            richTextBox.IsDocumentEnabled= true;
        }
        public void ChangeFontSelectio(string fnfamily)
        {
            
            var s = richTextBox.Selection;
            //if(s.IsEmpty)
            //{

            //    TextRange range = new TextRange(richTextBox.CaretPosition, richTextBox.CaretPosition);
            //    richTextBox.Document.FontFamily = new System.Windows.Media.FontFamily(fnfamily);
            //}
            //else
            //{
                TextRange txrng= new TextRange(s.Start, s.End);
                txrng.ApplyPropertyValue(RichTextBox.FontFamilyProperty, fnfamily);
                
            //}
            
        }
        public void AddTemplete(string temlate)
        {
            
            TextRange txrng = new TextRange(richTextBox.CaretPosition, richTextBox.CaretPosition);
            txrng.Text = temlate;
        }
    }
}
