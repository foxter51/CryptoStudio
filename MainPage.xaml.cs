using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestAssignment
{
    public partial class MainPage : Page
    {
        public static bool darkTheme = false;
        public static bool englishLanguage = true;

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
            if (englishLanguage) englishLanguage = false;
            else englishLanguage = true;
            Switch_Language();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Switch_Theme();
            Switch_Language();
        }

        private void Switch_Theme()
        {
            LinearGradientBrush linearGradientBrush = (LinearGradientBrush)Resources["LinearPanelBrush"];
            linearGradientBrush.GradientStops.Clear();

            if (darkTheme)
            {
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.1));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Gray, 0.5));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.9));
                MenuBar.Background = new SolidColorBrush(Colors.Gray);
                Resources["LabelsColor"] = Brushes.White;
            }
            else
            {
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0.1));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0.5));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0.9));
                MenuBar.Background = new SolidColorBrush(Colors.BlanchedAlmond);
                Resources["LabelsColor"] = Brushes.Black;
            }
        }

        private void Switch_Language()
        {
            this.Resources.MergedDictionaries[2].Clear();
            var resourceDictionary = new ResourceDictionary();

            if (englishLanguage)
            {
                resourceDictionary.Source = new Uri("/TestAssignment;component/Resources/lang.xaml", UriKind.RelativeOrAbsolute);
            }
            else
            {
                resourceDictionary.Source = new Uri("/TestAssignment;component/Resources/lang.ua-UA.xaml", UriKind.RelativeOrAbsolute);
            }

            this.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
