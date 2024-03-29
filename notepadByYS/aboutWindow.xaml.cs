﻿/*
* PROJECT : PROG2121 - A02-WPF
* PROGRAMMER : Yuvraj Singh
* FIRST VERSION : 2022-09-27
* DESCRIPTION : Create a Notepad using WPF: this is the aboutWindow class, 
* it is used to display info about the Application and the OS (a pre-written text).
*/

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
using System.Windows.Shapes;

namespace notepadByYS
{
    /// <summary>
    /// Interaction logic for aboutWindow.xaml
    /// </summary>
    public partial class aboutWindow : Window
    {


        public aboutWindow()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
