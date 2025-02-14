using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.ExampleSnippets
{
    public class MathService
    {
        public bool ContainsEven(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] % 2 == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int Minimum(int[][] arr)
        {
            int result = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    result = Min(arr, result, i, j);
                }
            }
            return result;
        }

        private static int Min(int[][] arr, int result, int i, int j)
        {
            if (result > arr[i][j])
            {
                result = arr[i][j];
            }

            return result;
        }

        public void ReportPrimes(int number)
        {
            for (int i = 2; i < number; i++)
            {
                ReportIfPrime(i);
            }
        }

        private void ReportIfPrime(int i)
        {
            if (IsPrime(i))
            {
                Console.WriteLine($"{i} is prime");
            }
        }

        private bool IsPrime(int n)
        {
            for (int i = 2; i <= (int)Math.Pow(n, 0.5); ++i)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
