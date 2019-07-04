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

namespace WpfBasics
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

        private void Apply_BTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is: {Description_TXTBOX.Text}");
        }

        private void Reset_BTN_Click(object sender, RoutedEventArgs e)
        {
            WeldCheckbox.IsChecked = 
            AssyCheckbox.IsChecked = 
            PlasmaCheckbox.IsChecked = 
            LaserCheckbox.IsChecked = 
            PurchaseCheckbox.IsChecked = 
            LatheCheckbox.IsChecked = 
            DrillCheckbox.IsChecked = 
            FoldCheckbox.IsChecked = 
            RollCheckbox.IsChecked = 
            SawCheckbox.IsChecked = false;
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Length_TXTBOX.Text += ((CheckBox)sender).Content;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * A Null check is added to prevent a Null reference exception:
             *  -   NoteTextBox is Null when the application starts
             */
            if (NoteTextBox == null)
                return;

            NoteTextBox.Text = (String)((ComboBoxItem)((ComboBox)sender).SelectedValue).Content;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_SelectionChanged(FinishedComboBox, null);
        }

        private void SupplierName_TXTBOX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Mass_TXTBOX.Text = SupplierName_TXTBOX.Text;
        }
    }
}
