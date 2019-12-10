using MemeoryMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryMap_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNonPersistentMemoryMapping();
            //TestPersistentMemoryMapping();

        }

        static void TestPersistentMemoryMapping()
        {
            Student student1 = new Student() { Name = "111" };
            Student student2 = new Student() { Name = "222" };
            Console.WriteLine("起两个程序然后依次按回车");

            Console.ReadKey();
            using (PersistentMemoryMapping pmm = new MemeoryMap.PersistentMemoryMapping("MyMemoryMap", "map.data", "myLock"))
            {
                pmm.Write<Student>(student1);
                Console.WriteLine($"Write {nameof(student1)},named {student1?.Name}");
            }
            Console.ReadKey();

            using (PersistentMemoryMapping pmm = new MemeoryMap.PersistentMemoryMapping("MyMemoryMap", "map.data", "myLock"))
            {
                pmm.Write<Student>(student2);
                Console.WriteLine($"Write {nameof(student2)},named {student2?.Name}");
            }
            Console.ReadKey();

            //using (PersistentMemoryMapping pmm = new MemeoryMap.PersistentMemoryMapping("MyMemoryMap", "map.data", "myLock"))
            //{
            //    pmm.Write<List<Student>>(new List<Student>() { student1 , student2 });
            //    Console.WriteLine($"Write {nameof(student2)},named {student2?.Name}");
            //}
            //Console.ReadKey();
        }

        static void TestNonPersistentMemoryMapping()
        {
            Student student1 = new Student() { Name = "111" };
            Student student2 = new Student() { Name = "222" };
            Console.WriteLine("起两个程序然后依次按回车");

            Console.ReadKey();
            NonPersistentMemoryMapping nonPersistentMemoryMapping = new MemeoryMap.NonPersistentMemoryMapping
        ("mmfName", "mutexName");

            nonPersistentMemoryMapping.Write<Student>(student1);
            Console.WriteLine($"Write {nameof(student1)},named {student1?.Name}");
            Console.ReadKey();

            nonPersistentMemoryMapping.Write<Student>(student2);
            Console.WriteLine($"Write {nameof(student2)},named {student2?.Name}");
            Console.ReadKey();

            nonPersistentMemoryMapping.ManualDispose();
            Console.WriteLine("MemoryMapping Clear");
            Console.ReadKey();


        }
    }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }

    }
}
