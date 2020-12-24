using System;
using System.Diagnostics;

namespace _201224_Study
{
    class Program
    {
        static void Main(string[] args)
        {
            TestFunctions tf = new TestFunctions();
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Running Sample Codes.");

            stopwatch.Start();
            Console.WriteLine(tf.HowManyPrimes(55000));
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds}ms");

            stopwatch.Start();
            Console.WriteLine(tf.GCD(55000, 1928340));
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds}ms");

            stopwatch.Start();
            Console.WriteLine(tf.LCM(55000, 1928340));
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds}ms");

            stopwatch.Start();
            Console.WriteLine(tf.Factorial(15));
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds}ms");

            stopwatch.Start();
            Console.WriteLine(tf.Binomial_coef_factorial(15, 3));
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds}ms");

            stopwatch.Start();
            Console.WriteLine(tf.Binomial_coef_dynamic(15, 3));
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds}ms");

            stopwatch.Start();
            Console.WriteLine(tf.Binomial_coef_memoization(15, 3));
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds}ms");
        }

        
    }
}
