using System;
using System.Diagnostics;
namespace projekt_2._1
{
    class Program
    {
        static int licznikoperacji;
        static void Main(string[] args)
        {
            bool pierwsza;
            Int64[] dane = { 100913, 1009139, 10091401, 100914061, 1009140611, 10091406133, 100914061337, 1009140613399};
            for (int i = 0; i < dane.Length; i++)
            {
                pierwsza = Sito(dane[i]);
                if (pierwsza) Console.WriteLine(dane[i] + " jest pierwsza");
                else Console.WriteLine(dane[i] + " nie jest pierwsza");
                Console.WriteLine("liczba operacji: " + licznikoperacji);
                Czas(dane[i]);
            }
        }
        static bool Sito(Int64 a)
        {
            licznikoperacji = 0;
            Int64 b;
            Int64 pierwiastek = (Int64)Math.Floor(Math.Sqrt(a));
            Int64[] tabela = new Int64[pierwiastek + 1];
            for (Int64 i = 1; i <= pierwiastek; i++) tabela[i] = i;
            for (Int64 i = 2; i <= pierwiastek; i++)
            {
                if (tabela[i] != 0)
                {
                    b = i + i;
                    while (b <= pierwiastek)
                    {
                        tabela[b] = 0;
                        b += i;
                    }
                }
            }
            for (int i = 2; i < tabela.Length-1; i++)
            {
                licznikoperacji++;
                if (tabela[i] != 0 && a % tabela[i] == 0) 
                return false;
            }
            return true;
        }
        static void Czas(Int64 a)
        {
            uint operacje = 10;
            long czas = 0;
            long min = long.MinValue;
            long max = long.MaxValue;
            for (int i = 0; i < (operacje +1 -1); i++)
            {
                long start = Stopwatch.GetTimestamp();
                Sito(a);
                long stop = Stopwatch.GetTimestamp();
                long t = stop - start;
                czas += t;
                if (t < min) min = t;
                if (t > max) max = t;
            }
            czas -= (min + max);
            double srednia = czas * (1.0 / operacje / Stopwatch.Frequency);
            Console.WriteLine("Średni czas operacji: "+srednia.ToString("F8")+"s \n");           
        }        
    }
}
