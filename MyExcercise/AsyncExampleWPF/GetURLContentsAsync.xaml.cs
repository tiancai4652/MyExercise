using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading;

namespace AsyncExampleWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GetURLContentsAsync : Window
    {
        public GetURLContentsAsync()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            resultsTextBox.Clear();
            SumPageSizes();
            resultsTextBox.Text += "\r\nControl returned to startButton_Click.";
        }

        private void SumPageSizes()
        {
            // 获取网址列表
            List<string> urlList = SetUpURLList();

            var total = 0;
            foreach (var url in urlList)
            {
                // GetURLContents returns the contents of url as a byte array.
                byte[] urlContents = GetURLContents(url);

                DisplayResults(url, urlContents);

                // Update the total.
                total += urlContents.Length;
            }

            // Display the total count for all of the web addresses.
            resultsTextBox.Text += $"\r\n\r\nTotal bytes returned:  {total}\r\n";
        }

        private List<string> SetUpURLList()
        {
            var urls = new List<string>
    {
        "https://www.cnblogs.com/lsq6/p/12006839.html",
        "https://www.cnblogs.com/MaMaNongNong/p/11945161.html",
        "https://www.cnblogs.com/",
        "https://www.cnblogs.com/xibei/p/12001805.html",
        "https://www.cnblogs.com/haogj/p/12003854.html",
    };
            return urls;
        }

        private byte[] GetURLContents(string url)
        {
            // The downloaded resource ends up in the variable named content.
            var content = new MemoryStream();

            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);

            //// Send the request to the Internet resource and wait for
            //// the response.
            //// Note: you can't use HttpWebRequest.GetResponse in a Windows Store app.
            //using (WebResponse response = webReq.GetResponse())
            //{
            //    // Get the data stream that is associated with the specified URL.
            //    using (Stream responseStream = response.GetResponseStream())
            //    {
            //        // Read the bytes in responseStream and copy them to content.
            //        responseStream.CopyTo(content);
            //    }
            //}
            //模拟网站响应时间为500ms
            Thread.Sleep(500);

            // Return the result as a byte array.
            return content.ToArray();
        }

        private void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format
            // is designed to be used with a monospaced font, such as
            // Lucida Console or Global Monospace.
            var bytes = content.Length;
            // Strip off the "https://".
            var displayURL = url.Replace("https://", "");
            resultsTextBox.Text += $"\n{displayURL,-58} {bytes,8}";
        }
    }
}
