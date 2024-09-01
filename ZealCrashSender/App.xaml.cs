using System.Configuration;
using System.Data;
using System.Windows;

namespace ZealCrashSender
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // e.Args contains the command line arguments
            if (e.Args.Length > 0)
            {
                // Example: display the arguments in a message box
                //string arguments = string.Join(" ", e.Args);
                //MessageBox.Show($"Command line arguments: {arguments}");

                // You can also pass the arguments to your main window or process them as needed
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                mainWindow.ProcessArguments(e.Args);
            }
            else
            {
                // Start the main window normally if no arguments are provided
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }

}
