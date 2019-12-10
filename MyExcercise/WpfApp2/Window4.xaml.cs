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
    public partial class Window4 : Window
    {
        //Mutex mut = new Mutex(false, "MyMutex");//=Mutex(false)

        public Window4()
        {
            InitializeComponent();

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(TaskRun2));
            thread.Start("线程2");
        }

        Mutex mut;
        void TaskRun2(object name)
        {
            bool creatNew = false;
            mut = new Mutex(false, "MyMutex1", out creatNew);
            if (creatNew)
            {
                this.Dispatcher.Invoke(() =>
                {
                    txtbox.Text += "正在运行..." + Environment.NewLine;
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    txtbox.Text += "当前实例已经运行一个了..." + Environment.NewLine;
                });
            }
        
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mut != null)
            {
                mut.Dispose();
            }
        }
    }
}
