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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {

                var files = Directory.GetFiles(fbd.SelectedPath);
                string str = "";
                foreach (var file in files)
                {
                    str += file + ";";
                }
                //var scrollBarSizeBoxState = System.Windows.Forms.VisualStyles.ScrollBarSizeBoxState.LeftAlign;
                System.Windows.Forms.MessageBox.Show($"Path: {fbd.SelectedPath}, Files: {str}");
                
            }
        }

       
    }
}
