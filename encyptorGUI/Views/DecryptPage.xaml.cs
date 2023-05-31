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
using System.Runtime.InteropServices;
using Microsoft.Win32;
using depLib;

namespace encyptorGUI.Views
{
    /// <summary>
    /// Логика взаимодействия для DecryptPage.xaml
    /// </summary>
    public partial class DecryptPage : UserControl
    {
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]

        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        private static string password;
        public string dir = "";
        public string outDir = "";
        GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);
        public DecryptPage()
        {
            InitializeComponent();
        }

        #region Decrypt Click

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            password = Password.Password;
            bool check = false;
            try
            {
                if (password != "" && dir != "")
                {
                    check = true;
                }
                else
                {
                    MessageBox.Show("Password field must be filled/File location must be chosen!");
                }
            }
            finally
            {
                if (check)
                {
                    var dec = new Encryption(dir, password, outDir);
                    dec.FileDecrypt();
                    Console.WriteLine("Your file was successfully decrypted!");
                    password = "";
                    dir = "";
                    MessageBox.Show("File was successfully decrypted!");
                    ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                    gch.Free();
                }
            }
        }

        #endregion

        #region Location

        private void location_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "All Files|*.*";
            fileDialog.DefaultExt = ".";
            Nullable<bool> dialogOK = fileDialog.ShowDialog();
            if (dialogOK == true)
            {
                string sFilenames = "";
                foreach (string sFilename in fileDialog.FileNames)
                {
                    sFilenames += ";" + sFilename;
                }
                sFilenames = sFilenames.Substring(1);
                dir = sFilenames;
                outDir = sFilenames;
                outDir = outDir.Substring(0, sFilenames.Length - 4);
            }
        }

        #endregion

    }
}
