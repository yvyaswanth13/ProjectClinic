using System;

namespace DateTest
{
    class Program
    {
       public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                DateTime dt = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(dt.ToShortDateString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
