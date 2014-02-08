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
	            new [] {0,  1,  0,  0,  0,  0,  0},
	            new [] {0,  2,  0,  0,  0,  0,  0},
	            new [] {0,  3,  0,  0,  0,  0,  0},
	            new [] {0,  5,  0,  0,  0,  0,  0},
	            new [] {0,  7,  4,  0,  0,  0,  0},
            };

            Console.WriteLine("Found a peak with value	: {0}", FindMax(problem));
        }


        static int FindMax(int[][] problem, int j = -1)
        {
            if (problem.Length <= 0) return 0;

            if (j == -1) j = problem.Length / 2;
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
            else if (problem[globalMax][j - 1] > problem[globalMax][j])
            {
                return FindMax(problem, j / 2);
            }
            else if (problem[globalMax][j + 1] > problem[globalMax][j])
            {
                return FindMax(problem, problem.Length - (j / 2));
            }

            return problem[globalMax][j];
        }

        static int FindGlobalMax(int[][] problem, int column)
        {
            int max = problem[0][column];
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
