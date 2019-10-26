using System;
using System.Numerics;

namespace Cryptolab2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ax = b(mod m)");
            Console.Write("a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("m: ");
            int m = int.Parse(Console.ReadLine());

            int gcd = Evklid(a, m);

            int x = 0;

            if(gcd > 1)
            {
                Console.WriteLine($"Down pow on {gcd}");
                if (b % gcd == 0)
                {
                    a /= gcd;
                    b /= gcd;
                    m /= gcd;

                    x = (int)(b * BigInteger.ModPow(a, Eyler(m) - 1, m));
                    Console.WriteLine($"Result: {x}");
                }

                //нет решений
                if(b % gcd != 0)
                {
                    Console.WriteLine("Нет решений");
                }
            }

  
            if(gcd == 1)
            {
                x = (int)(b * BigInteger.ModPow(a, Eyler(m) - 1, m) % m);
                Console.WriteLine($"Result: {x}");
            }
        }

        public static int Evklid(int a, int b)
        {
            while (b != 0)
                b = a % (a = b);

            return a;
        }

        public static int Eyler(int n)
        {
            int res = n, en = Convert.ToInt32(Math.Sqrt(n) + 1);
            for (int i = 2; i <= en; i++)
                if ((n % i) == 0)
                {
                    while ((n % i) == 0)
                        n /= i;
                    res -= (res / i);
                }
            if (n > 1) 
                res -= (res / n);
     
            return res;
        }
    }
}
