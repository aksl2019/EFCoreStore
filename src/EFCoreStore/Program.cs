using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EFCoreStore.Models;

namespace EFCoreStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var  generator = new DbContextGenerator();
         //   generator.BlogOneToZeroOrOneTester();
            generator.CategorySelfReferenceTester();

            Console.ReadLine();
        }
    }
}
