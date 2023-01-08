using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace AdvancedAsyncAwait
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
            resultsWindow.Text += $"Elapsed Milliseconds : {elapsedMs}";
        }

        private List<string> GetWebsites()
        {
            List<string> websites = new List<string>();
            resultsWindow.Text = "";
            websites.Add("https://www.google.com/");
            websites.Add("https://github.com/");
            websites.Add("https://www.quora.com/");
            websites.Add("https://www.w3schools.com/");
            websites.Add("https://www.facebook.com/");
            websites.Add("https://www.udemy.com/");
            websites.Add("https://fr.yahoo.com/");
            websites.Add("https://www.w3schools.com/");
            websites.Add("https://www.facebook.com/");
            websites.Add("https://www.udemy.com/");
            websites.Add("https://fr.yahoo.com/");
            websites.Add("https://www.google.com/");
            websites.Add("https://github.com/");
            websites.Add("https://www.quora.com/");
            websites.Add("https://www.w3schools.com/");
            websites.Add("https://www.facebook.com/");
            websites.Add("https://www.udemy.com/");
            websites.Add("https://fr.yahoo.com/");
            websites.Add("https://www.w3schools.com/");
            websites.Add("https://www.facebook.com/");
            websites.Add("https://www.udemy.com/");
            websites.Add("https://fr.yahoo.com/");
            return websites;
        }

        private void RunDownloadSync()
        {
            WebsiteDataModel website = new WebsiteDataModel();
            var websitesUrl = GetWebsites();
            foreach(var websiteUrl in websitesUrl)
            {
                website = DownloadWebsite(websiteUrl);
                LogResults(website);
            }
        }

        private async Task RunDownloadAsync(IProgress<ProgressReportModel> progress)
        {
            ProgressReportModel report = new ProgressReportModel();
            WebsiteDataModel website = new WebsiteDataModel();
            var websitesUrl = GetWebsites();
            var websites = new List<WebsiteDataModel>();
            foreach (var websiteUrl in websitesUrl)
            {
                website = await Task.Run(() => DownloadWebsite(websiteUrl));
                websites.Add(website);
                report.SitesDownloaded = websites;
                report.PercentageComplete = (websites.Count * 100) / websitesUrl.Count;
                progress.Report(report);
                LogResults(website);
            }
        }



        private async Task RunDownloadParallelAsync()
        {
            var websitesUrl = GetWebsites();
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>(); 
            foreach (var websiteUrl in websitesUrl)
            {
                tasks.Add(Task.Run(() => DownloadWebsite(websiteUrl)));
            }

            var results = await Task.WhenAll(tasks);
            foreach (var task in results)
            {
                LogResults(task);
            }
        }


        private WebsiteDataModel DownloadWebsite(string websiteUrl)
        {
            WebsiteDataModel website = new WebsiteDataModel();
            WebClient webClient = new WebClient();

            website.WebsiteUrl = websiteUrl;
            website.WebsiteData = webClient.DownloadString(websiteUrl);

            return website;
        }

        private void LogResults(WebsiteDataModel website)
        {
            resultsWindow.Text += $"{website.WebsiteUrl} Downloaded! Length : {website.WebsiteData.Length} {Environment.NewLine}";
        }

        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            Progress<ProgressReportModel> progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += ReportProgress; 

            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownloadAsync(progress);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Elapsed Milliseconds : {elapsedMs}";
        }

        private void ReportProgress(object sender, ProgressReportModel e)
        {
            progressBar.Value = e.PercentageComplete;
        }

        private async void executeAsyncParallel_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownloadParallelAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            resultsWindow.Text += $"Elapsed Milliseconds : {elapsedMs}";
        }
    }
}
