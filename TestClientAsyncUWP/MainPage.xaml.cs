using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestClientAsyncUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int _localOperationCounter = 0;
        int _webAPIOperationCounter = 0;
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AddListItem(string text)
        {
            ListViewItem listViewItem = new ListViewItem();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            listViewItem.Content = textBlock;
            lvwOutput.Items.Add(listViewItem);
        
        }

        private void btnLocalOperation_Click(object sender, RoutedEventArgs e)
        {
            _localOperationCounter++;
            AddListItem($"Fast Local Operation Completed {_localOperationCounter}");
        }

        private async void btnWebAPICall_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:50920/TestLongOperation");

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            _webAPIOperationCounter++;

            AddListItem($"{result} {_webAPIOperationCounter}");


        }
    }
}
