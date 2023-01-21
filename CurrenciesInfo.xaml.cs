using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Newtonsoft.Json;
using CoinGecko.Clients;
using System.Net.Http;
using CoinGecko.Entities.Response.Coins;
using System.Windows.Media;

namespace TestAssignment
{
    public partial class CurrenciesInfo : Page
    {
        private static HttpClient httpClient = new HttpClient();
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

        private PingClient pingClient = new PingClient(httpClient, serializerSettings);
        private CoinsClient coinsClient = new CoinsClient(httpClient, serializerSettings);
        private ExchangesClient exchangesClient = new ExchangesClient(httpClient, serializerSettings);

        private List<CoinMarkets> coinsList;

        public CurrenciesInfo()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Switch_Theme();
            Switch_Language();
            if((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                coinsList = coinsClient.GetCoinMarkets("USD").Result.ToList();
                CurrenciesListAll.ItemsSource = coinsList;
                CurrenciesListAll.SelectedIndex = 0;
                CurrenciesListAll.Focus();
            }
            else
            {
                MessageBox.Show("There is no connection to API!");
            }
        }

        private async void CurrenciesListAll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                CoinMarkets selectedCoin = (CoinMarkets)(CurrenciesListAll.SelectedItem);

                List<string> marketsNames = exchangesClient.GetExchangesList().Result.Select(m => m.Id).Take(5).ToList();

                List<string> marketsLinks = new List<string>();
                foreach(string name in marketsNames)
                {
                    marketsLinks.AddRange(exchangesClient.GetTickerByExchangeId(name, selectedCoin.Id).Result.Tickers.Select(t => t.TradeUrl).ToList());
                }

                Markets.ItemsSource = marketsLinks;
            }
            else
            {
                MessageBox.Show("There is no connection to API!");
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CurrenciesListAll.ItemsSource = coinsList.FindAll(coin => coin.Name.Contains(SearchBox.Text));
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
            this.Resources.MergedDictionaries[2].Clear();
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
