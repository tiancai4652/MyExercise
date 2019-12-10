using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        static string MemoryMappedFileNmae = "testmap";
        static string MutexNmae = "testmapmutex";
        static string MemoryMappedFilePath = "MemoryMappedFile.data";
        static long Size = 100;

       static void CreatFileIfNeeded(string path)
        {
            FileInfo fi = new FileInfo(path);
            var di = fi.Directory;
            if (!di.Exists)
                di.Create();
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreatFileIfNeeded(MemoryMappedFilePath);
            using (var mmf = MemoryMappedFile.CreateFromFile(MemoryMappedFilePath, FileMode.Open, MemoryMappedFileNmae, Size))
            {
                Mutex mutex;
                bool mutexCreated;
                try
                {
                     mutex = Mutex.OpenExisting(MutexNmae);
                }
                catch
                {
                    mutex = new Mutex(true, MutexNmae, out mutexCreated);
                }
                mutex.WaitOne();
                // Create a random access view, from the 256th megabyte (the offset)
                // to the 768th megabyte (the offset plus length).
                using (var accessor = mmf.CreateViewAccessor(0, Size))
                {
                    int colorSize = Marshal.SizeOf(typeof(int));
                    for (long i = 0; i < Size; i += colorSize)
                    {
                        accessor.Write(i, 1);
                    }
                }
                mutex.ReleaseMutex();
            }
            txtbox.Text = "写入1";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreatFileIfNeeded(MemoryMappedFilePath);
            using (var mmf = MemoryMappedFile.CreateFromFile(MemoryMappedFilePath, FileMode.Open, MemoryMappedFileNmae,Size))
            {
                Mutex mutex;
                bool mutexCreated;
                try
                {
                    mutex = Mutex.OpenExisting(MutexNmae);
                }
                catch
                {
                    mutex = new Mutex(true, MutexNmae, out mutexCreated);
                }
                mutex.WaitOne();
                // Create a random access view, from the 256th megabyte (the offset)
                // to the 768th megabyte (the offset plus length).
                using (var accessor = mmf.CreateViewAccessor(0, Size))
                {
                    int colorSize = Marshal.SizeOf(typeof(int));
                    for (long i = 0; i < Size; i += colorSize)
                    {
                        accessor.Write(i, 2);
                    }
                }
                mutex.ReleaseMutex();
            }
            txtbox.Text = "写入2";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var mmf = MemoryMappedFile.CreateFromFile(MemoryMappedFilePath, FileMode.Open, MemoryMappedFileNmae))
            {
                Mutex mutex;
                bool mutexCreated;
                try
                {
                    mutex = Mutex.OpenExisting(MutexNmae);
                }
                catch
                {
                    mutex = new Mutex(true, MutexNmae, out mutexCreated);
                }
                mutex.WaitOne();
                // Create a random access view, from the 256th megabyte (the offset)
                // to the 768th megabyte (the offset plus length).
                using (var accessor = mmf.CreateViewAccessor(0, Size))
                {
                    int colorSize = Marshal.SizeOf(typeof(int));
                    for (long i = 0; i < Size; i += colorSize)
                    {
                        txtbox.Text += accessor.ReadInt32(i) + Environment.NewLine;
                    }
                }
                mutex.ReleaseMutex();
            }
        }
    }
}
