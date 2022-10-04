using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                FileName = " ",
                Filter=" *.txt | *.*"
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

        /// <summary>
        /// NewCommand will be used to save the file and start a new blank page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveWindow sw = new saveWindow(tBox.Text);
            sw.ShowDialog();
            tBox.Text = sw.TBoxContent;
            sw.Close();


            
        }
        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = true;

        }

        /// <summary>
        /// Function used when the 'exit' option is selected, this will open a new window to ask
        /// the user if he want's to save the changes or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (textChanged == true)
            {
                saveWindow sw = new saveWindow(tBox.Text);
                sw.ShowDialog();
                tBox.Text = sw.TBoxContent;
                sw.Close();
                
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// Command used to open a new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bool? result = ofd.ShowDialog();
            tBox.Text = File.ReadAllText(ofd.FileName);


        }

        private void aboutClick(object sender, RoutedEventArgs e)
        {
            aboutWindow aw = new aboutWindow();

            aw.about.Text = "Microsoft Windows\r\nVersion 21H2 (OS Build 19044.2006)\r\n© Microsoft Corporation. All rights reserved.\r\nThe Windows 10 Pro operating system and its user interface are protected by trademark and other pending or existing intellectual property rights in the United States and other countries/regions.\r\nThis product is licensed under the Microsoft Software License\r\nTerms to:\r\nYuvraj Singh";
            aw.ShowDialog();
           
            aw.Close();
        }

        private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CutCommand_executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void CopyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CopyCommand_executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PasteCommand_executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void closing(object sender, CancelEventArgs cancelEventArgs)
        {
            if (textChanged)
            {
                if (textChanged == true)
                {
                    saveWindow sw = new saveWindow(tBox.Text);
                    sw.ShowDialog();
                    tBox.Text = sw.TBoxContent;
                    sw.Close();
                }
                else
                {
                    this.Close();
                }

            }
        }
    }
}
