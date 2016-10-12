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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Reflection;

namespace Task9_1
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

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            string targetDirectory = fbd.SelectedPath;

            if (!string.IsNullOrWhiteSpace(targetDirectory))
            {

                GetDllFiles(targetDirectory);
                //listBox_SelectionChanged(sender, );

                System.Windows.Forms.MessageBox.Show($@"Path: {targetDirectory}");

            }
        }

        public void GetDllFiles(string targetDirectory)
        {
            var files = Directory.GetFiles(targetDirectory);
            foreach (var file in files)
            {
                if (file.Contains(".dll"))
                {
                    listBox.Items.Add(file);
                }
                
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                // Set filter for file extension and default file extension 
                DefaultExt = ".dll",
                Filter = "Dll Files (*.dll)|*.dll"
            };
            
            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ChooseDllFile(filename);
                //listBox_Copy.Items.Add(filename);
            }
        }

        public void ChooseDllFile(string filename)
        {
            var assembly = Assembly.ReflectionOnlyLoadFrom(filename);
            var properties = assembly.GetTypes();
            foreach (var propertie in properties)
            {
                listBox_Copy.Items.Add(propertie);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //private bool listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //    if (!listBox.Items.IsEmpty)
        //    {
        //        return true;
        //    }

        //    return false;
        //}
    }
}
