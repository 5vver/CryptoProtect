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
using encyptorGUI.ViewModels;
using System.Windows.Controls.Primitives;

namespace encyptorGUI
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        // Moves window by moving the header
        private void Header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (popup.IsOpen)
            {
                popup.Visibility = Visibility.Collapsed;
                popup.IsOpen = false;
            }
        }

        // Encryption menu button
        private void Encryption_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EncryptModel();
            dash.Text = "CryptoProtect / Encryption";
        }

        // Decryption menu button
        private void Dercyption_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DecryptModel();
            dash.Text = "CryptoProtect / Decryption";
        }

        // Home
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MainViewModel();
            dash.Text = "CryptoProtect / DASHBOARD";
        }

        // Data Files menu button
        private void DataFiles_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new DataFilesModel();
        }

        // Close app
        private void CloseUP_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Header Options
        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            if (!popup.IsOpen)
            {
                popup.PlacementTarget = OptionsButton;
                popup.Placement = PlacementMode.Bottom;
                popup.IsOpen = true;
            }
            else
            {
                popup.Visibility = Visibility.Collapsed;
                popup.IsOpen = false;
            }
        }

        
    }
}
