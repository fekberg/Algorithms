using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peak_Finding
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] problem = new[]{
	            new [] {0,  0,  9,  0,  0,  0,  0},
	            new [] {0,  0,  0,  0,  0,  0,  0},
	            new [] {0,  1,  0,  0,  0,  8,  9},
	            new [] {0,  2,  0,  0,  0,  0,  0},
	            new [] {0,  3,  0,  0,  0,  0,  0},
	            new [] {0,  5,  0,  0,  0,  0,  0},
	            new [] {0,  4,  7,  0,  0,  0,  0},
            };
            int peak = new Program().FindPeak(problem);

            Console.WriteLine("Found a peak with value	: {0}", peak);
        }


        int FindPeak(int[][] problem, int left = 0, int right = -1)
        {
            if (problem.Length <= 0) return 0;

            if (right == -1) right = problem[0].Length;

            int j = (left + right) / 2;
            int globalMax = FindGlobalMax(problem, j);

            if (
                (globalMax - 1 > 0 &&
                problem[globalMax][j] >=
                problem[globalMax - 1][j]) &&

                (globalMax + 1 < problem.Length &&
                problem[globalMax][j] >=
                problem[globalMax + 1][j]) &&

                (j - 1 > 0 &&
                problem[globalMax][j] >=
                problem[globalMax][j - 1]) &&

                (j + 1 < problem[globalMax].Length &&
                problem[globalMax][j] >=
                problem[globalMax][j + 1])
                )
            {
                return problem[globalMax][j];
            }
            else if (j > 0 && problem[globalMax][j - 1] > problem[globalMax][j])
            {
                right = j;
                return FindPeak(problem, left, right);
            }
            else if (j + 1 < problem[globalMax].Length && problem[globalMax][j + 1] > problem[globalMax][j])
            {
                left = j;
                return FindPeak(problem, left, right);
            }

            return problem[globalMax][j];
        }

        int FindGlobalMax(int[][] problem, int column)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < problem.Length; i++)
            {
                if (max < problem[i][column])
                {
                    max = problem[i][column];
                    index = i;
                }
            }

            return index;
        }
    }
}
