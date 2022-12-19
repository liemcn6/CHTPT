using System;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            double[] ar = { 225, 72, 40, 195, 105, 242, 38, 249 };
            xxx(ar);
            double[] ar2 = { 225, 72, 40, 208, 41, 242, 12, 33 };
            xxx(ar2);
            double[] ar3 = { 225, 72, 40, 208, 41, 242, 52, 101 };
            xxx(ar3);
        }
        static void xxx(double[] ar)
        {
            double f = 0;
            double s = 0;
            double d = 0;
            for (int i = 7; i >= 0; i--)
            {
                if (i == 3) d = 0;
                if (i > 3)
                {
                    f += ar[i] * Math.Pow(256, d);
                    d++;
                }
                else

                {
                    s += ar[i] * Math.Pow(256, d);
                    d++;
                }
            }
            double ms = 1000 * f / UInt32.MaxValue;
            Console.WriteLine("MS: " + ms);

            Console.WriteLine(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(s).AddMilliseconds(ms).ToLocalTime());
        }
    }
}
