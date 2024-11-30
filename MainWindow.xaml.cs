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

        private void Print_Key_Down(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Q:
                    MessageBox.Show("Q was pressed");
                    break;
                case Key.D1:
                    MessageBox.Show("1 was pressed");
                    break;
                case Key.D2:
                    MessageBox.Show("2 was pressed");
                    break;
                case Key.D3:
                    MessageBox.Show("3 was pressed");
                    break;
                case Key.D4:
                    MessageBox.Show("4 was pressed");
                    break;
                default:
                    Console.WriteLine($"You pressed: {e.Key}");
                    MessageBox.Show($"You pressed: {e.Key}");
                    break;
            }
        }
    }
}
