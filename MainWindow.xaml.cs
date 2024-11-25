using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Guitar_UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                    break;
            }
        }
    }
}
