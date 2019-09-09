using CryptoLab1.Models;
using System;
using System.Linq;

namespace CryptoLab1.Factories
{
    internal static class AlphabetFactory
    {
        public static char[] Create(AlphabetType alphabetType)
        {
            switch (alphabetType)
            {
                case AlphabetType.None:
                    throw new NotSupportedException();
                case AlphabetType.English:
                    return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
                case AlphabetType.Russian:
                    return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
                case AlphabetType.Count:
                    throw new NotSupportedException();
            }

            throw new NotSupportedException();
        }
    }
}
