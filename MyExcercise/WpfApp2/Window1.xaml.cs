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

namespace WpfApp2
{
   
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        private static Mutex mut = new Mutex();

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(TaskRun));
            thread.Start("线程1");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(TaskRun));
            thread.Start("线程2");
        }



        void TaskRun(object name)
        {
            mut.WaitOne();
            TaskAsync(name);
            mut.ReleaseMutex();
        }

        void TaskAsync(object name)
        {
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(() => { 
            txtbox.Text += $"{name}_1..." + Environment.NewLine;
            });
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(() => {
                txtbox.Text += $"{name}_2..." + Environment.NewLine;
            });
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(() => {
                txtbox.Text += $"{name}_3..." + Environment.NewLine;
            });
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(() => {
                txtbox.Text += $"{name}_4..." + Environment.NewLine;
            });
            Thread.Sleep(1000);
            this.Dispatcher.Invoke(() => {
                txtbox.Text += $"{name}_5..." + Environment.NewLine;
            });
        }

       
    }
}
