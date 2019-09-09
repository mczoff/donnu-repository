using CryptoLab1.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoLab1.Models
{
    internal class CaesarСrypt
        : ICryptPolicy<string>
    {
        private readonly int _shift;
        private readonly char[] _alphabet;

        public CaesarСrypt(int shift, char[] alphabet)
        {
            _shift = shift;
            _alphabet = alphabet;
        }

        public string Encrypt(string cryptModel)
        {
            var crypt = cryptModel
                .Select(t =>
                {
                    if (!char.IsLetter(t))
                    {
                        return t;
                    }

                    bool isLower = char.IsLower(t);

                    var shiftchar = GetShitCharFromCollection(char.ToUpper(t), _alphabet, _alphabet.Length, _shift);

                    return isLower ? char.ToLower(shiftchar) : char.ToUpper(shiftchar);
                }).ToArray();

            return string.Join(string.Empty, crypt);
        }

        public string Decrypt(string cryptModel)
        {
            var crypt = cryptModel
               .Select(t =>
               {
                   if (!char.IsLetter(t))
                   {
                       return t;
                   }

                    bool isLower = char.IsLower(t);

                    var shiftchar = GetShitCharFromCollection(char.ToUpper(t), _alphabet, _alphabet.Length, -_shift);

                   return isLower ? char.ToLower(shiftchar) : char.ToUpper(shiftchar);
               }).ToArray();

            return string.Join(string.Empty, crypt);
        }

        private char GetShitCharFromCollection(char wordsChar, IEnumerable<char> _alphabetChars, int sizeCollection, int shift)
        {
            var alphabetIndexedChar = _alphabetChars
                .Select((t, i) => new { Index = i, Char = t })
                .FirstOrDefault(t => t.Char == wordsChar);

            if (alphabetIndexedChar == null)
                throw new NullReferenceException($"Not found {wordsChar} char");

            return _alphabetChars.ElementAt(GetShitIndexChar(alphabetIndexedChar.Index, shift, sizeCollection));
        }

        private int GetShitIndexChar(int index, int shift, int sizeCollection)
        {
            var shiftIndex = index + shift;

            if (shiftIndex < 0)
                shiftIndex += sizeCollection;

            return shiftIndex % sizeCollection;
        }
    }
}
