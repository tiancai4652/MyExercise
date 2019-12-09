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

namespace wpf1
{
    /// <summary>
    /// Windows1.xaml 的交互逻辑
    /// </summary>
    public partial class Windows1 : Window
    {
        public Windows1()
        {
            InitializeComponent();
        }


        void TakeTime()
        {
            Thread.Sleep(5000);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TakeTime();
            rich.Text="Done";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TakeTimeAsync();
        }

        async void TakeTimeAsync()
        {
            await Task.Delay(5000);
            rich.Text = "Done";
        }
    }
}
