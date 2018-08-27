using System;

namespace PrimesLib
{
    public static class PrimeFunctions
    {
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;

            for (int p = 2; p <= n / 2; p++)
            {
                if (n % p == 0) return false;
            }

            return true;
        }
    }
}

