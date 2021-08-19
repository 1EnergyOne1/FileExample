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
using System.IO;


namespace FileExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Считывание из файла символов, кроме знаков "!,№,;,%....."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = @"C:\Users\energ\Desktop\C#\С#8\Test\FileExample\FileExample\testfile.txt";


            char[] result;
            StringBuilder builder = new StringBuilder();

            using (StreamReader reader = File.OpenText(fileName))
            {
                result = new char[reader.BaseStream.Length];
                await reader.ReadAsync(result, 0, (int)reader.BaseStream.Length);
            }

            foreach (char c in result)
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                {
                    builder.Append(c);
                }
            }
            TextFile.Text = builder.ToString();
        }

        /// <summary>
        /// Запись данных из TextBox в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            string textReaderText = TextFile.Text;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            File.WriteAllText(System.IO.Path.Combine(docPath, @"C:\Users\energ\Desktop\C#\С#8\Test\FileExample\FileExample\testfile.txt"), textReaderText);

        }
    }
}
