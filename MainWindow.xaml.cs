using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;

using System.Threading;

namespace Guitar_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartPythonScript();
        }

        // Start the Python script in a separate thread
        private void StartPythonScript()
        {
            Thread pythonThread = new Thread(RunPythonScript);
            pythonThread.IsBackground = true;  // Ensures thread doesn't block app termination
            pythonThread.Start();
        }

        // Run the Python Pygame script
        private void RunPythonScript()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("python", @"C:/Users/mogun/source/repos/Guitar-UI/seven_nation_army.py")
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit(); // Optionally wait for it to exit if needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error running Python script: {ex.Message}");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string k = e.Key.ToString();
            string name = "border_" + k;
            System.Diagnostics.Debug.WriteLine(name);

            // Use FindName to locate the Border element
            var border = FindName(name) as Border;
            if (border != null)
            {
                border.BorderBrush = Brushes.Red; // Revert to default color
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            string k = e.Key.ToString();
            string name = "border_" + k;
            System.Diagnostics.Debug.WriteLine(name);

                    // Use FindName to locate the Border element
            var border = FindName(name) as Border;
            if (border != null)
            {
                border.BorderBrush = Brushes.White; // Revert to default color
            }
        }
    }
}
