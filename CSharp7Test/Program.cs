using System;
using System.Collections.Generic;

namespace CSharp7Features
{
    class Program
    {
        static void Main(string[] args)
        {
            // Named tuple values.
            Console.WriteLine("Named tuple values.");
            var item = TestGame();
            Console.WriteLine(item.Test1);
            Console.WriteLine(item.Test2);
            Console.WriteLine(item.Test3);

            // Digit separator.
            Console.WriteLine();
            Console.WriteLine("Digit separator.");
            int testNumber = 111_332;
            Console.WriteLine(testNumber);

            // Out variables.
            // Populate method also uses a local function!!! See below.
            Console.WriteLine();
            Console.WriteLine("Out variables.");
            Populate(out var i);
            Console.WriteLine(i);

            // Deconstructing of object to Tuple.
            Console.WriteLine();
            Console.WriteLine("Deconstructing of object to Tuple.");
            var (pointX, pointY) = new Point(10, 20);
            // Now I can use the deconstructed Tuple values however I want.
            Console.WriteLine($"{pointX} {pointY}");
            Console.WriteLine($"{pointX + 100}");
            Console.WriteLine($"{pointY - 10}");

            // Deconstructing Tuple return type to new variables.
            Console.WriteLine();
            Console.WriteLine("Deconstructing Tuple return type to new variables.");
            var values = new double[] { 1.33, 100.34, 244033.22 };
            var (count, sum) = Tally(values);
            Console.WriteLine($"Count of values was {count} and sum of values was {sum.ToString("C")}.");

            // Patterns examples.
            Console.WriteLine();
            Console.WriteLine("Patterns examples.");
            string test = null;
            if (test is null)
                Console.WriteLine("Test was null. Well, duh!");

            object myValue = 1000;
            PatternTest(myValue);
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void PatternTest(object myValue)
        {
            if (myValue is null) return;
            if (!(myValue is int x)) return;

            Console.WriteLine($"I just magically assigned x to {x} because it had the right type.");

            // Assignment to variable is a copy not a reference.
            x = x + 100;
            Console.WriteLine($"I also added some to x and it became {x} but myValue is still {myValue}.");
        }

        static (string Test1, string Test2, string Test3) TestGame()
        {
            return (Test1: "test1", Test2: "test2", Test3: "test3");
        }

        static void Populate(out string test)
        {
            // Calling local function only available to this method.
            test = GetTest();

            // LOCAL FUNCTION!!!
            string GetTest()
            {
                return "Test";
            }
        }

        class Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) { X = x; Y = y; }            

            // New Deconstruct method for deconstructing this class to Tuples.
            public void Deconstruct(out int x, out int y)
            {
                x = X;
                y = Y;
            }
        }

        static (int count, double sum) Tally(IEnumerable<double> values)
        {
            int count = 0;
            double sum = 0.0;
            foreach (var value in values)
            {
                count++;
                sum += value;
            }
            return (count, sum);
        }
    }
}