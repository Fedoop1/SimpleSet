using Set.Model;
using System;
using System.Collections.Generic;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleSet<int> simpleSet1 = new SimpleSet<int>();
            SimpleSet<int> simpleSet2 = new SimpleSet<int>();
            SimpleSet<int> simpleSet3 = new SimpleSet<int>();

            simpleSet1.Add(1);
            simpleSet1.Add(2);
            simpleSet1.Add(3);
            simpleSet1.Add(4);
            simpleSet1.Add(5);

            simpleSet2.Add(4);
            simpleSet2.Add(5);
            simpleSet2.Add(6);
            simpleSet2.Add(7);

            simpleSet3.Add(1);
            simpleSet3.Add(2);
            simpleSet3.Add(3);

            Console.WriteLine();
            Console.WriteLine("Union: "); //1-2-3-5-4-5-6-7;
            Console.WriteLine();

            foreach (var item in simpleSet1.Union(simpleSet2))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Difference: "); //1-2-3
            Console.WriteLine();

            foreach (var item in simpleSet1.Difference(simpleSet2))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Intersection: "); //4-5
            Console.WriteLine();

            foreach (int item in simpleSet2.Intersection(simpleSet1))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine("SubSet: " + simpleSet3.Subset(simpleSet1)); //True;
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("SymmetricDifference: "); //1-2-3-6-7
            Console.WriteLine();

            foreach (int item in simpleSet1.SymmetricDifference(simpleSet2))
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }
    }
}
