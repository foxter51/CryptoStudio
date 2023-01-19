using CoinGecko.Clients;
using CoinGecko.Entities.Response.Coins;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace TestAssignment
{
    public partial class Converter : Page
    {
        private static HttpClient httpClient = new HttpClient();
        private static JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

        private PingClient pingClient = new PingClient(httpClient, serializerSettings);
        private CoinsClient coinsClient = new CoinsClient(httpClient, serializerSettings);

        public Converter()
        {
            InitializeComponent();
        }

        private bool NumberValidationTextBox(string inputText)
        {
            Regex regex = new Regex("^[0-9]+(\\,[0-9]+)?$");
            return regex.IsMatch(inputText);
        }

        private void ConvertEvent(object sender, RoutedEventArgs e)
        {
            if (From.SelectedItem != null && To.SelectedItem != null && inputTextBox.Text.Length > 0)
            {
                CoinMarkets selectedFrom = (CoinMarkets)From.SelectedItem;
                CoinMarkets selectedTo = (CoinMarkets)To.SelectedItem;

                if (selectedFrom != selectedTo && NumberValidationTextBox(inputTextBox.Text))
                {
                    double inputSum = double.Parse(inputTextBox.Text);
                    double res = inputSum * (double)selectedFrom.CurrentPrice / (double)selectedTo.CurrentPrice;

                    outputTextBox.Text = res.ToString();
                }
                else outputTextBox.Text = "Please check your input!";
            }
            else outputTextBox.Text = "Please fill in the empty fields!";
        }

        private void NewSelectFromEvent(object sender, EventArgs e)
        {
            fromLabel.Content = From.Text;
            ClearFields();
        }
        private void NewSelectToEvent(object sender, EventArgs e)
        {
            toLabel.Content = To.Text;
            ClearFields();
        }

        private void SwitchEvent(object sender, RoutedEventArgs e)
        {
            int selectedFromId = From.SelectedIndex;
            int selectedToId = To.SelectedIndex;

            From.SelectedIndex = selectedToId;
            To.SelectedIndex = selectedFromId;

            NewSelectFromEvent(sender, e);
            NewSelectToEvent(sender, e);
        }

        private void InputTextChangedEvent(object sender, TextChangedEventArgs e)
        {
            if (inputTextBox.Text != "0,00") ClearFields();
        }

        private void ClearFields()
        {
            outputTextBox.Text = "";
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if ((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                List<CoinMarkets> coinsList = coinsClient.GetCoinMarkets("USD").Result.ToList();

                From.ItemsSource = coinsList;
                To.ItemsSource = coinsList;

                From.SelectedIndex = 0;
                To.SelectedIndex = 1;
            }
        }
    }
}
