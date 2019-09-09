using CryptoLab1.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLab1.Models
{
    internal class PolybiusCrypt
         : ICryptPolicy<string>
    {
        private readonly char[,] _matrix;

        public PolybiusCrypt(char[,] matrix)
        {
            _matrix = matrix;
        }

        public string Encrypt(string cryptModel)
        {
            var crypt = cryptModel
               .Select(t =>
               {
                   return GetAddressFromMatrix(char.ToUpper(t), _matrix, _matrix.GetLength(0));
               }).ToArray();

            return string.Join(string.Empty, crypt);
        }

        public string Decrypt(string cryptModel)
        {
            if (cryptModel.Length % 2 != 0)
            {
                throw new Exception("Unvalid data");
            }

            var crypt = cryptModel
              .Select((t, i) =>
              {
                  if (i >= cryptModel.Length / 2)
                  {
                      return '\0';
                  }

                  var jIndex = Convert.ToInt32(cryptModel[i * 2].ToString());
                  var iIndex = Convert.ToInt32(cryptModel[(i * 2) + 1].ToString());

                  return GetCharFromMatrix(iIndex, jIndex, _matrix);

              }).ToArray();

            return string.Join(string.Empty, crypt);
        }

        private object GetAddressFromMatrix(char wordsChar, char[,] matrix, int length)
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if(matrix[i, j] == wordsChar)
                    {
                        return i.ToString() + j;
                    }
                }
            }

            throw new NullReferenceException($"Not found {wordsChar} char");
        }

        private char GetCharFromMatrix(int i, int j, char[,] matrix)
        {
            return matrix[j, i];
        }
    }

}
