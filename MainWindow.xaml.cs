using System.Windows.Data;
using System.Windows;
using ParserWPF.Core;
using ParserWPF.Core.Habra;
using System.Windows.Controls;

namespace ParserWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParserWorker<string[]> parser;
        public MainWindow()
        {
            parser = new ParserWorker<string[]>(
                new HabraParser()
                );
            parser.OnNewData += Parser_OnNewData;
            parser.OnComplited += Parser_OnComplited;

            InitializeComponent();
        }

        private void Parser_OnComplited(object obj)
        {
            MessageBox.Show("All Complited", "Success!", MessageBoxButton.OK);
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (var item in arg2)
            {
                var element = $"{item} /{parser.ParserSettings.Preffix.ToUpper()}{parser.PageId}" +
                    $" ({parser.ParserSettings.BaseUrl}/{parser.ParserSettings.Preffix}{parser.PageId})";
                ListTitles.Items.Add(new TextBox{ Text = element, IsReadOnly = true});
            }
            
        }

        public void StartParser(object sender, RoutedEventArgs e)
        {
            parser.ParserSettings = new HabraSettings(int.Parse(StartValue.Text), int.Parse(EndValue.Text));
            parser.Start();
        }
        public void StopParser(object sender, RoutedEventArgs e)
        {
            parser.Abort();
        }
    }
}
