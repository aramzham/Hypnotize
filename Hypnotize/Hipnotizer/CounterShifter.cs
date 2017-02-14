using System;
using System.Collections.Generic;
using System.Linq;

namespace Hipnotizer
{
    public class CounterShifter
    {
        public int[][] CreateMatrix(int n)
        {
            var matrix = new int[n][];
            var r = new Random((int) DateTime.Now.Ticks);
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = r.Next(0, 10);
                }
            }
            return matrix;
        }
        public static int[][] Start(int[][] matrix)
        {
            var contours = new List<List<int>>();
            var minLength = Math.Min(matrix.Length, matrix[0].Length);
            var contourCount = minLength / 2 + minLength % 2;
            var result = new int[matrix.Length][];
            for (int m = 0; m < result.Length; m++) //initializing resulting array
                result[m] = new int[matrix[m].Length];
            var assign = false;
            var i = 0;
            var j = 0;
            var l = 0;
            for (int k = 0; k < contourCount; k++)
            {
                i = j = k;
                if (!assign) contours.Add(new List<int>());
                while (j < matrix[i].Length - k)
                {
                    if (!assign) contours[k].Add(matrix[i][j]);
                    else
                    {
                        result[i][j] = contours[k][l];
                        l++;
                    }
                    j++;
                }
                j--;
                i++;
                if (i == matrix.Length - k) j = k - 1;
                while (i < matrix.Length - k)
                {
                    if (!assign) contours[k].Add(matrix[i][j]);
                    else
                    {
                        result[i][j] = contours[k][l];
                        l++;
                    }
                    i++;
                }
                i--;
                j--;
                while (j >= 0 + k)
                {
                    if (!assign) contours[k].Add(matrix[i][j]);
                    else
                    {
                        result[i][j] = contours[k][l];
                        l++;
                    }
                    j--;
                }
                j++;
                i--;
                if (k == matrix[i].Length / 2) i = k;
                while (i > 0 + k)
                {
                    if (!assign) contours[k].Add(matrix[i][j]);
                    else
                    {
                        result[i][j] = contours[k][l];
                        l++;
                    }
                    i--;
                }
                l = 0;
                if (!assign)
                {
                    if (k % 2 == 0) contours[k] = RightShift(contours[k]);
                    else contours[k] = LeftShift(contours[k]);
                    if (k == contourCount - 1)
                    {
                        k = -1;
                        assign = true;
                    }
                }
            }
            return result;
        }
        private static List<int> LeftShift(List<int> list)
        {
            return list.Skip(1).Concat(list.Take(1)).ToList();
        }
        private static List<int> RightShift(List<int> list)
        {
            return list.Skip(list.Count - 1).Concat(list.Take(list.Count - 1)).ToList();
        }
    }
}
