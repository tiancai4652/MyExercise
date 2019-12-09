﻿using System;
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
using System.Threading.Tasks;

namespace AsyncExampleWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SynicWindow : Window
    {
        public SynicWindow()
        {
            InitializeComponent();
        }
        private async void startButton_Click(object sender, RoutedEventArgs e)
        {
            startButton.IsEnabled = false;
            resultsTextBox.Clear();

            await SumPageSizesAsync();

            resultsTextBox.Text += "\r\nControl returned to startButton_Click.\r\n";
            startButton.IsEnabled = true;
        }

        private async Task SumPageSizesAsync()
        {
            List<string> urlList = SetUpURLList();
            var total = 0;
            foreach (var url in urlList)
            {
                byte[] urlContents = await GetURLContentsAsync(url);
                DisplayResults(url, urlContents);
                total += urlContents.Length;
            }
            // Display the total count for all of the websites.
            resultsTextBox.Text +=
                $"\r\n\r\nTotal bytes returned:  {total}\r\n";
        }

        private List<string> SetUpURLList()
        {
            List<string> urls = new List<string>
            {
                "https://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "https://msdn.microsoft.com",
                "https://msdn.microsoft.com/library/hh290136.aspx",
                "https://msdn.microsoft.com/library/ee256749.aspx",
                "https://msdn.microsoft.com/library/hh290138.aspx",
                "https://msdn.microsoft.com/library/hh290140.aspx",
                "https://msdn.microsoft.com/library/dd470362.aspx",
                "https://msdn.microsoft.com/library/aa578028.aspx",
                "https://msdn.microsoft.com/library/ms404677.aspx",
                "https://msdn.microsoft.com/library/ff730837.aspx"
            };
            return urls;
        }

        bool taskx = false;
        public bool Taskx 
        {
            get
            {
                return taskx;
            }
            set
            {
                taskx = value;
            }
        }

        private async Task<byte[]> GetURLContentsAsync(string url)
        {
            var content = new MemoryStream();
            await Task.Delay(1000); ;
            return content.ToArray();
        }



        private void DisplayResults(string url, byte[] content)
        {
            var bytes = content.Length;
            var displayURL = url.Replace("https://", "");
            resultsTextBox.Text += $"\n{displayURL,-58} {bytes,8}";
        }
    }
}
