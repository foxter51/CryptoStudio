using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestAssignment
{
    public partial class MainPage : Page
    {
        public static bool darkTheme = false;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (darkTheme) darkTheme = false;
            else darkTheme = true;
            Switch_Theme();
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Switch_Theme();
        }

        private void Switch_Theme()
        {
            LinearGradientBrush linearGradientBrush = (LinearGradientBrush)Resources["LinearPanelBrush"];
            SolidColorBrush labelsBrush = (SolidColorBrush)Resources["LabelsColor"];
            linearGradientBrush.GradientStops.Clear();

            if (darkTheme)
            {
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.1));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Gray, 0.5));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.9));
                MenuBar.Background = new SolidColorBrush(Colors.Gray);
                labelsBrush.Color = Colors.White;
            }
            else
            {
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0.1));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0.5));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0.9));
                MenuBar.Background = new SolidColorBrush(Colors.BlanchedAlmond);
                labelsBrush.Color = Colors.Black;
            }
        }
    }
}
