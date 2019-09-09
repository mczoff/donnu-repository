using CryptoLab1.Abstractions;
using CryptoLab1.Factories;
using CryptoLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ICryptPolicy<string>> crypts = new Dictionary<string, ICryptPolicy<string>>();

            string code = "AlyabevBogdan";
            string key = "Hello";
            int shift = 4;

            crypts.Add("Caesar", new CaesarСrypt(shift, AlphabetFactory.Create(AlphabetType.English)));
            crypts.Add("Viginere", new ViginereCrypt(key, VigenereMatrixFactory.Create(AlphabetFactory.Create(AlphabetType.English))));
            crypts.Add("Polybius", new PolybiusCrypt(PolybiusMatrixFactory.Create(AlphabetFactory.Create(AlphabetType.English))));
 
            foreach (var crypt in crypts)
            {
                Console.WriteLine($"(--- {crypt.Key} ---)");

                var encryptText = crypt.Value.Encrypt(code);

                Console.WriteLine($"<Encrypt {code}>");
                Console.WriteLine(encryptText);

                var decryptText = crypt.Value.Decrypt(encryptText);
                Console.WriteLine("<Decrypt>");
                Console.WriteLine(decryptText);
            }
        }
    }
}
