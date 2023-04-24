using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace Naficebi.Template
{
    [Serializable]
    public class TemplateClass
    {
        public FlowDocument document { get; set; }
        private Paragraph p;
        private Run r;
        public TemplateClass()
        {
            document = new FlowDocument();
            FillDocument();
        }
        private void FillDocument()
        {
            p = new Paragraph(new Run("გზავნილის ჩაბარების აქტი"));
            p.TextAlignment= TextAlignment.Center;
            p.FontWeight= FontWeights.Bold;
            p.FontSize = 18;

            document.Blocks.Add(p);
            r = new();
            r.Text = " “……””……………”20...წელი";
            

            p = new Paragraph();
            p.Inlines.Add(r);
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Hello"));
            document.Blocks.Add(p);
        }
    }
}
