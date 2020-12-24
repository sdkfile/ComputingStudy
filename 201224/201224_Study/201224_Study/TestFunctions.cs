using System;
using System.Collections.Generic;
using System.Text;

namespace _201224_Study
{
    class TestFunctions
    {
        /// <summary>
        /// Basic and inefficient form of prime number discrimination
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPrime(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public bool IsPrimeRoot(int n)
        {
            if (n == 1) return false;
            if (n == 2) return true;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        public int HowManyPrimes(int n)
        {
            int output = 0;
            for (int i = 0; i < n; i++)
            {
                if (IsPrimeRoot(i))
                    output++;
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public long GCD(int a, int b)
        {
            int comparison;
            if (a.CompareTo(b) >= 0)
                comparison = b;
            else
                comparison = a;

            int output = 0;
            for (int i = 1; i <= comparison; i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    output = i;
                }
            }
            return output;
        }

        /// <summary>
        /// Based on the fact that lcm = (a * b) / gcd(a, b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public long LCM(int a, int b)
        {
            return a * (b / GCD(a, b));
        }

        /// <summary>
        /// this should return 1 even if n is 0
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long Factorial(int n)
        {
            if (n < 0)
                throw new InvalidOperationException();
            long ans = 1;
            for (int i = 0; i < n; i++)
            {
                ans *= i + 1;
            }
            return ans;
        }

        /// <summary>
        /// Based on the definition of binomial coefficient
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long Binomial_coef_factorial(int n, int k)
        {
            long A = Factorial(n);
            long B = Factorial(n - k);
            long C = Factorial(k);

            return A / (B * C);
        }

        /// <summary>
        /// Based on recurrence relation of binomial coefficient
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long Binomial_coef_dynamic(int n, int k)
        {
            long[,] cache = new long[n + 1, k + 1];

            for (int i = 0; i < n + 1; i++)
            {
                cache[i, 0] = 1;
            }
            for (int i = 0; i < k + 1; i++)
            {
                cache[i, i] = 1;
            }

            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < k + 1; j++)
                {
                    cache[i, j] = cache[i - 1, j] + cache[i - 1, j - 1];
                }
            }

            return cache[n, k];
        }


        /// <summary>
        /// Got this from https://shoark7.github.io/programming/algorithm/3-ways-to-get-binomial-coefficients
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long Binomial_coef_memoization(int n, int k)
        {
            if (k > n) return 0;
            
            // Prepare cache with size n + 1 by n + 1 and fill it with -1
            long[,] cache = new long[n + 1, n + 1];

            int row = cache.GetLength(0);
            int col = cache.GetLength(1);
            for (int i = 0; i < row * col; i++)
            {
                cache[i / col, i % col] = -1;
            }

            return Choose(0, 0, n, k, cache);
        }

        public long Choose(long times, long got, int n, int k, long[,] cache)
        {
            if (times == n)
                return got == k ? 1 : 0;
            if (cache[times, got] != -1)
                return cache[times, got];
            cache[times, got] = Choose(times + 1, got, n, k, cache) + Choose(times + 1, got + 1, n, k, cache);
            return cache[times, got];
        }
    }
}
