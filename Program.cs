using System;
using System.Net.Http;

namespace MODULE5HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var starter = new Starter();
            starter.Run().GetAwaiter().GetResult();
            Console.WriteLine("asd");
        }
    }
}