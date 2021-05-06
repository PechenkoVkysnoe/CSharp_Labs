using System;
using System.Collections.Generic;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Fraction> fractions = new List<Fraction>()
            {
                new Fraction(5),
                new Fraction(2, 3),
                new Fraction(1.45),
                Fraction.GetFraction("2/7"),
                Fraction.GetFraction("21,42"),
                Fraction.GetFraction("7")
            };
            fractions.Add(fractions[0] + fractions[1]);
            fractions.Add(fractions[3] - fractions[3]);
            fractions.Add(fractions[2] * fractions[4]);
            fractions.Add(fractions[5] / fractions[0]);
            fractions.Add(fractions[6].Clone() as Fraction);

            Console.WriteLine("List fractions:");
            fractions.ForEach(i => Console.WriteLine("{0:S}", i));

            Console.WriteLine("\noutput fraction in different formats:");
            Fraction testFraction = new Fraction(-42, 13);
            Console.WriteLine("{0:S}", testFraction);
            Console.WriteLine("{0:D}", testFraction);
            Console.WriteLine("{0:I}", testFraction);

            Console.WriteLine("\nCoversion:");
            Console.WriteLine((short)testFraction);
            Console.WriteLine((int)testFraction);
            Console.WriteLine((long)testFraction);
            Console.WriteLine((float)testFraction);
            Console.WriteLine((double)testFraction);
            Console.WriteLine(Convert.ToBoolean(testFraction));
            Console.WriteLine(Convert.ToString(testFraction));

            Console.WriteLine("\nComparison:");
            Console.WriteLine(fractions[0] == fractions[7]);
            Console.WriteLine(fractions[3] != fractions[5]);
            Console.WriteLine(fractions[6] < fractions[4]);
            Console.WriteLine(fractions[3] >= fractions[2]);
        }
    }
}