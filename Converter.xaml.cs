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
using System.Windows.Media;

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

        private bool Number_Validation_TextBox(string inputText)
        {
            Regex regex = new Regex("^[0-9]+(\\,[0-9]+)?$");
            return regex.IsMatch(inputText);
        }

        private void Convert_Event(object sender, RoutedEventArgs e)
        {
            if (From.SelectedItem != null && To.SelectedItem != null && inputTextBox.Text.Length > 0)
            {
                CoinMarkets selectedFrom = (CoinMarkets)From.SelectedItem;
                CoinMarkets selectedTo = (CoinMarkets)To.SelectedItem;

                if (selectedFrom != selectedTo && Number_Validation_TextBox(inputTextBox.Text))
                {
                    double inputSum = double.Parse(inputTextBox.Text);
                    double res = inputSum * (double)selectedFrom.CurrentPrice / (double)selectedTo.CurrentPrice;

                    outputTextBox.Text = res.ToString();
                }
                else outputTextBox.Text = "Please check your input!";
            }
            else outputTextBox.Text = "Please fill in the empty fields!";
        }

        private void New_Select_From_Event(object sender, EventArgs e)
        {
            fromLabel.Content = From.Text;
            Clear_Fields();
        }
        private void New_Select_To_Event(object sender, EventArgs e)
        {
            toLabel.Content = To.Text;
            Clear_Fields();
        }

        private void Switch_Event(object sender, RoutedEventArgs e)
        {
            int selectedFromId = From.SelectedIndex;
            int selectedToId = To.SelectedIndex;

            From.SelectedIndex = selectedToId;
            To.SelectedIndex = selectedFromId;

            New_Select_From_Event(sender, e);
            New_Select_To_Event(sender, e);
        }

        private void Input_Text_Changed_Event(object sender, TextChangedEventArgs e)
        {
            if (inputTextBox.Text != "0,00") Clear_Fields();
        }

        private void Clear_Fields()
        {
            outputTextBox.Text = "";
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Switch_Theme();
            Switch_Language();
            if ((await pingClient.GetPingAsync()).GeckoSays != String.Empty)
            {
                List<CoinMarkets> coinsList = coinsClient.GetCoinMarkets("USD").Result.ToList();

                From.ItemsSource = coinsList;
                To.ItemsSource = coinsList;

                From.SelectedIndex = 0;
                To.SelectedIndex = 1;
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
