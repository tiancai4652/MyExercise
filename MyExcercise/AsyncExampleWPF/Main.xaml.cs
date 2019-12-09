using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncExampleWPF
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetByteArrayAsync mainWindow = new GetByteArrayAsync();
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GetURLContentsAsyncView synicWindow = new GetURLContentsAsyncView();
            synicWindow.Show();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await DemoAsync();
            MessageBox.Show("Button_Click  ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }

        async Task DemoAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                MessageBox.Show("DemoAsync.InnerTask ThreadID:" + Thread.CurrentThread.ManagedThreadId);
            });
            Thread.Sleep(3000);
            MessageBox.Show("DemoAsync  ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }

        async void DemoAsync2()
        {
            await DemoAsync();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DemoAsync2();
            MessageBox.Show("Button_Click  ThreadID:" + Thread.CurrentThread.ManagedThreadId);
        }


        //为什么DemoAsync.InnerTask是一个线程而其他的都是主线程
    }
}
