using Core.QueryMySql.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.QueryMySql
{
    public partial class SyncAsyncForm : Form
    {
        public SyncAsyncForm()
        {
            InitializeComponent();
        }

        private List<string> PrepareData()
        {
            List<string> output = new List<string>();
            output.Add("https://www.yahoo.com");
            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.stackoverflow.com");
            output.Add("https://vnexpress.net");

            return output;
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            
            txtResults.Text += $"Total execution time: { elapsedMs }";
        }

        private async void btnAsync_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownloadAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            txtResults.Text += $"Total execution time: { elapsedMs }";
        }

        private async void btnAsync2_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownloadParallelAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            txtResults.Text += $"Total execution time: { elapsedMs }";
        }

        private void RunDownloadSync()
        {
            List<string> urlList = this.PrepareData();

            txtResults.Text = "";
            foreach (var url in urlList)
            {
                WebsiteDataModel websiteData = this.DownloadWebsite(url);
                this.ReportWebsiteInfo(websiteData);
            }
        }

        private async Task RunDownloadAsync()
        {
            List<string> urlList = this.PrepareData();

            txtResults.Text = "";
            foreach (var url in urlList)
            {
                WebsiteDataModel websiteData = await Task.Run(() => this.DownloadWebsite(url));
                this.ReportWebsiteInfo(websiteData);
            }
        }

        private async Task RunDownloadParallelAsync()
        {
            List<string> urlList = this.PrepareData();
            List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

            foreach (var url in urlList)
            {
                tasks.Add(this.DownloadWebsiteAsync(url));
            }

            var results = await Task.WhenAll(tasks);
            
            txtResults.Text = "";
            foreach (var websiteData in results)
            {
                this.ReportWebsiteInfo(websiteData);
            }
        }

        private WebsiteDataModel DownloadWebsite(string websiteUrl)
        {
            WebsiteDataModel websiteData = new WebsiteDataModel();
            WebClient client = new WebClient();

            websiteData.WebsiteUrl = websiteUrl;
            websiteData.WebsiteData = client.DownloadString(websiteUrl);

            return websiteData;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteUrl)
        {
            WebsiteDataModel websiteData = new WebsiteDataModel();
            WebClient client = new WebClient();

            websiteData.WebsiteUrl = websiteUrl;
            websiteData.WebsiteData = await client.DownloadStringTaskAsync(websiteUrl);

            return websiteData;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            txtResults.Text += $"{ data.WebsiteUrl } downloaded: { data.WebsiteData.Length } characters long.{ Environment.NewLine }";
        }
        
    }
}
