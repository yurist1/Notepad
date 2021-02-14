using Common.YuristNodepad;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace YuristNodepad
{

    public class RichTextBoxHelper : DependencyObject
    {
        public static string GetDocumentXaml(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentXamlProperty);
            //return "안녕";
        }

        public static void SetDocumentXaml(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentXamlProperty, value);
        }





        public static readonly DependencyProperty DocumentXamlProperty =
            DependencyProperty.RegisterAttached(
                "DocumentXaml",
                typeof(string),
                typeof(RichTextBoxHelper),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextChangePropertyChanged)));



        private static void OnTextChangePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)

        {

            var richTextBox = (RichTextBox)d;

            // Parse the XAML to a document (or use XamlReader.Parse())
            var xaml = GetDocumentXaml(richTextBox);
            var doc = new FlowDocument();
            var range = new TextRange(doc.ContentStart, doc.ContentEnd);

            //range.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)),
            //           DataFormats.Xaml); 
            range.Load(new MemoryStream(Encoding.UTF8.GetBytes(xaml)),
                       DataFormats.Text);



            // Set the document
            richTextBox.Document = doc;

            // When the document changes update the source
            range.Changed += (obj2, e2) =>
                {
                    if (richTextBox.Document == doc)
                    {
                        MemoryStream buffer = new MemoryStream();
                        //range.Save(buffer, DataFormats.Xaml);
                        range.Save(buffer, DataFormats.Text);
                        SetDocumentXaml(richTextBox,
                            Encoding.UTF8.GetString(buffer.ToArray()));
                    }
                };


        }


    }

}
