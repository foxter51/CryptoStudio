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
using CoinGecko.Entities.Response.Search;
using CoinGecko.Interfaces;

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
            //check API status
            if((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                CurrenciesList.ItemsSource = searchClient.GetSearchTrending().Result.TrendingItems.Select(item => item.TrendingItem).ToList();;
            }
        }
    }
}
