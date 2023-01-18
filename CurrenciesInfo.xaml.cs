using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        public CurrenciesInfo()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                CurrenciesListAll.ItemsSource = coinsClient.GetCoinMarkets("USD").Result.ToList();
                CurrenciesListAll.SelectedIndex = 0;
                CurrenciesListAll.Focus();
            }
        }
    }
}
