using System;
using System.IO;
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

namespace WpfTreeView
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get every logical drive
            foreach (var drive in Directory.GetLogicalDrives())
            {
                // create new item for every logical drive
                var item = new TreeViewItem()
                {
                    // {set} header
                    Header = drive,

                    // {set} full path
                    Tag = drive
                };
               

                // add sub item to item (dummy item)
                item.Items.Add(null);

                // listen for expanded item
                item.Expanded += Folder_Expanded;

                // add item to FolderView (TreeViewItem)  
                FolderView.Items.Add(item);
            }
        }


        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;

            // do this if item is not a dummy item
            if (item.Items.Count != 1 || item.Items[0] != null)
            {
                return;
            }

            // remove dummy data
            item.Items.Clear();

            // get fullpath name
            var fullpath = (string)item.Tag;

        }
    }
}
