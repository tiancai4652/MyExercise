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
using System.Windows.Shapes;

namespace wpf1
{
    /// <summary>
    /// WhenAllView.xaml 的交互逻辑
    /// </summary>
    public partial class WhenAllView : Window
    {
        public WhenAllView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Task<bool>> tasks = new List<Task<bool>>();
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(GetV());
            }
            var result = Task.WhenAll(tasks);

            txtblock.Text += "AllOK" + Environment.NewLine;
        }

        async Task<bool> GetV()
        {
            bool a = true;
            await Task.Delay(1000);
            txtblock.Text += "OK" + Environment.NewLine;
            return a;
            
        }

        async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Task<bool>> tasks = new List<Task<bool>>();
            for (int i = 0; i < 5; i++)
            {
                tasks.Add(GetV());
            }
            var result = await Task.WhenAll(tasks);

            txtblock.Text += "AllOK" + Environment.NewLine;
        }
    }
}
