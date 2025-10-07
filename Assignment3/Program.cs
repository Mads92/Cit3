using System;
using System.Runtime.CompilerServices;

namespace Assignment3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Web Service :-)");
            /*
            UrlParser up = new UrlParser();
            Console.WriteLine(up.ParseUrl("Howdy"));
            */
            CategoryService cs = new CategoryService();
            Console.WriteLine(cs.GetCategories());
            Console.WriteLine("SPEAK TO ME");
        }
    }
    
    

}
