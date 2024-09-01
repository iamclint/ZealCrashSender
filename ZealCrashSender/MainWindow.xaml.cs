using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZealCrashSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string zip = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ProcessArguments(string[] args)
        {
            if (args.Length>0)
            {
                ArgumentsText.Text = args[0];
                zip = "crashes\\" + args[1];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string uploadUrl = "http://eqzeal.cc:5000/api/FileUpload/upload";

            try
            {
                await FileUploader.UploadFileAsync(zip, uploadUrl);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}