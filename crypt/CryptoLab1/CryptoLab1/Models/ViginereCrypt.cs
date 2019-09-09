using CryptoLab1.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLab1.Models
{
    internal class ViginereCrypt
        : ICryptPolicy<string>
    {
        private readonly string _key;
        private readonly char[,] _viginereMatrix;

        public ViginereCrypt(string key, char[,] viginereMatrix)
        {
            _key = key;
            _viginereMatrix = viginereMatrix;
        }

        public string Encrypt(string cryptModel)
        {
            var crypt = cryptModel
              .Select((t, i) =>
              {
                  if (!char.IsLetter(t))
                  {
                      return t;
                  }
                      
                  char keyChar = _key.ElementAt(i % _key.Length);

                  bool isLower = char.IsLower(t);

                  var shiftchar = GetCharFromMatrix(char.ToUpper(t), char.ToUpper(keyChar), _viginereMatrix, _viginereMatrix.GetLength(0));

                  return isLower ? char.ToLower(shiftchar) : char.ToUpper(shiftchar);
              }).ToArray();

            return string.Join(string.Empty, crypt);
        }

        public string Decrypt(string cryptModel)
        {
            var crypt = cryptModel
              .Select((t, i) =>
              {
                  if (!char.IsLetter(t))
                  {
                      return t;
                  }

                  char keyChar = _key.ElementAt(i % _key.Length);

                  bool isLower = char.IsLower(t);

                  var shiftchar = GetDecodeCharFromMatrix(char.ToUpper(t), char.ToUpper(keyChar), _viginereMatrix, _viginereMatrix.GetLength(0));

                  return isLower ? char.ToLower(shiftchar) : char.ToUpper(shiftchar);
              }).ToArray();

            return string.Join(string.Empty, crypt);
        }
       
        private char GetCharFromMatrix(char wordChar, char keyChar,  char[,] viginereMatrix, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (viginereMatrix[i, 0] == wordChar)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (viginereMatrix[0, j] == keyChar)
                        {
                            return viginereMatrix[i, j];
                        }
                    }
                }
            }

            throw new NotSupportedException("Char not found in matrix");
        }

        private char GetDecodeCharFromMatrix(char wordChar, char keyChar, char[,] viginereMatrix, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (viginereMatrix[i, 0] == keyChar)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (viginereMatrix[i, j] == wordChar)
                        {
                            return viginereMatrix[0, j];
                        }
                    }
                }
            }

            throw new NotSupportedException("Char not found in matrix");
        }
    }
}
