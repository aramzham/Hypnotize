using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hipnotizer;

namespace ContourShifting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 75;
            Console.WindowHeight = 22;
            var cs = new CounterShifter();
            var matrix = cs.CreateMatrix(10);
            while (true)
            {
                matrix = CounterShifter.Start(matrix);
                for (int i = 0; i < matrix.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"{matrix[i][j]}\t");
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(200);
                Console.Clear();
            }

            Console.ReadKey();
        }
    }
}
