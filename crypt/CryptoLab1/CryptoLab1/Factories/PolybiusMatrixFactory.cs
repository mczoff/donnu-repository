using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLab1.Factories
{
    internal static class PolybiusMatrixFactory
    {
        public static char[,] Create(char[] alphabet)
        {
            int size = ((int)Math.Sqrt(alphabet.Length)) + 1;

            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = alphabet.ElementAtOrDefault((i * size) + j);
                }
            }

            return matrix;
        }
    }
}
