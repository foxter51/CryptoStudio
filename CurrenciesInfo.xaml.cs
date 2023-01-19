using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Newtonsoft.Json;
using CoinGecko.Clients;
using System.Net.Http;
using CoinGecko.Entities.Response.Coins;

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
            if((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                coinsList = coinsClient.GetCoinMarkets("USD").Result.ToList();
                CurrenciesListAll.ItemsSource = coinsList;
                CurrenciesListAll.SelectedIndex = 0;
                CurrenciesListAll.Focus();
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
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CurrenciesListAll.ItemsSource = coinsList.FindAll(coin => coin.Name.Contains(SearchBox.Text));
        }
    }
}
