using Elasto_lib;

namespace Elasto
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Hello, World!");
            ProductCollection product = new();
            product.DisplayAllProductCollection();
            product.DisplayProductByProperties("Id");
        }
    }
}