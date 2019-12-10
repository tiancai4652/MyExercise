using MemeoryMap;
using MemoryMap_Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryMap_Sample_Read
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
            while (true)
            {
                using (PersistentMemoryMapping pmm = new MemeoryMap.PersistentMemoryMapping("MyMemoryMap", "map.data", "myLock"))
                {
                    Student student = pmm.Read<Student>();
                    Console.WriteLine($"Read {nameof(student)},named {student?.Name}");
                }
                Console.ReadKey();
            }
        }

        static void TestNonPersistentMemoryMapping()
        {
            while (true)
            {
                NonPersistentMemoryMapping nonPersistentMemoryMapping = new MemeoryMap.NonPersistentMemoryMapping
     ("mmfName", "mutexName");
                Student student = nonPersistentMemoryMapping.Read<Student>();
                Console.WriteLine($"Read {nameof(student)},named {student?.Name}");
                Console.ReadKey();
            }
        }
    }


}
