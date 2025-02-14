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
            for(int i = 0; i<arr.Length; i++)
            {
                for(int j =0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] %2 == 0)
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
                    result = Math.Min(result, arr[i][j]);
                }
            }
            return result;
        }
    }
}
