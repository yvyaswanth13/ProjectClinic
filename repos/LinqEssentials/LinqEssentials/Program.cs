using System;
using System.Collections.Generic;
using System.Linq;


namespace LinqEssentials
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> fruits = new List<String>();
            fruits.Add("apple");
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Orange");
            fruits.Add("Lime");
            var fruit = (from i in fruits
                         where i.ToLower().StartsWith('a')
                         select i);
            foreach (var i in fruit)
                Console.WriteLine(i);
            var res = fruits.Take(3);
            foreach (var i in res)
                Console.WriteLine(i);
            string[] vegetables = { "Tomato", "Cucumber", "Carrot" };
           var con= vegetables.Concat(fruits);
            foreach (var i in con)
                Console.WriteLine(i);




        }
    }
}
