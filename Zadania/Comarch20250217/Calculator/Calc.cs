using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comarch20250217.Calculator
{
    internal class Calc 
    {
        public Calc(int z)
        {
            // ...
        }

        public Calc()
        {
            
        }

        public int Add(int x, int y)
        {
            int wynik = x + y;
            return wynik;
        }

        public int Substract(int x, int y)
        {
            int wynik = x - y;
            return wynik;
        }
        
        internal float Dividy(int x, int y)
        {
            if (y == 0)
            {
                throw new ArgumentException(message: "Dzielnik nie może być zerem!", paramName: nameof(y));
            }

            float wynik = x / y;
            return wynik;

        }

        public void Sortowanie()
        {
            int[] liczby = WczytajTablice();
            PosortujTablice(liczby);
            PokazTablice(liczby);
        }

        private static int[] WczytajTablice()
        {
            Console.WriteLine("Podaj dowolną ilość liczb oddzielonych spacją: ");
            string[] sLiczby = Console.ReadLine()!.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            
            int[] liczby = new int[sLiczby.Length];
            for (int i = 0; i < sLiczby.Length; i++)
            {
                liczby[i] = int.Parse(sLiczby[i]);
            }
            //Można też: liczby = Array.ConvertAll(sLiczby, int.Parse);

            return liczby;
        }

        private static void PosortujTablice(int[] liczby)
        {
            // Algorytm sortowania bąbelkowego
            int n = liczby.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (liczby[j] > liczby[j + 1])
                    {
                        // Zamiana elementów, jeśli są w złej kolejności
                        int temp = liczby[j];
                        liczby[j] = liczby[j + 1];
                        liczby[j + 1] = temp;
                    }
                }
            }
        }

        private static void PokazTablice(int[] liczby)
        {
            Console.WriteLine($"[{string.Join(", ", liczby)}]");
        }

    }
}
