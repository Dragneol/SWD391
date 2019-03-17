using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        public int Id { get; set; }
        public int Code { get; set; }
    }
    class Program
    {
        int c, d;
        public int MyProperty { get; set; }
        static void Swap1(int a, int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        static void Swap2(ref int a,ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        static void SwapObj(Student sta, Student stb)
        {
            var tmp = sta.Id;
            sta.Id = stb.Id;
            stb.Id = tmp;
        }

        static void showStudent(List<Student> list)
        {
            foreach(var std in list)
            {
                Console.WriteLine(std.Id);
            }
        }
        static void Main(string[] args)
        {
            int a = 3;
            
            Student std1 = new Student() { Id = 1 };
            Student std2 = new Student() { Id = 2 };

            int b = 5;

            //SwapObj(std1, std2);

            List<Student> list = new List<Student>();
            list.Add(std1);
            list.Add(std2);
            int c = 6;
            showStudent(list);
            Console.WriteLine(std1.Id);
            Console.WriteLine(std2.Id);
            Console.ReadLine();
        }
    }
}
