using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static  void Main(string[] args)
        {

            Test2();

            Console.WriteLine("Test2");
            Console.ReadKey();
        }


        static void Test1()
        {
            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Test1");
           
        }

        static void Test2()
        { 
            
        }

    }
}
