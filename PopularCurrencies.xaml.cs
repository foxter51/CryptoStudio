using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Newtonsoft.Json;
using CoinGecko.Clients;
using System.Net.Http;
using System.Windows.Media;

namespace TestAssignment
{
    public partial class Currencies : Page
    {
        private static HttpClient httpClient = new HttpClient();
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

        private PingClient pingClient = new PingClient(httpClient, serializerSettings);
        private SearchClient searchClient = new SearchClient(httpClient, serializerSettings);

        public Currencies()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Switch_Theme();
            Switch_Language();
            if((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                CurrenciesList.ItemsSource = searchClient.GetSearchTrending().Result.TrendingItems.Select(item => item.TrendingItem).ToList();
            }
            else
            {
                MessageBox.Show("There is no connection to API!");
            }
        }

        private void Switch_Theme()
        {
            LinearGradientBrush linearGradientBrush = (LinearGradientBrush)Resources["LinearPanelBrush"];
            linearGradientBrush.GradientStops.Clear();

            if (MainPage.darkTheme)
            {
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.1));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Gray, 0.5));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.9));
                Resources["LabelsColor"] = Brushes.White;
            }
            else
            {
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0.1));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0.5));
                linearGradientBrush.GradientStops.Add(new GradientStop(Colors.LightGoldenrodYellow, 0.9));
                Resources["LabelsColor"] = Brushes.Black;
            }
        }

        private void Switch_Language()
        {
            this.Resources.MergedDictionaries[1].Clear();
            var resourceDictionary = new ResourceDictionary();

            if (MainPage.englishLanguage)
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
