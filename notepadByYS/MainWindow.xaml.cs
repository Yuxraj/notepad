using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace notepadByYS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool textChanged = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function crated to count the characters inside the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textChanged = true;
            cLable.Content = tBox.Text.Length.ToString();
        }

        /// <summary>
        /// SaveAsCommand will be used to save the file with a name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialogF = new SaveFileDialog()
            {
                FileName = " "
            };

            bool? result = saveFileDialogF.ShowDialog();
            StreamWriter createFile = new StreamWriter(File.Create(saveFileDialogF.FileName));
            createFile.Write(tBox.Text);
            createFile.Close();

        }
        private void SaveAsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveWindow sw = new saveWindow(tBox.Text);
            sw.ShowDialog();
            sw.Close();

            tBox.Text = " ";
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = true;

        }


    }
}
