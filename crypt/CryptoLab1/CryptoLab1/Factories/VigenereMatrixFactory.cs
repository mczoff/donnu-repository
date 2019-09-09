using System;
using System.Linq;
using System.Collections.Generic;
using CryptoLab1.Models;

namespace CryptoLab1.Factories
{
    internal static class VigenereMatrixFactory
    {
        public static char[,] Create(char[] alphabet)
        {
            int size = alphabet.Length;

            char[,] matrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = alphabet.ElementAt((i + j) % size);
                }
            }

            return matrix;
        }
    }
}
