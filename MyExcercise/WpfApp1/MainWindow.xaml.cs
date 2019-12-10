using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string MemoryMappedFileNmae = "testmap";
        static long Size = 10000;
        static string MutexNmae = "testmapmutex";


        /// <summary>
        /// 只有Creat和Dispose用
        /// </summary>
        static MemoryMappedFile MemoryMappedFile;
        static Mutex Mutex;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MemoryMappedFile = MemoryMappedFile.CreateNew(MemoryMappedFileNmae, Size);
            bool mutexCreated;
            Mutex = new Mutex(true, MutexNmae, out mutexCreated);
            using (MemoryMappedViewStream stream = MemoryMappedFile.CreateViewStream())
            {
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(1);
            }
            Mutex.ReleaseMutex();
            txtbox.Text += "MemoryMappedFile.CreateNew" + Environment.NewLine;
            txtbox.Text += "writer.Write(1)" + Environment.NewLine;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MemoryMappedFileNmae))
                {

                    Mutex mutex = Mutex.OpenExisting(MutexNmae);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(1, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(0);
                    }
                    mutex.ReleaseMutex();
                    txtbox.Text += "writer.Write(0)" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first.");
                txtbox.Text += "Memory - mapped file does not exist. Run Process A first." + Environment.NewLine;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MemoryMappedFileNmae))
                {

                    Mutex mutex = Mutex.OpenExisting(MutexNmae);
                    mutex.WaitOne();

                    using (MemoryMappedViewStream stream = mmf.CreateViewStream(2, 0))
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(1);
                    }
                    mutex.ReleaseMutex();
                    txtbox.Text += "writer.Write(1)" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first, then B.");
                txtbox.Text += "Memory - mapped file does not exist. Run Process A first." + Environment.NewLine;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MemoryMappedFileNmae))
                {
                    Mutex mutex = Mutex.OpenExisting(MutexNmae);
                    mutex.WaitOne();
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        txtbox.Text += $"Process A says: { reader.ReadBoolean()}" + Environment.NewLine;
                        txtbox.Text += $"Process B says: { reader.ReadBoolean()}" + Environment.NewLine;
                        txtbox.Text += $"Process C says: { reader.ReadBoolean()}" + Environment.NewLine;
                    }
                    mutex.ReleaseMutex();

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first, then B.");
                txtbox.Text += "Memory - mapped file does not exist. Run Process A first." + Environment.NewLine;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                MemoryMappedFile.Dispose();
                Mutex.Dispose();
                txtbox.Text += "MemoryMappedFile and Mutex.Dispose();" + Environment.NewLine;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Memory-mapped file does not exist. Run Process A first, then B.");
                txtbox.Text += "Memory - mapped file does not exist. Run Process A first." + Environment.NewLine;
            }
        }
    }
}
