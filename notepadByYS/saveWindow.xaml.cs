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
using System.Windows.Shapes;

namespace notepadByYS
{
    /// <summary>
    /// Interaction logic for saveWindow.xaml
    /// </summary>
    public partial class saveWindow : Window
    {
        /// <summary>
        /// created a variable to assign the value of the text box from MainWindow
        /// </summary>
        private string tBoxContent = "";

        public string TBoxContent
        {
            get { return tBoxContent; }
            set { tBoxContent = value; }
        }


        /// <summary>
        /// Getting the content of the text box of MaiNWindow to pass to tBoxContent
        /// </summary>
        /// <param name="content"></param>
        public saveWindow(string content)
        {
            InitializeComponent();
            TBoxContent = content;
        }

        /// <summary>
        /// Function to save the text before executing a new empty page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialogF = new SaveFileDialog()
            {
                FileName = "test.txt"
            };

            bool? result = saveFileDialogF.ShowDialog();
            StreamWriter createFile = new StreamWriter(File.Create(saveFileDialogF.FileName));
            createFile.Write(TBoxContent);
            createFile.Close();
            this.Close();

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            TBoxContent = " ";
            this.Close();
             

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
