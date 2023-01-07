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
using System.Net;

namespace AsyncAwaitProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void executeNormal_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            RunDownloadSync();
            watch.Stop();   
            var elapsedMs = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total Time : {elapsedMs}";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            await RunDownloadAsync();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total Time : {elapsedMs}";
        }

        private async void executeAsyncParallel_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            await RunDownloadParallelAsync();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultWindow.Text += $"Total Time : {elapsedMs}";
        }

        private List<String>  PrepData()
        {
            List<String> websites = new List<String>();

            resultWindow.Text = "";

            websites.Add("https://www.google.com/");
            websites.Add("https://github.com/");
            websites.Add("https://www.quora.com/");
            websites.Add("https://www.w3schools.com/");
            websites.Add("https://www.facebook.com/");
            websites.Add("https://www.udemy.com/"); 
            websites.Add("https://fr.yahoo.com/");
            return websites;
        }

        

        private void RunDownloadSync()
        {
            List<String> websites = PrepData();
            foreach(var website in websites)
            {
                WebsiteDataModel result = DownloadWebsite(website);
                ReportDownloadInfo(result);
            }
        }


        private async Task RunDownloadAsync()
        {
            List<String> websites = PrepData();
            foreach (var website in websites)
            {
                WebsiteDataModel result = await Task.Run(() => DownloadWebsite(website));
                ReportDownloadInfo(result);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            List<String> websites = PrepData();
            List<Task<WebsiteDataModel>> websiteDataModelsTasks = new List<Task<WebsiteDataModel>>();
            foreach(var website in websites)
            {
                // websiteDataModelsTasks.Add(Task.Run(() => DownloadWebsite(website)));
                websiteDataModelsTasks.Add(DownloadWebsiteAsync(website));
            }
            var results = await Task.WhenAll(websiteDataModelsTasks);
            foreach(var item in results)
            {
                ReportDownloadInfo(item);
            }
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteUrl)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            output.WebsiteUrl = websiteUrl;
            output.WebsiteData = await client.DownloadStringTaskAsync(websiteUrl);

            return output;
        }

        private WebsiteDataModel DownloadWebsite(string websiteUrl)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();

            output.WebsiteUrl = websiteUrl;
            output.WebsiteData = client.DownloadString(websiteUrl);

            return output;
        }

        private void ReportDownloadInfo(WebsiteDataModel website)
        {
            resultWindow.Text += $"{website.WebsiteUrl} " +
                $"Length : {website.WebsiteData.Length} " +
                $"Downloaded succusfully! " +
                $"{Environment.NewLine}";
        }
    }
}
