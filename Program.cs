using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#1
            var sample = Calculate(1, 2);
            Console.WriteLine(sample.sum);

            //#2
            GetSamplePatternMatching(new object());

            //#3
            IEnumerable<int> en = GetLocalFunction(5);

            //#4
            var person = new Person();

            //#5
            var point = new Point(1, 2);

            //6
            var r = Find(new int[] { 1, 2, 3, 4, 5 }, 4);

            //7
            var (_, product, _) = Calculate(3, 4);

            //8
            GetNullCoalesce();

            Console.ReadKey();
        }

        private static void GetNullCoalesce()
        {
            List<int> numbers = null;
            numbers ??= new List<int>();
            numbers.Add(1);
        }

        /// <summary>
        /// 6. Ref Returns and Locals for Performance Optimization
        /// </summary>
        /// <returns></returns>
        private static ref int Find(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == target)
                    return ref numbers[i];
            }
            throw new IndexOutOfRangeException("Not found");
        }

        /// <summary>
        /// 3. Using Local Functions for Encapsulation
        /// </summary>
        private static IEnumerable<int> GetLocalFunction(int n)
        {
            int Fib1(int term) => term <= 2 ? 1 : Fib(term - 1) + Fib1(term - 2);

            //OR

            int Fib(int term)
            {
                if (term <= 1) return 1;
                else return Fib(term - 1) + Fib(term - 2);
            }

            return Enumerable.Range(1, n).Select(Fib);
        }

        /// <summary>
        /// 2. Pattern Matching Enhancements
        /// </summary>
        private static void GetSamplePatternMatching(object shape)
        {
            if (shape is object o)
            {
                Console.WriteLine(o.ToString());
            }
        }

        /// <summary>
        /// 1. Leveraging Tuples for Multiple Return Values
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static (int sum, int product, double average) Calculate(int a, int b)
        {
            return (a + b, a * b, (a + b) / 2);
        }
    }

    /// <summary>
    /// 4. Expression-bodied Members for Succinct Code
    /// </summary>
    internal class Person
    {
        public string Name { get; set; }
        public override string ToString() => $"Name: {Name}";
    }

    /// <summary>
    /// 5. Readonly Structs for Immutable Data Types
    /// </summary>
    internal readonly struct Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y) => (X, Y) = (x, y);
    }
}
