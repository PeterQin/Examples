using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GetCurrentDirectory(): " + Directory.GetCurrentDirectory());
            Environment.CurrentDirectory = @"W:\Common";
            Console.WriteLine("GetCurrentDirectory(): " + Directory.GetCurrentDirectory());
            Console.WriteLine("BaseDirectory: " + AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine("\r\nPress any key to Esc");
            Console.Read();
        }
    }
}
