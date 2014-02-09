using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var first = program.GetWords("file1.txt");
            var second = program.GetWords("file2.txt");

            var firstFrequencies = program.ComputeFrequency(first);
            var secondFrequencies = program.ComputeFrequency(second);

            var distance = program.ComputeDistance(firstFrequencies, secondFrequencies);

            Console.WriteLine("The distance is: {0}", distance);

        }

        public string[] GetWords(string filename)
        {
            var words = new List<string>();
            var characters = new List<char>();

            var input = new StreamReader(filename).ReadToEnd();
            var seperators = new List<char> { ' ' };
            seperators.AddRange(Environment.NewLine);
            foreach (var word in input.Split(seperators.ToArray()))
            {
                foreach (var character in word.ToCharArray())
                {
                    if (char.IsLetterOrDigit(character)) characters.Add(character);
                }

                if (characters.Count > 0)
                {
                    words.Add(string.Join("", characters).ToLowerInvariant());
                    characters.Clear();
                }
            }

            return words.ToArray();
        }

        public double ComputeDistance(Dictionary<string, int> first, Dictionary<string, int> second)
        {
            var numerator = ComputeInnerProduct(first, second);

            var denominator = Math.Sqrt(ComputeInnerProduct(first, first) * ComputeInnerProduct(second, second));

            return Math.Acos(numerator / denominator);
        }

        public int ComputeInnerProduct(Dictionary<string, int> first, Dictionary<string, int> second)
        {
            var sum = 0;
            foreach (var key in first.Keys)
            {
                if (second.ContainsKey(key)) sum += first[key] * second[key];
            }

            return sum;
        }

        public Dictionary<string, int> ComputeFrequency(string[] input)
        {
            var result = new Dictionary<string, int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (result.ContainsKey(input[i]))
                {
                    result[input[i]]++;
                }
                else
                {
                    result.Add(input[i], 1);
                }
            }

            return result;
        }
    }
}
