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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SynicWindow synicWindow = new SynicWindow();
            synicWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DemoAsync();
            MessageBox.Show("同步代码");
        }

        async Task DemoAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                MessageBox.Show("DemoAsync.InnerTask" + Thread.CurrentThread.ManagedThreadId);
            });
            Thread.Sleep(3000);
            MessageBox.Show("DemoAsync" + Thread.CurrentThread.ManagedThreadId);
        }

        async Task DemoAsync2()
        {
            await DemoAsync();
            Thread.Sleep(3000);
            MessageBox.Show("DemoAsync2" + Thread.CurrentThread.ManagedThreadId);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DemoAsync2();
            Thread.Sleep(3000);
            MessageBox.Show("Button_Click" + Thread.CurrentThread.ManagedThreadId);
        }


        //为什么DemoAsync.InnerTask是一个线程而其他的都是主线程
    }
}
