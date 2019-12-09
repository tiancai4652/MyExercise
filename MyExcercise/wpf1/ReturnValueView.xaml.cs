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
    /// ReturnValueView.xaml 的交互逻辑
    /// </summary>
    public partial class ReturnValueView : Window
    {
        public ReturnValueView()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            txtbox.Text += await ShowTodaysInfo();
        }

        private static async Task<string> ShowTodaysInfo()
        {
            string ret = $"Today is {DateTime.Today:D}\n" +
                         "Today's hours of leisure: " +
                         $"{await GetLeisureHours()}";
            return ret;
        }
        static async Task<int> GetLeisureHours()
        {
            // Task.FromResult is a placeholder for actual work that returns a string.  
            var today = await TaskAsync();

            // The method then can process the result in some way.  
            int leisureHours;
            if (today.First() == 'S')
                leisureHours = 16;
            else
                leisureHours = 5;

            return leisureHours;
        }

        static async Task<string> TaskAsync()
        {
            await Task.Delay(1000);
            return DateTime.Now.DayOfWeek.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtbox.Text = $"You rolled { GetDiceRoll().Result}";
        }

        private static async ValueTask<int> GetDiceRoll()
        {
            int roll1 = await Roll();
            int roll2 = await Roll();
            return roll1 + roll2;
        }
        static Random rnd;
        private static async ValueTask<int> Roll()
        {
            if (rnd == null)
                 rnd = new Random();

            await Task.Delay(500);
            int diceRoll = rnd.Next(1, 7);
            return diceRoll;
        }
    }
}
